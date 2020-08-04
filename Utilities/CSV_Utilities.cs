using System.Data;
using System.IO;

namespace GK_Assessment.Utilities
{
    class CSV_Utilities
    {
        /// <summary>
        /// Generate a Data Table from a csv file, using the first row as a header row.
        /// </summary>
        /// <param name="InputFilePath">Absolute file path to the CSV file to be read.</param>
        /// <returns>A Data Table containing the values extracted from the CSV file.</returns>
        public static DataTable CreateTestDataTable(string InputFilePath)
        {
            DataTable TestData = new DataTable();

            using (var stream = new StreamReader(InputFilePath))
            {
                //Create DataTable columns:
                string[] columns = stream.ReadLine().Split(";");

                foreach (string columnName in columns)
                {
                    TestData.Columns.Add(columnName);
                }

                //Create DataTable rows:
                while (!stream.EndOfStream)
                {
                    string[] row = stream.ReadLine().Split(";");
                    DataRow dataTableRow = TestData.NewRow();

                    for (int i = 0; i < row.Length; i++)
                    {
                        dataTableRow[i] = row[i];
                    }

                    TestData.Rows.Add(dataTableRow);
                }
            }

            return TestData;
        }
    }
}
