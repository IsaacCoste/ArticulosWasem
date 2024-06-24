using ArticulosAPi.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Linq.Expressions;

namespace ArticulosAPi.Services;
public class ArticulosService
{
    private readonly Contexto _contexto;
    public ArticulosService(Contexto contexto)
    {
        _contexto = contexto;
    }
    private async Task<bool> Insertar(Articulos articulo)
    {
        _contexto.Articulos.Add(articulo);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Articulos articulo)
    {
        _contexto.Articulos.Update(articulo);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Existe(int articuloId)
    {
        return await _contexto.Articulos
            .AnyAsync(a => a.ArticuloId == articuloId);
    }
    public async Task<bool> Existe(int tecnicoId, string? descripcion)
    {
        return await _contexto.Articulos
            .AnyAsync(a => a.ArticuloId != tecnicoId && a.Descripcion.Equals(descripcion));
    }
    public async Task<bool> Guardar(Articulos articulo)
    {
        if (!await Existe(articulo.ArticuloId))
            return await Insertar(articulo);
        else
            return await Modificar(articulo);
    }
    public async Task<bool> Eliminar(Articulos articulo)
    {
        var cantidad = await _contexto.Articulos
            .Where(a => a.ArticuloId == articulo.ArticuloId)
            .ExecuteDeleteAsync();
        return cantidad > 0;
    }
    public async Task<Articulos?> Buscar(int articuloId)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.ArticuloId == articuloId);
    }
    public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}