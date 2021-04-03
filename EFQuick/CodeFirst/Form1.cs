using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeFirst.Context;
using CodeFirst.Model;

namespace CodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {	
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new EfPerformanceContext())
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                #region BulkInsert
                #region
                context.Configuration.AutoDetectChangesEnabled = false;
                List<Product> products = new List<Product>();
                for (int i = 0; i < 10000; i++)
                {
                    Product product = new Product();
                    product.Id = System.Guid.NewGuid();
                    product.Name = "Name" + i;
                    product.Price = Convert.ToDecimal(i);
                    products.Add(product);
                }
                context.BulkInsert(products);
                context.BulkSaveChanges();
                #endregion
                #endregion
                sw.Stop();
                string s = string.Format("插入10000行数据，用了{0}毫秒\n", sw.ElapsedMilliseconds);


                sw = new Stopwatch();
                sw.Start();
                #region 方法二（原生EF）
                #region
                context.Configuration.AutoDetectChangesEnabled = false;// 解决批量性能问题
                context.Configuration.ValidateOnSaveEnabled = false;// 解决“对一个或多个实体的验证失败。”
                List<Product> products1 = new List<Product>();
                for (int i = 0; i < 10; i++)
                {
                    Product product = new Product();
                    product.Id = System.Guid.NewGuid();
                    product.Name = "Name" + i;
                    product.Price = Convert.ToDecimal(i);
                    products1.Add(product);
                    context.Entry<Product>(product).State = EntityState.Added;
                }
                context.SaveChanges();
                #endregion
                #endregion
                sw.Stop();
                s += string.Format("插入10000行数据，用了{0}毫秒\n", sw.ElapsedMilliseconds);
            }
        }

		private void button2_Click(object sender, EventArgs e)
		{
			//插入数据到一个数据表中
			using (var context = new EfPerformanceContext())
			{
				Product product = new Product();
				product.Name = "productName01";
				product.Price = 1.01m;
				context.Products.Add(product);
				context.SaveChanges();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			//初始化数据库，数据库是否存在，如果不确认是否存在，可以先点击尝试创建数据库
			using (var context = new EfPerformanceContext())
			{
				if (context.Database.CreateIfNotExists())
				{
					label1.Text = "数据库创建成功";
				}
				else
				{
					label1.Text = "数据库已存在！";
				}
			}
		}
	}
}
