using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using DevExpress.DashboardCommon;

namespace Dashboard_SetMasterFilter {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            // Loads a dashboard from an XML file.
            dashboardViewer1.LoadDashboard(@"..\..\Data\Dashboard.xml");

            // Creates a list with values to be selected in the Grid dashboard item.
            List<object> rowValues1 = new List<object>();
            rowValues1.AddRange(new[] { "UK", "Anne Dodsworth" } );
            List<object> rowValues2 = new List<object>();
            rowValues2.AddRange(new[] { "USA", "Andrew Fuller" } );
            List<IList> selectedRows = new List<IList>( new[] {rowValues1, rowValues2} );

            // Creates a range with specified minimum and maximum values.
            DateTime minimumValue = new DateTime(1995, 3, 1);
            DateTime maximumValue = new DateTime(1995, 10, 1);
            RangeFilterSelection selectedRange = new RangeFilterSelection(minimumValue, maximumValue);

            // Selects specified values in the Grid dashboard item.
            dashboardViewer1.SetMasterFilter("gridDashboardItem1", selectedRows);
            // Selects a specified range in the Range Filter dashboard item.
            dashboardViewer1.SetRange("rangeFilterDashboardItem1", selectedRange);
        }
    }
}
