using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class ProductHistorySummaryModel
    {
        public ICollection<ProductHistoryModel> productHistoryModels = new List<ProductHistoryModel>();
    }
}
