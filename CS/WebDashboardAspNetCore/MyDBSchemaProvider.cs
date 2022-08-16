using DevExpress.DataAccess.Sql;
using DevExpress.Xpo.DB;
using System.Linq;

namespace WebDashboardAspNetCore {
    public class MyDBSchemaProvider : IDBSchemaProviderEx {
        DBSchemaProviderEx provider;
        public MyDBSchemaProvider() {
            this.provider = new DBSchemaProviderEx();
        }

        public DBTable[] GetTables(SqlDataConnection connection, params string[] tableList) {
            // Returns only the tables which names start with the letter C.
            return provider.GetTables(connection, tableList)
                .Where(table => table.Name.StartsWith("C"))
                .ToArray();
        }

        public DBTable[] GetViews(SqlDataConnection connection, params string[] viewList) {
            // Returns only the views which names start with Sales.
            return provider.GetViews(connection, viewList)
                .Where(view => view.Name.StartsWith("Sales"))
                .ToArray();
        }

        public DBStoredProcedure[] GetProcedures(SqlDataConnection connection, params string[] procedureList) {
            // Returns only the stored procedures with zero argumnents.
            return provider.GetProcedures(connection, procedureList)
                .Where(storedProcedure => storedProcedure.Arguments.Count == 0)
                .ToArray();
        }

        public void LoadColumns(SqlDataConnection connection, params DBTable[] tables) {
            // Loads all columns in tables.
            provider.LoadColumns(connection, tables);
 
        }
    }
}


