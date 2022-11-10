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

namespace SQLServer01
{
    public partial class frmVIP : Form
    {
        private const string CONNECTIONSTRING = "Server=tcp:labuser71sqlserver.database.windows.net,1433;Initial Catalog=labuser71sql;Persist Security Info=False;User ID=tjdudgml3;Password=tjdudgml123!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection Sqlcon = null;
        private SqlCommand SqlCmd = null;
        private SqlDataAdapter SqlApt = new SqlDataAdapter();

        private DataSet dataMain = new DataSet();
        public frmVIP()
        {
            InitializeComponent();
            

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
    }
}
