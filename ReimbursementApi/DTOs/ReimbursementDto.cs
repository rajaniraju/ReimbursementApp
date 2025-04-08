
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System;

namespace ReimbursementApi.DTOs
{
    public class ReimbursementDto
    {
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Receipt { get; set; }
    }
}
