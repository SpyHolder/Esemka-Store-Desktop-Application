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
using System.Security.Cryptography;

namespace EsemkaStore2
{
    public partial class Login : Form
    {
        connection connec = new connection();
        string mail;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = connec.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = '" + txt_Email.Text + "'", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    SHA256 sha256 = SHA256Managed.Create();
                    byte[] hashValue;
                    UTF8Encoding objutf8 = new UTF8Encoding();
                    hashValue = sha256.ComputeHash(objutf8.GetBytes(txt_Password.Text));
                    string encrypt = Convert.ToBase64String(hashValue);

                    SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Password = '" + encrypt + "'", con);
                    DataTable tb = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(tb);
                    if (tb.Rows.Count > 0)
                    {
                        foreach (DataRow row in tb.Rows)
                        {
                            /*if (row["Role"].ToString() == "1")
                            {
                                MenuUtama MU = new MenuUtama();
                                MU.Show();
                                this.Hide();
                            }
                            else if (row["Role"].ToString() == "2")
                            {
                                MenuUtama MU = new MenuUtama();
                                MU.Show();
                                this.Hide();
                            }*/
                            mail = tb.Rows[0][0].ToString();
                            MenuUtama MU = new MenuUtama(mail);
                            MU.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password salah");
                    }
                }
                else
                {
                    MessageBox.Show("Email salah");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
