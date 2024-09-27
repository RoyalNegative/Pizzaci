using PizzaciPractice.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Serialization;

namespace PizzaciPractice
{
    public partial class Form1 : Form
    {
        private string username;
        private string password; 


        private EmployeeManager bireyManager; 
        public Form1()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '*';
            this.bireyManager = new EmployeeManager();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "" || tbPassword.Text == "") 
            {
                MessageBox.Show("Doldurup tekrar deneyin");
                return; 
            }
            else
            {
                this.username = tbUsername.Text;
                this.password = tbPassword.Text;

                foreach (Employee birey in bireyManager.GetBireys())
                {
                    if (birey.Username == this.username && birey.Password == this.password)
                    {
                        MessageBox.Show("Giris Basarili");

                        if (username == "admin" && password == "admin")
                        {
                            AdminNavigation adminNavigation = new AdminNavigation(birey, this);
                            this.Hide();
                            adminNavigation.Show();
                            return;
                        }
                        else
                        {
                            //Normal Employee Girisi
                        }
                    }
                }
                MessageBox.Show("Basarisiz kullanici adi veya parola.");
                tbUsername.Text = "";
                tbPassword.Text = "";
            }
        }

        private void cbxParolayiSakla_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxParolayiSakla.Checked)
            {
                tbPassword.PasswordChar = '*';
            }
            else
            {
                tbPassword.PasswordChar = '\0';
            }
        }

        
    }
}
