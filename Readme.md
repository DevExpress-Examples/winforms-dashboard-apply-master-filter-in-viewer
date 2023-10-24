<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128580723/18.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5097)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# BI Dashboard for WinForms - How to Set Master Filter in Dashboard Viewer

The following example demonstrates how to set master filter in the [Dashboard Viewer](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer) control.

The Dashboard Viewer control loads a dashboard with two master filter items - the Grid and Range Filter dashboard items. The Chart item displays the filtered data.  

The [DashboardViewer.ConfigureDataConnection](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.ConfigureDataConnection) event is handled to specify the [Extract Data Source](https://docs.devexpress.com/Dashboard/115900/creating-dashboards/creating-dashboards-in-the-winforms-designer/providing-data/extract-data-source) filename. The [DashboardViewer.CustomizeDashboardTitle](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.CustomizeDashboardTitle) event handler creates the command button that executes the application's SetMasterFilterMethod procedure.

The SetMasterFilterMethod procedure uses the [DashboardViewer.SetMasterFilter](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.SetMasterFilter.overloads) method to select the rows in the [Grid]( https://docs.devexpress.com/Dashboard/15150)  dashboard item. The [DashboardViewer.SetRange](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.SetRange.overloads) method selects the range in the [Range Filter](https://docs.devexpress.com/Dashboard/15265) dashboard item.

This example also demonstrates how to handle the [DashboardViewer.MasterFilterSet](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.MasterFilterSet) and [DashboardViewer.MasterFilterCleared](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.MasterFilterCleared) events.

![Screenshot](images/screenshot.png)

> To reduce the application loading time and memory usage, initialize master filters before loading data as illustrated in the [
How to apply default filtering to master filters in Dashboard Viewer](https://github.com/DevExpress-Examples/how-to-apply-default-filtering-to-master-filters-in-dashboardviewer-t329583/) example.

## Files to Review

* [Form1.cs](./CS/Dashboard_SetMasterFilter/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_SetMasterFilter/Form1.vb))

## Documentation

- [Master Filtering](https://docs.devexpress.com/Dashboard/116912)

## More Examples

- [How to Apply Default Filtering to Master Filter Items that Affect Each Other](https://github.com/DevExpress-Examples/win-viewer-how-to-apply-default-filtering-to-master-filter-items-that-affect-each-other-t474844) 
- [How to Initialize Master Filters in Dashboard Viewer](https://github.com/DevExpress-Examples/how-to-apply-default-filtering-to-master-filters-in-dashboardviewer-t329583)
