using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Mars.POM.Utilities
{
    public class TableComparer
    {
        public static bool AreTablesEqual(Table tableA, Table tableB)
        {
            Log.Information("tableA.Header.Count: " + tableA.Header.Count);
            Log.Information("tableB.Header.Count: " + tableB.Header.Count);
            if (tableA.Header.Count != tableB.Header.Count ||
                !tableA.Header.SequenceEqual(tableB.Header))
            {
                return false;
            }
            Log.Information("tableA.Rows.Count: " + tableA.Rows.Count);
            Log.Information("tableB.Rows.Count: " + tableB.Rows.Count);
            if (tableA.Rows.Count != tableB.Rows.Count)
            {
                return false;
            }

            for (int i = 0; i < tableA.Rows.Count; i++)
            {
                TableRow rowA = tableA.Rows[i];
                TableRow rowB = tableB.Rows[i];

                Log.Information("Line number: " + i);

                foreach (string columnName in tableA.Header)
                {
                    Log.Information("columnName: " + columnName);

                    Log.Information("Actual value: " + rowA[columnName]);
                    Log.Information("Expected value: " + rowB[columnName]);
                    if (!rowA[columnName].Equals(rowB[columnName]))
                    {
                        Log.Information("Actual value: " + rowA[columnName]);
                        Log.Information("Expected value: " + rowB[columnName]);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
