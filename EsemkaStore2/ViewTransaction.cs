using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaStore2
{
    public partial class ViewTransaction : Form
    {
        connection connec = new connection();
        public ViewTransaction()
        {
            InitializeComponent();
        }

        void Show()
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Code,UserEmail,CreateAt FROM TransactionHeaders", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                dgv_Users.DataSource = table;
                dgv_Users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ViewTransaction_Load(object sender, EventArgs e)
        {
            Show();
        }

        private void btb_Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgv_Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgv_Users.Rows[e.RowIndex];
                string Email = row.Cells["UserEmail"].Value.ToString();
                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand com = new SqlCommand("SELECT Name,Quantity FROM TransactionDetails JOIN Products ON TransactionDetails.ProductId = Products.Id WHERE " +
                    "TransactionDetails.Headerld = (SELECT Id FROM TransactionHeaders WHERE UserEmail = '" + Email + "')", con);
                DataTable tb = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(com);
                adp.Fill(tb);
                dgv_ProductTransactionDetail.DataSource = tb;
                dgv_ProductTransactionDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
