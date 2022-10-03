using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElImportador.Dominio;
using ElImportador.Presentacion.Presentadores;

namespace ElImportador.Presentacion.Interfaces
{
    public interface IVistaProducto
    {

        void SetPresentador(PresentadorPrincipal presentador);
        void Mostrar(bool editar, Producto producto);
        void Salir();
        void GuardarOModificar();
        void IniciarBindings();
    }
}
