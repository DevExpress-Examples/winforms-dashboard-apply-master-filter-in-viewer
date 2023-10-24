Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Collections
Imports DevExpress.DashboardCommon
Imports System.IO
Imports DevExpress.DashboardWin
Imports System.Linq
Imports DevExpress.XtraEditors

Namespace Dashboard_SetMasterFilter

    Public Partial Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            AddHandler dashboardViewer1.ConfigureDataConnection, AddressOf DashboardViewer1_ConfigureDataConnection
            AddHandler dashboardViewer1.CustomizeDashboardTitle, AddressOf DashboardViewer1_CustomizeDashboardTitle
            dashboardViewer1.LoadDashboard("Dashboard.xml")
            AddHandler dashboardViewer1.MasterFilterSet, AddressOf DashboardViewer1_MasterFilterSet
            AddHandler dashboardViewer1.MasterFilterCleared, AddressOf DashboardViewer1_MasterFilterCleared
        End Sub

        Private Sub SetMasterFilterMethod()
            ' Create a list with values to select in the Grid dashboard item.
            Dim rowValues1 As List(Of Object) = New List(Of Object)()
            rowValues1.AddRange({"UK", "Anne Dodsworth"})
            Dim rowValues2 As List(Of Object) = New List(Of Object)()
            rowValues2.AddRange({"USA", "Andrew Fuller"})
            Dim selectedRows As List(Of IList) = New List(Of IList)({rowValues1, rowValues2})
            ' Create a selection range and specify its minimum and maximum values.
            Dim minimumValue As Date = New DateTime(2015, 3, 1)
            Dim maximumValue As Date = New DateTime(2016, 3, 1)
            Dim selectedRange As RangeFilterSelection = New RangeFilterSelection(minimumValue, maximumValue)
            ' Select the values in the Grid dashboard item.
            dashboardViewer1.SetMasterFilter("gridDashboardItem1", selectedRows)
            ' Select the range in the Range Filter dashboard item.
            dashboardViewer1.SetRange("rangeFilterDashboardItem1", selectedRange)
        End Sub

        Private Sub DashboardViewer1_MasterFilterSet(ByVal sender As Object, ByVal e As MasterFilterSetEventArgs)
            Dim viewer As DashboardViewer = CType(sender, DashboardViewer)
            ' If the Master Filter includes Anne Dodsworth as Sales Person, disable print and export.
            If e.DashboardItemName.Contains("grid") Then viewer.AllowPrintDashboard = If(e.SelectedValues.[Select](Function(value) value(1).ToString()).Contains("Anne Dodsworth"), False, True)
        End Sub

        Private Sub DashboardViewer1_MasterFilterCleared(ByVal sender As Object, ByVal e As MasterFilterClearedEventArgs)
            MessageBox.Show("Selection cleared in the " & e.DashboardItemName & "Master Filter item.")
        End Sub

        Private Sub DashboardViewer1_CustomizeDashboardTitle(ByVal sender As Object, ByVal e As CustomizeDashboardTitleEventArgs)
            Dim viewer As DashboardViewer = CType(sender, DashboardViewer)
            ' Create the command button to set Master Filter.
            Dim setMasterFilterItem As DashboardToolbarItem = New DashboardToolbarItem("Set Master Filter", New Action(Of DashboardToolbarItemClickEventArgs)(Sub(args) SetMasterFilterMethod()))
            setMasterFilterItem.Caption = "Set Master Filter"
            e.Items.Insert(0, setMasterFilterItem)
        End Sub

        Private Sub DashboardViewer1_ConfigureDataConnection(ByVal sender As Object, ByVal e As DashboardConfigureDataConnectionEventArgs)
            Dim parameters As ExtractDataSourceConnectionParameters = TryCast(e.ConnectionParameters, ExtractDataSourceConnectionParameters)
            If parameters IsNot Nothing Then parameters.FileName = Path.GetFileName(parameters.FileName)
        End Sub
    End Class
End Namespace
