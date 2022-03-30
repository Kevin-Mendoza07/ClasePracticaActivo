using AppCore.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaDepreciacion
{
    public partial class FrmActualizar : Form
    {
        public IActivoServices activoServices { get; set; }
        public FrmActualizar()
        {
            InitializeComponent();
        }

        private void FrmActualizar_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Activo activo = new Activo()
            {
                Id = int.Parse(lblId.Text),
                Nombre = txtNombre.Text,
                Valor = (float)nudValor.Value,
                VidaUtil = (int)nudVidaUtil.Value,
                ValorResidual = (float)nudValorResidual.Value
            };

            activoServices.Update(activo, activo.Id);
            Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
