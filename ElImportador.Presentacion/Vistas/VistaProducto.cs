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
    public partial class VistaProducto : Form, IVistaProducto
    {
        public PresentadorPrincipal _presentador;

        public VistaProducto()
        {
            InitializeComponent();            
        }

        public void Mostrar(bool editar, Producto producto)
        {
            
            if (editar)
            {
                productoBindingSource.DataSource = producto;
                marcaBindingSource.DataSource = _presentador.GetMarcas();
                btnGuardar.Text = "EDITAR";
                ShowDialog();
                return;
            }
            btnGuardar.Text = "GUARDAR";
            IniciarBindings();
            ShowDialog();
        }

        public void SetPresentador(PresentadorPrincipal presentador)
        {
            _presentador = presentador;
            
        }

        public void Salir()
        {
            Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarOModificar();
        }

        public void GuardarOModificar()
        {
            var producto = productoBindingSource.DataSource as Producto;            
            producto.Marca = comboMarcas.SelectedItem as Marca;
            _presentador.GuardarProducto(producto);
        }

        public void IniciarBindings()
        {
            productoBindingSource.DataSource = _presentador.ProductoVacio();
            marcaBindingSource.DataSource = _presentador.GetMarcas();
        }
    }
}
