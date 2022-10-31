using System.Data.Common;
using System.Data;
using Snowflake.Data.Client;
using OData.Demo.Data.Entities;

namespace OData.Demo.Data
{
    public class SnowflakeConnector
    {
        public static List<Gadgets> SnowflakeGetData() {
            Boolean testStatus = true;
            List<Gadgets> GadgetsList = new List<Gadgets>();

            try
            {

                using (IDbConnection conn = new SnowflakeDbConnection())
                {
                    conn.ConnectionString = "account=ib65413.central-india.azure;user=SUJAY; password=Sujay@9860;ROLE=ACCOUNTADMIN; db =TEST_SNOWFLAKE;";
                    conn.Open();
                    Console.WriteLine("Connection successful!");
                    using (IDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "USE WAREHOUSE my_wh";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "select * from Gadgets";   // sql opertion fetching 
                        //data from an existing table
                        IDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Gadgets gadgets = new();
                            gadgets.ProductName = reader.GetString(1);
                            gadgets.Cost = Convert.ToInt32(reader.GetString(3));
                            gadgets.Brand = reader.GetString(2);
                            gadgets.Id = Convert.ToInt32(reader.GetString(0));
                            Console.WriteLine(reader.GetString(0));
                            Console.WriteLine(reader.GetString(1));
                            Console.WriteLine(reader.GetString(2));
                            Console.WriteLine(reader.GetString(3));
                            Console.WriteLine(reader.GetString(4));
                            Console.WriteLine(reader.GetString(5));
                            Console.WriteLine(reader.GetString(6));
                            Console.WriteLine(reader.GetString(7));
                            GadgetsList.Add(gadgets);
                        }
                        conn.Close();
                    }
                }
            }
            catch (DbException exc)
            {
                Console.WriteLine("Error Message: {0}", exc.Message);
                testStatus = false;
            }
            return GadgetsList;

        }
    }
}
