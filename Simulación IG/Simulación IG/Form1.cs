/*
        Universidad Autónoma de San Luis Potosí
                Facultad de Ingeniería
                
          Ingeniería en Sistemas Inteligentes
          Interfaces Gráficas con Aplicaciones
        Alumnos:
            -Villagrán Saucedo Gabriel Aldair.
            -Cerda Estrada José Martín.
        
        Profesor:
            -Dr. Alberto Salvador Núñez Varela.

Proyecto: Simulación Colisiones de Múltiples Objetos.
Proyecto correspondiente al segundo parcial de la materia. El fin de este proyecto
es el de la implementación de múltiples hilos (N hilos en este caso). En nuestro caso
un hilo es creado cada vez que se genera un nuevo planeta. El hilo se encarga de calcular 
la posición del objeto en el mundo (la forma principal) así como la verificación de si el 
objeto del cual está encargado se encuentra colisionando con algún otro objeto.
 
Las imágenes utilizadas para este proyecto se encuentra en la carpeta Resources.
 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Simulación_IG
{
    public partial class Mundo : Form
    {
        Image canon;//Variable para guardar imagen del cañon.
                    //Esta imagen no es guardada en un PictureBox.
        int angulo;//Para el manejo de el cañon.
        int xCan, yCan;//Posición del cañon.
        int contPlanetas = 0;//Lleva el conteo de cuantos planetas han sido creados.
        int kGravedad = 100;//Constante de gravedad implementada para este proyecto.
        int swPl = 1;//Variable de control para alternar imagen de los planetas creados.
        List<int> pesos = new List<int>();//Almacena la información de los pesos de los planetas.
        List<PictureBox> planetas = new List<PictureBox>();//Lista que almacena los planetas (PictureBox).
        List<Thread> hilos = new List<Thread>();//Almacena la referencia de los hilos para la creación de N hilos.



        public Mundo()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//Usado para poder interactuar con el
                                                    //mundo desde los hilos. No tocar.
        }

        private void Mundo_Load(object sender, EventArgs e)
        {
            //Carga de la imagen del cañon.      
            canon = global::Simulación_IG.Properties.Resources.cañon_1;
            //Posición del cañon.
            xCan = this.Width / 2 - canon.Width / 2;
            yCan = this.Height - canon.Height - 15;
        }

        /*
        *Al tener que realizar una rotación con el cañon, 
        *utilizamos esta implementación en lugar de hacer uso de 
        *un PictureBox.
        */
        private void Mundo_Paint(object sender, PaintEventArgs e)
        {           
            //Dibujado de cañon y control           
            Bitmap bm = new Bitmap(canon.Width, canon.Height);
            Graphics cn = Graphics.FromImage(bm);
            cn.TranslateTransform(bm.Width/2,bm.Height/2);
            cn.RotateTransform(angulo*5);
            cn.TranslateTransform(-bm.Width / 2, -bm.Height / 2);
            cn.InterpolationMode = InterpolationMode.HighQualityBicubic;
            cn.DrawImage(canon, 0, 0);
            e.Graphics.TranslateTransform(xCan, yCan);
            e.Graphics.DrawImage(bm, 0, 0);
        }

        /*Al hacer clic en disparar se procede a la creación del planeta 
         * para luego crear el hilo encargado de controlar el planeta.
        */
        private void btnDisparar_Click(object sender, EventArgs e)
        {
            creaPlaneta();
            simulaPlaneta();

        }

        /*
         * Debido a que usamos PictureBox tenemos que setear los valores
         * del PictureBox creado de forma manual.
         */
        private void creaPlaneta()
        {
            PictureBox planeta = new PictureBox();//creación del PictureBox.
            //Aquí inicia el seteo de valores.
            planeta.BackColor = System.Drawing.Color.Transparent;
            //Usamos switch para alternar la imagen que usará el PictureBox.
            switch(swPl)
            {
                case 1: planeta.Image = global::Simulación_IG.Properties.Resources.planet_33;
                    break;
                case 2: planeta.Image = global::Simulación_IG.Properties.Resources.planet_35;
                    break;
                case 3: planeta.Image = global::Simulación_IG.Properties.Resources.planet_39;
                    break;
                case 4: planeta.Image = global::Simulación_IG.Properties.Resources.planet_41;
                    break;
                case 5: planeta.Image = global::Simulación_IG.Properties.Resources.planet_42;
                    break;

            }            
            planeta.Location = new Point(xCan, yCan);
            planeta.Name = "Planeta" + contPlanetas.ToString();
            planeta.Size = new System.Drawing.Size(50, 50);
            planeta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            planeta.Show();

            //Se agrega el planeta a la lista de planetas.
            planetas.Add(planeta);           
            //Se debe de agregar el PictureBox a la lista de controles de la forma.
            this.Controls.Add(planeta);
            //Se agrega el peso encontrado en el TextBox y queda asociado al planeta.
            pesos.Add(int.Parse(txtPeso.Text));
            //Condicional utilizado para "ciclar" el switch.
            if (swPl == 5)
                swPl = 1;
            else
                swPl++;

        }

        /*
         * Función encargada de la creación de los hilos así 
         * como el agregado del hilo a la lista de hilos.
         */
        private void simulaPlaneta()
        {
            //Usamos como delegado la función movimientoPlaneta.
            Thread hilo = new Thread(movimientoPlaneta);
            hilo.Start();
            hilos.Add(hilo);
        }

        private void movimientoPlaneta()
        {
            int nPlnt = planetas.Count - 1;//Cada hilo recibe el índice con el que
                                           //tendrá acceso al planeta -peso en las listas
                                           //correspondientes.
            int velocidad = kGravedad/pesos[nPlnt];//Función encargada de controlar la velocidad
                                                   //en base a la constante y el peso del planeta.
            int x = velocidad * (angBar.Value/3) * -1;//Varibale para control del movimiento a lo ancho
                                                      //basado en el ángulo de tiro y la velocidad.
            int y = velocidad;//Varibale para control del movimiento a lo ancho.            
            Point pos = new Point();//Punto para tener datos de la posición del planeta.
            

            /*
             * Ciclo infinito en cada hilo para estar constantemente realizando los
             * cálculos necesarios.
             */
            while (true)
            {
                //Se obtiene la posición actual.
                pos = planetas[nPlnt].Location;
                int X = pos.X;
                int Y = pos.Y;                
                //verificación para mantener al planeta dentro del mundo.
                if (Y <= 0 || Y >= this.Height)
                {
                    if (x == 0)
                        x = velocidad;//Variar el movimiento en casod e tiro 90°.
                    y *= -1;
                }
                if (X <= 0 || X >= this.Width)
                    x *= -1;

                //Aquí buscamos si se está realizando alguna colisión.
                foreach (PictureBox c in planetas)
                {
                   if(planetas[nPlnt].Bounds.IntersectsWith(c.Bounds) && !c.Equals(planetas[nPlnt]))
                    {
                        //Se aplican los efectos de la colisión.
                        x *= -1;
                        y *= -1;                        
                    }
                   
                }

                //Cambio de posición para generar el movimiento.
                planetas[nPlnt].Location = new Point(pos.X-x, pos.Y-y);                
                
                Thread.Sleep(120);//Se usa para poder visualizar de mejor manera el movimiento.
                                 //También controlamos los fotogramas.
            }
        }

        //Función para el cierre de hilos al momento de cerrar la ventana.
        private void Mundo_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(Thread t in hilos)
            {
                t.Abort();
            }
        }


        //Obtenemos el valor del ángulo con el trackBar (Valores de -10 a 10).
        private void angBar_ValueChanged(object sender, EventArgs e)
        {
            angulo = angBar.Value;
            Invalidate();
        }
    }
}
