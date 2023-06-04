using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Services;
using System;
using System.Collections.Generic;
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
                }
                else
                {
                    MessageBox.Show("Change something for update!");
                }
            });

            SelectedItem = new RelayCommand((obj) =>
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
        public RelayCommand SelectedItem { get; set; }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
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
