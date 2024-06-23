using ArticulosAPi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticulosAPi.DAL;
public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Articulos> Articulos { get; set; }
}