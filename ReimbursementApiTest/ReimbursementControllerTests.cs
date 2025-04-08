using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ReimbursementApi.Controllers;
using ReimbursementApi.Data;
using ReimbursementApi.Models;
using ReimbursementApi.DTOs;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace ReimbursementApiTest
{
    public class ReimbursementControllerTests
    {
        private readonly AppDbContext _context;
        private readonly Mock<IWebHostEnvironment> _mockEnvironment;
        private readonly Mock<IOptions<AppSettings>> _mockAppSettings;  
        private readonly ReimbursementController _controller;

        public ReimbursementControllerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
             .UseInMemoryDatabase(databaseName: "TestDb")
             .Options;

            _context = new AppDbContext(options); 
            _mockEnvironment = new Mock<IWebHostEnvironment>();
            _mockAppSettings = new Mock<IOptions<AppSettings>>();

            
            _controller = new ReimbursementController(_context, _mockEnvironment.Object, _mockAppSettings.Object);
        }

        [Fact]
        public async Task Submit_NoReceipt_ReturnsBadRequest()
        {
            var dto = new ReimbursementDto
            {
                Receipt = null,
                PurchaseDate = DateTime.Now,
                Amount = 100.00m,
                Description = "Test reimbursement"
            };

        
            var result = await _controller.Submit(dto);

       
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Receipt file is required.", badRequestResult.Value);
        }

        [Fact]
        public async Task Submit_MissingPurchaseDate_ReturnsBadRequest()
        {
          
            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(f => f.FileName).Returns("receipt.jpg");
            formFileMock.Setup(f => f.Length).Returns(1024);
            formFileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                        .Returns(Task.CompletedTask);

            var dto = new ReimbursementDto
            {
                Receipt = formFileMock.Object,
                PurchaseDate = default(DateTime), 
                Amount = 100.00m,
                Description = "Test reimbursement"
            };

       
            var result = await _controller.Submit(dto);

       
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Purchase date is required.", badRequestResult.Value);
        }

        [Fact]
        public async Task Submit_MissingAmount_ReturnsBadRequest()
        {
       
            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(f => f.FileName).Returns("receipt.jpg");
            formFileMock.Setup(f => f.Length).Returns(1024);
            formFileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                        .Returns(Task.CompletedTask);

            var dto = new ReimbursementDto
            {
                Receipt = formFileMock.Object,
                PurchaseDate = DateTime.Now,
                Amount = 0,  // Missing Amount
                Description = "Test reimbursement"
            };

         
            var result = await _controller.Submit(dto);

         
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Amount is required.", badRequestResult.Value);
        }

    }
}
