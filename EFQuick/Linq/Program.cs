using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fusion.Context.Model;


namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Fun2();
        }

        private void Fun1()
        {
            Console.WriteLine((new ExeTestData()).Fun());
            Console.Read();
            return;
            int[] intAry1 = { 5, 15, 23, 30, 33, 40 };//创建整数数组 intAry1 作为数据源
            int[] intAry2 = { 10, 20, 30, 50, 60, 70, 80 };//创建整数数组 intAry2 作为数据源
                                                           //查询 query1 使用 join 子句从两个数据源获取数据
                                                           //演示左联接的使用
            var query1 =
            from val1 in intAry1
            join val2 in intAry2 on val1 % 5 equals val2 % 15 into val2Grp
            from grp in val2Grp.DefaultIfEmpty()
            select new { VAL1 = val1, VAL2GRP = grp };

            IList<Person> people = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                Person person = new Person();
                person.Name = "Name" + i;
                person.Num = "Num" + i;
                people.Add(person);
            }
            var tempList = people.Where(a => a.Name.Contains("2"));
            const int pageSize = 10;
            int pageNum = 0;
            while ((pageNum) * pageSize < people.Count)
            {
                var a = people.Skip((pageNum++) * pageSize).Take(pageSize).ToList();
            }
        }

        private static void Fun2()
        {
            Guid batchId = System.Guid.NewGuid();
            List<ProductHistoryModel> list1 = new List<ProductHistoryModel>();
            for (int i = 0; i < 4; i++)
            {
                ProductHistoryModel model = new ProductHistoryModel();
                model.ProductCode = "productCode" + i;
                model.OriginalOrderBatchId = batchId;
                model.ProductName = "productName" + i;
                model.PieceBarcode = "piecebarcode" + i;
                model.BarBarcode = "barcode" + i;
                model.Abnormity = false;
                if (i % 2 == 0)
                    model.Abnormity = true;
                model.Price = i;
                list1.Add(model);
            }
            List<ProductHistoryModel> list_1 = new List<ProductHistoryModel>();
            for (int i = 0; i < 4; i++)
            {
                ProductHistoryModel model = new ProductHistoryModel();
                model.ProductCode = "productCode" + i;
                model.OriginalOrderBatchId = batchId;
                model.ProductName = "productName" + i;
                model.PieceBarcode = "piecebarcode" + i;
                model.BarBarcode = "barcode" + i;
                model.Abnormity = false;
                if (i % 2 == 0)
                    model.Abnormity = true;
                model.Price = i;
                list_1.Add(model);
            }
            ProductHistorySummaryModel productHistorySummaryModel = new ProductHistorySummaryModel();
            productHistorySummaryModel.productHistoryModels = list_1;
            List<ProductHistorySummaryModel> productHistorySummaryModels = new List<ProductHistorySummaryModel>();
            productHistorySummaryModels.Add(productHistorySummaryModel);
            var a = productHistorySummaryModels.SelectMany(p => p.productHistoryModels);
            foreach(var f in a)
            {

            }
            //var a = from d in list1 join from m in list_1
        }
    }
    class Person
    {
        public string Name;
        public string Num;
    }
}
