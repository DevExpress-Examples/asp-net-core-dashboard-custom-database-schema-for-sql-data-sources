<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/524110630/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1109764)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Dashboard for ASP.NET Core - How to customize a database schema for SQL data sources

This example shows how to create a custom database schema for the dashboard. The example contains two implementation of the [IDBSchemaProviderEx](https://docs.devexpress.com/CoreLibraries/DevExpress.DataAccess.Sql.IDBSchemaProviderEx) interface, `LimitDBSchemaProvider` and `ManualDBSchemaProvider`. Call the [DashboardConfigurator.SetDBSchemaProvider](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.DashboardConfigurator.SetDBSchemaProvider(DevExpress.DataAccess.Sql.IDBSchemaProviderEx)) method to assign the database schema to the Web Dashboard.

To see the result, add a new query or edit the existing query.

### The LimitDBSchemaProvider class

File: [LimitDBSchemaProvider.cs](./CS/WebDashboardAspNetCore/LimitDBSchemaProvider.cs)

This provider displays only the following database entities:

- Tables which names start with the letter *C*
- Views which names start with *Sales*
- Stored procedures with zero arguments

![](images/custom_dbschema_views.png)

### The ManualDBSchemaProvider class

File: [ManualDBSchemaProvider.cs](./CS/WebDashboardAspNetCore/ManualDBSchemaProvider.cs)

This provider loads two tables (`Categories` and `Products`) for the `NWindConnectionString` connection. Both tables contain only two columns and the tables are linked by the `CategoryID` field.

![](images/custom_dbschema_tables.png)

This technique improves the [Data Source Wizard](https://docs.devexpress.com/Dashboard/117680/) performance when loading the database schema.

## Files to Review

* [LimitDBSchemaProvider.cs](./CS/WebDashboardAspNetCore/LimitDBSchemaProvider.cs)
* [ManualDBSchemaProvider.cs](./CS/WebDashboardAspNetCore/ManualDBSchemaProvider.cs)
* [DashboardUtils.cs](/CS/WebDashboardAspNetCore/Code/DashboardUtils.cs#L19)

## Documentation

* [Implement a Custom Database Schema](https://docs.devexpress.com/Dashboard/404044/web-dashboard/dashboard-backend/implement-a-custom-database-schema?p=netframework)

## More Examples

* [Dashboard for MVC - How to customize a data store schema for SQL data sources](https://github.com/DevExpress-Examples/aspnet-mvc-dashboard-how-to-customize-a-data-store-schema-for-sql-data-sources-t584271)
* [Dashboard for ASP.NET Web Forms - How to customize a database schema for SQL data sources](https://github.com/DevExpress-Examples/web-forms-dashboard-custom-database-schema-for-sql-data-sources)
* [Dashboard for ASP.NET Core - How to implement multi-tenant Dashboard architecture](https://github.com/DevExpress-Examples/DashboardUserBasedAspNetCore#data-source-schema)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-core-dashboard-custom-database-schema-for-sql-data-sources&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-core-dashboard-custom-database-schema-for-sql-data-sources&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
