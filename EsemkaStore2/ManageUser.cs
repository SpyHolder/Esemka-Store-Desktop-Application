using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaStore2
{
    public partial class ManageUser : Form
    {
        connection connec = new connection();

        string strPathImage,Permission,email,Name;
        string oldImage, fileName;
        SqlTransaction trans;
        string ServerPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
        public ManageUser()
        {
            InitializeComponent();
        }

        void Show()
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Email,Name,DoB AS 'Date of Birth',Gender,Address,Role,PathPhoto FROM Users", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                dgv_Users.DataSource = table;
                dgv_Users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void FirstShow()
        {
            dgv_Users.Enabled = true;
            txt_Email.Text = "";
            txt_Email.Enabled = true;
            txt_Name.Text = "";
            rb_Female.Checked = false;
            rb_Male.Checked = false;
            txt_Address.Text = "";
            dtp_Birthday.Text = "";
            txt_Password.Text = "";
            pb_PathPhoto.Image = null;
            txt_Role.Text = "";
            btn_Save.Enabled = false;
            txt_Search.Text = "";
            btn_Cancel.Enabled = false;
            btn_Add.Enabled = true;
            btn_Edit.Enabled = true;
            btn_Remove.Enabled = true;
            btn_Choose.Enabled = true;
        }
        void AfterAction()
        {
            txt_Email.Enabled = false;
            rb_Female.Checked = false;
            rb_Male.Checked = false;
            txt_Name.Text = "";
            txt_Address.Text = "";
            dtp_Birthday.Text = "";
            txt_Password.Text = "";
            pb_PathPhoto.Image = null;
            txt_Role.Text = "";
            txt_Search.Text = "";
            btn_Add.Enabled = false;
            btn_Edit.Enabled = false;
            btn_Remove.Enabled = false;
            btn_Choose.Enabled = false;
            btn_Save.Enabled = true;
            btn_Cancel.Enabled = true;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Choose_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Select image(*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";
                openFileDialog1.Title = "Select Images";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pb_PathPhoto.Image = Image.FromFile(openFileDialog1.FileName);
                    strPathImage = Path.GetFullPath(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
            Show();
            FirstShow();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Permission == "INSERT")
                {
                    File.Copy(openFileDialog1.FileName, ServerPath + "\\Images\\Users\\" + fileName);
                    trans.Commit();
                    MessageBox.Show("Data berhasil di simpan");
                    Permission = "";
                    Show();
                    FirstShow();
                    strPathImage = null;
                }
                else if (Permission == "DELETE")
                {
                    if (DialogResult.Yes == MessageBox.Show("Yakin mau menghapus-nya?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (oldImage != "NULL")
                        {
                            File.Delete(ServerPath + oldImage);
                            trans.Commit();
                            MessageBox.Show("Data berhasil di hapus");
                            Permission = "";
                            Show();
                            FirstShow();
                        }
                        else
                        {
                            trans.Commit();
                            MessageBox.Show("Data berhasil di hapus");
                            Permission = "";
                            Show();
                            FirstShow();
                        }
                    }
                }
                else if (Permission == "UPDATE")
                {
                    if (DialogResult.Yes == MessageBox.Show("Apakah kamu mau mengedit-nya?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if(strPathImage != null)
                        {
                            File.Delete(ServerPath + oldImage);
                            File.Copy(openFileDialog1.FileName, ServerPath + "\\Images\\Users\\" + fileName);
                            trans.Commit();
                            MessageBox.Show("Data berhasil di ubah");
                            Permission = "";
                            Show();
                            FirstShow();
                        }
                        else
                        {
                            trans.Commit();
                            MessageBox.Show("Data berhasil di ubah");
                            Permission = "";
                            Show();
                            FirstShow();
                        }
                       
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
                trans.Rollback();
                Show();
                FirstShow();
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
                if (!txt_Email.Text.Equals(""))
                {
                    dgv_Users.Enabled = false;
                    SqlConnection con = connec.GetConnection();
                    con.Open();
                    trans = con.BeginTransaction();
                    SqlCommand com = new SqlCommand("SELECT * FROM Users WHERE Email = '" + email + "'", con, trans);
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    adapter.Fill(table);
                    oldImage = table.Rows[0][6].ToString();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE Email = '" + txt_Email.Text + "'", con, trans);
                    cmd.ExecuteNonQuery();
                    Permission = "DELETE";
                    AfterAction();
                }
                else
                {
                    MessageBox.Show("Silahkan pilih data yang mau dihapus");
                }
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
                SqlCommand cmd = new SqlCommand("SELECT Email,Name,DoB AS 'Date of Birth',Gender,Address,Role FROM Users WHERE Email LIKE '%" +
                    txt_Search.Text + "%' OR Name LIKE '%" +
                    txt_Search.Text + "%' OR DoB LIKE '%" +
                    txt_Search.Text + "%' OR Gender LIKE '%" +
                    txt_Search.Text + "%' OR Address LIKE '%" +
                    txt_Search.Text + "%' OR Role LIKE '%" +
                    txt_Search.Text + "%'", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                dgv_Users.DataSource = table;
                dgv_Users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgv_Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgv_Users.Rows[e.RowIndex];
                txt_Email.Text = row.Cells["Email"].Value.ToString();
                txt_Name.Text = row.Cells["Name"].Value.ToString();
                dtp_Birthday.Text = row.Cells["Date of Birth"].Value.ToString();
                string gender = row.Cells["Gender"].Value.ToString();
                if(gender == "L")
                {
                    rb_Male.Checked = true;
                }
                else if(gender == "P")
                {
                    rb_Female.Checked = true;
                }
                txt_Address.Text = row.Cells["Address"].Value.ToString();
                email = row.Cells["Email"].Value.ToString();
    

                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PathPhoto,Role FROM Users WHERE Email = '" + email + "'", con);
                DataTable tb = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tb);
                txt_Role.Text = tb.Rows[0][1].ToString();
                if (tb.Rows[0][0].ToString() != "NULL")
                {
                    pb_PathPhoto.Image = Image.FromFile(ServerPath + tb.Rows[0][0].ToString());
                    Name = tb.Rows[0][0].ToString();
                }
                else
                {
                    pb_PathPhoto.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = null;
                if (rb_Male.Checked) { gender = "L"; }
                else if (rb_Female.Checked) { gender = "P"; }

                if (txt_Email.Text.Equals("") || txt_Name.Text.Equals("") || txt_Address.Text.Equals("") || txt_Role.Text.Equals("") || gender == null)
                {
                    MessageBox.Show("Silahkan Lengkapi Data");
                }
                else
                {
                    dgv_Users.Enabled = false;
                    SqlConnection con = connec.GetConnection();
                    con.Open();
                    trans = con.BeginTransaction();

                    SHA256 sha256 = SHA256Managed.Create();
                    byte[] hashValue;
                    UTF8Encoding objutf8 = new UTF8Encoding();
                    hashValue = sha256.ComputeHash(objutf8.GetBytes(txt_Password.Text));
                    string encrypt = Convert.ToBase64String(hashValue);

                    if (strPathImage != null)
                    {
                        fileName = Path.GetFileName(openFileDialog1.FileName);
                        string QueryPath = "\\Images\\Users\\" + fileName;
                        SqlCommand cmd;
                        if (txt_Password != null)
                        {
                            cmd = new SqlCommand("UPDATE Users SET Email = '" +
                                txt_Email.Text + "', Name = '" +
                                txt_Name.Text + "', DoB = '" +
                                dtp_Birthday.Text + "', Gender = '" +
                                gender + "', Address = '" +
                                txt_Address.Text + "', Password = '" +
                                encrypt + "', PathPhoto = '" +
                                QueryPath + "' WHERE Email = '" +
                                email + "'", con, trans);
                        }
                        else
                        {
                            cmd = new SqlCommand("UPDATE Users SET Email = '" +
                               txt_Email.Text + "', Name = '" +
                               txt_Name.Text + "', DoB = '" +
                               dtp_Birthday.Text + "', Gender = '" +
                               gender + "', Address = '" +
                               txt_Address.Text + "', PathPhoto = '" +
                               QueryPath + "' WHERE Email = '" +
                               email + "'", con, trans);
                        }
                        cmd.ExecuteNonQuery();
                        SqlCommand com = new SqlCommand("SELECT * FROM Users WHERE Email = '" + email + "'", con, trans);
                        DataTable table = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(com);
                        adapter.Fill(table);

                        oldImage = table.Rows[0][6].ToString();
                        Permission = "UPDATE";
                        AfterAction();
                    }
                    else
                    {
                        SqlCommand command;
                        if (txt_Password.Text != null)
                        {
                            command = new SqlCommand("UPDATE Users SET Email = '" +
                                txt_Email.Text + "', Name = '" +
                                txt_Name.Text + "', DoB = '" +
                                dtp_Birthday.Text + "', Gender = '" +
                                gender + "', Address = '" +
                                txt_Address.Text + "', Password = '" +
                                encrypt + "' WHERE Email = '" +
                                email + "'", con, trans);
                        }
                        else
                        {
                            command = new SqlCommand("UPDATE Users SET Email = '" +
                                txt_Email.Text + "', Name = '" +
                                txt_Name.Text + "', DoB = '" +
                                dtp_Birthday.Text + "', Gender = '" +
                                gender + "', Address = '" +
                                txt_Address.Text + "' WHERE Email = '" +
                                email + "'", con, trans);
                        }
                        command.ExecuteNonQuery();
                        Permission = "UPDATE";
                        AfterAction();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = null;
                if (rb_Male.Checked) { gender = "L"; }
                else if (rb_Female.Checked) { gender = "P"; }

                if (txt_Email.Text.Equals("") || txt_Name.Text.Equals("") || txt_Address.Text.Equals("") || txt_Password.Text.Equals("") || txt_Role.Text.Equals("") || gender == null)
                {
                    MessageBox.Show("Silahkan Lengkapi Data");
                }
                else
                {
                    SqlConnection con = connec.GetConnection();
                    con.Open();
                    trans = con.BeginTransaction();

                    SHA256 sha256 = SHA256Managed.Create();
                    byte[] hashValue;
                    UTF8Encoding objutf8 = new UTF8Encoding();
                    hashValue = sha256.ComputeHash(objutf8.GetBytes(txt_Password.Text));
                    string encrypt = Convert.ToBase64String(hashValue);

                    if (strPathImage == null)
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO Users (Email,Name,DoB,Gender,Address,Password,PathPhoto,Role) VALUES ('" +
                            txt_Email.Text + "','" +
                            txt_Name.Text + "','" +
                            dtp_Birthday.Text + "','" + gender + "','" +
                            txt_Address.Text + "','" +
                            encrypt + "','NULL','"+ 
                            txt_Role.Text + "')", con, trans);
                        cmd.ExecuteNonQuery();
                        Permission = "INSERT";
                        AfterAction();
                    }
                    else
                    {
                        fileName = Path.GetFileName(openFileDialog1.FileName);
                        string QueryPath = "\\Images\\Users\\" + fileName;
                        SqlCommand com = new SqlCommand("INSERT INTO Users (Email,Name,DoB,Gender,Address,Password,PathPhoto,Role) VALUES ('" +
                            txt_Email.Text + "','" +
                            txt_Name.Text + "','" +
                            dtp_Birthday.Text + "','" + gender + "','" +
                            txt_Address.Text + "','" +
                            encrypt + "','" +
                            QueryPath + "','" +
                            txt_Role.Text + "')", con, trans);
                        com.ExecuteNonQuery();
                        Permission = "INSERT";
                        AfterAction();
                    }
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
