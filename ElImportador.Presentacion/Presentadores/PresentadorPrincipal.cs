using ElImportador.Dominio;
using ElImportador.Dominio.Contratos;
using ElImportador.Presentacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElImportador.Presentacion.Presentadores
{
    public class PresentadorPrincipal
    {
        public IPanelCotizaciones _panel;
        public IVistaProducto _vistaProducto;
        public ICotizaciones _repositorio;
        public ISimulador _simulador;

        

        public PresentadorPrincipal(IVistaProducto vistaProducto, ICotizaciones repositorio, ISimulador simulador)
        {
            _repositorio = repositorio;
            _vistaProducto = vistaProducto;
            _vistaProducto.SetPresentador(this);
            _vistaProducto.IniciarBindings();
            _simulador = simulador;
            
        }

        public void Iniciar()
        {
            _simulador.Iniciar();
            _simulador.Agregar(LecturaTomada);
        }

        public void LecturaTomada(double valor)
        {
            
            Producto.Dolar = valor;
            _panel.ActualizarDolar(valor);
            var lista = _repositorio.ActualizarCotizaciones(valor);
            _panel.Actualizar(lista);
        }

        public List<Producto> GetMenor()
        {
          return _repositorio.GetMenor();
        }

        public List<Producto> GetMayor()
        {
            return _repositorio.GetMayor();
        }

        public List<Marca> GetMarcas()
        {
            return _repositorio.GetMarcas();
        }

        public void SetVistaPanel(IPanelCotizaciones panel)
        {
            _panel = panel;
            _panel.Actualizar(_repositorio.GetCotizaciones());
        }

        public Producto ProductoVacio()
        {
            return new Producto();
        }

        public void NuevoProducto()
        {
            _vistaProducto.Mostrar(false,null);
        }

        public void Desconectar()
        {
            _simulador.Quitar(LecturaTomada);
            _simulador.Desconectar();
            
        }

        public void ActualizarProducto(Producto producto)
        {
            _vistaProducto.Mostrar(true, producto);
        }

        public void GuardarProducto(Producto producto)
        {
            if (!_repositorio.ExisteProducto(producto))
            {
                _repositorio.AgregarProducto(producto);
                _vistaProducto.Salir();
                _panel.Actualizar(_repositorio.GetCotizaciones());
                return;
            }
            _repositorio.EditarProducto();
            _panel.Actualizar(_repositorio.GetCotizaciones());
            _vistaProducto.Salir();
                        
        }

        public List<Producto> FiltrarLista(string text)
        {
           return _repositorio.FiltrarProductos(text);
        }
    }
}
