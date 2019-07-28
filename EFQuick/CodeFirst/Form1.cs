using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            using (var context = new EfPerformanceContext())
            {
                if(context.Database.CreateIfNotExists())
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
