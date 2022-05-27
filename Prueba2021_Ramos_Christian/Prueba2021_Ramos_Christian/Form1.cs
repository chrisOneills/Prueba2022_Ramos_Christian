using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace Prueba2021_Ramos_Christian
{

    public partial class Form1 : Form
    {
        ClassEntidad objE = new ClassEntidad();
        ClassNegocio objN = new ClassNegocio();
        public Form1()
        {
            InitializeComponent();
        }

        void listar()
        {            
           objN.N_listar_proveedores();


        }

        void mantenimiento (String accion)
        {
            objE.cod_proveedor = txtCodigo.Text;
            objE.dsc_ruc = txtRuc.Text;
            objE.dsc_razon_social = txtRazonSocial.Text;
            objE.dsc_nombre_comercial = txtNombre.Text;
            objE.num_celular = Convert.ToInt32(txtCelular.Text);
            objE.dsc_direccion = txtDireccion.Text;           
            objE.fecha_creacion = txtFecha.Text;
            objE.flg_activo = txtEstado.Text;
            objE.accion = accion;

            objN.N_mantenimiento_proveedores(objE);
            //String rs = objN.N_mantenimiento_proveedores(objE);
            //MessageBox.Show(rs, "Mensaje!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      


        private void Form1_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
               dataGridViewListar.DataSource = objN.N_listar_proveedores();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mantenimiento("1");
            dataGridViewListar.DataSource = objN.N_listar_proveedores();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mantenimiento("2");
            limpiarDatos();
            dataGridViewListar.DataSource = objN.N_listar_proveedores();
        }

        private void dataGridViewListar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridViewListar.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridViewListar[0, fila].Value.ToString();
            txtRuc.Text = dataGridViewListar[1, fila].Value.ToString();
            txtRazonSocial.Text = dataGridViewListar[2, fila].Value.ToString();
            txtNombre.Text = dataGridViewListar[3, fila].Value.ToString();
            txtCelular.Text = dataGridViewListar[4, fila].Value.ToString();
            txtDireccion.Text = dataGridViewListar[5, fila].Value.ToString();
            txtFecha.Text = dataGridViewListar[6, fila].Value.ToString();
            txtEstado.Text = dataGridViewListar[7, fila].Value.ToString();
        }
        void limpiarDatos()
        {
            txtCodigo.Clear();
            txtRuc.Clear();
            txtRazonSocial.Clear();
            txtNombre.Clear();
            txtCelular.Clear();
            txtDireccion.Clear();
            txtFecha.Clear();
            txtEstado.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void Anular_Click(object sender, EventArgs e)
        {
            mantenimiento("3");
            dataGridViewListar.DataSource = objN.N_listar_proveedores();
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
