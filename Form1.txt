using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace AccessDatabaseComparer
{
    public partial class Form1 : Form
    {
        // Global path variables for US and CAN environments
        private string ProdOutputUS = @"\\dwprod4fs.production.kubra.com\DocWebPROD\1_DocWeb_PROD\System\Destinations\Global\";
        private string ProdOutputCAN = @"\\dwprodfs.production.kubra.com\DocWebPROD\1_DocWeb_PROD\System\Destinations\Global\";
        private string ArchiveOutput = @"\\corp1\Common\Service Delivery\COE\Waste Connections\Implementation\Testing\OldKDPOSTExtracts";
        private string TestOutput = @"\\testx-fs.corpx.kubra.com\docweb\1_DocWeb_TEST\System\Destinations\Global\";
        private string PrepOutputUS = @"\\dwprep4fs.production.kubra.com\DocWebPREP\1_DocWeb_PREP\System\Destinations\Global\";
        private string PrepOutputCAN = @"\\dwpreprs.production.kubra.com\DocWebPREP\1_DocWeb_PREP\System\Destinations\Global\";

        // Variables to store current paths
        private string ProdOutput;
        private string PrepOutput;

        // Declare the new ComboBox
        //private ComboBox comboBoxCANUS;


        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;

        private const int BatchSize = 1000;
        private int totalDocDataEntries;
        private int totalDocumentIndexEntries;
        private int docDataProcessedCount;
        private int documentIndexProcessedCount;


        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabZipSelection)
            {
                // Run the connection check in a background task with a timeout
                Task.Run(() =>
                {
                    bool isConnected = false;

                    var task = Task.Run(() =>
                    {
                        try
                        {
                            // Try to access the network path
                            var directories = System.IO.Directory.GetDirectories(@"\\dwprod4fs.production.kubra.com\DocWebPROD");
                            isConnected = true;
                        }
                        catch
                        {
                            isConnected = false;
                        }
                    });

                    // If the task takes more than 4 seconds, assume failure
                    if (!task.Wait(4000) || !isConnected)
                    {
                        // Show message box and switch back to manual selection tab
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show("Connection to DocWebPROD failed. Please connect to the jump box to use this feature.", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tabControl.SelectedTab = tabManualSelection;
                        }));
                    }
                });
            }
        }

        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the license context


            // Default to US paths
            UpdatePathsForUS();



            // Add event handler for environment selection change
            comboBoxEnvironment.SelectedIndexChanged += ComboBoxEnvironment_SelectedIndexChanged;

            // Add event handler for tab control selection change
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            // Initialize ContextMenuStrip
            contextMenuStrip = new ContextMenuStrip();
            copyToolStripMenuItem = new ToolStripMenuItem("Copy");
            contextMenuStrip.Items.Add(copyToolStripMenuItem);
            listBoxProgress.ContextMenuStrip = contextMenuStrip;

            copyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            listBoxProgress.KeyDown += ListBoxProgress_KeyDown;

        }


        private void ComboBoxCANUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCANUS.SelectedItem.ToString() == "CAN")
            {
                UpdatePathsForCAN();
            }
            else
            {
                UpdatePathsForUS();
            }

            // Optionally, handle environment-specific changes for the GUI
        }

        private void UpdatePathsForCAN()
        {
            // Use CAN paths
            ProdOutput = ProdOutputCAN;
            PrepOutput = PrepOutputCAN;
        }

        private void UpdatePathsForUS()
        {
            // Use US paths
            ProdOutput = ProdOutputUS;
            PrepOutput = PrepOutputUS;
        }



        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelectedItems();
        }

        private void ListBoxProgress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopySelectedItems();
            }
        }

        private void CopySelectedItems()
        {
            if (listBoxProgress.SelectedItems.Count > 0)
            {
                var selectedItems = string.Join(Environment.NewLine, listBoxProgress.SelectedItems.Cast<string>());
                Clipboard.SetText(selectedItems);
            }
        }
        private void buttonSelectBeforeDb_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select Before Database";
            this.openFileDialog.Filter = "All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxBeforeDbPath.Text = openFileDialog.FileName;
            }
        }

        private void buttonSelectAfterDb_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select After Database";
            this.openFileDialog.Filter = "All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxAfterDbPath.Text = openFileDialog.FileName;
            }
        }

        private async void buttonCompare_Click(object sender, EventArgs e)
        {
            buttonCompare.Enabled = false;
            UpdateProgress("Preparing Comparison", "Please wait.");

            string beforeDbPath;
            string afterDbPath;
            string[] beforeJobIds;
            string[] afterJobIds;

            if (tabControl.SelectedTab == tabManualSelection)
            {
                beforeDbPath = textBoxBeforeDbPath.Text;
                afterDbPath = textBoxAfterDbPath.Text;

                if (string.IsNullOrEmpty(beforeDbPath) || string.IsNullOrEmpty(afterDbPath))
                {
                    UpdateProgress("Error", "Please select both databases.");
                    buttonCompare.Enabled = true;
                    return;
                }

                await PerformComparison(beforeDbPath, afterDbPath, Path.GetFileNameWithoutExtension(beforeDbPath), Path.GetFileNameWithoutExtension(afterDbPath));
            }
            else
            {
                string prodOutput = ProdOutput;
                string archiveOutput = @"\\corp1\Common\Service Delivery\COE\Waste Connections\Implementation\Testing\OldKDPOSTExtracts";

                beforeJobIds = textBoxBeforeZip.Text.Split(',');
                afterJobIds = textBoxAfterZip.Text.Split(',');

                for (int i = 0; i < beforeJobIds.Length; i++)
                {
                    UpdateProgress("Preparing Comparison", $"Please wait. {beforeJobIds[i].Trim()} VS {afterJobIds[i].Trim()}");

                    // Check in primary location first
                    beforeDbPath = await ExtractDatabaseFromZipAsync(
                        prodOutput,
                        beforeJobIds[i].Trim() + ".zip");

                    // If the file is not found in the primary location, check in the archive location
                    if (beforeDbPath == null && checkBoxArchivedJobs.Checked)
                    {
                        beforeDbPath = await ExtractDatabaseFromZipAsync(
                            archiveOutput,
                            beforeJobIds[i].Trim() + ".zip");
                    }

                    // Determine output path based on the selected environment for afterDbPath
                    string outputPath = "";
                    if (comboBoxEnvironment.SelectedItem.ToString() == "TEST")
                    {
                        outputPath = TestOutput;
                    }
                    else if (comboBoxEnvironment.SelectedItem.ToString() == "PREP")
                    {
                        outputPath = PrepOutput;
                    }

                    // Check only primary location for afterDbPath
                    afterDbPath = await ExtractDatabaseFromZipAsync(
                        outputPath,
                        afterJobIds[i].Trim() + ".zip");

                    if (string.IsNullOrEmpty(beforeDbPath))
                    {
                        UpdateProgress("Error", "Unable to extract databases from the provided Before DB zip files.");
                        buttonCompare.Enabled = true;
                        return;
                    }
                    if (string.IsNullOrEmpty(afterDbPath))
                    {
                        UpdateProgress("Error", "Unable to extract databases from the provided After DB zip files.");
                        buttonCompare.Enabled = true;
                        return;
                    }
                    await PerformComparison(beforeDbPath, afterDbPath, beforeJobIds[i].Trim(), afterJobIds[i].Trim());
                }
            }

            buttonCompare.Enabled = true;
        }

        private async Task PerformComparison(string beforeDbPath, string afterDbPath, string beforeJobId, string afterJobId)
        {
            if (!checkBoxDocData.Checked && !checkBoxDocumentIndex.Checked)
            {
                UpdateProgress("Error", "Please select at least one table to compare.");
                return;
            }

            // listBoxProgress.Items.Clear();

            try
            {
                UpdateProgress("Database Loading", "Loading databases...");
                var beforeDb = await ReadDatabaseAsync(beforeDbPath);
                UpdateProgress("Database Loading", "Loaded 'before' database.");

                var afterDb = await ReadDatabaseAsync(afterDbPath);
                UpdateProgress("Database Loading", "Loaded 'after' database.");

                UpdateProgress("Preparing Comparison", "Preparing comparison tasks...");

                var tasks = new List<Task<ConcurrentDictionary<string, List<ComparisonResult>>>>();
                if (checkBoxDocData.Checked)
                {
                    tasks.Add(Task.Run(() => CompareDocData(beforeDb, afterDb)));
                }
                if (checkBoxDocumentIndex.Checked)
                {
                    tasks.Add(Task.Run(() => CompareDocumentIndex(beforeDb, afterDb)));
                }

                var results = await Task.WhenAll(tasks);

                UpdateProgress("Saving Results", "Saving results to Excel...");
                var docDataResults = results.Length > 0 ? results[0] : null;
                var documentIndexResults = results.Length > 1 ? results[1] : null;

                string fileName = $"comparison_results_{beforeJobId}_vs_{afterJobId}.xlsx";

                if ((docDataResults != null && docDataResults.Any()) || (documentIndexResults != null && documentIndexResults.Any()))
                {
                    string outputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comparison output");
                    Directory.CreateDirectory(outputFolder);
                    string outputPath = Path.Combine(outputFolder, fileName);
                    SaveResultsToExcel(docDataResults, documentIndexResults, outputPath);
                }
                else
                {
                    //MessageBox.Show("Before and After data are identical. No differences found.");
                    UpdateProgress("Saving Results", "Comparison completed with no differences.");
                }

                UpdateProgress("Saving Results", "Comparison completed and saved to Excel.");
            }
            catch (Exception ex)
            {
                UpdateProgress("Error", "Error: " + ex.Message);
            }
        }

        private async Task<string> ExtractDatabaseFromZipAsync(string zipFolderPath, string zipFileName)
        {
            return await Task.Run(() =>
            {
                try
                {
                    string fullZipPath = Path.Combine(zipFolderPath, zipFileName);

                    // Debug output
                    Console.WriteLine($"Full zip path: {fullZipPath}");

                    if (!File.Exists(fullZipPath))
                    {
                        Console.WriteLine($"Zip file not found: {fullZipPath}");
                        return null;
                    }

                    using (var zip = ZipFile.OpenRead(fullZipPath))
                    {
                        var entries = zip.Entries.ToList();
                        foreach (var zipEntry in entries)
                        {
                            Console.WriteLine($"Entry found: {zipEntry.FullName}");
                        }

                        var databaseEntry = zip.Entries
                            .FirstOrDefault(e => e.FullName.Contains("KDPOST"));

                        if (databaseEntry != null)
                        {
                            string tempFilePath = Path.GetTempFileName();
                            databaseEntry.ExtractToFile(tempFilePath, overwrite: true);
                            return tempFilePath;
                        }
                        else
                        {
                            Console.WriteLine("No matching entry found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
                return null;
            });
        }

        private async Task<DataSet> ReadDatabaseAsync(string dbPath)
        {
            return await Task.Run(() =>
            {
                var ds = new DataSet();
                var connectionString = GetConnectionString(dbPath);
                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    var tableNames = GetTableNames(connection);
                    foreach (var tableName in tableNames)
                    {
                        var adapter = new OleDbDataAdapter($"SELECT * FROM [{tableName}]", connection);
                        var table = new DataTable(tableName);
                        adapter.Fill(table);
                        ds.Tables.Add(table);
                        UpdateProgress("Table Loading", $"Loaded table: {tableName} with {table.Rows.Count} rows");
                    }
                }
                return ds;
            });
        }

        private string GetConnectionString(string dbPath)
        {
            string[] connectionStrings =
            {
                $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={dbPath};",
                $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};",
                $"Provider=Microsoft.ACE.OLEDB.14.0;Data Source={dbPath};",
                $"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath};"
            };

            foreach (var connStr in connectionStrings)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connStr))
                    {
                        conn.Open();
                        return connStr; // Return the first successful connection string
                    }
                }
                catch
                {
                    // Ignore and try the next connection string
                }
            }

            throw new InvalidOperationException("Unable to find a suitable provider to open the database.");
        }

        private List<string> GetTableNames(OleDbConnection connection)
        {
            var tableNames = new List<string>();
            var schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            foreach (DataRow row in schemaTable.Rows)
            {
                if (row["TABLE_TYPE"].ToString() == "TABLE")
                {
                    tableNames.Add(row["TABLE_NAME"].ToString());
                }
            }
            return tableNames;
        }

        private ConcurrentDictionary<string, List<ComparisonResult>> CompareDocData(DataSet beforeDb, DataSet afterDb)
        {
            var result = new ConcurrentDictionary<string, List<ComparisonResult>>();
            var beforeTable = beforeDb.Tables["DocData"];
            var afterTable = afterDb.Tables["DocData"];

            var encoding = Encoding.UTF8;

            var beforeData = beforeTable.AsEnumerable()
                .ToDictionary(row => $"{row["DocKey"]}-{row["Page"]}", row => encoding.GetString(encoding.GetBytes(row["PageData"].ToString())));

            var afterData = afterTable.AsEnumerable()
                .ToDictionary(row => $"{row["DocKey"]}-{row["Page"]}", row => encoding.GetString(encoding.GetBytes(row["PageData"].ToString())));

            totalDocDataEntries = beforeData.Count + afterData.Count;
            docDataProcessedCount = 0;
            UpdateProgress("DocData Comparison", $"Preparing DocData comparison. Total entries: {totalDocDataEntries}");

            var allKeys = beforeData.Keys.Union(afterData.Keys).ToList();

            Parallel.ForEach(Partitioner.Create(0, allKeys.Count, BatchSize), new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, range =>
            {
                int batchStart = range.Item1;
                int batchEnd = Math.Min(range.Item2, allKeys.Count);

                for (int i = batchStart; i < batchEnd; i++)
                {
                    var key = allKeys[i];
                    beforeData.TryGetValue(key, out string beforePageData);
                    afterData.TryGetValue(key, out string afterPageData);

                    if (beforePageData != afterPageData)
                    {
                        string status;
                        if (beforePageData == null)
                        {
                            status = $"Document page added for {key}";
                        }
                        else if (afterPageData == null)
                        {
                            status = $"Document page removed for {key}";
                        }
                        else
                        {
                            status = $"PageData mismatch for {key}";
                        }

                        var keyParts = key.Split('-');
                        var docKey = keyParts[0];
                        var page = int.Parse(keyParts[1]);

                        result.AddOrUpdate(key, new List<ComparisonResult>
                {
                    new ComparisonResult
                    {
                        DocKey = docKey,
                        Page = page,
                        Status = status,
                        BeforeValue = beforePageData,
                        AfterValue = afterPageData
                    }
                }, (existingKey, list) =>
                {
                    list.Add(new ComparisonResult
                    {
                        DocKey = docKey,
                        Page = page,
                        Status = status,
                        BeforeValue = beforePageData,
                        AfterValue = afterPageData
                    });
                    return list;
                });
                    }

                    Interlocked.Increment(ref docDataProcessedCount);
                }

                UpdateProgress("DocData Comparison",
                    $"Batch {batchStart / BatchSize + 1} processed. Live count: {docDataProcessedCount}.");
            });

            UpdateProgress("DocData Comparison", $"DocData comparison completed. Total processed: {docDataProcessedCount} entries.");

            return result;
        }

        private ConcurrentDictionary<string, List<ComparisonResult>> CompareDocumentIndex(DataSet beforeDb, DataSet afterDb)
        {
            var result = new ConcurrentDictionary<string, List<ComparisonResult>>();
            var beforeTable = beforeDb.Tables["DocumentIndex"];
            var afterTable = afterDb.Tables["DocumentIndex"];

            var beforeData = beforeTable.AsEnumerable()
                .ToDictionary(row => row["DocKey"].ToString(), row => row);

            var afterData = afterTable.AsEnumerable()
                .ToDictionary(row => row["DocKey"].ToString(), row => row);

            totalDocumentIndexEntries = beforeData.Count + afterData.Count;
            documentIndexProcessedCount = 0;
            UpdateProgress("DocumentIndex Comparison", $"Preparing DocumentIndex comparison. Total entries: {totalDocumentIndexEntries}");

            var allKeys = beforeData.Keys.Union(afterData.Keys).ToList();

            Parallel.ForEach(Partitioner.Create(0, allKeys.Count, BatchSize), new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, range =>
            {
                int batchStart = range.Item1;
                int batchEnd = Math.Min(range.Item2, allKeys.Count);

                for (int i = batchStart; i < batchEnd; i++)
                {
                    var key = allKeys[i];
                    beforeData.TryGetValue(key, out DataRow beforeRow);
                    afterData.TryGetValue(key, out DataRow afterRow);

                    if (beforeRow != null && afterRow != null)
                    {
                        var allColumnNames = beforeTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

                        foreach (var columnName in allColumnNames)
                        {
                            var beforeValue = beforeRow[columnName]?.ToString();
                            var afterValue = afterRow[columnName]?.ToString();

                            if (beforeValue != afterValue)
                            {
                                var status = $"Column '{columnName}' mismatch for DocKey '{key}'";

                                result.AddOrUpdate(key, new List<ComparisonResult>
                                {
                                    new ComparisonResult
                                    {
                                        Status = status,
                                        BeforeValue = beforeValue,
                                        AfterValue = afterValue,
                                        ColumnName = columnName
                                    }
                                }, (existingKey, list) =>
                                {
                                    list.Add(new ComparisonResult
                                    {
                                        Status = status,
                                        BeforeValue = beforeValue,
                                        AfterValue = afterValue,
                                        ColumnName = columnName
                                    });
                                    return list;
                                });
                            }
                        }
                    }
                    else if (beforeRow == null)
                    {
                        result.AddOrUpdate(key, new List<ComparisonResult>
                        {
                            new ComparisonResult
                            {
                                Status = $"DocumentIndex entry added for {key}",
                                BeforeValue = "N/A",
                                AfterValue = "N/A",
                                ColumnName = "N/A"
                            }
                        }, (existingKey, list) =>
                        {
                            list.Add(new ComparisonResult
                            {
                                Status = $"DocumentIndex entry added for {key}",
                                BeforeValue = "N/A",
                                AfterValue = "N/A",
                                ColumnName = "N/A"
                            });
                            return list;
                        });
                    }
                    else if (afterRow == null)
                    {
                        result.AddOrUpdate(key, new List<ComparisonResult>
                        {
                            new ComparisonResult
                            {
                                Status = $"DocumentIndex entry removed for {key}",
                                BeforeValue = "N/A",
                                AfterValue = "N/A",
                                ColumnName = "N/A"
                            }
                        }, (existingKey, list) =>
                        {
                            list.Add(new ComparisonResult
                            {
                                Status = $"DocumentIndex entry removed for {key}",
                                BeforeValue = "N/A",
                                AfterValue = "N/A",
                                ColumnName = "N/A"
                            });
                            return list;
                        });
                    }

                    Interlocked.Increment(ref documentIndexProcessedCount);
                }

                UpdateProgress("DocumentIndex Comparison",
                    $"Batch {batchStart / BatchSize + 1} processed. Live count: {documentIndexProcessedCount}.");
            });

            UpdateProgress("DocumentIndex Comparison", $"DocumentIndex comparison completed. Total processed: {documentIndexProcessedCount} entries.");

            return result;
        }

        private void SaveResultsToExcel(ConcurrentDictionary<string, List<ComparisonResult>> docDataResults, ConcurrentDictionary<string, List<ComparisonResult>> documentIndexResults, string fileName)
        {
            using (var package = new ExcelPackage())
            {
                bool hasDocDataResults = docDataResults != null && docDataResults.Any();
                bool hasDocumentIndexResults = documentIndexResults != null && documentIndexResults.Any();

                if (hasDocDataResults)
                {
                    var ws1 = package.Workbook.Worksheets.Add("DocData Comparison");
                    ws1.Cells[1, 1].Value = "DocKey";
                    ws1.Cells[1, 2].Value = "Page";
                    ws1.Cells[1, 3].Value = "Status";
                    ws1.Cells[1, 4].Value = "PageData Before";
                    ws1.Cells[1, 5].Value = "PageData After";

                    var docDataList = docDataResults.SelectMany(kvp => kvp.Value)
                        .OrderBy(r => (int.TryParse(r.DocKey, out int dk) ? (int?)dk : null, r.DocKey))
                        .ThenBy(r => r.Page)
                        .ToList();

                    int row = 2;
                    foreach (var result in docDataList)
                    {
                        ws1.Cells[row, 1].Value = result.DocKey;
                        ws1.Cells[row, 2].Value = result.Page;
                        ws1.Cells[row, 3].Value = result.Status;
                        ws1.Cells[row, 4].Value = result.BeforeValue;
                        ws1.Cells[row, 5].Value = result.AfterValue;
                        row++;
                    }

                    ws1.Column(4).Width = 150;
                    ws1.Column(5).Width = 150;

                    ws1.Column(1).AutoFit();
                    ws1.Column(2).AutoFit();
                    ws1.Column(3).AutoFit();

                    foreach (var rowIndex in Enumerable.Range(2, docDataList.Count))
                    {
                        ws1.Row(rowIndex).Style.WrapText = true;
                    }
                }

                if (hasDocumentIndexResults)
                {
                    var ws2 = package.Workbook.Worksheets.Add("DocumentIndex Comparison");

                    var allColumns = documentIndexResults
                        .SelectMany(kvp => kvp.Value)
                        .Select(result => result.ColumnName)
                        .Distinct()
                        .ToList();

                    int columnIndex = 1;
                    ws2.Cells[1, columnIndex++].Value = "DocKey";

                    foreach (var column in allColumns)
                    {
                        ws2.Cells[1, columnIndex++].Value = column + " Before";
                        ws2.Cells[1, columnIndex++].Value = column + " After";
                    }

                    var groupedResults = documentIndexResults
                        .GroupBy(kvp => kvp.Key)
                        .OrderBy(g => (int.TryParse(g.Key, out int dk) ? (int?)dk : null, g.Key))
                        .ToList();

                    int row = 2;
                    foreach (var group in groupedResults)
                    {
                        var docKey = group.Key;
                        var results = group.SelectMany(g => g.Value)
                                           .GroupBy(r => r.ColumnName)
                                           .ToDictionary(g => g.Key, g => g.ToList());

                        ws2.Cells[row, 1].Value = docKey;

                        int colIndex = 2;
                        foreach (var column in allColumns)
                        {
                            if (results.ContainsKey(column))
                            {
                                var result = results[column].FirstOrDefault();
                                ws2.Cells[row, colIndex].Value = result?.BeforeValue ?? "-";
                                ws2.Cells[row, colIndex + 1].Value = result?.AfterValue ?? "-";
                            }
                            else
                            {
                                ws2.Cells[row, colIndex].Value = "-";
                                ws2.Cells[row, colIndex + 1].Value = "-";
                            }
                            colIndex += 2;
                        }

                        row++;
                    }

                    foreach (var col in Enumerable.Range(1, allColumns.Count * 2 + 1))
                    {
                        ws2.Column(col).AutoFit();
                    }

                    foreach (var rowIndex in Enumerable.Range(2, groupedResults.Count))
                    {
                        ws2.Row(rowIndex).Style.WrapText = true;
                        ws2.Row(rowIndex).Height = ws2.Row(rowIndex).Height + 10;
                    }
                }

                if (!hasDocDataResults && !hasDocumentIndexResults)
                {
                    UpdateProgress("No Differences", "No differences found.");
                    return;
                }

                string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Comparison Output", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                package.SaveAs(new FileInfo(outputPath));
                UpdateProgress("Saved Results", $"Results saved to: {outputPath}");
            }
        }

        private void UpdateProgress(string category, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, string>(UpdateProgress), category, message);
            }
            else
            {
                listBoxProgress.Items.Add($"[{category}] {message}");
                listBoxProgress.TopIndex = listBoxProgress.Items.Count - 1;
            }
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (TimeIntervalDialog dialog = new TimeIntervalDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    linkLabel1.Enabled = false; // Disable the link at the start of the process
                    DateTime startTime = dialog.StartTime;
                    int intervalInMinutes = dialog.Interval;

                    // Calculate the delay
                    TimeSpan delay = startTime - DateTime.Now;
                    if (delay.TotalMilliseconds > 0 && delay.TotalMilliseconds <= int.MaxValue)
                    {
                        await Task.Delay(delay);
                    }

                    UpdateProgress("File Drop Start", "File dropping process started. Please wait.");

                    foreach (var jobId in textBoxBeforeZip.Text.Split(','))
                    {
                        string trimmedJobId = jobId.Trim();
                        if (string.IsNullOrWhiteSpace(trimmedJobId))
                        {
                            UpdateProgress("Input Required", "Please enter a PROD Job ID that you want to drop in the selected Test/Prep environment");
                            linkLabel1.Enabled = true; // Re-enable the link in case of an error
                            return;
                        }

                        string server = "idoxsprodussql08.production.kubra.com";
                        string database = "WasteConnections_KubraDoc40";
                        string table = "dbo.DataBaseList";
                        string column = "Date_Added";
                        string zipPath = @"\\dwprod4fs.production.kubra.com\DocWebPROD\1_DocWeb_PROD\System\Archive\Data";
                        if (checkBoxArchivedJobs.Checked)
                        {
                            zipPath = @"\\corp1\Common\Service Delivery\COE\Waste Connections\Implementation\Testing\OldProdDataExtracts";
                        }

                        string extractPath = Path.Combine(Path.GetTempPath(), "extracted");
                        string destinationPath = @"\\testx-fs.corpx.kubra.com\docweb\1_DocWeb_TEST\System\Transmissions\ToKubra\WASTECONNECTIONS";

                        if (comboBoxEnvironment.SelectedItem.ToString() == "TEST")
                        {
                            destinationPath = @"\\testx-fs.corpx.kubra.com\docweb\1_DocWeb_TEST\System\Transmissions\ToKubra\WASTECONNECTIONS";
                        }
                        else if (comboBoxEnvironment.SelectedItem.ToString() == "PREP")
                        {
                            destinationPath = @"\\dwprep4fs.production.kubra.com\DocWebPREP\1_DocWeb_PREP\System\Transmissions\ToKUBRA\WASTECONNECTIONS";
                        }

                        string zipFile = Path.Combine(zipPath, $"{trimmedJobId}.zip");

                        string dateAdded = await Task.Run(() => GetDateAdded(server, database, table, column, trimmedJobId));

                        if (dateAdded == null)
                        {
                            UpdateProgress("Error", "No matching record found or Date_Added is NULL");
                            linkLabel1.Enabled = true; // Re-enable the link in case of an error
                            return;
                        }

                        if (!File.Exists(zipFile))
                        {
                            UpdateProgress("Error", "Zip file not found: " + zipFile);
                            linkLabel1.Enabled = true; // Re-enable the link in case of an error
                            return;
                        }

                        try
                        {
                            if (Directory.Exists(extractPath))
                            {
                                Directory.Delete(extractPath, true);
                            }
                            Directory.CreateDirectory(extractPath);
                            await Task.Run(() => ZipFile.ExtractToDirectory(zipFile, extractPath));
                            string newFileName = string.Empty;
                            foreach (var file in Directory.GetFiles(extractPath))
                            {
                                string fileName = Path.GetFileName(file);
                                newFileName = $"{Path.GetFileNameWithoutExtension(file)}_FD_{dateAdded}{Path.GetExtension(file)}";
                                string newFilePath = Path.Combine(extractPath, newFileName);

                                File.Move(file, newFilePath);
                                string finalFilePath = Path.Combine(destinationPath, $"{newFileName}.override");

                                File.Copy(newFilePath, finalFilePath, true);

                                UpdateProgress("File Dropped", $"Prod job [Filename:{newFileName}] successfully dropped in the selected testing environment");
                            }

                            Directory.Delete(extractPath, true);
                        }
                        catch (Exception ex)
                        {
                            UpdateProgress("Error", "An error occurred: " + ex.Message);
                            linkLabel1.Enabled = true; // Re-enable the link in case of an error
                            return;
                        }

                        await Task.Delay(TimeSpan.FromMinutes(intervalInMinutes));
                    }

                    UpdateProgress("File Drop End", "File dropping process ended.");
                }
            }

            linkLabel1.Enabled = true; // Re-enable the link after the process completes
        }
        private string GetDateAdded(string server, string database, string table, string column, string jobid)
        {
            string result = null;

            string query = $@"
            DECLARE @DateAdded DATETIME;
            DECLARE @FormattedDate VARCHAR(6);
            SELECT TOP 1 @DateAdded = {column} FROM {table} WHERE DB_Name LIKE '%_{jobid}.%' ORDER BY {column} DESC;
            IF @DateAdded IS NOT NULL BEGIN
                SELECT FORMAT(DATEADD(DAY, 5, @DateAdded), 'MMddyy');
            END ELSE BEGIN
                SELECT 'Date_Added is NULL';
            END;";

            using (SqlConnection connection = new SqlConnection($"Server={server};Database={database};Integrated Security=True;"))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                result = (string)command.ExecuteScalar();
            }

            return result == "Date_Added is NULL" ? null : result;
        }

        private void ComboBoxEnvironment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEnvironment.SelectedItem.ToString() == "TEST")
            {
                linkLabel1.Text = "Auto Drop\nProd to Test";
                labelAfterZip.Text = "After - Test Job ID:";
            }
            else if (comboBoxEnvironment.SelectedItem.ToString() == "PREP")
            {
                linkLabel1.Text = "Auto Drop\nProd to Prep";
                labelAfterZip.Text = "After - Prep Job ID:";
            }
        }

        private void checkBoxArchivedJobs_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

    public class ComparisonResult
    {
        public string DocKey { get; set; }  // Added for sorting in DocData
        public int Page { get; set; }  // Added for sorting in DocData
        public string Status { get; set; }
        public string BeforeValue { get; set; }
        public string AfterValue { get; set; }
        public string ColumnName { get; set; } // Only for DocumentIndex
    }
}
