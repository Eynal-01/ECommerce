﻿using ECommerce.DataAccess.Abstractions;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _repository;
        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public ObservableCollection<Product> GetFromHigherToLower(bool isLower)
        {
            IOrderedEnumerable<Product> items = null;
            if (!isLower)
            {
                items = from p in _repository.GetAll()
                        orderby p.Price descending
                        select p;
            }
            else
            {
                items = from p in _repository.GetAll()
                        orderby p.Price ascending
                        select p;
            }

            return new ObservableCollection<Product>(items);
        }

        public void UpdateProduct(Product product)
        {
            _repository.UpdateData(product);
        }

        public void AddProduct(Product product)
        {
            _repository.AddData(product);
        }
    }
}
