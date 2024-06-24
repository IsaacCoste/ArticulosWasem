using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace ArticulosAPi.DAL;
public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Articulos> Articulos { get; set; }
}