using ECommerce.DataAccess.Abstractions;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ECommerce.Domain.Services
{
    public class OrderService
    {
        private IRepository<Order> _repository;
        public OrderService()
        {
            _repository = new OrderRepository();
        }

        public void AddOrder(Order order)
        {
            _repository.AddData(order);
        }

        public ObservableCollection<Order> GetAllOrders()
        {
            IOrderedEnumerable<Order> items = null;
            items = from o in _repository.GetAll()
                    orderby o.ProductId descending
                    select o;
            return new ObservableCollection<Order>(items);
        }
    }
}
