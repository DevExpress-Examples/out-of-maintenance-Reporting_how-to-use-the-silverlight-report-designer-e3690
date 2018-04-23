using System.Web;
using DevExpress.Data.Utils.ServiceModel;
using DevExpress.XtraReports.Service;
using DevExpress.XtraReports.UI;
using SilverlightReportDesignerDemo.Web.DataSet1TableAdapters;
// ...

namespace SilverlightReportDesignerDemo.Web {
    // NOTE: You can use the "Rename" command on the "Refactor" menu 
    // to change the class name "ReportService1" in code, svc and config file together.
    [SilverlightFaultBehavior]
    public class ReportService1 : ReportService {

        // Register all datasources used by your reports using the following method.
        protected override void RegisterDataSources(XtraReport report, string reportName) {
            XtraReport1 report1 = report as XtraReport1;
            if (report1 != null) {
                report1.RegisterDataSourceName("XtraReport1Data", report1.DataSource);
            }
        }

        // Populate your datasources for an editing session using the following method.
        protected override void FillDataSources(XtraReport report, string reportName, bool isDesignActive) {
            DataSet1 dataSet = (DataSet1)report.GetDataSourceByName("XtraReport1Data");

            using (var categoriesTableAdapter = new CategoriesTableAdapter())
            using (var productsTableAdapter = new ProductsTableAdapter()) {
                categoriesTableAdapter.Fill(dataSet.Categories);
                productsTableAdapter.Fill(dataSet.Products);
            }
        }

        // Override the following two methods to get access to a session.
        // It is not required to override these methods when working with a file or database.
        // In addition, make sure that in the web.config file's <system.serviceModel> section 
        // a <serviceHostingEnvironment> parameter is added with the aspNetCompatibilityEnabled attribute enabled.
        protected override void SaveReportLayout(string reportName, byte[] layoutData) {
            HttpContext.Current.Session[reportName] = layoutData;
        }

        protected override byte[] LoadReportLayout(string reportName) {
            return (byte[])HttpContext.Current.Session[reportName];
        }
    }
}



