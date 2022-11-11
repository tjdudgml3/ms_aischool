using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLServer01
{
    public partial class frmVIP : Form
    {
        private string CONNECTIONSTRING = ConfigurationManager.AppSettings["connection_string"]; 
        private SqlConnection Sqlcon = null;
        private SqlCommand SqlCmd = null;
        private SqlDataAdapter SqlApt = new SqlDataAdapter();

        private DataSet dataMain = new DataSet();
        public frmVIP()
        {
            InitializeComponent();
            ReloadData();



        }

        private void bntExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVIP_Load(object sender, EventArgs e)
        {
            
            /*Sqlcon = new SqlConnection(CONNECTIONSTRING);
            DataSet dataProducts = new DataSet();
            string query = "SELECT * FROM dbo.VIPmembers";

            SqlCommand cmd = Sqlcon.CreateCommand();
            //cmd.Parameters.Add(new SqlParameter("@brand_id", selectedBrandID));
            cmd.CommandText = query;
            SqlApt.SelectCommand = cmd;
            SqlApt.Fill(dataProducts);
            gridMemberLsit.DataSource = dataProducts.Tables[0];*/
        }

        public void ReloadData()
        {
            dataMain.Clear();
            Sqlcon = new SqlConnection(CONNECTIONSTRING);
            DataSet dataVIP = new DataSet();
            string query = "SELECT * FROM dbo.VIPmembers";

            SqlCommand cmd = Sqlcon.CreateCommand();
            //cmd.Parameters.Add(new SqlParameter("@brand_id", selectedBrandID));
            cmd.CommandText = query;
            SqlApt.SelectCommand = cmd;
            SqlApt.Fill(dataVIP);
            gridMemberLsit.DataSource = dataVIP.Tables[0];
        }

        private void bntInsert_Click(object sender, EventArgs e)
        {
            frmInsert frmInsert= new frmInsert(this);
            
            frmInsert.ShowDialog();

        }
    }
}
