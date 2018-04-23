Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim fSession As New Session()
		Dim gv As New ASPxGridView()
		gv.DataSource = New XPCollection(Of Customer)(fSession)
		gv.SettingsDetail.ShowDetailRow = True
		gv.SettingsDetail.ShowDetailButtons = True
		gv.Templates.DetailRow = New DetailRowTemplate(fSession)
		gv.KeyFieldName = "Oid"
		ASPxRoundPanel1.Controls.Add(gv)
		gv.DataBind()
	End Sub
End Class

Public Class DetailRowTemplate
	Implements ITemplate
	Private fSession As Session

	Public Sub New(ByVal s As Session)
		fSession = s
	End Sub
	Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
		Dim detailGridView As New ASPxGridView()
		detailGridView.SettingsDetail.IsDetailGrid = True
		detailGridView.KeyFieldName = "Oid"
		AddHandler detailGridView.BeforePerformDataSelect, AddressOf OnDetailViewBeforePerformDataSelect
		container.Controls.Add(detailGridView)
	End Sub

	Protected Sub OnDetailViewBeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
		Dim grid As ASPxGridView = CType(sender, ASPxGridView)
		Dim key As Object = grid.GetMasterRowKeyValue()
		Dim customer As Customer = fSession.GetObjectByKey(Of Customer)(key)
		Dim dataSource As New XPCollection(Of Order)(customer.Orders)
		dataSource.DisplayableProperties = "Oid;OrderName;OrderDate"
		grid.DataSource = dataSource
	End Sub
End Class