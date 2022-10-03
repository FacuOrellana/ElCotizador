using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimuladorCotizacion;
namespace ElImportador.Dominio
{
    public class Producto
    {

       

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double PrecioOriginal => Costo;
        public double Costo { get; set; }
        public double PrecioNacional
        {
            get
            {
                return Math.Round((PrecioOriginal * Dolar),2);
            }

            set
            {

            }
                       
        }
        public int? MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
        public string Modelo { get; set; }
        public double Impuesto => 0.25;
        public double MargenGanancia { get; set; }
        public static double Dolar { get;set; }

        public override string ToString()
        {
            return $"Producto = {Descripcion} , Precio = {PrecioNacional}";
        }


    }
}
