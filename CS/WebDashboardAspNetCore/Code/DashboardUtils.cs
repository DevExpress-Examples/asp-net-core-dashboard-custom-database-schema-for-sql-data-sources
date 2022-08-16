using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;

namespace WebDashboardAspNetCore {
    public static class DashboardUtils {
        public static DashboardConfigurator CreateDashboardConfigurator(IConfiguration configuration, IFileProvider fileProvider) {
            DashboardConfigurator configurator = new DashboardConfigurator();
            configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(configuration));

            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage(fileProvider.GetFileInfo("Data/Dashboards").PhysicalPath);
            configurator.SetDashboardStorage(dashboardFileStorage);

            configurator.SetDataSourceStorage(new DataSourceInMemoryStorage());

            configurator.SetDBSchemaProvider(new CustomDBSchemaProvider());
            // configurator.SetDBSchemaProvider(new MyDBSchemaProvider());


            return configurator;
        }
    }
}