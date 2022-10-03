using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElImportador.Dominio.Contratos
{
    public interface ICotizaciones
    {
        void AgregarProducto(Producto producto);
        void EditarProducto();
        List<Producto> ActualizarCotizaciones(double valor);
        List<Producto> GetCotizaciones();
        List<Marca> GetMarcas();
        bool ExisteProducto(Producto producto);
        List<Producto> GetMayor();
        List<Producto> GetMenor();
        List<Producto> FiltrarProductos(string text);
    }
}
