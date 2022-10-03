using ElImportador.Dominio;
using ElImportador.Presentacion.Interfaces;
using ElImportador.Presentacion.Presentadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElImportador.Presentacion.Vistas
{
    public partial class PanelVista : Form, IPanelCotizaciones
    {
        PresentadorPrincipal _presentador;

        public PanelVista(PresentadorPrincipal presentador)
        {
            InitializeComponent();
            _presentador = presentador;
            _presentador.SetVistaPanel(this);
            _presentador.Iniciar();
        }

        public void Actualizar(List<Producto> lista)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(()=> ActualizarGrilla(lista)));
            }
            else
            {
                ActualizarGrilla(lista);
            }
            
        }

        private void ActualizarGrilla(List<Producto> lista)
        {
            productoBindingSource.ResetBindings(false);
            dvgProductos.DataSource = lista;          
        }

        public void ActualizarDolar(double valor)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => Actualizar(valor)));
            }
            else
            {
              Actualizar(valor);
            }

            
        }

        private void Actualizar(double valor)
        {
            lblValorDolar.Text = $"{Math.Round(valor, 2)}";
        }

        public void Agregar()
        {
            _presentador.NuevoProducto();
        }

        public void Editar(Producto producto)
        {
            _presentador.ActualizarProducto(producto);
        }

        public void Salir()
        {
            _presentador.Desconectar();
            Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            var p = dvgProductos.CurrentRow.DataBoundItem as Producto;
            Editar(dvgProductos.CurrentRow.DataBoundItem as Producto);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void FiltrarLista(object sender, EventArgs e)
        {
           var lista = _presentador.FiltrarLista(txtBuscar.Text);
            if (txtBuscar.Text == null) return;

            BuscarProductos(lista);
        }

        public void BuscarProductos(List<Producto> lista)
        {
            productoBindingSource.ResetBindings(false);
            dvgProductos.DataSource = lista;
            if (lista == null)
            {
                MessageBox.Show("No existen productos para la la descripcion ingresada", "PAV 2020", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnMenor_Click(object sender, EventArgs e)
        {
            Mostrar(_presentador.GetMenor());
        }

        private void btnMayor_Click(object sender, EventArgs e)
        {
            Mostrar(_presentador.GetMayor());
        }

        public void Mostrar(List<Producto> lista)
        {
            dvgProductos.DataSource = lista;
        }
    }
}
