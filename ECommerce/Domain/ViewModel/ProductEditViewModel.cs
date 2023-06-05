using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ECommerce.Domain.ViewModel
{
    public class ProductEditViewModel : BaseViewModel
    {
        private readonly ProductService _productService;
        public ProductEditViewModel()
        {

            _productService = new ProductService();
            SelectedProduct = new Product();

            AllProducts = _productService.GetAllProducts();


            InsertCommand = new RelayCommand((obj) =>
            {
                if (SelectedProduct.Name == ProductName)
                {
                    MessageBox.Show("Product already exists! You only edit operation for this product");
                }
                else
                {
                    var product = new Product
                    {
                        Name = ProductName,
                        Price = ProductPrice,
                        Description = ProductDescription,
                        Quantity = ProductQuantity,
                        Discount = ProductDiscount
                    };
                    _productService.AddProduct(product);
                    AllProducts = _productService.GetAllProducts();
                    ProductName = null;
                    ProductPrice = 0;
                    ProductDescription = null;
                    ProductQuantity = 0;
                    ProductDiscount = 0;
                }
            });

            EditCommand = new RelayCommand((obj) =>
            {
                if (SelectedProduct.Name != ProductName || SelectedProduct.Price != ProductPrice ||
                    SelectedProduct.Discount != ProductDiscount || SelectedProduct.Quantity != ProductQuantity || SelectedProduct.Description != ProductDescription)
                {
                    SelectedProduct.Name = ProductName;
                    SelectedProduct.Price = ProductPrice;
                    SelectedProduct.Discount = ProductDiscount;
                    SelectedProduct.Description = ProductDescription;
                    SelectedProduct.Quantity = ProductQuantity;
                    ProductName = null;
                    ProductPrice = 0;
                    ProductDescription = null;
                    ProductQuantity = 0;
                    ProductDiscount = 0;
                }
                else
                {
                    MessageBox.Show("Change something for update!");
                }
            });

            SelectedProductCommand = new RelayCommand((obj) =>
            {
                ProductName = SelectedProduct.Name;
                ProductPrice = SelectedProduct.Price;
                ProductDiscount = (int)SelectedProduct.Discount;
                ProductQuantity = SelectedProduct.Quantity;
                ProductDescription = SelectedProduct.Description;
            });
        }

        public RelayCommand EditCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand SelectedProductCommand { get; set; }

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

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }


        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged(); }
        }

        private decimal productPrice;

        public decimal ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; OnPropertyChanged(); }
        }

        private int productQuantity;

        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; OnPropertyChanged(); }
        }

        private string productDescription;

        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; OnPropertyChanged(); }
        }

        private int productDiscount;

        public int ProductDiscount
        {
            get { return productDiscount; }
            set { productDiscount = value; OnPropertyChanged(); }
        }
    }
}
