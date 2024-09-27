using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K4os.Compression.LZ4.Encoders;
using MySql.Data.MySqlClient;
using PizzaciPractice.Class;





namespace PizzaciPractice.DAL
{
    public class EmployeeDBManager
    {
        string DatabaseConnectionString = DBConnection.ConnectionString;

        public EmployeeDBManager()
        {

        }


        #region CRUD Employees

        public bool AddEmployee(Employee employee)
        {
            using (var connection = new MySqlConnection(DatabaseConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO employees (Name, Surname, Username, Password, Email, Age) VALUES (@name, @surname, @username, @password, @email, @age)", connection))
                {
                    command.Parameters.AddWithValue("@name", employee.Name);
                    command.Parameters.AddWithValue("@surname", employee.Surname);
                    command.Parameters.AddWithValue("@username", employee.Username);
                    command.Parameters.AddWithValue("@password", employee.Password);
                    command.Parameters.AddWithValue("@email", employee.Email);
                    command.Parameters.AddWithValue("@age", employee.Age);

                    int RowsAffected = command.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var connection = new MySqlConnection(DatabaseConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Employees", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
                            employee.Id = reader.GetInt32("id");
                            employee.Name = reader.GetString("name");
                            employee.Surname = reader.GetString("surname");
                            employee.Username = reader.GetString("username");
                            employee.Password = reader.GetString("password");
                            employee.Email = reader.GetString("email");
                            employee.Age = reader.GetInt32("age");


                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();

            using (var connection = new MySqlConnection(DatabaseConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM employees WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employee.Id = reader.GetInt32("id");
                            employee.Name = reader.GetString("name");
                            employee.Surname = reader.GetString("surname");
                            employee.Username = reader.GetString("username");
                            employee.Password = reader.GetString("password");
                            employee.Email = reader.GetString("email");
                            employee.Age = reader.GetInt32("age");
                        }
                    }
                }
            }

            return employee;
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (var connection = new MySqlConnection(DatabaseConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE employees SET Name = @name, Surname = @surname, Username = @username, Password = @password, Email = @email, Age = @age WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", employee.Id);
                    command.Parameters.AddWithValue("@name", employee.Name);
                    command.Parameters.AddWithValue("@surname", employee.Surname);
                    command.Parameters.AddWithValue("@username", employee.Username);
                    command.Parameters.AddWithValue("@password", employee.Password);
                    command.Parameters.AddWithValue("@email", employee.Email);
                    command.Parameters.AddWithValue("@age", employee.Age);
                    
                    int RowsAffected = command.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        return true; 
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
        }


        public bool DeleteEmployee(int id)
        {
            using (var connection = new MySqlConnection(DatabaseConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM employees WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int RowsAffected = command.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        #endregion
    }
}
