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

namespace PizzaciPractice
{
    public partial class EmployeeManagerPg : Form
    {

        AdminNavigation adminNavigation;
        EmployeeManager employeeManager;
        private List<Employee> employees;
        public EmployeeManagerPg(AdminNavigation adminNavigation)
        {
            InitializeComponent();
            this.adminNavigation = adminNavigation;
            this.employeeManager = new EmployeeManager();
            employees = employeeManager.GetBireys();
            UpdateTable();
        }


        private void UpdateTable()
        {
            dataGridView1.DataSource = null; 

            dataGridView1.DataSource = employees;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.adminNavigation.Show();
            this.Close();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Bir isim girmedin.");
            }
            else
            {
                Employee emp = new Employee();
                foreach (Employee birey in employeeManager.GetBireys())
                {
                    if (birey.Name == tbName.Text)
                    {
                        emp = birey;
                        break;
                    }
                }

                if (emp.Name is null)
                {
                    MessageBox.Show("Isim bulunamadi.");
                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = new List<Employee> { emp };
                    tbName.Text = "";   
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
