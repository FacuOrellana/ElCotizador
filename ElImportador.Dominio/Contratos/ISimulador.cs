using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimuladorCotizacion;

namespace ElImportador.Dominio.Contratos
{
    public interface ISimulador
    {

       
        void Iniciar();
        void Desconectar();        
        void Agregar(CotizacionHandler cotizacion);
        void Quitar(CotizacionHandler cotizacion);

    }
}
