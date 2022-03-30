using AppCore.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace practicaDepreciacion
{
    public partial class Form1 : Form
    {
        IActivoServices activoServices;
        IEmpleadoServices empleadoServices;
        List<Activo> activos;
        List<int> activoIds;
        public Form1(IActivoServices activoServices, IEmpleadoServices empleadoServices)
        {
            this.activoServices = activoServices;
            this.empleadoServices = empleadoServices;
            InitializeComponent();
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede numeros");
            }
        }



        private void txtValor_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtValorR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtVidaU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtEnviar_Click(object sender, EventArgs e)
        {
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los formularios.");
            }
            else
            {

                Activo activo = new Activo()
                {
                    Nombre = txtNombre.Text,
                    Valor = double.Parse(txtValor.Text),
                    ValorResidual = double.Parse(txtValorR.Text),
                    VidaUtil = int.Parse(txtVidaU.Text)
                };
                activoServices.Add(activo);
                dataGridView1.DataSource = null;
                limpiar();
                dataGridView1.DataSource = activoServices.Read();

            }
        }
        private bool verificar()
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtValor.Text) || String.IsNullOrEmpty(txtVidaU.Text) || String.IsNullOrEmpty(txtValorR.Text))
            {

                return false;
            }
            return true;
        }
        private void limpiar()
        {
            this.txtNombre.Text = String.Empty;
            this.txtValor.Text = String.Empty;
            this.txtValorR.Text = String.Empty;
            this.txtVidaU.Text = String.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FrmDepreciacion depreciacion = new FrmDepreciacion(activoServices.Read()[e.RowIndex]);
                depreciacion.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = activoServices.Read();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow.Selected == false)
            {
                MessageBox.Show("Debe seleccionar un activo", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            FrmActualizar frmActualizar = new FrmActualizar();
            frmActualizar.activoServices = activoServices;
            frmActualizar.lblId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frmActualizar.txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frmActualizar.nudValor.Value = decimal.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            frmActualizar.nudValorResidual.Value = decimal.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            frmActualizar.nudVidaUtil.Value = decimal.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            frmActualizar.ShowDialog();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = activoServices.Read();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow.Selected == false)
            {
                MessageBox.Show("Debe seleccionar un activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            activos = activoServices.Read();

            activoIds = activos.Select(x => x.Id).ToList();

            activoServices.Delete((int)dataGridView1.CurrentRow.Cells[0].Value, activoIds);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = activoServices.Read();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
