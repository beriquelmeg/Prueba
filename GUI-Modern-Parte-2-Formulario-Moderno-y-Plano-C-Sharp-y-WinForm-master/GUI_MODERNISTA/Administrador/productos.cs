using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Transversal;
using MaterialSkin;
using MaterialSkin.Controls;
using Modelo_Negocio;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Windows.Input;
using System.Globalization;

namespace Diseno
{
    public partial class productos : Form
    {

        public productos()
        {
            InitializeComponent();
            limpiar_formulario();
        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    PicFotoPlato.Image = Image.FromFile(imagen);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void limpiar_formulario()
        {
            TxtNombrePlato.Text = "";
            TxtDescPlato.Text = "";
            TxtPrecio.Text = "";
            CbxTipoPlato.Text = "--Seleccione un tipo de plato--";
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {

            Acceso ac = new Acceso();
            var conn = ac.conectar();
            conn.Open();

            using (OracleCommand command = new OracleCommand("NUEVA_PREPARACION", conn))
            {
                string message = "¿Estas seguro de agregar la preparacion?.";
                string caption = "Añadir nueva preparacion.";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                string v_plato;
                v_plato = CbxTipoPlato.Text;

                int v_tipo;

                switch (v_plato)
                {
                    case "ENTRADAS":
                        v_tipo = 1;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = TxtNombrePlato.Text;
                        command.Parameters.Add("V_PRECIO", OracleDbType.Int32).Value = TxtPrecio.Text;
                        command.Parameters.Add("V_ID_PREPARACION", OracleDbType.Int32).Value = v_tipo;
                        command.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = TxtDescPlato.Text;
                        command.Parameters.Add("V_IMAGEN", OracleDbType.LongRaw).Value = PicFotoPlato.Image;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            limpiar_formulario();
                        }
                        break;
                    case "PLATOS DE FONDO":
                        v_tipo = 2;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = TxtNombrePlato.Text;
                        command.Parameters.Add("V_PRECIO", OracleDbType.Int32).Value = TxtPrecio.Text;
                        command.Parameters.Add("V_ID_PREPARACION", OracleDbType.Int32).Value = v_tipo;
                        command.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = TxtDescPlato.Text;
                        command.Parameters.Add("V_IMAGEN", OracleDbType.Varchar2).Value = PicFotoPlato;

                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            limpiar_formulario();
                        }
                        break;
                    case "POSTRES":
                        v_tipo = 3;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = TxtNombrePlato.Text;
                        command.Parameters.Add("V_PRECIO", OracleDbType.Int32).Value = TxtPrecio.Text;
                        command.Parameters.Add("V_ID_PREPARACION", OracleDbType.Int32).Value = v_tipo;
                        command.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = TxtDescPlato.Text;
                        command.Parameters.Add("V_IMAGEN", OracleDbType.Varchar2).Value = PicFotoPlato;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            limpiar_formulario();
                        }
                        break;

                    case "ESPECIALIDADES DE LA CASA":
                        v_tipo = 4;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = TxtNombrePlato.Text;
                        command.Parameters.Add("V_PRECIO", OracleDbType.Int32).Value = TxtPrecio.Text;
                        command.Parameters.Add("V_ID_PREPARACION", OracleDbType.Int32).Value = v_tipo;
                        command.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = TxtDescPlato.Text;
                        command.Parameters.Add("V_IMAGEN", OracleDbType.Varchar2).Value = PicFotoPlato;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            limpiar_formulario();
                        }
                        break;
                    case "BEBESTIBLES":
                        v_tipo = 5;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = TxtNombrePlato.Text;
                        command.Parameters.Add("V_PRECIO", OracleDbType.Int32).Value = TxtPrecio.Text;
                        command.Parameters.Add("V_ID_PREPARACION", OracleDbType.Int32).Value = v_tipo;
                        command.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = TxtDescPlato.Text;
                        command.Parameters.Add("V_IMAGEN", OracleDbType.Varchar2).Value = PicFotoPlato;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            limpiar_formulario();
                        }
                        break;
                    case "MENU PARA NIÑOS":
                        v_tipo = 6;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = TxtNombrePlato.Text;
                        command.Parameters.Add("V_PRECIO", OracleDbType.Int32).Value = TxtPrecio.Text;
                        command.Parameters.Add("V_ID_PREPARACION", OracleDbType.Int32).Value = v_tipo;
                        command.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = TxtDescPlato.Text;
                        command.Parameters.Add("V_IMAGEN", OracleDbType.Varchar2).Value = PicFotoPlato;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            limpiar_formulario();
                        }
                        break;
                    case "VEGETARIANO":
                        v_tipo = 7;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = TxtNombrePlato.Text;
                        command.Parameters.Add("V_PRECIO", OracleDbType.Int32).Value = TxtPrecio.Text;
                        command.Parameters.Add("V_ID_PREPARACION", OracleDbType.Int32).Value = v_tipo;
                        command.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = TxtDescPlato.Text;
                        command.Parameters.Add("V_IMAGEN", OracleDbType.Varchar2).Value = PicFotoPlato;

                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            limpiar_formulario();
                        }
                        break;

                }
                conn.Close();
            }

        }
    }
}
