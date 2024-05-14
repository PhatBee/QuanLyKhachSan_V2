using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class PreviewPrintBaoCao : Form
    {
        public PreviewPrintBaoCao()
        {
            InitializeComponent();
        }

        private void PreviewPrintBaoCao_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void ShowReport(DataTable table)
        {
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1RptBaoCaoHoaDon", table);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

        }
    }
}
