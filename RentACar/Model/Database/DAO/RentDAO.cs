using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model.Database.DAO
{
    class RentDAO : IGenericDAO<RentInfo>
    {
        private static readonly string SELECT_ALL = @"SELECT
            R.idRent,
            C.Name,
            C.Surname,
            C.ID_Number,
            CA.Brand,
            CA.Model,
            R.Pick_Up,
            R.Return,
            R.Total_Price
        FROM `rent` AS R
        JOIN `customer` AS C ON R.CUSTOMER_idCustomer = C.idCUSTOMER
        JOIN `car` AS CA ON R.CAR_ChassisNumber = CA.ChassisNumber;";


        public RentDAO() { }



        public List<RentInfo> GetAll()
        {
            List<RentInfo> result = new List<RentInfo>();
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
                    result.Add(new RentInfo()
                    {
                        idRent = reader.GetInt32(0),
                        name = reader.GetString(1),
                        surname = reader.GetString(2),
                        idNumber = reader.GetString(3),
                        brand = reader.GetString(4),
                        model = reader.GetString(5),
                        pickUp = reader.GetString(6),
                        returnDate = reader.GetString(7),
                        totalPrice = reader.GetDouble(8)
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
