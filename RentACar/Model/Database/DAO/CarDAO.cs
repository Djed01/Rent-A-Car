using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model.Database.DAO
{
    internal class CarDAO : IGenericDAO<Car>
    {
        private static readonly string SELECT_ALL = @"SELECT * FROM `car`";
        public CarDAO() { }


        public List<Car> GetAll()
        {
            List<Car> result = new List<Car>();
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
                    result.Add(new Car()
                    {
                        ChassisNumber = reader.GetString(0),
                        Brand = reader.GetString(1),
                        Model = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        PricePerDay = reader.GetDouble(4),
                        Engine = reader.GetString(5),
                        Image = reader.GetString(6),
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
