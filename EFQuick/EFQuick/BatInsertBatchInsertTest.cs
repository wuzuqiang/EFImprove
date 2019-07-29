using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace EFQuick
{
    public class BatchInsertTest
    {
        static readonly string StrConnMsg = System.Configuration.ConfigurationManager.ConnectionStrings["CodeFirstApp"].ToString();
        static readonly long totalRow = 1000000;
        static readonly int getRow = 1000;
        public static void Main1(string[] args)
        {
            InsertOne();
            InsertTwo();
            InsertThree();
            InsertFour();
            Console.WriteLine("插入数据结束");
            Console.ReadLine();
        }
        #region 方式一
        static void InsertOne()
        {
            Console.WriteLine("采用一条一条插入的方式实现");
            Stopwatch sw = new Stopwatch();

            using (SqlConnection conn = new SqlConnection(StrConnMsg)) //using中会自动Open和Close 连接。
            {
                string sql = "INSERT INTO Products(Id,Name,Price) VALUES(newid(),@p,@d)";
                conn.Open();
                for (int i = 0; i < totalRow; i++)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@p", "商品" + i);
                        cmd.Parameters.AddWithValue("@d", i);
                        sw.Start();
                        cmd.ExecuteNonQuery();
                        //Console.WriteLine(string.Format("插入一条记录，已耗时{0}毫秒", sw.ElapsedMilliseconds));
                    }
                    if (i == getRow)
                    {
                        sw.Stop();
                        break;
                    }
                }
            }
            Console.WriteLine(string.Format("插入{0}条记录，每{4}条的插入时间是{1}毫秒,预估总得插入时间是{2}毫秒，{3}分钟", totalRow, sw.ElapsedMilliseconds
                , ((sw.ElapsedMilliseconds / getRow) * totalRow), GetMinute((sw.ElapsedMilliseconds / getRow * totalRow)), getRow));
        }
        static int GetMinute(long l)
        {
            return (Int32)l / 60000;
        }
        #endregion
        #region 方式二
        static void InsertTwo()
        {
            Console.WriteLine("使用Bulk插入的实现方式");
            Stopwatch sw = new Stopwatch();
            DataTable dt = GetTableSchema();

            using (SqlConnection conn = new SqlConnection(StrConnMsg))
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(conn);
                bulkCopy.DestinationTableName = "Products";
                bulkCopy.BatchSize = dt.Rows.Count;
                conn.Open();
                sw.Start();

                for (int i = 0; i < totalRow; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = Guid.NewGuid();
                    dr[1] = string.Format("商品", i);
                    dr[2] = (decimal)i;
                    dt.Rows.Add(dr);
                }
                if (dt != null && dt.Rows.Count != 0)
                {
                    bulkCopy.WriteToServer(dt);
                    sw.Stop();
                }
                Console.WriteLine(string.Format("插入{0}条记录共花费{1}毫秒，{2}分钟", totalRow, sw.ElapsedMilliseconds, GetMinute(sw.ElapsedMilliseconds)));
            }
        }
        static DataTable GetTableSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("Id",typeof(Guid)),
                new DataColumn("Name",typeof(string)),
                new DataColumn("Price",typeof(decimal))});
            return dt;
        }
        #endregion
        #region 方式三
        static void InsertThree()
        {
            Console.WriteLine("使用TVPs插入的实现方式");
            Stopwatch sw = new Stopwatch();
            DataTable dt = GetTableSchema();

            using (SqlConnection conn = new SqlConnection(StrConnMsg))
            {
                string sql = "INSERT INTO Products(Id,Name,Price) select Id,Name,Price from @TempTb";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlParameter catParam = cmd.Parameters.AddWithValue("@TempTb", dt);
                    catParam.SqlDbType = SqlDbType.Structured;
                    catParam.TypeName = "dbo.ProductTemp";
                    conn.Open();
                    sw.Start();

                    for (int i = 0; i < totalRow; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = Guid.NewGuid();
                        dr[1] = string.Format("商品", i);
                        dr[2] = (decimal)i;
                        dt.Rows.Add(dr);
                    }

                    if (dt != null && dt.Rows.Count != 0)
                    {
                        cmd.ExecuteNonQuery();
                        sw.Stop();
                    }
                    Console.WriteLine(string.Format("TVPs插入{0}条记录共花费{1}毫秒，{2}分钟", totalRow, sw.ElapsedMilliseconds, GetMinute(sw.ElapsedMilliseconds)));
                }
            }
        }
        #endregion
        #region 方式四
        static void InsertFour()
        {
            Console.WriteLine("采用拼接批量SQL插入的方式实现");
            Stopwatch sw = new Stopwatch();

            using (SqlConnection conn = new SqlConnection(StrConnMsg)) //using中会自动Open和Close 连接。
            {
                conn.Open();
                sw.Start();
                for (int j = 0; j < totalRow / getRow; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO Products(Id,Name,Price) VALUES");
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        for (int i = 0; i < getRow; i++)
                        {
                            sb.AppendFormat("(newid(),'商品{0}',{0}),", j * i + i);
                        }
                        cmd.Connection = conn;
                        cmd.CommandText = sb.ToString().TrimEnd(',');
                        cmd.ExecuteNonQuery();
                    }
                }
                sw.Stop();
                Console.WriteLine(string.Format("插入{0}条记录，共耗时{1}毫秒，{1}分钟", totalRow, sw.ElapsedMilliseconds, GetMinute(sw.ElapsedMilliseconds)));
            }
        }
        #endregion
    }
    /**
     * create database CarSYS;    
go    
use CarSYS;    
go 
CREATE TABLE Products(
Id UNIQUEIDENTIFIER PRIMARY KEY,
NAME VARCHAR(50) NOT NULL,
Price DECIMAL(18,2) NOT NULL
)
     * */
}
