using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Model
{
    public class HistoryOriginalOrderBatch
    {

        public Guid Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime? DeliveryDate { get; private set; }
        public int CompanyCount { get; private set; }
        public int DeliveryRouteCount { get; private set; }
        public int CustomerCount { get; private set; }
        public int OrderCount { get; private set; }
        public int ProductCount { get; private set; }
        public int TotalQuantity { get; private set; }
        public int NormalQuantity { get; private set; }
        public int AbnormityQuantity { get; private set; }
        public string DownloadBatch { get; private set; }
        public string Remark { get; private set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<HistoryOriginalOrder> OriginalOrders { get; private set; } = new List<HistoryOriginalOrder>();
    }
}
