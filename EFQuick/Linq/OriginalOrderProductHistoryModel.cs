using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{

    public class ProductHistoryModel
    {
        public string ProductCode { get; set; }
        public Guid OriginalOrderBatchId { get; set; }
        public string ProductName { get; set; }
        public int ProductNo { get; set; }
        public string PieceBarcode { get; set; }
        public string BarBarcode { get; set; }
        public bool Abnormity { get; set; }
        public int SortQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
