using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElImportador.Dominio;
using ElImportador.Dominio.Contratos;
using SimuladorCotizacion;

namespace ElImportador.AccesoADatos.Servicios
{
    public class Cotizador:ISimulador
    {
        private Simulador _simulador;
        

        public Cotizador()
        {
            _simulador = Simulador.Cotizacion;
            
        }

        public void Iniciar()
        {
           _simulador.Conectar(5);
            
        }

        public void Agregar(CotizacionHandler cotizacion)
        {
            _simulador.CotizacionModificada += cotizacion;
        }
            
        public void Desconectar()
        {
            _simulador.Desconectar();
        }

        public void Quitar(CotizacionHandler cotizacion)
        {
            _simulador.CotizacionModificada -= cotizacion;
        }
    }
}
