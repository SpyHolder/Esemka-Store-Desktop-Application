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
using System.IO;

namespace EsemkaStore2
{
    public partial class ManageProduct : Form
    {
        connection connec = new connection();

        string strPath,Permission,id,oldPath;
        SqlTransaction tr;
        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

        void FirstClear()
        {
            txt_ID.Text = "";
            txt_Name.Text = "";
            txt_Description.Text = "";
            txt_Price.Text = "";
            txt_Stock.Text = "";
            txt_Search.Text = "";
            txt_ID.Enabled = true;
            btn_Add.Enabled = true;
            btn_Edit.Enabled = true;
            btn_Remove.Enabled = true;
            pb_PhotoPath.Image = null;
            btn_Save.Enabled = false;
            btn_Cancel.Enabled = false;
        }
        void Show()
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT Id as 'ID',Name,Description,Price,Stock FROM Products WHERE DeleteAt IS NULL", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                dgv_Product.DataSource = table;
                dgv_Product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void AfterButton()
        {
            txt_Name.Text = "";
            txt_Description.Text = "";
            txt_Price.Text = "";
            txt_Stock.Text = "";
            pb_PhotoPath.Image = null;
            txt_ID.Enabled = false;
            btn_Add.Enabled = false;
            btn_Edit.Enabled = false;
            btn_Remove.Enabled = false;
            btn_Save.Enabled = true;
            btn_Cancel.Enabled = true;
        }

        public ManageProduct()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            Show();
            FirstClear();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Choose_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = "C://Picture";
                openFileDialog1.Title = "Select Image";
                openFileDialog1.Filter = "Select image(*.jpg;*.png;*.jpeg;*.gif)|*.jpg;*.png;*.jpeg;*.gif";
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pb_PhotoPath.Image = Image.FromFile(openFileDialog1.FileName);
                    strPath = Path.GetFullPath(openFileDialog1.FileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_ID.Text.Equals("") || txt_Name.Text.Equals("") || txt_Description.Text.Equals("") || txt_Price.Text.Equals("") || txt_Stock.Text.Equals(""))
                {
                    MessageBox.Show("Data masih kosong");
                }
                else
                {
                    SqlConnection con = connec.GetConnection();
                    con.Open();
                    tr = con.BeginTransaction();
                    if (strPath == null)
                    {
                        SqlCommand com = new SqlCommand("INSERT INTO Products (Id,Name,Description,Price,Stock,CreateAt,PhotoPath) VALUES ('" + txt_ID.Text + "','" +
                            txt_Name.Text + "','" +
                            txt_Description.Text + "','" +
                            txt_Price.Text + "','" + txt_Stock.Text + "','"+ DateTime.Now.ToString("d") + "', 'NULL')", con, tr);
                        com.ExecuteNonQuery();
                        AfterButton();
                        Permission = "INPUT";
                    }
                    else
                    {
                        string fileName = Path.GetFileName(openFileDialog1.FileName);
                        string SQLpath = "\\Images\\" + fileName;

                        SqlCommand cmd = new SqlCommand("INSERT INTO Products (Id,Name,Description,Price,Stock,CreateAt,PhotoPath) VALUES ('" + txt_ID.Text + "','" +
                            txt_Name.Text + "','" +
                            txt_Description.Text + "','" +
                            txt_Price.Text + "','" + txt_Stock.Text + "','"+ DateTime.Now.ToString("d") + "','" + SQLpath + "')", con, tr);
                        File.Copy(openFileDialog1.FileName, path + "\\Images\\" + fileName);
                        cmd.ExecuteNonQuery(); 
                        AfterButton();
                        Permission = "INPUT";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Permission == "INPUT")
                {
                        tr.Commit();
                        MessageBox.Show("Data berhasil di simpan");
                        Permission = "";
                        Show();
                        FirstClear();
                }
                else if (Permission == "DELETE")
                {
                    if(DialogResult.Yes == MessageBox.Show("Yakin mau menghapus-nya?","Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        tr.Commit();
                        MessageBox.Show("Data berhasil di hapus");
                        Permission = "";
                        Show();
                        FirstClear();
                    }
                }
                else if(Permission == "UPDATE")
                {
                    if (DialogResult.Yes == MessageBox.Show("Apakah kamu mau mengedit-nya?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        tr.Commit();
                        MessageBox.Show("Data berhasil di ubah");
                        Permission = "";
                        Show();
                        FirstClear();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                tr.Rollback();
                Show();
                FirstClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Cancel_Click_1(object sender, EventArgs e)
        {
            try
            {
                tr.Rollback();
                Show();
                FirstClear();
            }
            catch (Exception ex)
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
                SqlCommand cmd = new SqlCommand("SELECT Id as 'ID',Name,Description,Price,Stock FROM products WHERE DeleteAt IS NULL AND Id IN (SELECT Id FROM Products WHERE Id LIKE '%" + txt_Search.Text + "%' OR Name LIKE '%" + txt_Search.Text + "%' OR Description LIKE '%" + txt_Search.Text + "%' OR Price LIKE '%" + txt_Search.Text + "%' OR Stock LIKE '%" + txt_Search.Text + "%')", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                dgv_Product.DataSource = table;
                dgv_Product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
           catch (Exception ex)
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
                tr = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand("UPDATE Products SET DeleteAt = '" + DateTime.Now.ToString("d") + "' WHERE Id = '" + txt_ID.Text + "'", con, tr);
                cmd.ExecuteNonQuery();
                AfterButton();
                Permission = "DELETE";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgv_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgv_Product.Rows[e.RowIndex];
                txt_ID.Text = row.Cells["ID"].Value.ToString();
                txt_Name.Text = row.Cells["Name"].Value.ToString();
                txt_Description.Text = row.Cells["Description"].Value.ToString();
                txt_Price.Text = row.Cells["Price"].Value.ToString();
                txt_Stock.Text = row.Cells["Stock"].Value.ToString();
                id = row.Cells["ID"].Value.ToString();

                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PhotoPath FROM Products WHERE Id = '" + id + "'", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                
                oldPath = path + table.Rows[0][0].ToString();
                if (table.Rows[0][0].ToString() != "NULL")
                {
                    pb_PhotoPath.Image = Image.FromFile(oldPath);
                }
                else
                {
                    pb_PhotoPath.Image = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_ID.Text.Equals("") || txt_Name.Text.Equals("") || txt_Description.Text.Equals("") || txt_Price.Text.Equals("") || txt_Stock.Text.Equals(""))
                {
                    MessageBox.Show("Silahkan Lengkapi Data");
                }
                else
                {
                    SqlConnection con = connec.GetConnection();
                    con.Open();
                    tr = con.BeginTransaction();
                    if (strPath == null)
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Products SET Id = '" +
                            txt_ID.Text + "', Name = '" +
                            txt_Name.Text + "', Description = '" +
                            txt_Description.Text + "', Price = '" +
                            txt_Price.Text + "', Stock = '" +
                            txt_Stock.Text + "' WHERE Id = '" + id + "'", con, tr);
                        cmd.ExecuteNonQuery();
                        AfterButton();
                        Permission = "UPDATE";
                    }
                    else
                    {
                        string fileName = Path.GetFileName(openFileDialog1.FileName);
                        string SQLpath = "\\Images\\" + fileName;

                        SqlCommand com = new SqlCommand("UPDATE Products SET Id = '" + txt_ID.Text + "', Name = '" +
                            txt_Name.Text + "', Description = '" +
                            txt_Description.Text + "', Price = '" +
                            txt_Price.Text + "', Stock = '" +
                            txt_Stock.Text + "', PhotoPath = '" +
                            SQLpath + "' WHERE Id = '" + id + "'", con, tr);
                        com.ExecuteNonQuery();

                        SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE Id = '" + id + "'", con, tr);
                        DataTable tb = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(tb);

                        string imagePath = tb.Rows[0][5].ToString();

                        File.Delete(path + imagePath);
                        File.Copy(openFileDialog1.FileName, path + "\\Images\\" + fileName);

                        AfterButton();
                        Permission = "UPDATE";
                    } 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
