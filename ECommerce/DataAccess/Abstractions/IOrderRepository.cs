using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ECommerce.DataAccess.Abstractions
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
