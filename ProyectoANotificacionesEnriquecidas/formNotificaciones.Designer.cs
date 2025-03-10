namespace ProyectoANotificacionesEnriquecidas
{
    partial class formNotificacion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btNotificacionSimple = new Button();
            btNotificacionImagen = new Button();
            btQuitarNotificaciones = new Button();
            btNotificarBoton = new Button();
            btNotificacionSegundoPlano = new Button();
            SuspendLayout();
            // 
            // btNotificacionSimple
            // 
            btNotificacionSimple.Location = new Point(30, 29);
            btNotificacionSimple.Name = "btNotificacionSimple";
            btNotificacionSimple.Size = new Size(109, 58);
            btNotificacionSimple.TabIndex = 0;
            btNotificacionSimple.Text = "Notificación simple";
            btNotificacionSimple.UseVisualStyleBackColor = true;
            btNotificacionSimple.Click += btNotificacionSimple_Click;
            // 
            // btNotificacionImagen
            // 
            btNotificacionImagen.Location = new Point(30, 102);
            btNotificacionImagen.Name = "btNotificacionImagen";
            btNotificacionImagen.Size = new Size(109, 55);
            btNotificacionImagen.TabIndex = 1;
            btNotificacionImagen.Text = "Notificación con imagen";
            btNotificacionImagen.UseVisualStyleBackColor = true;
            btNotificacionImagen.Click += btNotificacionImagen_Click;
            // 
            // btQuitarNotificaciones
            // 
            btQuitarNotificaciones.Location = new Point(30, 186);
            btQuitarNotificaciones.Name = "btQuitarNotificaciones";
            btQuitarNotificaciones.Size = new Size(212, 23);
            btQuitarNotificaciones.TabIndex = 2;
            btQuitarNotificaciones.Text = "Quitar todas las notificaciones";
            btQuitarNotificaciones.UseVisualStyleBackColor = true;
            btQuitarNotificaciones.Click += btQuitarNotificaciones_Click;
            // 
            // btNotificarBoton
            // 
            btNotificarBoton.Location = new Point(155, 34);
            btNotificarBoton.Name = "btNotificarBoton";
            btNotificarBoton.Size = new Size(116, 49);
            btNotificarBoton.TabIndex = 3;
            btNotificarBoton.Text = "Notificación con botón de acción";
            btNotificarBoton.UseVisualStyleBackColor = true;
            btNotificarBoton.Click += btNotificarBoton_Click;
            // 
            // btNotificacionSegundoPlano
            // 
            btNotificacionSegundoPlano.Location = new Point(186, 102);
            btNotificacionSegundoPlano.Name = "btNotificacionSegundoPlano";
            btNotificacionSegundoPlano.Size = new Size(85, 42);
            btNotificacionSegundoPlano.TabIndex = 4;
            btNotificacionSegundoPlano.Text = "Segundo plano";
            btNotificacionSegundoPlano.UseVisualStyleBackColor = true;
            btNotificacionSegundoPlano.Click += btNotificacionSegundoPlano_Click;
            // 
            // formNotificacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 246);
            Controls.Add(btNotificacionSegundoPlano);
            Controls.Add(btNotificarBoton);
            Controls.Add(btQuitarNotificaciones);
            Controls.Add(btNotificacionImagen);
            Controls.Add(btNotificacionSimple);
            Name = "formNotificacion";
            Text = "ProyectoA - Notificaciones enriquecidas";
            ResumeLayout(false);
        }

        #endregion

        private Button btNotificacionSimple;
        private Button btNotificacionImagen;
        private Button btQuitarNotificaciones;
        private Button btNotificarBoton;
        private Button btNotificacionSegundoPlano;
    }
}
