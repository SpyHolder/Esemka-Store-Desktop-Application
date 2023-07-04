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
using System.Xml.Linq;

namespace EsemkaStore2
{
    public partial class AddTransaction : Form
    {

        connection connec = new connection();
        string idProduct,idCart,quantity,userEmail;
        int subtotal;
        public AddTransaction(string Email) : this()
        {
            userEmail = Email;
        }

        public AddTransaction()
        {
            InitializeComponent();
        }

        private void btb_Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        void FirstShow()
        {
            txt_ValueProduck.Text = "0";
            txt_ValueCart.Text = "0";
            lbl_DateTime.Text = DateTime.Now.ToLongTimeString() + ", " + DateTime.Now.ToLongDateString();
        }
        void Show()
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name,Price,Stock FROM Products WHERE DeleteAt IS NULL", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                dgv_Produck.DataSource = table;
                dgv_Produck.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                SqlCommand com = new SqlCommand("SELECT Name,Quantity,Price,Quantity * Price AS 'Subtotal' FROM TransactionDetails JOIN Products ON TransactionDetails.ProductId = Products.Id WHERE TransactionDetails.Headerld IS NULL", con);
                DataTable tb = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(com);
                adp.Fill(tb);
                dgv_TransactionDetail.DataSource = tb;
                dgv_TransactionDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                /*dgv_TransactionDetail.Rows.Add(
                    tb.Rows[0][0].ToString(),
                    tb.Rows[0][1].ToString(),
                    tb.Rows[0][2].ToString(),
                    tb.Rows[0][3].ToString());*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void AddTransaction_Load(object sender, EventArgs e)
        {
            Show();
            FirstShow();
        }

        private void btn_MinProduck_Click(object sender, EventArgs e)
        {
            try
            {
                int valueCRT = Int32.Parse(txt_ValueProduck.Text) - 1;
                if (valueCRT < 0)
                {
                    txt_ValueProduck.Text = "0";
                }
                else
                {
                    txt_ValueProduck.Text = valueCRT.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_PlusProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int valueCRT = Int32.Parse(txt_ValueProduck.Text) + 1;
                txt_ValueProduck.Text = valueCRT.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_MinCart_Click(object sender, EventArgs e)
        {
            try
            {
                int valuePRD = Int32.Parse(txt_ValueCart.Text) - 1;
                if (valuePRD < 0)
                {
                    txt_ValueCart.Text = "0";
                }
                else
                {
                    txt_ValueCart.Text = valuePRD.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_PlusCart_Click(object sender, EventArgs e)
        {
            try
            {
                int valuePRD = Int32.Parse(txt_ValueCart.Text) + 1;
                txt_ValueCart.Text = valuePRD.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_DateTime.Text = DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btn_AddtoCart_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand cod = new SqlCommand("SELECT * FROM TransactionDetails WHERE ProductId = '"+idProduct+ "' AND TransactionDetails.Headerld IS NULL", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cod);
                adapter.Fill(table);
                SqlCommand cmd;
                if(table.Rows.Count > 0)
                {
                    cmd = new SqlCommand("UPDATE TransactionDetails SET Quantity = Quantity + '"+txt_ValueProduck.Text+"' WHERE ProductId = '"+idProduct+"'", con);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO TransactionDetails (ProductId,Quantity) VALUES ('" + idProduct + "','" + txt_ValueProduck.Text + "')", con);
                }
                cmd.ExecuteNonQuery();
                SqlCommand com = new SqlCommand("UPDATE Products SET Stock = Stock - '" + txt_ValueProduck.Text + "' WHERE Id = '" + idProduct + "'", con);
                com.ExecuteNonQuery();
                MessageBox.Show("Berhasil");
                Show();
                FirstShow();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgv_Produck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                DataGridViewRow row = this.dgv_Produck.Rows[e.RowIndex];
                string name = row.Cells["Name"].Value.ToString();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE Name = '" + name + "'", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);

                idProduct = table.Rows[0][0].ToString(); ;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgv_TransactionDetail_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(Quantity * Price) AS 'total' FROM TransactionDetails JOIN Products ON TransactionDetails.ProductId = Products.Id", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                lbl_Harga.Text = table.Rows[0][0].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand com = new SqlCommand("UPDATE TransactionHeaders SET Total = Total + '"+lbl_Harga.Text+"',CreateAt = '"+DateTime.Now.ToString("d")+"'", con);
                com.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("SELECT Id FROM TransactionHeaders WHERE UserEmail = '" + userEmail + "'", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                string HeaderId = table.Rows[0][0].ToString();
                SqlCommand comm = new SqlCommand("UPDATE TransactionDetails SET TransactionDetails.Headerld = '"+HeaderId+"' WHERE TransactionDetails.Headerld IS NULL;", con);
                comm.ExecuteNonQuery();
                MessageBox.Show("Berhasil Save");
                Show();
                FirstShow();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name,Price,Stock FROM Products WHERE DeleteAt IS NULL AND Name LIKE '%" + txt_Search.Text + "%' OR Price LIKE '%" + txt_Search.Text + "%' OR Stock LIKE '%" + txt_Search.Text + "%'", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                dgv_Produck.DataSource = table;
                dgv_Produck.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE TransactionDetails SET Quantity = Quantity - '" + txt_ValueCart.Text + "' WHERE Id = '" + idCart + "'", con);
                cmd.ExecuteNonQuery();
                SqlCommand cod = new SqlCommand("SELECT * FROM TransactionDetails WHERE id = '" + idCart + "'", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cod);
                adapter.Fill(table);
                if (Int32.Parse(table.Rows[0][2].ToString()) == 0)
                {
                    SqlCommand dlt = new SqlCommand("DELETE FROM TransactionDetails WHERE Id = '" + idCart + "'", con);
                    dlt.ExecuteNonQuery();
                }
                SqlCommand updtPRD = new SqlCommand("UPDATE Products SET Stock = Stock + '" + txt_ValueCart.Text + "' WHERE Id = '" + idProduct + "'", con);
                updtPRD.ExecuteNonQuery();
                Show();
                FirstShow();
                MessageBox.Show("Berhasil Again");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgv_TransactionDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                DataGridViewRow row = this.dgv_TransactionDetail.Rows[e.RowIndex];
                quantity = row.Cells[1].Value.ToString();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TransactionDetails WHERE Quantity = '" + quantity + "'", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                idProduct = table.Rows[0][1].ToString();
                idCart = table.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
