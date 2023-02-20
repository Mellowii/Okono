﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
namespace đồ_án
{
    public partial class BaoCaoNhapHang : Form
    {
        public BaoCaoNhapHang()
        {
            InitializeComponent();
        }

        private void BaoCaoThongKe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'OKONODataSet1.BCNhapHangTheoNgay' table. You can move, or remove it, as needed.
         //   this.BCNhapHangTheoNgayTableAdapter.Fill(this.OKONODataSet1.BCNhapHangTheoNgay);
            // TODO: This line of code loads data into the 'OKONODataSet1.BCNhapHangTheoNgay' table. You can move, or remove it, as needed.
            //this.BCNhapHangTheoNgayTableAdapter.Fill(OKONODataSet1.BCNhapHangTheoNgay);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.OKONOConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BCNhapHangTheoNgay";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@NgayNhap", dtpNgayNhap.Value.Date));
            //Khai báo dataset để chứa dữ liệu
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            // Thiết lập báo cáo
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "D:\\Learn\\Donet\\đồ án\\đồ án\\RptBCNHangrdlc.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "dsNhapHang";
                rds.Value = ds.Tables[0];
                // Gán lên mẫu bc
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("THÔNG BÁO", "BẠN MUỐN ĐÓNG FORM?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // đóng form
                this.Close();
            }
            else
            {
                //xử lí khác
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();
            tc.ShowDialog();
        }
    }
}
