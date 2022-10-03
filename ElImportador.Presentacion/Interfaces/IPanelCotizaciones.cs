using ElImportador.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElImportador.Presentacion.Interfaces
{
    public interface IPanelCotizaciones
    {
        void Agregar();
        void Editar(Producto producto);
        void Salir();
        void Actualizar(List<Producto> lista);
        void ActualizarDolar(double valor);
        void BuscarProductos(List<Producto> lista);
        void Mostrar(List<Producto> producto);
    }
}
