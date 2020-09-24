using PlayingWithSql.LoadCsv.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithSql.LoadCsv
{
    public class PopulateDb
    {
        // https://stackoverflow.com/questions/12939501/insert-into-c-sharp-with-sqlcommand Example of insert
        // 

        public async Task PopulateDbWithData(IEnumerable<SampleData> sampleDatas)
        {
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=SqlLearning;Integrated Security=True";
            string sql = @"
                        insert into dbo.sample_data ([country], [order_date], [ship_date], [total_revenue], [total_profit])
                        VALUES
                        (@country, @order_date, @ship_date, @total_revenue, @total_profit)
                        ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                foreach (SampleData sampleData in sampleDatas)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = sampleData.Country;
                        cmd.Parameters.Add("@order_date", SqlDbType.DateTime).Value = sampleData.OrderDate;
                        cmd.Parameters.Add("@ship_date", SqlDbType.DateTime).Value = sampleData.ShipDate;
                        cmd.Parameters.Add("@total_revenue", SqlDbType.Float).Value = sampleData.TotalRevenue;
                        cmd.Parameters.Add("@total_profit", SqlDbType.VarChar).Value = sampleData.TotalProfit;

                        cmd.CommandType = CommandType.Text;
                        await cmd.ExecuteNonQueryAsync();
                    }
                }


            }
        }
    }
}
