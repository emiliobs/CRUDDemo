using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDDemo07122019.Models
{
    public  class EmployeeDAL
    {
        string connectionString = "Data Source=.;Initial Catalog=CRUDDemo07122019;Integrated Security=True";


        //Gel All
        public IEnumerable<Employee> GetAllEmployee()
        {

            List<Employee> employeeList = new List<Employee>();

            using (var db = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("SP_GetAllEmployee", db);
                cmd.CommandType = CommandType.StoredProcedure;

                db.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while(sqlDataReader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.Name = sqlDataReader["Name"].ToString();
                    employee.Gender = sqlDataReader["Gender"].ToString();
                    employee.Company = sqlDataReader["Company"].ToString();
                    employee.Department = sqlDataReader["Department"].ToString();

                    employeeList.Add(employee);
                }

                db.Close();
            }

            return employeeList;
        }

        //To Insert Employee
        public void AddEmployee(Employee employee)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("SP_InsertEmployee",db);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Company", employee.Company);
                cmd.Parameters.AddWithValue("@Department", employee.Department);

                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        // To Update Employee
        public void UpdateEmployee(Employee employee)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("SP_UpdateEmployee", db);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Company", employee.Company);
                cmd.Parameters.AddWithValue("@Department", employee.Department);

                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        //To Delete Employee
         public void DeleteEmployee(int? id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("Sp_DeleteEmployee", db);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        //Get Employye By ID
        public Employee GetEmployeeById(int id)
        {

            var employee = new Employee();

            using (var db = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("Sp_GetEmployeebyId", db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",id);

                db.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.Name = sqlDataReader["Name"].ToString();
                    employee.Gender = sqlDataReader["Gender"].ToString();
                    employee.Company = sqlDataReader["Company"].ToString();
                    employee.Department = sqlDataReader["Department"].ToString();

                }
                db.Close();
            }

            return employee;
        }

    }
}
