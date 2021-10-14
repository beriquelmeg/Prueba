
namespace Diseno
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.PnlItems = new System.Windows.Forms.Panel();
            this.PnlRecuperar = new System.Windows.Forms.Panel();
            this.BtnEnviar_Clave = new System.Windows.Forms.Button();
            this.LblCorreo = new System.Windows.Forms.Label();
            this.TxtCorreo = new System.Windows.Forms.TextBox();
            this.LblRecuperar = new System.Windows.Forms.Label();
            this.ChkMostrar = new System.Windows.Forms.CheckBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnOlvidarContra = new System.Windows.Forms.Button();
            this.LblError = new System.Windows.Forms.Label();
            this.BtnAcceder = new System.Windows.Forms.Button();
            this.TxtContrasena = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.PnlNavegacion = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.PnlFondo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PnlItems.SuspendLayout();
            this.PnlRecuperar.SuspendLayout();
            this.PnlNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.PnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlItems
            // 
            this.PnlItems.BackColor = System.Drawing.Color.White;
            this.PnlItems.Controls.Add(this.PnlRecuperar);
            this.PnlItems.Controls.Add(this.ChkMostrar);
            this.PnlItems.Controls.Add(this.LblTitulo);
            this.PnlItems.Controls.Add(this.BtnOlvidarContra);
            this.PnlItems.Controls.Add(this.LblError);
            this.PnlItems.Controls.Add(this.BtnAcceder);
            this.PnlItems.Controls.Add(this.TxtContrasena);
            this.PnlItems.Controls.Add(this.TxtUsuario);
            this.PnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlItems.Location = new System.Drawing.Point(0, 0);
            this.PnlItems.Name = "PnlItems";
            this.PnlItems.Size = new System.Drawing.Size(800, 450);
            this.PnlItems.TabIndex = 0;
            // 
            // PnlRecuperar
            // 
            this.PnlRecuperar.Controls.Add(this.BtnEnviar_Clave);
            this.PnlRecuperar.Controls.Add(this.LblCorreo);
            this.PnlRecuperar.Controls.Add(this.TxtCorreo);
            this.PnlRecuperar.Controls.Add(this.LblRecuperar);
            this.PnlRecuperar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlRecuperar.Location = new System.Drawing.Point(0, 0);
            this.PnlRecuperar.Name = "PnlRecuperar";
            this.PnlRecuperar.Size = new System.Drawing.Size(800, 450);
            this.PnlRecuperar.TabIndex = 8;
            this.PnlRecuperar.Visible = false;
            // 
            // BtnEnviar_Clave
            // 
            this.BtnEnviar_Clave.BackColor = System.Drawing.Color.Black;
            this.BtnEnviar_Clave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEnviar_Clave.ForeColor = System.Drawing.Color.White;
            this.BtnEnviar_Clave.Location = new System.Drawing.Point(209, 313);
            this.BtnEnviar_Clave.Name = "BtnEnviar_Clave";
            this.BtnEnviar_Clave.Size = new System.Drawing.Size(136, 37);
            this.BtnEnviar_Clave.TabIndex = 3;
            this.BtnEnviar_Clave.Text = "Enviar";
            this.BtnEnviar_Clave.UseVisualStyleBackColor = false;
            this.BtnEnviar_Clave.Click += new System.EventHandler(this.BtnEnviar_Clave_Click);
            // 
            // LblCorreo
            // 
            this.LblCorreo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblCorreo.AutoSize = true;
            this.LblCorreo.BackColor = System.Drawing.Color.Transparent;
            this.LblCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCorreo.Location = new System.Drawing.Point(205, 181);
            this.LblCorreo.Name = "LblCorreo";
            this.LblCorreo.Size = new System.Drawing.Size(140, 20);
            this.LblCorreo.TabIndex = 2;
            this.LblCorreo.Text = "Ingrese su correo";
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.Location = new System.Drawing.Point(130, 243);
            this.TxtCorreo.Multiline = true;
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.Size = new System.Drawing.Size(302, 24);
            this.TxtCorreo.TabIndex = 1;
            // 
            // LblRecuperar
            // 
            this.LblRecuperar.AutoSize = true;
            this.LblRecuperar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRecuperar.Location = new System.Drawing.Point(180, 108);
            this.LblRecuperar.Name = "LblRecuperar";
            this.LblRecuperar.Size = new System.Drawing.Size(209, 25);
            this.LblRecuperar.TabIndex = 0;
            this.LblRecuperar.Text = "Recuperar Contraseña";
            // 
            // ChkMostrar
            // 
            this.ChkMostrar.AutoSize = true;
            this.ChkMostrar.Location = new System.Drawing.Point(393, 228);
            this.ChkMostrar.Name = "ChkMostrar";
            this.ChkMostrar.Size = new System.Drawing.Size(155, 21);
            this.ChkMostrar.TabIndex = 8;
            this.ChkMostrar.Text = "Mostrar Contraseña";
            this.ChkMostrar.UseVisualStyleBackColor = true;
            this.ChkMostrar.CheckedChanged += new System.EventHandler(this.ChkMostrar_CheckedChanged);
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(219, 94);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(91, 33);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "Login";
            // 
            // BtnOlvidarContra
            // 
            this.BtnOlvidarContra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOlvidarContra.FlatAppearance.BorderSize = 0;
            this.BtnOlvidarContra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnOlvidarContra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnOlvidarContra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOlvidarContra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnOlvidarContra.Location = new System.Drawing.Point(154, 356);
            this.BtnOlvidarContra.Name = "BtnOlvidarContra";
            this.BtnOlvidarContra.Size = new System.Drawing.Size(233, 27);
            this.BtnOlvidarContra.TabIndex = 6;
            this.BtnOlvidarContra.Text = "¿Has olvidado tu contraseña?.";
            this.BtnOlvidarContra.UseVisualStyleBackColor = true;
            this.BtnOlvidarContra.Click += new System.EventHandler(this.BtnOlvidarContra_Click);
            this.BtnOlvidarContra.MouseEnter += new System.EventHandler(this.BtnOlvidarContra_MouseEnter);
            this.BtnOlvidarContra.MouseLeave += new System.EventHandler(this.BtnOlvidarContra_MouseLeave);
            // 
            // LblError
            // 
            this.LblError.AutoSize = true;
            this.LblError.Location = new System.Drawing.Point(151, 255);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(40, 17);
            this.LblError.TabIndex = 5;
            this.LblError.Text = "Error";
            // 
            // BtnAcceder
            // 
            this.BtnAcceder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAcceder.AutoSize = true;
            this.BtnAcceder.BackColor = System.Drawing.Color.Black;
            this.BtnAcceder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAcceder.ForeColor = System.Drawing.Color.White;
            this.BtnAcceder.Location = new System.Drawing.Point(168, 283);
            this.BtnAcceder.Name = "BtnAcceder";
            this.BtnAcceder.Size = new System.Drawing.Size(190, 46);
            this.BtnAcceder.TabIndex = 4;
            this.BtnAcceder.Text = "Acceder";
            this.BtnAcceder.UseVisualStyleBackColor = false;
            this.BtnAcceder.Click += new System.EventHandler(this.BtnAcceder_Click);
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtContrasena.ForeColor = System.Drawing.Color.Gray;
            this.TxtContrasena.Location = new System.Drawing.Point(154, 222);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.Size = new System.Drawing.Size(233, 22);
            this.TxtContrasena.TabIndex = 3;
            this.TxtContrasena.Text = "Contraseña";
            this.TxtContrasena.Click += new System.EventHandler(this.TxtContrasena_Click);
            this.TxtContrasena.TextChanged += new System.EventHandler(this.TxtContrasena_TextChanged);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtUsuario.ForeColor = System.Drawing.Color.Gray;
            this.TxtUsuario.Location = new System.Drawing.Point(154, 179);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(233, 22);
            this.TxtUsuario.TabIndex = 2;
            this.TxtUsuario.Text = "Usuario";
            this.TxtUsuario.Click += new System.EventHandler(this.TxtUsuario_Click);
            // 
            // PnlNavegacion
            // 
            this.PnlNavegacion.BackColor = System.Drawing.Color.Black;
            this.PnlNavegacion.Controls.Add(this.btnCerrar);
            this.PnlNavegacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlNavegacion.Location = new System.Drawing.Point(0, 0);
            this.PnlNavegacion.Name = "PnlNavegacion";
            this.PnlNavegacion.Size = new System.Drawing.Size(800, 32);
            this.PnlNavegacion.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(767, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 31);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlFondo
            // 
            this.PnlFondo.Controls.Add(this.pictureBox1);
            this.PnlFondo.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlFondo.Location = new System.Drawing.Point(554, 32);
            this.PnlFondo.Name = "PnlFondo";
            this.PnlFondo.Size = new System.Drawing.Size(246, 418);
            this.PnlFondo.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 418);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PnlFondo);
            this.Controls.Add(this.PnlNavegacion);
            this.Controls.Add(this.PnlItems);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.PnlItems.ResumeLayout(false);
            this.PnlItems.PerformLayout();
            this.PnlRecuperar.ResumeLayout(false);
            this.PnlRecuperar.PerformLayout();
            this.PnlNavegacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.PnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlItems;
        private System.Windows.Forms.TextBox TxtContrasena;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Panel PnlNavegacion;
        private System.Windows.Forms.Panel PnlFondo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnOlvidarContra;
        private System.Windows.Forms.Label LblError;
        private System.Windows.Forms.Button BtnAcceder;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel PnlRecuperar;
        private System.Windows.Forms.Label LblCorreo;
        private System.Windows.Forms.TextBox TxtCorreo;
        private System.Windows.Forms.Label LblRecuperar;
        private System.Windows.Forms.Button BtnEnviar_Clave;
        private System.Windows.Forms.CheckBox ChkMostrar;
    }
}