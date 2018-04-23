Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Collections
Imports DevExpress.DashboardCommon

Namespace Dashboard_SetMasterFilter
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			' Loads a dashboard from an XML file.
			dashboardViewer1.LoadDashboard("..\..\Data\Dashboard.xml")

			' Creates a list with values to be selected in the Grid dashboard item.
			Dim rowValues1 As New List(Of Object)()
			rowValues1.AddRange(New String() { "UK", "Anne Dodsworth" })
			Dim rowValues2 As New List(Of Object)()
			rowValues2.AddRange(New String() { "USA", "Andrew Fuller" })
            Dim selectedRows As New List(Of IList)(New IList() {rowValues1, rowValues2})


			' Creates a range with specified minimum and maximum values.
			Dim minimumValue As New DateTime(1995, 3, 1)
			Dim maximumValue As New DateTime(1995, 10, 1)
			Dim selectedRange As New RangeFilterSelection(minimumValue, maximumValue)

			' Selects specified values in the Grid dashboard item.
			dashboardViewer1.SetMasterFilter("gridDashboardItem1", selectedRows)
			' Selects a specified range in the Range Filter dashboard item.
			dashboardViewer1.SetRange("rangeFilterDashboardItem1", selectedRange)
		End Sub
	End Class
End Namespace
