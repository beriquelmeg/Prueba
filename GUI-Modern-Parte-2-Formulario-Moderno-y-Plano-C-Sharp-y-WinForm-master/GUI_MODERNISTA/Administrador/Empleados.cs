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
    public partial class Empleados : MaterialForm
    {
        public Empleados()
        {
            InitializeComponent();
            CargarGrilla();
            PnlFormulario.Visible = false;
        }

        public class Rut
        {
            public String formatear(String rut)
            {
                int cont = 0;
                String format;
                if (rut.Length == 0)
                {
                    return "";
                }
                else
                {
                    rut = rut.Replace(".", "");
                    rut = rut.Replace("-", "");
                    format = "-" + rut.Substring(rut.Length - 1);
                    for (int i = rut.Length - 2; i >= 0; i--)
                    {

                        format = rut.Substring(i, 1) + format;

                        cont++;
                        if (cont == 3 && i != 0)
                        {
                            format = "." + format;
                            cont = 0;
                        }
                    }
                    return format;
                }
            }
        }

        private void CargarGrilla()
        {
            try
            {
                Acceso ac = new Acceso();
                var conn = ac.conectar();
                conn.Open();
                using (var command = new OracleCommand("fn_mostrar_datos", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    List<CacheLista> lista = new List<CacheLista>();

                    OracleParameter output = command.Parameters.Add("l_cursor", OracleDbType.RefCursor); //%rowtype
                    output.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();
                    OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                    while (reader.Read())
                    {
                        CacheLista caus = new CacheLista();

                        caus.ID = reader.GetInt32(0);
                        caus.Nombre = reader.GetString(1);
                        caus.Apellido = reader.GetString(2);
                        caus.Rut = reader.GetString(3);
                        caus.Usuario = reader.GetString(4);
                        caus.Contrasena = reader.GetString(5);
                        caus.Email = reader.GetString(6);
                        caus.Fono = reader.GetString(7);
                        caus.Rol_id = reader.GetInt32(8);
                        caus.Rol = reader.GetString(9);
                        caus.Estado = reader.GetString(10);

                        lista.Add(caus);
                    }
                    DtListaEmpleados.DataSource = lista;
                }
            }
            catch
            {
                MessageBox.Show("Error al mostrar datos en la grilla");
            }
        }

        private void DtListaEmpleados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BtnGuardar.Visible = false;
            PnlFormulario.Visible = true;
            int FilaActual;
            FilaActual = DtListaEmpleados.CurrentRow.Index;

            string id;
            id = DtListaEmpleados.Rows[FilaActual].Cells[0].Value.ToString();
            TxtID.Text = id;

            string nombre;
            nombre = DtListaEmpleados.Rows[FilaActual].Cells[1].Value.ToString();
            TxtNombre.Text = nombre;

            string apellido;
            apellido = DtListaEmpleados.Rows[FilaActual].Cells[2].Value.ToString();
            TxtApellido.Text = apellido;

            string rut;
            rut = DtListaEmpleados.Rows[FilaActual].Cells[3].Value.ToString();
            TxtRut.Text = rut;

            string usuario;
            usuario = DtListaEmpleados.Rows[FilaActual].Cells[4].Value.ToString();
            TxtUsuario.Text = usuario;

            string contrasena;
            contrasena = DtListaEmpleados.Rows[FilaActual].Cells[5].Value.ToString();
            TxtContrasena.Text = contrasena;

            string email;
            email = DtListaEmpleados.Rows[FilaActual].Cells[6].Value.ToString();
            TxtEmail.Text = email;

            string fono;
            fono = DtListaEmpleados.Rows[FilaActual].Cells[7].Value.ToString();
            TxtFono.Text = fono;

            string rol;
            rol = DtListaEmpleados.Rows[FilaActual].Cells[9].Value.ToString();
            CbxRol.Text = rol;

            string estado;
            estado = DtListaEmpleados.Rows[FilaActual].Cells[10].Value.ToString();
            CbxEstado.Text = estado;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            PnlFormulario.Visible = false;
        }

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            LblTitulo.Text = "Edicion de usuarios.";
            BtnGuardarCambios.Visible = true;
            BtnGuardar.Visible = false;

            Acceso ac = new Acceso();
            var conn = ac.conectar();
            conn.Open();

            using (OracleCommand command = new OracleCommand("modificar_usuarios", conn))
            {
                string message = "¿Estas seguro de modificar el usuario?.";
                string caption = "Modificacion de usuarios.";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                string v_estado;
                v_estado = CbxEstado.Text;

                string v_desc;
                v_desc = CbxRol.Text;
                int v_rol;

                switch (v_desc)
                {
                    case "ADMINISTRADOR":
                        v_rol = 1;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_id", OracleDbType.Int32).Value = TxtID.Text;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "COCINERO":
                        v_rol = 2;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_id", OracleDbType.Int32).Value = TxtID.Text;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "RECEPCION":
                        v_rol = 3;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_id", OracleDbType.Int32).Value = TxtID.Text;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "FINANZAS":
                        v_rol = 4;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_id", OracleDbType.Int32).Value = TxtID.Text;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "GARZON":
                        v_rol = 5;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_id", OracleDbType.Int32).Value = TxtID.Text;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "BODEGA":
                        v_rol = 6;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_id", OracleDbType.Int32).Value = TxtID.Text;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "CLIENTE":
                        v_rol = 7;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_id", OracleDbType.Int32).Value = TxtID.Text;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;

                }
            }
        }

        public void limpiar_formulario()
        {
            TxtID.Text = "";
            TxtNombre.Text = "";
            TxtApellido.Text = "";
            TxtRut.Text = "";
            TxtUsuario.Text = "";
            TxtContrasena.Text = "";
            TxtFono.Text = "";
            TxtEmail.Text = "";
            CbxEstado.Text = "--Seleccion un Rol--";
            CbxRol.Text = "--Seleccion un Rol--";
        }

        private void BtnAñadir_Click(object sender, EventArgs e)
        {
            PnlFormulario.Visible = true;
            LblTitulo.Text = "Añadir nuevo usuario.";
            BtnGuardarCambios.Visible = false;
            BtnGuardar.Visible = true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Acceso ac = new Acceso();
            var conn = ac.conectar();
            conn.Open();

            using (OracleCommand command = new OracleCommand("insertar_usuario", conn))
            {
                string message = "¿Estas seguro de agregar el usuario?.";
                string caption = "Añadir nuevo usuario.";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                string v_estado;
                v_estado = CbxEstado.Text;

                string v_desc;
                v_desc = CbxRol.Text;
                int v_rol;

                switch (v_desc)
                {
                    case "ADMINISTRADOR.":
                        v_rol = 1;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "COCINERO.":
                        v_rol = 2;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "RECEPCION.":
                        v_rol = 3;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "FINANZAS.":
                        v_rol = 4;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "GARZON.":
                        v_rol = 5;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "BODEGA.":
                        v_rol = 6;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;
                    case "CLIENTE.":
                        v_rol = 7;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = TxtNombre.Text;
                        command.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = TxtApellido.Text;
                        command.Parameters.Add("v_rut", OracleDbType.Varchar2, 12).Value = TxtRut.Text;
                        command.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = TxtUsuario.Text;
                        command.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = TxtContrasena.Text;
                        command.Parameters.Add("v_email", OracleDbType.Varchar2).Value = TxtEmail.Text;
                        command.Parameters.Add("v_fono", OracleDbType.Varchar2).Value = TxtFono.Text;
                        command.Parameters.Add("c_rol", OracleDbType.Int32).Value = v_rol;
                        command.Parameters.Add("c_estado", OracleDbType.Varchar2).Value = v_estado;


                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.ExecuteNonQuery();
                            CargarGrilla();
                            limpiar_formulario();
                            PnlFormulario.Visible = false;
                        }
                        break;

                }
            }

        }

        private void TxtRut_MouseLeave(object sender, EventArgs e)
        {
            Rut auxR = new Rut();
            this.TxtRut.Text = auxR.formatear(this.TxtRut.Text);
        }



        public DataGridView consultarDatos(string dato)
        {
            Acceso ac = new Acceso();
            var conn = ac.conectar();


            OracleDataAdapter comando;
            DataGridView dt;


            string consulta = String.Format("SELECT us.id, us.nombre || ' ' || us.apellidos as Nombre, us.usuario, us.contrasena, us.email, us.fono, us.rol_id, ro.rol_descripcion, us.estado FROM usuario us JOIN roles ro ON us.rol_id = ro.rol_id where us.nombre like '"+dato +"%';");
            comando = new OracleDataAdapter(consulta, conn);

            dt = new DataGridView();

            try
            {
                //Cargamos el DataTable con el resultado
                dt.DataSource = comando;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error : " + ex.Message);
                dt = null;
            }

            return dt;
        }

        private void TxtBuscarEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            string busqueda;
            busqueda = TxtBuscarEmpleado.Text;
            busqueda = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(busqueda.ToLower()));
            DtListaEmpleados = consultarDatos(busqueda);
        }
    }
}
