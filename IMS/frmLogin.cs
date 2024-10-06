using IMS.data.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace IMS
{
    public partial class frm_login : Form
    {

        public frm_login()
        {
            InitializeComponent();
        }

      
        private async Task Login(string username, string password)
        {
            try
            {
                // Basic validation
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    bunifuSnackbar1.Show(this, "Please Provide username or Password", BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                bool isLogin = await Users.LoginAsync(username, password);
                if (isLogin)
                {
                    this.Hide();
                    frm_home frm_Home = new frm_home();
                    frm_Home.Show();
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Invalid Login", BunifuSnackbar.MessageTypes.Warning);
                }
            }
            catch (Exception ex)
            {
                bunifuSnackbar1.Show(this,ex.Message, BunifuSnackbar.MessageTypes.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text; // Assuming you have a txtUsername TextBox
            string password = textBox2.Text; // Assuming you have a txtPassword TextBox
            await Login(username, password);
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            // Any additional initialization can go here
        }

        private async void frm_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = textBox1.Text; // Assuming you have a txtUsername TextBox
                string password = textBox2.Text; // Assuming you have a txtPassword TextBox
                await Login(username, password);
            }
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = textBox1.Text; // Assuming you have a txtUsername TextBox
                string password = textBox2.Text; // Assuming you have a txtPassword TextBox
                await Login(username, password);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private async void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = textBox1.Text; // Assuming you have a txtUsername TextBox
                string password = textBox2.Text; // Assuming you have a txtPassword TextBox
                await Login(username, password);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
