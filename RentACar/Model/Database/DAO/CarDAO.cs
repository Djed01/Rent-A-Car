using Microsoft.VisualBasic;
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
        private static readonly string INSERT = @"INSERT INTO `car`(ChassisNumber, Brand,Model,Year,PricePerDay,Engine,Image) VALUES (@ChassisNumber, @Brand,@Model,@Year,@PricePerDay,@Engine,@Image)";
        private static readonly string UPDATE = @"UPDATE `car` SET Brand=@Brand,Model=@Model,Year=@Year,PricePerDay=@PricePerDay,Engine=@Engine WHERE ChassisNumber=@ChassisNumber";
        private static readonly string DELETE = "DELETE FROM `car` WHERE ChassisNumber=@ChassisNumber";
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

        public void Add(Car car)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@ChassisNumber", car.ChassisNumber);
                cmd.Parameters.AddWithValue("@Brand", car.Brand);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@PricePerDay", car.PricePerDay);
                cmd.Parameters.AddWithValue("@Engine", car.Engine);
                cmd.Parameters.AddWithValue("@Image", car.Image);
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

        public void Update(Car car)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@ChassisNumber", car.ChassisNumber);
                cmd.Parameters.AddWithValue("@Brand", car.Brand);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@PricePerDay", car.PricePerDay);
                cmd.Parameters.AddWithValue("@Engine", car.Engine);
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

        public void Delete(String chassisNumber)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@ChassisNumber", chassisNumber);
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

    }
}
