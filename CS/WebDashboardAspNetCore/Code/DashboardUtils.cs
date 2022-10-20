using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.Excel;
using DevExpress.DataAccess.Sql;
using Microsoft.Extensions.FileProviders;

namespace WebDashboardAspNetCore {
    public static class DashboardUtils {
        public static DashboardConfigurator CreateDashboardConfigurator(IConfiguration configuration, IFileProvider fileProvider) {
            DashboardConfigurator configurator = new DashboardConfigurator();
            configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(configuration));

            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage(fileProvider.GetFileInfo("Data/Dashboards").PhysicalPath);
            configurator.SetDashboardStorage(dashboardFileStorage);

            configurator.SetDataSourceStorage(new DataSourceInMemoryStorage());

            // This method assigns the database schema provider to the Web Dashboard.
            // Uncomment one of the following lines depending on the provider.
            configurator.SetDBSchemaProvider(new ManualDBSchemaProvider());
            //configurator.SetDBSchemaProvider(new LimitDBSchemaProvider());

            return configurator;
        }
    }
}