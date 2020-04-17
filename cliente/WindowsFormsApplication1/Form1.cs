using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        string usuario;
        string IPservidor;
        int puertoservidor;
        public Form1(string u, string ip, int puerto, Socket srv)
        {
            InitializeComponent();
            usuario = u;
            IPservidor = ip;
            puertoservidor = puerto;
            server = srv;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (checkganador.Checked)
            {
                string mensaje = "4/" + IDpartida.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


                if (mensaje == "NO EXISTE")
                    MessageBox.Show("La partida introducida no existe.");
                else if (mensaje == "ERROR")
                    MessageBox.Show("No se ha podido realizar la búsqueda en la base de datos.");
                else
                    MessageBox.Show("Nombre del ganador: "+mensaje);
            }
            else if (checkgoles.Checked)
            {
                string mensaje = "5/" + nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


                if (mensaje == "NO EXISTE")
                    MessageBox.Show("El jugador introducido no existe.");
                else if (mensaje == "ERROR")
                    MessageBox.Show("No se ha podido realizar la búsqueda en la base de datos.");
                else
                    MessageBox.Show("Número de goles marcados: "+mensaje);

            }
            else if (checkpartidas.Checked)
            {
                string mensaje = "3/" + nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


                if (mensaje == "NO EXISTE")
                    MessageBox.Show("El jugador introducido no existe.");
                else if (mensaje == "ERROR")
                    MessageBox.Show("No se ha podido realizar la búsqueda en la base de datos.");
                else
                    MessageBox.Show("Número de partidas ganadas: "+mensaje);

            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "0/" + usuario;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            if(mensaje=="DESCONECTA")
            {
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                this.Close();
                Form2 inicio = new Form2();
                inicio.Show();
            }
            else
            {
                MessageBox.Show("ERROR EN LA DESCONEXIÓN");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string mensaje = "6/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            string[] msj = mensaje.Split('/');
            NConectados.Text = msj[0];
            msj = msj[1].Split(',');
            for(int i=0; i < msj.Length; i++)
            {
                listBox1.Items.Add(msj[i]);
            }
        }

    }
}
