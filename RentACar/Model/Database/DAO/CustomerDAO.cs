using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RentACar.Model.Database.DAO
{
    class CustomerDAO : IGenericDAO<Customer>
    {
        private static readonly string SELECT_ALL = @"SELECT * FROM `customer`";
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
                        DateOfBirth = reader.GetString(6),
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
    }

}

