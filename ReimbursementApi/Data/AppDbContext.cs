using Moq;
using Microsoft.EntityFrameworkCore;
using ReimbursementApi.Models;

namespace ReimbursementApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Reimbursement> Reimbursements { get; set; } = null!;

        public static implicit operator global::Moq.Mock<object>(AppDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}
