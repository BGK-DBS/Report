using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ReportWebApi.Models
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options)
    : base(options)
        {
        }

        public DbSet<ReportItem> ReportItem { get; set; } = null!;
    }
}
