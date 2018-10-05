using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadDBF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string constr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\DBF;Extended Properties=dBASE IV;User ID=Admin;Password=;";
            string fileName = "KK_02676.DBF";
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                var sql = "select * from " + fileName;
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet(); 
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                dgvResult.DataSource = ds.Tables[0];
            }
            
        }
    }
}
