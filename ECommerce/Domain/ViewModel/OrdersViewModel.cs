using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModel
{
    public class OrdersViewModel : BaseViewModel
    {
        private readonly OrderService _orderService;
        public OrdersViewModel()
        {
            _orderService = new OrderService();
            AllOrders = _orderService.GetAllOrders();
        }
        private ObservableCollection<Order> allOrders;

        public ObservableCollection<Order> AllOrders
        {
            get { return allOrders; }
            set { allOrders = value; OnPropertyChanged(); }
        }
    }
}