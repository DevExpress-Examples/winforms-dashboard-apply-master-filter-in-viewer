using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using DevExpress.DashboardCommon;
using System.IO;
using DevExpress.DashboardWin;
using System.Linq;
using DevExpress.XtraEditors;

namespace Dashboard_SetMasterFilter {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
            dashboardViewer1.ConfigureDataConnection += DashboardViewer1_ConfigureDataConnection;
            dashboardViewer1.CustomizeDashboardTitle += DashboardViewer1_CustomizeDashboardTitle;

            dashboardViewer1.LoadDashboard("Dashboard.xml");

            dashboardViewer1.MasterFilterSet += DashboardViewer1_MasterFilterSet;
            dashboardViewer1.MasterFilterCleared += DashboardViewer1_MasterFilterCleared;
        }

        private void SetMasterFilterMethod()
        {
            // Create a list with values to select in the Grid dashboard item.
            List<object> rowValues1 = new List<object>();
            rowValues1.AddRange(new[] { "UK", "Anne Dodsworth" });
            List<object> rowValues2 = new List<object>();
            rowValues2.AddRange(new[] { "USA", "Andrew Fuller" });
            List<IList> selectedRows = new List<IList>(new[] { rowValues1, rowValues2 });

            // Create a selection range and specify its minimum and maximum values.
            DateTime minimumValue = new DateTime(2015, 3, 1);
            DateTime maximumValue = new DateTime(2016, 3, 1);
            RangeFilterSelection selectedRange = new RangeFilterSelection(minimumValue, maximumValue);

            // Select the values in the Grid dashboard item.
            dashboardViewer1.SetMasterFilter("gridDashboardItem1", selectedRows);
            // Select the range in the Range Filter dashboard item.
            dashboardViewer1.SetRange("rangeFilterDashboardItem1", selectedRange);
        }

        private void DashboardViewer1_MasterFilterSet(object sender, MasterFilterSetEventArgs e)
        {
            DashboardViewer viewer = (DashboardViewer)sender;
            // If the Master Filter includes Anne Dodsworth as Sales Person, disable print and export.
            if (e.DashboardItemName.Contains("grid"))
                viewer.AllowPrintDashboard = e.SelectedValues.Select(value => value[1].ToString()).Contains("Anne Dodsworth") ? false : true;
        }

        private void DashboardViewer1_MasterFilterCleared(object sender, MasterFilterClearedEventArgs e)
        {
            MessageBox.Show("Selection cleared in the " + e.DashboardItemName + "Master Filter item.");
        }

        private void DashboardViewer1_CustomizeDashboardTitle(object sender, CustomizeDashboardTitleEventArgs e)
        {
            DashboardViewer viewer = (DashboardViewer)sender;

            // Create the command button to set Master Filter.
            DashboardToolbarItem setMasterFilterItem = new DashboardToolbarItem("Set Master Filter",
                new Action<DashboardToolbarItemClickEventArgs>((args) => { SetMasterFilterMethod(); }));
            setMasterFilterItem.Caption = "Set Master Filter";
            e.Items.Insert(0, setMasterFilterItem);
        }

        private void DashboardViewer1_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
        {
            ExtractDataSourceConnectionParameters parameters = e.ConnectionParameters as ExtractDataSourceConnectionParameters;
            if (parameters != null)
                parameters.FileName = Path.GetFileName(parameters.FileName);
        }
    }
}
