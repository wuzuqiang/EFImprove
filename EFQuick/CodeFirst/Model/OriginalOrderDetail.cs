using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Model
{
    public class OriginalOrderDetail
    {
        public Guid Id { get; private set; }
        public Guid OriginalOrderId { get; private set; }
        public Guid OriginalOrderBatchId { get; private set; }
        public string OrderId { get; private set; }
        public string ProductCode { get; private set; }
        public string ProductName { get; private set; }
        public int ProductNo { get; private set; }
        public string PieceBarcode { get; private set; }
        public string BarBarcode { get; private set; }
        public bool Abnormity { get; private set; }
        public int SortQuantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string Remark { get; private set; }
        public string TaskCode { get; private set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual OriginalOrder OriginalOrder { get; private set; }    //数据库中会用OriginalOrderId来表示OriginalOrder子表，挺好的。这样就关联起来了
	}
}
