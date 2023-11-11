using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RentACar.Model.Database.DAO
{
    class CustomerDAO : IGenericDAO<Customer>
    {
        private static readonly string SELECT_ALL = @"SELECT * FROM `customer`";
        private static readonly string INSERT = @"INSERT INTO `customer`(Name, Surname,Email,Phone,ID_Number,Date_Of_Birth,Gender) VALUES (@Name, @Surname,@Email,@Phone,@ID_Number,@Date_Of_Birth,@Gender)";
        private static readonly string DELETE = "DELETE FROM `customer` WHERE idCUSTOMER=@idCUSTOMER";
        private static readonly string UPDATE = @"UPDATE `customer` SET Name=@Name, Surname=@Surname,Email=@Email,Phone=@Phone,ID_Number=@ID_Number,Date_Of_Birth=@Date_Of_Birth,Gender=@Gender WHERE idCustomer=@idCustomer";

        public CustomerDAO() { }



        public List<Customer> GetAll()
        {
            List<Customer> result = new List<Customer>();
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
                    result.Add(new Customer()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone = reader.GetString(4),
                        IdNumber = reader.GetString(5),
                        DateOfBirth = reader.GetDateTime(6).ToString("yyyy-MM-dd"),
                        Gender = reader.GetString(7),
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


        public int Add(Customer customer)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Surname", customer.Surname);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@ID_Number", customer.IdNumber);
                cmd.Parameters.AddWithValue("@Date_Of_Birth", customer.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", customer.Gender);
                cmd.ExecuteNonQuery();
                customer.ID = (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            finally
            {
                Util.CloseQuietly(conn);
            }
            return customer.ID;
        }


        public void Delete(int id)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@idCUSTOMER", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (MainWindow.currentLanguage == 1)
                {
                    MessageBox.Show("Unable to delete customer because of existing rents!", "Info");
                }
                else
                {
                    MessageBox.Show("Клијент посједује записе о изнајмљивању немогуће обрисати!", "Информација");
                }
            }
            finally
            {
                Util.CloseQuietly(conn);
            }
        }

        public void Update(int id, Customer customer)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@idCUSTOMER", id);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Surname", customer.Surname);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Date_Of_Birth", customer.DateOfBirth);
                cmd.Parameters.AddWithValue("@ID_Number", customer.IdNumber);
                cmd.Parameters.AddWithValue("@Gender", customer.Gender);
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

