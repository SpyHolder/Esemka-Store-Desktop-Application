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
    public partial class MenuUtama : Form
    {
        string userEmail;
        public MenuUtama()
        {
            InitializeComponent();
        }

        public MenuUtama(string Email) : this()
        {
            userEmail = Email;
        }

        private void btn_Manage_Product_Click(object sender, EventArgs e)
        {
            ManageProduct MP = new ManageProduct();
            MP.Show();
        }

        private void btn_Manage_User_Click(object sender, EventArgs e)
        {
            ManageUser MU = new ManageUser();
            MU.Show();
        }

        private void btn_Add_Transaction_Click(object sender, EventArgs e)
        {
            AddTransaction MU = new AddTransaction(userEmail);
            MU.Show();
        }

        private void btn_View_Transaction_Click(object sender, EventArgs e)
        {
            ViewTransaction VT = new ViewTransaction();
            VT.Show();
        }

        private void MenuUtama_Load(object sender, EventArgs e)
        {
            
        }
    }
}
