Imports Microsoft.VisualBasic
Imports System.Windows.Controls
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Printing
' ...

Namespace SilverlightReportDesignerDemo
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub dXTabControl1_SelectionChanged(ByVal sender As Object, ByVal e As TabControlSelectionChangedEventArgs)
            If e.NewSelectedItem Is previewTab Then
                Dim reportPreviewModel = CType(documentPreview.Model, ReportServicePreviewModel)
                reportPreviewModel.ReportName = reportDesigner.SessionId
                reportPreviewModel.CreateDocument()
            End If
		End Sub
	End Class
End Namespace
