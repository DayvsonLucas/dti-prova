﻿using AutoMapper;
using DTI.Application.Interface;
using DTI.Application.Services.Base;
using DTI.Application.ViewModels;
using DTI.Domain.Core.Notifications;
using DTI.Domain.Entities;
using DTI.Domain.Validations;
using DTI.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DTI.Application.Services
{
    public class ProductServices : BaseService, IProductServices
    {
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        public ProductServices(IProductRepository product,
                               IMapper mapper,
                               INotificationHandler notification) : base(notification)
        {
            _product = product;
            _mapper = mapper;
        }

        public async Task<bool> Add(ProductViewModel entity)
        {

            var product = _mapper.Map<Product>(entity);

            if (!ExecuteValidation(new ProductValidator(), product)) return false;

            if (_product.GetWhere(x => x.Id == entity.Id).Result.Any())
            {
                Notify("Já existe um produto cadastrado com esse id");
                return false;
            }

            await _product.Add(product);
            return true;
        }
        public async Task<bool> Update(ProductViewModel entity)
        {
            var product = _mapper.Map<Product>(entity);

            if (!ExecuteValidation(new ProductValidator(), product)) return false;

            await _product.Update(product);

            return true;
        }

        public async Task<int> CountWhere(Expression<Func<ProductViewModel, bool>> predicate)
        {
            var predicates = _mapper.Map<Expression<Func<Product, bool>>>(predicate);
            return await _product.CountWhere(predicates);
        }

        public async Task<ProductViewModel> FirstOrDefault(Expression<Func<ProductViewModel, bool>> predicate)
        {
            var predicates = _mapper.Map<Expression<Func<Product, bool>>>(predicate);
            return _mapper.Map<ProductViewModel>(await _product.FirstOrDefault(predicates));
        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _product.GetById(id));
        }

        public async Task<IEnumerable<ProductViewModel>> GetWhere(Expression<Func<ProductViewModel, bool>> predicate)
        {
            var predicates = _mapper.Map<Expression<Func<Product, bool>>>(predicate);
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _product.GetWhere(predicates));
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _product.GetAll());
        }
        public async Task<bool> Remove(Guid id)
        {
            var product = await _product.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                Notify($"O produto com id '{product.Id}' não foi localizado");
                return false;
            }

            else
                await _product.Delete(product);

            return true;
        }
    }
}
