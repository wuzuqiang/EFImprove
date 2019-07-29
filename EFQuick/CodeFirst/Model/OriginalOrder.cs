using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Model
{
    public class OriginalOrder
    {
        public Guid Id { get; private set; }
        public Guid OriginalOrderBatchId { get; private set; }
        public string OrderId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string OrderType { get; private set; }
        public string CustomerCode { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerAddress { get; private set; }
        public string CustomerPhone { get; private set; }
        public string NationCode { get; private set; }
        public string DeliveryRouteCode { get; private set; }
        public string DeliveryRouteName { get; private set; }
        public string DeliveryDistrictCode { get; private set; }
        public string DeliveryDistrictName { get; private set; }
        public int DeliveryOrder { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public int TotalQuantity { get; private set; }
        public int NormalQuantity { get; private set; }
        public int AbnormityQuantity { get; private set; }
        public int DetailCount { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string DownloadBatch { get; private set; }
        public string CompanyCode { get; private set; }
        public string CompanyName { get; private set; }
        public string VehicleDispatchBillNo { get; private set; }
        public string PostalBillNo { get; private set; }
        public bool PostalDelivery { get; private set; }
        public string Remark { get; private set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual OriginalOrderBatch OriginalOrderBatch { get; private set; }
        public virtual ICollection<OriginalOrderDetail> OriginalOrderDetails { get; private set; } = new List<OriginalOrderDetail>();
    }
}
