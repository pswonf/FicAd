using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FicAd
{
    public partial class Form1 : Form
    {
        Pswonf.Comm.SqlDbManager oSqlDbManager = new Pswonf.Comm.SqlDbManager();

        public Form1()
        {
            InitializeComponent();

            FicAd.ServiceReference1.WebServiceSoapClient uwinWs = new ServiceReference1.WebServiceSoapClient();

            oSqlDbManager.ConnectionString = "Data Source=localhost;Initial Catalog=sh;User ID=sa;Password=white2014;Connect Timeout=1200";


            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Enabled = false;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                DataSet ds = new DataSet();

                ds = uwinWs.GetData("A34003", "sanhag", "uwindb1.부속기관_산학협동관_창업보육센타_호실별업체정보_조회", "20150803");

                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                this.dataGridView1.Enabled = true;
                Cursor.Current = Cursors.Default;
            }

            //this.webBrowser1.DocumentText = "</td></tr>< tr ><tr><td width = \"48\" align=\"center\" class=\"header6 header40\" style=\"width:48px;\">Cat.</td><td align = \"center\"></td></tr>";

            this.dataGridView1.Columns.Clear();

            //System.Data.SqlClient.SqlParameter[] sqlParams = new System.Data.SqlClient.SqlParameter[2];

            try
            {
                DataSet ds = new DataSet();
                ds = oSqlDbManager.GetDatasetExecuteProcedure("[dbo].[산학지원팀_공통_층별안내도]");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB 개체 검색", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
