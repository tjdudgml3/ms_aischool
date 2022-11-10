using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Collections;
/*
 CREATE TABLE dbo.VIPmembers{
    member_id int IDENTITY(1,1),
    member_name VARCHAR(200) not NULL,
    member_email VARCHAR(100),
    member_phone VARCHAR(25),
    regi_date smalldatetime DEFAULT=GETDATE()
PRIMARY KEY(MEMEBER_ID)
}
 
 */

namespace SQLServer01
{
    

    public partial class frmMain : Form
    {
        private const string CONNECTIONSTRING = "Server=tcp:labuser71sqlserver.database.windows.net,1433;Initial Catalog=labuser71sql;Persist Security Info=False;User ID=tjdudgml3;Password=tjdudgml123!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection Sqlcon = null;
        private SqlCommand SqlCmd = null;
        private SqlDataAdapter SqlApt = new SqlDataAdapter();

        private DataSet dataMain = new DataSet();

        public frmMain()
        {
            InitializeComponent();
        }

        private void bntConnect_Click(object sender, EventArgs e)
        {
            Sqlcon = new SqlConnection(CONNECTIONSTRING);
            bntConnect.Enabled= false;
        }

        private void bntGetData_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM production.brands WHERE brand_id > @id";
            SqlCommand cmd = Sqlcon.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = -1;

            SqlApt.SelectCommand=cmd;
            SqlApt.Fill(dataMain);

            DataRowCollection dataRows = dataMain.Tables[0].Rows;
            lstbrands.Items.Clear();
            //lstbrands.Items.Add((dataMain.Tables[0].Columns[0].ColumnName, dataMain.Tables[0].Columns[1].ColumnName));
            //lstbrands.Items.Add(dataMain.Tables[0]);
            for (int i = 0; i < dataRows.Count; i++)
            {
                //lstbrands.Items.Add((dataRows[i][0].ToString(),dataRows[i][1].ToString()));
                lstbrands.Items.Add(dataRows[i][1].ToString());
            }
            //fill to datagrid
            /*DataSet dataProducts = new DataSet();
            query = "SELECT * FROM production.products";
            cmd.CommandText= query;
            SqlApt.Fill(dataProducts);
            grdGridVew.DataSource= dataProducts.Tables[0];
            */
            bntGetData.Enabled= false;
        }

        private void lstbrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstbrands.SelectedIndex == -1)
            {
                MessageBox.Show("test");
                return;
            }


            //fill to datagrid
            int selectedIndex = lstbrands.SelectedIndex;
            int selectedBrandID = Int32.Parse(dataMain.Tables[0].Rows[selectedIndex][0].ToString());
            //MessageBox.Show(selectedBrandID.ToString());


            DataSet dataProducts = new DataSet();
            string query = "SELECT * FROM production.products WHERE brand_id = @brand_id";

            SqlCommand cmd = Sqlcon.CreateCommand();
            cmd.Parameters.Add(new SqlParameter("@brand_id", selectedBrandID));
            cmd.CommandText = query;
            SqlApt.SelectCommand = cmd;
            SqlApt.Fill(dataProducts);
            grdGridVew.DataSource = dataProducts.Tables[0];

        }

        private void bntVIP_Click(object sender, EventArgs e)
        {
            frmVIP vip = new frmVIP();
                vip.ShowDialog();
        }
    }
}
