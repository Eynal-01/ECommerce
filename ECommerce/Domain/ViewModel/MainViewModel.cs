using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Services;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        public RelayCommand ToLowerCommand { get; set; }
        public RelayCommand SelectProductCommand { get; set; }
        public RelayCommand AdminSideCommand { get; set; }

        private readonly ProductService _productService;
        //private readonly OrderService _orderService;

        public MainViewModel()
        {
            _productService = new ProductService();
            FilterText = "Higher To Lower";

            AllProducts = _productService.GetFromHigherToLower(IsLower);

            //AllOrders = _orderService.

            ToLowerCommand = new RelayCommand((obj) =>
            {
                IsLower = !IsLower;
                if (!IsLower)
                {
                    FilterText = "Lower To Higher";
                }
                else
                {
                    FilterText = "Higher To Lower";
                }
                AllProducts = _productService.GetFromHigherToLower(IsLower);
            });


            SelectProductCommand = new RelayCommand((obj) =>
            {
                var vm = new ProductInfoViewModel();
                vm.ProductInfo = SelectedProduct;
                var view = new ProductWindow();
                view.DataContext = vm;
                view.ShowDialog();
            });

            AdminSideCommand = new RelayCommand((obj) =>
            {
                var vm = new AdminSideViewModel();      
                var view = new AdminSide();
                view.DataContext = vm;
                view.ShowDialog();
            });
        }

        public bool IsLower { get; set; } = true;

        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set { filterText = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }


        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }
    }
}
