
using Microsoft.AspNetCore.Mvc;
using ReimbursementApi.Data;
using ReimbursementApi.Models;
using ReimbursementApi.DTOs;
using Microsoft.Extensions.Options;

namespace ReimbursementApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReimbursementController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IOptions<AppSettings> _appSettings;
        public ReimbursementController(AppDbContext context, IWebHostEnvironment env, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            _context = context;
            _env = env;
        }
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("API is running!");
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromForm] ReimbursementDto dto)
        {


            if (dto.Receipt == null || dto.Receipt.Length == 0)
                return BadRequest("Receipt file is required.");

            if (dto.PurchaseDate == default)
                return BadRequest("Purchase date is required.");

            if (dto.Amount <= 0)
                return BadRequest("Amount is required.");

            try
            {
                // Save the file
                var uploads = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
                Directory.CreateDirectory(uploads);
                var filePath = Path.Combine(uploads, dto.Receipt.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Receipt.CopyToAsync(stream);
                }

                // Save entry to DB
                var reimbursement = new Reimbursement
                {
                    PurchaseDate = dto.PurchaseDate,
                    Amount = dto.Amount,
                    Description = dto.Description,
                    ReceiptFileName = dto.Receipt.FileName
                };


                _context.Reimbursements.Add(reimbursement);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Reimbursement submitted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


    }
}

