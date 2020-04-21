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
            //ShowInnerJoin();
            Fun2();
            //初步使用Linq();
            Fun2();
            Test多表连接查询join();
            结果后插入行号();
            Console.ReadLine();
        }

        private static void 结果后插入行号()
        {
            var list = new List<models>();
            list.Add(new models() { id = 10, Name = "Lucy", Phone = "13545147370" });
            list.Add(new models() { id = 10, Name = "Lucy", Phone = "13424241212" });
            list.Add(new models() { id = 29, Name = "Jack", Phone = "13867671212" });
            list.Add(new models() { id = 19, Name = "bobo", Phone = "13987872323" });
            list.Add(new models() { id = 15, Name = "hk", Phone = "13527271818" });
            list.Add(new models() { id = 33, Name = "cy", Phone = "15627271616" });
            var tt = list.OrderBy(p => p.Name).OrderByDescending(p => p.Birthday).OrderByDescending(p => p.id).Select((p, idx) => new
            {
                row = idx,
                name = p.Name,
                phone = p.Phone
            });

            foreach (var item in tt)
            {
                Console.WriteLine(item.row + "====" + item.name + "====" + item.phone);
                Console.WriteLine("<br />");
            }
        }



        private static void 初步使用Linq()
        {
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

        private static void ShowInnerJoin()
        {
            int[] intAry1 = { 5, 15, 25, 30, 33, 40 };//创建整数数组 intAry1 作为数据源
            int[] intAry2 = { 10, 20, 30, 50, 60, 70, 80 };//创建整数数组 intAry2 作为数据源
                                                           //查询 query1 使用 join 子句从两个数据源获取数据
                                                           //演示内部联接的使用
            var query1 =
            from val1 in intAry1
            join val2 in intAry2 on val1*2 equals val2
            select new { VAL1 = val1, VAL2 = val2 };
            var query2 =
            from val1 in intAry1
            join val2 in intAry2 on val1 * 3 equals val2
            select new { VAL1 = val1, VAL2 = val2 };

            //右连接？
            var query002 =
            from val1 in intAry1
            join val2 in intAry2 on val1 % 5 equals val2 % 15 into val2Grp
            from grp in val2Grp.DefaultIfEmpty()
            select new { VAL2GRP = grp, VAL1= val2Grp};
        }

        private void ShowAllJoin()
        {
            #region //
//            #region
//            1、左连接：
//            var LeftJoin = from emp in ListOfEmployees
//                           join dept in ListOfDepartment
//                           on emp.DeptID equals dept.ID into JoinedEmpDept
//                           from dept in JoinedEmpDept.DefaultIfEmpty()
//                           select new
//                           {
//                               EmployeeName = emp.Name,
//                               DepartmentName = dept != null ? dept.Name : null
//                           };

//            2、右连接：
//var RightJoin = from dept in ListOfDepartment
//                join employee in ListOfEmployees
//                on dept.ID equals employee.DeptID into joinDeptEmp
//                from employee in joinDeptEmp.DefaultIfEmpty()
//                select new
//                {
//                    EmployeeName = employee != null ? employee.Name : null,
//                    DepartmentName = dept.Name
//                };

//            3、内连接：
// var query = from t in entitiy.TB_GCGL_ADA_USER
//             join p in entitiy.TB_GCGL_ZY_ZYK
//             on t.ETPRS_CODE equals p.ETPRS_CODE
//             select new TB_USER_ZYK
//             {
//                 USER_ID = t.USER_ID,
//                 USER_NAME = t.USER_NAME,
//                 USER_PASSWORD = t.USER_PASSWORD,
//             };
//            #endregion
#endregion
}
        private static void Test多表连接查询join()
        {
            //Console.WriteLine((new ExeTestData()).Fun());
            //Console.Read();
            //return;

            object query1;
            #region 内部连接
            #region
            {
                int[] intAry1 = { 5, 15, 25, 30, 33, 40 };//创建整数数组 intAry1 作为数据源
                int[] intAry2 = { 10, 20, 30, 50, 60, 70, 80 };//创建整数数组 intAry2 作为数据源
                                                               //查询 query1 使用 join 子句从两个数据源获取数据
                                                               //演示内部联接的使用
                query1 =
                    from val1 in intAry1
                    join val2 in intAry2 on val1 % 5 equals val2 % 15
                    select new { VAL1 = val1, VAL2 = val2 };
            }
            #endregion
            #endregion
            #region 分组连接  
            #region
            {
                int[] intAry1 = { 5, 15, 25, 30, 33, 40 };//创建整数数组 intAry1 作为数据源
                int[] intAry2 = { 10, 20, 30, 50, 60, 70, 80 };//创建整数数组 intAry2 作为数据源
                                                               //查询 query1 使用 join 子句从两个数据源获取数据
                                                               //演示分组联接的使用
                query1 =
                from val1 in intAry1
                join val2 in intAry2 on val1 % 5 equals val2 % 15 into val2Grp
                select new { VAL1 = val1, VAL2GRP = val2Grp.DefaultIfEmpty() };
            }
            #endregion
            #endregion
            #region 左外连接
            #region
            {
                int[] intAry1 = { 5, 15, 23, 30, 33, 40 };//创建整数数组 intAry1 作为数据源
                int[] intAry2 = { 10, 20, 30, 50, 60, 70, 80 };//创建整数数组 intAry2 作为数据源
                                                               //查询 query1 使用 join 子句从两个数据源获取数据
                                                               //演示左联接的使用
                query1 =
                from val1 in intAry1
                join val2 in intAry2 on val1 % 5 equals val2 % 15 into val2Grp
                from grp in val2Grp.DefaultIfEmpty()
                select new { VAL1 = val1, VAL2GRP = grp };
            }
            #endregion
            #endregion
        }

        private static void Fun2()
        {
            Guid batchId = System.Guid.NewGuid();
            List<ProductHistoryModel> list1 = new List<ProductHistoryModel>();
            #region 添加数据进list1、list_1
            for (int i = 0; i < 4; i++)
            {
                ProductHistoryModel model = new ProductHistoryModel();
                model.ProductCode = "A" + "productCode" + i;
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
                model.ProductCode = "B" + "productCode" + i;
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
            {
                int i = 0;
                var queryResult = from d in list1
                                  join m in list_1
                                      on d.OriginalOrderBatchId equals m.OriginalOrderBatchId
                                  select new ProductHistoryModel
                                  {
                                      ProductCode = d.ProductCode,
                                      PieceBarcode = m.ProductCode
                                  };
                Console.WriteLine("分组后的结果为：");
                foreach (var item in queryResult)
                {
                    Console.WriteLine("行数" + i + "级别：" + item.ProductCode + "  个数：" + item.PieceBarcode);
                    i++;
                }
            }
            #region group by
            #region
            {

                var queryResult = from e in list1
                                  group e by e.OriginalOrderBatchId into g
                                  select new { g.Key, counts = g.Count() };
                foreach (var item in queryResult)
                {
                    Console.WriteLine("级别：" + item.Key + "  个数：" + item.counts);
                }
            }
            #endregion
            #endregion

        }
    }
    class Person
    {
        public string Name;
        public string Num;
    }
}
