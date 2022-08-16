using DevExpress.DataAccess.Sql;
using DevExpress.Xpo.DB;
using System.Collections.Specialized;

namespace WebDashboardAspNetCore {
    public class CustomDBSchemaProvider : IDBSchemaProviderEx {
        DBTable[] tables;
        public void LoadColumns(SqlDataConnection connection, params DBTable[] tables) {
            // Loads the specified columns in the Categories and Products tables.
            foreach (DBTable table in tables) {
                if (table.Name == "Categories" && table.Columns.Count == 0) {
                    DBColumn categoryIdColumn = new DBColumn { Name = "CategoryID", ColumnType = DBColumnType.Int32 };
                    table.AddColumn(categoryIdColumn);
                    DBColumn categoryNameColumn = new DBColumn { Name = "CategoryName", ColumnType = DBColumnType.String };
                    table.AddColumn(categoryNameColumn);
                }
                if (table.Name == "Products" && table.Columns.Count == 0) {
                    DBColumn categoryIdColumn = new DBColumn { Name = "CategoryID", ColumnType = DBColumnType.Int32 };
                    table.AddColumn(categoryIdColumn);
                    DBColumn productNameColumn = new DBColumn { Name = "ProductName", ColumnType = DBColumnType.String };
                    table.AddColumn(productNameColumn);

                    // Links the tables by the CategoryID field.
                    DBForeignKey foreignKey = new DBForeignKey(
                        new[] { categoryIdColumn },
                        "Categories",
                        CustomDBSchemaProvider.CreatePrimaryKeys("CategoryID"));
                    table.ForeignKeys.Add(foreignKey);
                }
            }
        }

        public static StringCollection CreatePrimaryKeys(params string[] names) {
            StringCollection collection = new StringCollection();
            collection.AddRange(names);
            return collection;
        }

        public DBTable[] GetTables(SqlDataConnection connection, params string[] tableList) {
            // Loads only the Categories and Products tables for the NWindConnectionString connection.
            if (connection.Name == "NWindConnectionString") {
                if (tables != null) {
                    return tables;
                }
                tables = new DBTable[2];

                DBTable categoriesTable = new DBTable("Categories");
                tables[0] = categoriesTable;

                DBTable productsTable = new DBTable("Products");
                tables[1] = productsTable;
            } else
                tables = new DBTable[0];

            LoadColumns(connection, tables);
            return tables;
        }

        public DBTable[] GetViews(SqlDataConnection connection, params string[] viewList) {
            DBTable[] views = new DBTable[0];
            return views;
        }

        public DBStoredProcedure[] GetProcedures(SqlDataConnection connection, params string[] procedureList) {
            DBStoredProcedure[] storedProcedures = new DBStoredProcedure[0];
            return storedProcedures;
        }
    }
}
