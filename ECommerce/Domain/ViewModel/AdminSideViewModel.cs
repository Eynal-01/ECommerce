using ECommerce.Commands;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModel
{
    public class AdminSideViewModel : BaseViewModel
    {
        public RelayCommand ProductsCommand { get; set; }
        public RelayCommand OrdersCommand { get; set; }

        public AdminSideViewModel()
        {
            ProductsCommand = new RelayCommand((obj) =>
            {
                var vm = new ProductEditViewModel();
                //vm.ProductInpfo = SelectedProduct;
                var view = new ProductEdit();
                view.DataContext = vm;
                view.ShowDialog();
            });

            OrdersCommand = new RelayCommand((obj) =>
            {
                var vm = new OrdersViewModel();
                var view = new Orders();
                view.DataContext = vm;
                view.ShowDialog();
            });
        }
    }
}
