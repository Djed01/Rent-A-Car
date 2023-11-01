using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model.Database.DAO
{
    class EmployeeDAO : IGenericDAO<Employee>
    {
        private static readonly string SELECT_ALL = @"SELECT User.idUser, User.Name, User.Surname, User.Email, User.Phone, User.Address, User.City, User.PostCode, User.Username, User.Password
                                                    FROM Employee
                                                    INNER JOIN User ON Employee.USER_idUser = User.idUser
                                                    LEFT JOIN deactivated ON Employee.USER_idUser = deactivated.EMPLOYEE_USER_idUSER
                                                    WHERE deactivated.EMPLOYEE_USER_idUSER IS NULL;
";
        private static readonly string INSERT = "InsertNewEmployee";
        private static readonly string DEACTIVATE = "INSERT INTO Deactivated (EMPLOYEE_USER_idUSER, Date, ADMIN_USER_idUSER) VALUES (@EMPLOYEE_USER_idUSER, CURDATE(), @ADMIN_USER_idUSER);";
        private static readonly string UPDATE = @"UPDATE `customer` SET Name=@Name, Surname=@Surname,Email=@Email,Phone=@Phone,ID_Number=@ID_Number,Date_Of_Birth=@Date_Of_Birth,Gender=@Gender WHERE idCustomer=@idCustomer";
        private static readonly string SELECT_DEACTIVATED = @"SELECT User.idUser, User.Name, User.Surname, User.Email, User.Phone, User.Address, User.City, User.PostCode, User.Username, User.Password
                                                            FROM deactivated
                                                            INNER JOIN Employee ON deactivated.EMPLOYEE_USER_idUSER = Employee.USER_idUSER
                                                            INNER JOIN User ON Employee.USER_idUser = User.idUser;";

        private static readonly string ACTIVATE = @"DELETE FROM `deactivated` WHERE EMPLOYEE_USER_idUSER=@EMPLOYEE_USER_idUSER";

        public EmployeeDAO() { }



        public List<Employee> GetAll()
        {
            List<Employee> result = new List<Employee>();
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_ALL;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Employee()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone = reader.GetString(4),
                        Address = reader.GetString(5),
                        City = reader.GetString(6),
                        PostCode = reader.GetString(7),
                        Username = reader.GetString(8),
                        Password = reader.GetString(9),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greska", ex);
            }
            finally
            {
                Util.CloseQuietly(reader, conn);
            }
            return result;
        }

        public List<Employee> GetDeactivated()
        {
            List<Employee> result = new List<Employee>();
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_DEACTIVATED;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Employee()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone = reader.GetString(4),
                        Address = reader.GetString(5),
                        City = reader.GetString(6),
                        PostCode = reader.GetString(7),
                        Username = reader.GetString(8),
                        Password = reader.GetString(9),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greska", ex);
            }
            finally
            {
                Util.CloseQuietly(reader, conn);
            }
            return result;
        }


        public int Add(Employee employee)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@p_Name", employee.Name);
                cmd.Parameters["@p_Name"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@p_Surname", employee.Surname);
                cmd.Parameters["@p_Surname"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@p_Email", employee.Email);
                cmd.Parameters["@p_Email"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@p_Phone", employee.Phone);
                cmd.Parameters["@p_Phone"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@p_Address", employee.Address);
                cmd.Parameters["@p_Address"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@p_City", employee.City);
                cmd.Parameters["@p_City"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@p_PostCode", employee.PostCode);
                cmd.Parameters["@p_PostCode"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@p_Username", employee.Username);
                cmd.Parameters["@p_Username"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@p_Password", employee.Password);
                cmd.Parameters["@p_Password"].Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            finally
            {
                Util.CloseQuietly(conn);
            }
        }


           public void Deactivate(int id, int adminID)
           {
               MySqlConnection conn = null;
               MySqlCommand cmd;
               try
               {
                   conn = Util.GetConnection();
                   cmd = conn.CreateCommand();
                   cmd.CommandText = DEACTIVATE;
                   cmd.Parameters.AddWithValue("@EMPLOYEE_USER_idUSER", id);
                   cmd.Parameters.AddWithValue("@ADMIN_USER_idUSER", adminID);
                   cmd.ExecuteNonQuery();
               }
               catch (Exception ex)
               {
                   throw new Exception("Greska", ex);
               }
               finally
               {
                   Util.CloseQuietly(conn);
               }
           }


        public void Activate(int id)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = ACTIVATE;
                cmd.Parameters.AddWithValue("@EMPLOYEE_USER_idUSER", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Greska", ex);
            }
            finally
            {
                Util.CloseQuietly(conn);
            }
        }


        public void Update(Employee employee)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;

            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEmployee"; // Name of the stored procedure

                // Parameters for the stored procedure
                cmd.Parameters.AddWithValue("@p_EmployeeID", employee.ID);
                cmd.Parameters["@p_EmployeeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Name", employee.Name);
                cmd.Parameters["@p_Name"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Surname", employee.Surname);
                cmd.Parameters["@p_Surname"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Email", employee.Email);
                cmd.Parameters["@p_Email"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone", employee.Phone);
                cmd.Parameters["@p_Phone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Address", employee.Address);
                cmd.Parameters["@p_Address"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_City", employee.City);
                cmd.Parameters["@p_City"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PostCode", employee.PostCode);
                cmd.Parameters["@p_PostCode"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Username", employee.Username);
                cmd.Parameters["@p_Username"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Password", employee.Password);
                cmd.Parameters["@p_Password"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            finally
            {
                Util.CloseQuietly(conn);
            }
        }

    }
}
