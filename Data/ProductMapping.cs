using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ProductMapping 
{
    protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>()
            .Property(p => p.Code).HasMaxLength(20)
            .IsRequired(false);
    }
}