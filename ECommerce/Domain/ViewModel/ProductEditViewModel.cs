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

namespace ECommerce.Domain.ViewModel
{
    public class ProductEditViewModel : BaseViewModel
    {
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
                    
                }
            });

            EditCommand = new RelayCommand((obj) =>
            {

            });
        }

        public RelayCommand EditCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }

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
