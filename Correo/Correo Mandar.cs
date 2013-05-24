using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace Correo
{
    class Correo_Mandar
    {
        SmtpClient server;
        MailMessage mensage;
        Attachment adjunto;
        string correo, password, host;
        int puerto;

        public Correo_Mandar()
        {
            server = new SmtpClient();
            mensage = new MailMessage();
        }//Fin Constructor

        public void Establecer_Iniciales(string correo, string password)
        {
            this.correo = correo; this.password = password;

            if (correo.Contains("@hotmail.com"))
            {
                host = "smtp.live.com";
                puerto = 587;
                server.EnableSsl = true;
            }
            else if (correo.Contains("@yahoo.com"))
            {
                puerto = 25;
                host = "out.izymail.com";
                server.EnableSsl = false;
            }
            else if (correo.Contains("@gmail.com") || correo.Contains("@unitec.edu"))
            {
                host = "smtp.gmail.com";
                puerto = 587;
                server.EnableSsl = true;
            }

            server.Host = this.host;
            server.Port = this.puerto;
            server.Credentials = new System.Net.NetworkCredential(correo, password);
        }//Establece q servidor, puerto, eh inicia sessio.

        public void Enviar_Correo(string correo_a_enviar, string mensaje)
        {
            Array a;
            a = correo_a_enviar.Split(';');
            string tmp;

            for (int i = 0; i < a.Length-1; i++)
            {
                tmp = a.GetValue(i).ToString() as string;
                if (!tmp.Equals(""))
                {
                    mensage.From = new System.Net.Mail.MailAddress(this.correo);
                    mensage.To.Add(tmp);
                    mensage.Subject = "";
                    mensage.Body = mensaje;
                }
            }
            server.Send(mensage);

            System.Windows.Forms.MessageBox.Show("Correo Enviado Exitosamente");
        }//Enviar correo sin tema

        public void Enviar_Correo(string correo_a_enviar, string tema, string mensaje)
        {
            Array a;
            a = correo_a_enviar.Split(';');
            string tmp;

            for (int i = 0; i < a.Length - 1; i++)
            {
                tmp = a.GetValue(i).ToString() as string;
                if (!tmp.Equals(""))
                {
                    mensage.From = new System.Net.Mail.MailAddress(correo);
                    mensage.To.Add(tmp);
                    mensage.Subject = tema;
                    mensage.Body = mensaje;
                }
            }
            server.Send(mensage);

            System.Windows.Forms.MessageBox.Show("Correo Enviado Exitosamente");
        }//Enviar correo tema

        public void Enviar_Correo_Ruta(string correo_a_enviar, string mensaje, string ruta)
        {
            Array a;
            a = correo_a_enviar.Split(';');
            string tmp;

            for (int i = 0; i < a.Length - 1; i++)
            {
                tmp = a.GetValue(i).ToString() as string;
                if (!tmp.Equals(""))
                {
                    adjunto = new System.Net.Mail.Attachment(ruta);
                    mensage.From = new System.Net.Mail.MailAddress(correo);
                    mensage.To.Add(tmp);
                    mensage.Subject = "";
                    mensage.Body = mensaje;
                    mensage.Attachments.Add(adjunto);
                }
            }
            server.Send(mensage);

            System.Windows.Forms.MessageBox.Show("Correo Enviado Exitosamente");
        }//Enviar correo con archivo y sin tema

        public void Enviar_Correo(string correo_a_enviar, string tema, string mensaje, string ruta)
        {
            Array a;
            a = correo_a_enviar.Split(';');
            string tmp;

            for (int i = 0; i < a.Length - 1; i++)
            {
                tmp = a.GetValue(i).ToString() as string;
                if (!tmp.Equals(""))
                {
                    adjunto = new System.Net.Mail.Attachment(ruta);
                    mensage.From = new System.Net.Mail.MailAddress(correo);
                    mensage.To.Add(tmp);
                    mensage.Subject = tema;
                    mensage.Body = mensaje;
                    mensage.Attachments.Add(adjunto);
                }
            }
                server.Send(mensage);

            System.Windows.Forms.MessageBox.Show("Correo Enviado Exitosamente");
        }//Enviar correo completo
    }
}