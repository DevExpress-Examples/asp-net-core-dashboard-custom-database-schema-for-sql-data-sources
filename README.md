<!-- default badges list -->
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Dashboard for ASP.NET Core - How to customize a database schema for SQL data sources

This example shows how to provide a custom database schema for the dashboard. The example contains two implementation of the [IDBSchemaProviderEx](https://docs.devexpress.com/CoreLibraries/DevExpress.DataAccess.Sql.IDBSchemaProviderEx) interface, `MyDBSchemaProvider` and `CustomDBSchemaProvider`. Use the [DashboardConfigurator.SetDBSchemaProvider](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.DashboardConfigurator.SetDBSchemaProvider(DevExpress.DataAccess.Sql.IDBSchemaProviderEx)) method to assign the database schema for the Web Dashboard.

To see the result, add a new query or edit the existing query.

### The MyDBSchemaProvider class

File: [MyDBSchemaProvider.cs](./CS/WebDashboardAspNetCore/MyDBSchemaProvider.cs)

This provider displays only:

- Tables which names start with the letter *C*
- Views which names start with *Sales*
- Stored procedures with zero arguments

![](images/custom_dbschema_views.png)

### The CustomDBSchemaProvider class

File: [CustomDBSchemaProvider.cs](./CS/WebDashboardAspNetCore/CustomDBSchemaProvider.cs)

This provider loads only two tables (`Categories` and `Products`) for the `NWindConnectionString` connection. Both tables contain only two columns and the tables are linked by the `CategoryID` field.

![](images/custom_dbschema_tables.png)

This technique improves the dashboard performance, since only the specified tables are loaded to the dashboard.

## Files to Look At

* [MyDBSchemaProvider.cs](./CS/WebDashboardAspNetCore/MyDBSchemaProvider.cs)
* [CustomDBSchemaProvider.cs](./CS/WebDashboardAspNetCore/CustomDBSchemaProvider.cs)
* [DashboardUtils.cs](/CS/WebDashboardAspNetCore/Code/DashboardUtils.cs#L19)

## Documentation

* [IDBSchemaProviderEx](https://docs.devexpress.com/CoreLibraries/DevExpress.DataAccess.Sql.IDBSchemaProviderEx)

## More Examples

* [Dashboard for MVC - How to customize a data store schema for SQL data sources](https://github.com/DevExpress-Examples/aspnet-mvc-dashboard-how-to-customize-a-data-store-schema-for-sql-data-sources-t584271)
* [Dashboard for ASP.NET Core - How to implement multi-tenant Dashboard architecture](https://github.com/DevExpress-Examples/DashboardUserBasedAspNetCore#data-source-schema)
