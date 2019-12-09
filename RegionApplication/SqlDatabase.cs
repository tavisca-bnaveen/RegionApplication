using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace RegionApplication
{
    public class SqlDatabase : IDatabase
    {
        private MySqlConnection _mySqlConnection;
        private MySqlCommand _mySqlCommand;
        private string _connection= "SERVER = 127.0.0.1; PORT = 3306; DATABASE = oncalltracking; USER Id = root; PASSWORD = Bora@025";
        public SqlDatabase()
        {
            _mySqlConnection = new MySqlConnection(_connection);
        }
        public void RegionintoDatabase(Region region)
        {

            _mySqlCommand = _mySqlConnection.CreateCommand();

            _mySqlCommand.CommandType = CommandType.StoredProcedure;
            _mySqlCommand.CommandText = "spRegion";
            _mySqlCommand.Parameters.AddWithValue("@RegionID", region.RegionID);
            _mySqlCommand.Parameters.AddWithValue("@RegionName", region.RegionName);
            _mySqlCommand.Parameters.AddWithValue("@RegionNameLong", region.RegionNameLong);
            _mySqlCommand.Parameters.AddWithValue("@Latitude", region.Latitude);
            _mySqlCommand.Parameters.AddWithValue("@Longitude", region.Longitude);
            _mySqlCommand.Parameters.AddWithValue("@SubClassification", region.SubClassification);

            try
            {
                _mySqlConnection.Open();
                _mySqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                
            }
            finally
            {
                _mySqlConnection.Close();
            }

        }
    }
}
