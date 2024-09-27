using PizzaciPractice.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaciPractice.Class
{
    public class EmployeeManager
    {

        private EmployeeDBManager EmployeeDBManager;
        private List<Employee> bireys;


        public EmployeeManager()
        {
            bireys = new List<Employee>();
            EmployeeDBManager = new EmployeeDBManager();
            this.bireys = EmployeeDBManager.GetEmployees();
        }

        #region CRUD Operations

        public bool AddBirey(Employee birey)
        {
            if (EmployeeDBManager.AddEmployee(birey))
            {
                return true; 
            }
            else { return false; }
        }


        public List<Employee> GetBireys()
        {
            return bireys;
        }

        public Employee GetBirey(int id)
        {
            Employee employee = EmployeeDBManager.GetEmployeeById(id);
            return employee;
        }


       

        public bool UpdateBirey(int id, Employee birey)
        {
            if (EmployeeDBManager.UpdateEmployee(birey))
            {
                UpdateList();
                return true;
            }
            else
            {
                return false; 
            }

            
        }

        private void UpdateList()
        {
            this.bireys = EmployeeDBManager.GetEmployees();
        }

        public bool DeleteBirey(int id)
        {
            if (EmployeeDBManager.DeleteEmployee(id))
            {
                return true;
            }
            else { return false; }
        }

        #endregion



    }
}
