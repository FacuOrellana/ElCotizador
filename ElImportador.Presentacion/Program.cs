using ElImportador.Presentacion.Interfaces;
using ElImportador.Presentacion.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using ElImportador.AccesoADatos.Repositorio;
using ElImportador.Dominio.Contratos;
using ElImportador.AccesoADatos.Servicios;

namespace ElImportador.Presentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var contenedor = new UnityContainer();
            contenedor.RegisterType<IVistaProducto, VistaProducto>();
            contenedor.RegisterType<ICotizaciones, Repository>();
            contenedor.RegisterType<ISimulador, Cotizador>();
            var vista = contenedor.Resolve<PanelVista>();
            Application.Run(vista);
        }
    }
}
