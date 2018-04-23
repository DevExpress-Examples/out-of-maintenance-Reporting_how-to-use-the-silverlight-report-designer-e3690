Imports Microsoft.VisualBasic
Imports System.Web
Imports DevExpress.Data.Utils.ServiceModel
Imports DevExpress.XtraReports.Service
Imports DevExpress.XtraReports.UI
Imports SilverlightReportDesignerDemo.Web.DataSet1TableAdapters

Namespace SilverlightReportDesignerDemo.Web
	' NOTE: You can use the "Rename" command on the "Refactor" menu 
	' to change the class name "ReportService1" in code, svc and config file together.
	<SilverlightFaultBehavior> _
	Public Class ReportService1
		Inherits ReportService

		' Register all datasources used by your reports using the following method.
		Protected Overrides Sub RegisterDataSources(ByVal report As XtraReport, ByVal reportName As String)
			Dim report1 As XtraReport1 = TryCast(report, XtraReport1)
			If report1 IsNot Nothing Then
				report1.RegisterDataSourceName("XtraReport1Data", report1.DataSource)
			End If
		End Sub

		' Populate your datasources for an editing session using the following method.
		Protected Overrides Sub FillDataSources(ByVal report As XtraReport, ByVal reportName As String, ByVal isDesignActive As Boolean)
			Dim dataSet As DataSet1 = CType(report.GetDataSourceByName("XtraReport1Data"), DataSet1)

			Using categoriesTableAdapter = New CategoriesTableAdapter()
			Using productsTableAdapter = New ProductsTableAdapter()
				categoriesTableAdapter.Fill(dataSet.Categories)
				productsTableAdapter.Fill(dataSet.Products)
			End Using
			End Using
		End Sub

		' Override the following two methods to get access to a session.
		' It is not required to override these methods when working with a file or database.
		' In addition, make sure that in the web.config file's <system.serviceModel> section 
		' a <serviceHostingEnvironment> parameter is added with the aspNetCompatibilityEnabled attribute enabled.
		Protected Overrides Sub SaveReportLayout(ByVal reportName As String, ByVal layoutData() As Byte)
			HttpContext.Current.Session(reportName) = layoutData
		End Sub

		Protected Overrides Function LoadReportLayout(ByVal reportName As String) As Byte()
			Return CType(HttpContext.Current.Session(reportName), Byte())
		End Function
	End Class
End Namespace



