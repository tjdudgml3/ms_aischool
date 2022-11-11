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
    public partial class frmInsert : Form
    {
        private string CONNECTIONSTRING;
        private SqlConnection Sqlcon = null;
        private SqlCommand SqlCmd = null;
        private frmVIP frm_vip_members;
        public frmInsert(frmVIP vipmembers)
        {
            InitializeComponent();
            frm_vip_members = vipmembers;
        }

        private void bntInsert_Click(object sender, EventArgs e)
        {
            if (textName.Text.Trim().Length ==0)
            {
                MessageBox.Show("Please input VIP name",":ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

            }
            else
            {
                CONNECTIONSTRING = ConfigurationManager.AppSettings["connection_string"];
                string query = "INSERT INTO dbo.VIPmembers(member_name, member_email, member_phone) VALUES(@name,@email,@phone)";
                DataSet dataInsert = new DataSet();
                Sqlcon = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = Sqlcon.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@name",SqlDbType.VarChar, 200)).Value = textName.Text;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 25)).Value = textEmail.Text;
                cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.VarChar, 100)).Value = textPhone.Text;
                Sqlcon.Open();
                cmd.ExecuteNonQuery();
                Sqlcon.Close();


                frm_vip_members.ReloadData();
                    
            }


        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            if(textName.Text.Trim().Length !=0)
            {
                var buttonResult =  MessageBox.Show("you are closing without saving. are you sure to quit?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(buttonResult== DialogResult.No) {
                    return;
                }
            }
            this.Close();

        }
    }
}
