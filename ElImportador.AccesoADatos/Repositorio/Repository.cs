using ElImportador.Dominio;
using ElImportador.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElImportador.AccesoADatos.Repositorio
{
    public class Repository: ICotizaciones
    {
        public CotizacionesContext _context;

        public Repository(CotizacionesContext context)
        {
            _context = context;
        }

        public List<Producto> ActualizarCotizaciones(double valor)
        {
            foreach(var item in _context.Productos.ToList())
            {
                item.PrecioNacional = item.PrecioOriginal * valor;
            }
            return _context.Productos.ToList();

        }

        public void AgregarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();

        }

        public void EditarProducto()
        {
            _context.SaveChanges();
        }

        public bool ExisteProducto(Producto producto)
        {
            var item = _context.Productos
                       .Where(p => p.Id == producto.Id)
                       .FirstOrDefault();

            if (_context.Productos.ToList().Contains(item))
            {
                return true;
            }

            return false;
        }

        public List<Producto> FiltrarProductos(string text)
        {
            try
            {
                var lista = from b in _context.Productos
                             where b.Descripcion.ToLower().Contains(text.ToLower())
                             select b;

                return lista.ToList();
                             
                
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public List<Producto> GetCotizaciones()
        {
            return _context.Productos.ToList();
        }

        public List<Marca> GetMarcas()
        {
            return _context.Marcas.ToList();
        }

        public List<Producto> GetMayor()
        {
            

            var valor = _context.Productos.Max(p => p.Costo);
            var listaaa = _context.Productos.ToList();
            var lista = from b in _context.Productos
                        where b.Costo == valor
                        select b;

            return lista.ToList();
        }

        public List<Producto> GetMenor()
        {
            var valor = _context.Productos.Min(p => p.Costo);
            var lista = from b in _context.Productos
                        where b.Costo == valor
                        select b;

            return lista.ToList();
        }
    }
}
