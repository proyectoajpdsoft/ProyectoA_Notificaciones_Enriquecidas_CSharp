using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;

namespace ProyectoANotificacionesEnriquecidas
{
    public partial class formNotificacion : Form
    {
        public formNotificacion()
        {
            InitializeComponent();
        }

        // Mostrar notificación enriquecida simple (solo texto)
        private void btNotificacionSimple_Click(object sender, EventArgs e)
        {
            new ToastContentBuilder()
                .AddArgument("IDNotificacion", 1111)
                .AddText("Esta es una notificación enriquecida de prueba.")
                .AddText("Aparecerán estas tres líneas en el área de notificación del sistema.")
                .AddText("La primera línea es el título de la notificación, aparecerá en negrita.")
                .Show();
        }

        // Mostrar notificación Toast con texto e imágenes
        private void btNotificacionImagen_Click(object sender, EventArgs e)
        {
            new ToastContentBuilder()
               .AddArgument("IDNotificacion", 2222)
               .AddText("Título de la notificación")
               .AddText("Texto de la notificación.")
               .AddAttributionText("Pie de la notificación.")
               // Esto mostrará una imagen debajo del texto de la notificación
               .AddInlineImage(new Uri(@"D:\pildora_phishing.png"))
               //Esto mostrará una imagen encima de la notificación
               .AddHeroImage(new Uri(@"D:\pildora2.png"))
               // Colocar imagen a la izquierda del texto
               //.AddAppLogoOverride(new Uri(@"D:\logo.png"), ToastGenericAppLogoCrop.Circle)
               .SetToastScenario(ToastScenario.Default)
               .SetToastDuration(ToastDuration.Short)
               .Show();
        }

        // Cierra todas las notificaciones abiertas y las quita del histórico de Windows
        private void btQuitarNotificaciones_Click(object sender, EventArgs e)
        {
            CerrarNotificaciones();
        }

        // Mostrar notificación con botones de acción
        private void btNotificarBoton_Click(object sender, EventArgs e)
        {
            NotificacionConBotones();
        }

        // Mostrar notificación Toast con dos botones de acción
        public static void NotificacionConBotones()
        {
            new ToastContentBuilder()
               .AddArgument("IDNotificacion", 7777)
               .AddText("Título de la notificación")
               .AddText("Texto de la notificación.")
               .AddAttributionText("Pie de la notificación.")
               // Esto mostrará una imagen debajo del texto de la notificación
               .AddInlineImage(new Uri(@"D:\logo.png"))
               .AddButton(new ToastButton()
                    .SetContent("Visitar ProyectoA")
                    .AddArgument("accion", "visitar")
                    .SetImageUri(new Uri(@"D:\logo.png"))
                    .SetBackgroundActivation())
               .AddButton(new ToastButton()
                    .SetContent("Cerrar")
                    .AddArgument("accion", "cerrar")
                    .SetBackgroundActivation())
               .SetToastScenario(ToastScenario.Default)
               .SetToastDuration(ToastDuration.Short)
               .Show();
        }

        // Método para cerrar todas las notificaciones y eliminarlas del histórico
        public static void CerrarNotificaciones()
        {
            ToastNotificationManagerCompat.History.Clear();
        }

        // Mostrar notificación que aceptará pulsación en el cuerpo y en segundo plano (cuando está en el histórico)
        private void btNotificacionSegundoPlano_Click(object sender, EventArgs e)
        {
            new ToastContentBuilder()
               .AddArgument("IDNotificacion", 5555)
               .AddText("Título de la notificación")
               .AddText("Texto de la notificación.")
               .AddAttributionText("Pie de la notificación.")
               // Esto mostrará una imagen debajo del texto de la notificación
               .AddInlineImage(new Uri(@"D:\pildora_phishing.png"))
               .SetToastScenario(ToastScenario.Default)
               .SetToastDuration(ToastDuration.Short)
               .Show(toast =>
               {
                   toast.ExpirationTime = DateTime.Now.AddMinutes(1);
               });
        }

        // Método que se ejecutará si se pulsa el cuerpo de la notificación
        // O si se pulsa estando en el histórico
        private static void PulsadaNotificacionSegundoPlano()
        {
            MessageBox.Show("Has pulsado en la notificación 5555.",
                "ProyectoA - Notificación...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Capturar evento cuando se pulsa un botón en la ventana de notificación Toast
        public static void BotonToastPulsado()
        {
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

                // Comprobamos si el evento recibido viene de la notificación "7777" (que tiene los botones)
                if (args.Contains("IDNotificacion"))
                {
                    if (args["IDNotificacion"] == "7777")
                    {
                        // Si contiene el argumento "accion" es porque se ha pulsado uno de los botones
                        if (args.Contains("accion"))
                        {
                            // Para el botón de acción de "Visitar ProyectoA"
                            if (args["accion"] == "visitar")
                            {
                                MessageBox.Show("Ha pulsado en el botón de Visitar ProyectoA.",
                                    "Botón pulsado...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                string url = "https://www.proyectoa.com";
                                try
                                {
                                    //System.Diagnostics.Process.Start(url);
                                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                                }
                                catch (System.ComponentModel.Win32Exception noBrowser)
                                {
                                    if (noBrowser.ErrorCode == -2147467259)
                                        MessageBox.Show(noBrowser.Message);
                                }
                                catch (Exception other)
                                {
                                    MessageBox.Show(other.Message);
                                }
                            }
                            else if (args["accion"] == "cerrar") // Para el botón de acción de "Cerrar"
                            {
                                MessageBox.Show("Ha pulsado en el botón de cerrar notificación.",
                                    "Botón pulsado...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CerrarNotificaciones();
                            }
                        }
                    }

                    // Para la notificación que aceptará la pulsación en el cuerpo, tanto
                    // mientras se muestra como cuando está en el histórico
                    if (args["IDNotificacion"] == "5555")
                    {
                        PulsadaNotificacionSegundoPlano();
                    }
                }
            };
        }
    }
}
