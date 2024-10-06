using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public partial class frm_home : Form
    {
        string n2 = "";
        public frm_home()
        {
            InitializeComponent();
        }
        private void nav(string n)
        {
            // Check if the form is already in the pnl_body
          

            this.pnl_body.Controls.Clear(); // Clear only if the form does not exist
            Form newForm = null; // Declare a variable to hold the new form

            switch (n) {
                case "inventory":
                     newForm = new frm_inventory();
                    break;

                case "cat":
                    newForm = new frm_cat();
                    break;

                case "plist":
                    newForm = new frm_product();
                    break;

                case "user":
                    newForm = new frm_userM();
                    break;
            }

            if (newForm != null)
            {
               
                    newForm.TopLevel = false;
                    newForm.FormBorderStyle = FormBorderStyle.None; // Optional to remove border
                 //   newForm.Dock = DockStyle.Fill; // Make sure the new form fills the panel

                    this.pnl_body.Controls.Add(newForm);
                    newForm.Show();
                

            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_inventory_Click(object sender, EventArgs e)
        {
            nav("inventory");
            n2 = "inventory";
        }

        private void frm_home_Resize(object sender, EventArgs e)
        {
        }

        private void frm_home_ResizeBegin(object sender, EventArgs e)
        {
            
        }

        private void btn_categories_Click(object sender, EventArgs e)
        {
            nav("cat");
            n2 = "cat";
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            nav("plist");
            n2 = "plist";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void aaa1_Load(object sender, EventArgs e)
        {

        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {

        }

        private void btn_usermanagement_Click(object sender, EventArgs e)
        {
            nav("user");
            n2 = "user";
        }
    }
}
