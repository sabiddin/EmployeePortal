using EmployeePortal.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeePortal.DAL
{
    public class EmployeeDAL
    {
        public static bool AddEmployee(Employee employee)
        {
            bool success = false;
            using (SqlConnection conn = new SqlConnection(@"Password=sa123;Persist Security Info=True;User ID=sa;Initial Catalog=EmployeePortal;Data Source=VSI-P51-003\SYED"))
            {
                try
                {
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = "sp_Employee";
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Mode", 1);
                    comm.Parameters.AddWithValue("@ID", employee.ID);
                    comm.Parameters.AddWithValue("@Username", employee.Username);
                    comm.Parameters.AddWithValue("@Gender", employee.GenderID);
                    comm.Parameters.AddWithValue("@Phone", employee.Phone);
                    comm.Parameters.AddWithValue("@Email", employee.Email);
                    comm.Parameters.AddWithValue("@DOB", employee.DOB);
                    comm.Parameters.AddWithValue("@Address", employee.Address);
                    comm.Parameters.AddWithValue("@Document", employee.DocumentID);
                    comm.Parameters.AddWithValue("@SSC", employee.SSC);
                    comm.Parameters.AddWithValue("@Inter", employee.Inter);
                    comm.Parameters.AddWithValue("@Degree", employee.Degree);

                    conn.Open();
                    object i = comm.ExecuteNonQuery();
                    if (i != null)
                    {
                        success = true;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
            return success;
        }
        public static bool UpdateEmployee(Employee employee)
        {
            bool success = false;
            using (SqlConnection conn = new SqlConnection(@"Password=sa123;Persist Security Info=True;User ID=sa;Initial Catalog=EmployeePortal;Data Source=VSI-P51-003\SYED"))
            {
                try
                {
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = "sp_Employee";
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Mode", 2);
                    comm.Parameters.AddWithValue("@ID", employee.ID);
                    comm.Parameters.AddWithValue("@Username", employee.Username);
                    comm.Parameters.AddWithValue("@Gender", employee.GenderID);
                    comm.Parameters.AddWithValue("@Phone", employee.Phone);
                    comm.Parameters.AddWithValue("@Email", employee.Email);
                    comm.Parameters.AddWithValue("@DOB", employee.DOB);
                    comm.Parameters.AddWithValue("@Address", employee.Address);
                    comm.Parameters.AddWithValue("@Document", employee.DocumentID);
                    comm.Parameters.AddWithValue("@SSC", employee.SSC);
                    comm.Parameters.AddWithValue("@Inter", employee.Inter);
                    comm.Parameters.AddWithValue("@Degree", employee.Degree);

                    conn.Open();
                    object i = comm.ExecuteNonQuery();
                    if (i != null)
                    {
                        success = true;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return success;
        }
        public static bool DeleteEmployee(int ID)
        {
            bool success = false;
            using (SqlConnection conn = new SqlConnection(@"Password=sa123;Persist Security Info=True;User ID=sa;Initial Catalog=EmployeePortal;Data Source=VSI-P51-003\SYED"))
            {
                try
                {
                    SqlCommand comm = conn.CreateCommand();                    
                    comm.CommandText = "sp_Employee";
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Mode", 3);
                    comm.Parameters.AddWithValue("@ID", ID);
                    comm.Parameters.AddWithValue("@Username", DBNull.Value);
                    comm.Parameters.AddWithValue("@Gender", DBNull.Value);
                    comm.Parameters.AddWithValue("@Phone", DBNull.Value);
                    comm.Parameters.AddWithValue("@Email", DBNull.Value);
                    comm.Parameters.AddWithValue("@DOB", DBNull.Value);
                    comm.Parameters.AddWithValue("@Address", DBNull.Value);
                    comm.Parameters.AddWithValue("@Document", DBNull.Value);
                    comm.Parameters.AddWithValue("@SSC", DBNull.Value);
                    comm.Parameters.AddWithValue("@Inter", DBNull.Value);
                    comm.Parameters.AddWithValue("@Degree", DBNull.Value);
                    conn.Open();
                    object i = comm.ExecuteNonQuery();
                    if (i != null)
                    {
                        success = true;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
            return success;
        }

        public static List<DropDownOption> GetGenders()
        {
            List<DropDownOption> genders = new List<DropDownOption>();
            DataSet dataSet = new DataSet();
            using (SqlConnection conn = new SqlConnection(@"Password=sa123;Persist Security Info=True;User ID=sa;Initial Catalog=EmployeePortal;Data Source=VSI-P51-003\SYED"))
            {
                try
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Code, Value FROM tbl_Gender", conn);
                    sqlDataAdapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (dataSet != null && dataSet.Tables[0] != null)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        DropDownOption gender = new DropDownOption
                        {
                            Code = Convert.ToInt32(row["Code"].ToString()),
                            Value = row["Value"].ToString()
                        };
                        genders.Add(gender);
                    }
                }
            }
            return genders;
        }
        public static List<DropDownOption> GetDocuments()
        {
            List<DropDownOption> documents = new List<DropDownOption>();
            DataSet dataSet = new DataSet();
            using (SqlConnection conn = new SqlConnection(@"Password=sa123;Persist Security Info=True;User ID=sa;Initial Catalog=EmployeePortal;Data Source=VSI-P51-003\SYED"))
            {
                try
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Code, Value FROM tbl_Document", conn);
                    sqlDataAdapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (dataSet != null && dataSet.Tables[0] != null)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        DropDownOption document = new DropDownOption
                        {
                            Code = Convert.ToInt32(row["Code"].ToString()),
                            Value = row["Value"].ToString()
                        };
                        documents.Add(document);
                    }
                }
            }
            return documents;
        }
        public static List<Employee> GetEmployees(int? ID)
        {
            List<Employee> employees = new List<Employee>();
            DataSet dataSet = new DataSet();
            using (SqlConnection conn = new SqlConnection(@"Password=sa123;Persist Security Info=True;User ID=sa;Initial Catalog=EmployeePortal;Data Source=VSI-P51-003\SYED"))
            {
                
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                command.CommandText = "sp_EmployeeGet";
                if(!ID.HasValue)
                    command.Parameters.AddWithValue("@ID", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ID", ID);
                sqlDataAdapter.SelectCommand = command;
                try
                {                                                                           
                    sqlDataAdapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (dataSet != null && dataSet.Tables[0] != null)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        Employee employee = new Employee();
                        employee.ID = Convert.ToInt32(row["ID"].ToString());
                        employee.Address = row["Address"].ToString();
                        employee.SSC = Convert.ToBoolean(row["SSC"]);
                        employee.Inter = Convert.ToBoolean(row["Inter"]);
                        employee.Degree = Convert.ToBoolean(row["Degree"]);
                        employee.DOB = Convert.ToDateTime(row["DOB"]);
                        employee.DocumentDesc = row["DocumentDesc"].ToString();
                        employee.DocumentID = Convert.ToInt32(row["DocumentID"].ToString());
                        employee.Email = row["Email"].ToString();
                        employee.GenderDesc = row["GenderDesc"].ToString();
                        employee.GenderID = Convert.ToInt32(row["GenderID"].ToString());
                        employee.Phone = row["Phone"].ToString();
                        employee.Username = row["Username"].ToString();
                        if (employee.SSC)
                        {
                            employee.Education += " SSC";
                        }
                        if (employee.Inter)
                        {
                            employee.Education += " Inter";
                        }
                        if (employee.Degree)
                        {
                            employee.Education += " Degree";
                        }
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }
    }
}