using CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Context
{
    public class EfPerformanceContext:DbContext
	{
		public static Common.Logging.ILog Log1 = Common.Logging.LogManager.GetLogger(typeof(EfPerformanceContext));

		public EfPerformanceContext()
            :base("name=CodeFirstApp")
		{
			this.Database.CommandTimeout = 600;
			this.Database.Log = sql =>
			{
				if(!string.IsNullOrEmpty(sql))
				{
					//将处理过的sql写入日志
					Log1.Info($"^_^^_^********sql：" + sql.ToString());
				}
			};
		}
        public DbSet<Product> Products { get; set; }
		public DbSet<OriginalOrder> OriginalOrders { get; set; }
	}
}
