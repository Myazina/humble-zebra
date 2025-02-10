
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Api1.Controllers;
using Api1.Dtos;
using Api1.Interfaces;
using Api1.Models;
using Api1.Data;
using Api1.Helpers;
using Api1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Api1.Dtos.Product;

namespace Api1.Tests.Controller
{
    public class ProductControllerTests
    {
        private readonly ApiContext _context;
        private readonly IProductRepository _productRepo;   
        private readonly IMapper _mapper;      
        public ProductControllerTests()
        {
            _context = A.Fake<ApiContext>();
            _productRepo = A.Fake<IProductRepository>();           
            _mapper = A.Fake<IMapper>();
        }   
         [Fact]
        public void ProductController_GetProducts_ReturnOK()
        {
            //Arrange
            var products = A.Fake<ProductDto>();
            var productList = A.Fake<List<ProductDto>>();           
            
            A.CallTo(() => _mapper.Map<List<ProductDto>>(products)).Returns(productList);

            var controller = new ProductController(_context, _productRepo);

            //Act
            var result = controller.HttpContext.Request.QueryString;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }        
            
    }
}