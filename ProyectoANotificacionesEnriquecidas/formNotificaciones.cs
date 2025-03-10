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

        // Mostrar notificaci�n enriquecida simple (solo texto)
        private void btNotificacionSimple_Click(object sender, EventArgs e)
        {
            new ToastContentBuilder()
                .AddArgument("IDNotificacion", 1111)
                .AddText("Esta es una notificaci�n enriquecida de prueba.")
                .AddText("Aparecer�n estas tres l�neas en el �rea de notificaci�n del sistema.")
                .AddText("La primera l�nea es el t�tulo de la notificaci�n, aparecer� en negrita.")
                .Show();
        }

        // Mostrar notificaci�n Toast con texto e im�genes
        private void btNotificacionImagen_Click(object sender, EventArgs e)
        {
            new ToastContentBuilder()
               .AddArgument("IDNotificacion", 2222)
               .AddText("T�tulo de la notificaci�n")
               .AddText("Texto de la notificaci�n.")
               .AddAttributionText("Pie de la notificaci�n.")
               // Esto mostrar� una imagen debajo del texto de la notificaci�n
               .AddInlineImage(new Uri(@"D:\pildora_phishing.png"))
               //Esto mostrar� una imagen encima de la notificaci�n
               .AddHeroImage(new Uri(@"D:\pildora2.png"))
               // Colocar imagen a la izquierda del texto
               //.AddAppLogoOverride(new Uri(@"D:\logo.png"), ToastGenericAppLogoCrop.Circle)
               .SetToastScenario(ToastScenario.Default)
               .SetToastDuration(ToastDuration.Short)
               .Show();
        }

        // Cierra todas las notificaciones abiertas y las quita del hist�rico de Windows
        private void btQuitarNotificaciones_Click(object sender, EventArgs e)
        {
            CerrarNotificaciones();
        }

        // Mostrar notificaci�n con botones de acci�n
        private void btNotificarBoton_Click(object sender, EventArgs e)
        {
            NotificacionConBotones();
        }

        // Mostrar notificaci�n Toast con dos botones de acci�n
        public static void NotificacionConBotones()
        {
            new ToastContentBuilder()
               .AddArgument("IDNotificacion", 7777)
               .AddText("T�tulo de la notificaci�n")
               .AddText("Texto de la notificaci�n.")
               .AddAttributionText("Pie de la notificaci�n.")
               // Esto mostrar� una imagen debajo del texto de la notificaci�n
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

        // M�todo para cerrar todas las notificaciones y eliminarlas del hist�rico
        public static void CerrarNotificaciones()
        {
            ToastNotificationManagerCompat.History.Clear();
        }

        // Mostrar notificaci�n que aceptar� pulsaci�n en el cuerpo y en segundo plano (cuando est� en el hist�rico)
        private void btNotificacionSegundoPlano_Click(object sender, EventArgs e)
        {
            new ToastContentBuilder()
               .AddArgument("IDNotificacion", 5555)
               .AddText("T�tulo de la notificaci�n")
               .AddText("Texto de la notificaci�n.")
               .AddAttributionText("Pie de la notificaci�n.")
               // Esto mostrar� una imagen debajo del texto de la notificaci�n
               .AddInlineImage(new Uri(@"D:\pildora_phishing.png"))
               .SetToastScenario(ToastScenario.Default)
               .SetToastDuration(ToastDuration.Short)
               .Show(toast =>
               {
                   toast.ExpirationTime = DateTime.Now.AddMinutes(1);
               });
        }

        // M�todo que se ejecutar� si se pulsa el cuerpo de la notificaci�n
        // O si se pulsa estando en el hist�rico
        private static void PulsadaNotificacionSegundoPlano()
        {
            MessageBox.Show("Has pulsado en la notificaci�n 5555.",
                "ProyectoA - Notificaci�n...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Capturar evento cuando se pulsa un bot�n en la ventana de notificaci�n Toast
        public static void BotonToastPulsado()
        {
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

                // Comprobamos si el evento recibido viene de la notificaci�n "7777" (que tiene los botones)
                if (args.Contains("IDNotificacion"))
                {
                    if (args["IDNotificacion"] == "7777")
                    {
                        // Si contiene el argumento "accion" es porque se ha pulsado uno de los botones
                        if (args.Contains("accion"))
                        {
                            // Para el bot�n de acci�n de "Visitar ProyectoA"
                            if (args["accion"] == "visitar")
                            {
                                MessageBox.Show("Ha pulsado en el bot�n de Visitar ProyectoA.",
                                    "Bot�n pulsado...", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            else if (args["accion"] == "cerrar") // Para el bot�n de acci�n de "Cerrar"
                            {
                                MessageBox.Show("Ha pulsado en el bot�n de cerrar notificaci�n.",
                                    "Bot�n pulsado...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CerrarNotificaciones();
                            }
                        }
                    }

                    // Para la notificaci�n que aceptar� la pulsaci�n en el cuerpo, tanto
                    // mientras se muestra como cuando est� en el hist�rico
                    if (args["IDNotificacion"] == "5555")
                    {
                        PulsadaNotificacionSegundoPlano();
                    }
                }
            };
        }
    }
}
