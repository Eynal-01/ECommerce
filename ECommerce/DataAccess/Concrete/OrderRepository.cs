using ECommerce.DataAccess.Abstractions;
using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ECommerce.DataAccess.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EECommerceDataContext _context;
        public OrderRepository()
        {
            _context = new EECommerceDataContext();
        }
        public void AddData(Order data)
        {
            _context.Orders.InsertOnSubmit(data);
            _context.SubmitChanges();
        }

        public void DeleteData(Order data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Order> GetAll()
        {
            var orders = from o in _context.Orders
                           orderby o.CustomerId
                           select o;
            return new ObservableCollection<Order>(orders);
        }

        public Order GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Order data)
        {
            throw new NotImplementedException();
        }
    }
}
