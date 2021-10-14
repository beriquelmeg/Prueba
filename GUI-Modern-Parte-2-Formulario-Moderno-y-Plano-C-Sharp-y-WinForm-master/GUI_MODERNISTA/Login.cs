using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Modelo_Negocio;
using Oracle.ManagedDataAccess.Client;

namespace Diseno
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
            ocultar_elementos();
        }

        public void ocultar_elementos()
        {
            LblError.Visible = false;
        }

        private void BtnOlvidarContra_MouseEnter(object sender, EventArgs e)
        {
            BtnOlvidarContra.ForeColor = Color.Red;
        }

        private void BtnOlvidarContra_MouseLeave(object sender, EventArgs e)
        {
            BtnOlvidarContra.ForeColor = Color.Black;
        }

        private void TxtUsuario_Click(object sender, EventArgs e)
        {
            TxtUsuario.Text = "";
        }

        private void TxtContrasena_Click(object sender, EventArgs e)
        {
            TxtContrasena.Text = "";
        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            if (TxtUsuario.Text != "Usuario")
            {
                if (TxtContrasena.Text != "Contraseña")
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(TxtUsuario.Text, TxtContrasena.Text);
                    if (validLogin == true)
                    {
                        Pagina_Administrador pagina_administrador = new Pagina_Administrador();
                        pagina_administrador.Show();
                        pagina_administrador.FormClosed += CerrarSesion;
                        this.Hide();
                    }
                    else
                    {
                        ErrorLogin("Usuario o Contraseña invalido.");
                        TxtContrasena.Text="Contraseña";
                        TxtUsuario.Focus();
                    }
                }
                else
                {
                    ErrorLogin("Porfavor ingrese su contraseña");
                }
            }
            else
            {
                ErrorLogin("Porfavor Ingrese su usuario");
            }
        }
        private void ErrorLogin(string msg)
        {
            LblError.Text = msg;
            LblError.Visible = true;
        }

        public void CerrarSesion(object sender, EventArgs e)
        {
            TxtUsuario.Text = "Usuario";
            TxtContrasena.Text= "Contraseña";
            LblError.Visible = false;
            this.Show();
            //txtUsuario.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            string message = "¿Estas seguro de serrar la aplicacion?.";
            string caption = "Cierre de aplicacion.";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void BtnOlvidarContra_Click(object sender, EventArgs e)
        {
            PnlRecuperar.Visible = true;
        }

        // Recuperar contraseña -------------------------------------------------------



        // Envio de contraseña ---------------------------------
        private void EnviarCorreoContrasena(int contrasenaNueva, string correo)
        {
            string contraseña = "frutilla#";
            string mensaje = string.Empty;
            //Creando el correo electronico
            string destinatario = correo;
            string remitente = "restaurantsiglo@gmail.com";
            string asunto = "Nueva contraseña Restaurante XXI";
            string cuerpoDelMesaje = "Se ha actualizado su contraseña, podrá actualizarla dentro de los ajuste de su cuenta en la aplicacion. Su nueva contraseña es: " + " " + Convert.ToString(contrasenaNueva);
            MailMessage ms = new MailMessage(remitente, destinatario, asunto, cuerpoDelMesaje);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("restaurantsiglo@gmail.com", contraseña);

            try
            {
                Task.Run(() =>
                {

                    smtp.Send(ms);
                    ms.Dispose();
                    MessageBox.Show("Correo enviado, sirvase revisar su bandeja de entrada");
                }
                );

                MessageBox.Show("Esta tarea puede tardar unos segundos, por favor espere.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electronico: " + ex.Message);
            }
        }


        public void GenerarNuevaContrasena(string email)
        {
            Acceso ac = new Acceso();
            var conn = ac.conectar();
            

            Random rd = new Random(DateTime.Now.Millisecond);
            int nuevaContrasena = rd.Next(100000, 999999);
            OracleCommand cmd = new OracleCommand("NuevaContrasena", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("v_correo", OracleDbType.Varchar2)).Value = TxtCorreo.Text;
            cmd.Parameters.Add(new OracleParameter("v_contra", OracleDbType.Varchar2)).Value = Convert.ToString(nuevaContrasena);
            try
            {
                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas != 0)
                {
                    EnviarCorreoContrasena(nuevaContrasena, email);
                }
            }
            catch
            {

            }
        }



        private void BtnEnviar_Clave_Click(object sender, EventArgs e)
        {
            GenerarNuevaContrasena(TxtCorreo.Text);
            PnlRecuperar.Visible = false;
            TxtCorreo.Text = "";
        }

        private void ChkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            TxtContrasena.PasswordChar = ChkMostrar.Checked ? '\0' : '*';
        }

        private void TxtContrasena_TextChanged(object sender, EventArgs e)
        {
            if(TxtContrasena.Text != "Contraseña")
            {
                TxtContrasena.PasswordChar = '*';
            }
            else
            {
                TxtContrasena.PasswordChar = '\0';
            }
        }
    }
}
