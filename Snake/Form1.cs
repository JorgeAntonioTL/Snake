using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Snake
{
    public partial class Form1 : Form
    {
        private PictureBox rectangulo = new PictureBox();
        public static int tama = 10, casilla=tama/2;
        public static int divLin = 600 / tama;
        public static PictureBox cabeza_box = new PictureBox();
        public static PictureBox cuerpo_box = new PictureBox();
        public static PictureBox cola_box = new PictureBox();



        static int[,] esc = new int[tama, tama];
        private static System.Timers.Timer tiempo;


        public Form1()
        {
            InitializeComponent();
            Console.WriteLine(casilla);
            Console.WriteLine(divLin);
            escenario();
            SetTimer();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            rectangulo.Dock = DockStyle.Fill;
            rectangulo.BackColor = Color.White;
            rectangulo.Paint += new System.Windows.Forms.PaintEventHandler(this.rectangulo_Paint);
            rectangulo.Paint += new System.Windows.Forms.PaintEventHandler(this.cabeza);
            rectangulo.Paint += new System.Windows.Forms.PaintEventHandler(this.cuerpo);
            rectangulo.Paint += new System.Windows.Forms.PaintEventHandler(this.cola);

            this.Controls.Add(rectangulo);

        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            tiempo = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            tiempo.Elapsed += vueltaTiempo;
            tiempo.AutoReset = true;
            tiempo.Enabled = true;
        }
        private static void vueltaTiempo(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("entro");
            cabeza_box.Location = new Point(cabeza_box.Location.X+100, cabeza_box.Location.Y+0);
        }
        private void rectangulo_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen greenPen = new Pen(Color.Green, 3);
            int x = 50;
            int y = 50;
            int width = 600;
            int height = 600;
            g.DrawRectangle(greenPen, x, y, width, height);
            for (float i = divLin + 50; i <= 650; i = i + divLin)
            {
                //trace("linea",cont);
                g.DrawLine(System.Drawing.Pens.Black, i, 50, i, 650);
            }
            for (float i = divLin + 50; i <= 650; i = i + divLin)
            {
                //trace("linea",cont);
                g.DrawLine(System.Drawing.Pens.Black, 50, i, 650, i);
            }

                                     
        }
        public void escenario()
        {
            int [,] esc = new int[tama,tama];
            for (int i = 0; i < tama; i++)
            {
                for (int j = 0; j < tama; j++)
                {
                    esc[i,j]=0;
                }
            }
        }
        /*public void Lineas()
        {
            Pen greenPen = new Pen(Color.Green, 3);
            int x = 50;
            int y = 50;
            int width = 600;
            int height = 600;
            Graphics rect;
            //rect.DrawRectangle(greenPen, x, y, width, height);

            for (int hor = 50 + divLin; hor < 650; hor = hor + divLin)
            {
                //trace("linea",cont);
                arrL1[contL1] = new Sprite();
                arrL1[contL1].graphics.lineStyle(1, 0x000100);
                arrL1[contL1].graphics.moveTo(hor, 650);
                arrL1[contL1].graphics.lineTo(hor, 50);
                addChild(arrL1[contL1]);
                contL1++;
            } //
        }*/ //LEGACY

        /*public void gusanito(object sender, PaintEventArgs e)
        {
            /*Graphics cabe = e.Graphics;
            RectangleF cabeRec = new RectangleF(casilla  * divLin +50, casilla * divLin+50, divLin, divLin);
            cabe.FillRectangle(greenBrush, cabeRec);*
                        SolidBrush greenBrush = new SolidBrush(Color.Green);

            Graphics ojo = e.Graphics;
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            RectangleF ojoCir = new RectangleF(casilla * divLin+60, casilla * divLin+57, 10, 10);
            ojo.FillEllipse(blackBrush, ojoCir);

            Graphics cuer = e.Graphics;
            RectangleF cuerRec = new RectangleF(casilla * divLin - (divLin)+50, casilla * divLin + 50, divLin, divLin);
            cuer.FillRectangle(greenBrush, cuerRec);

            Graphics cola = e.Graphics;
            RectangleF colaRec = new RectangleF(casilla * divLin - (2 * divLin)+50, casilla * divLin + 50, divLin, divLin);
            cola.FillRectangle(greenBrush, colaRec);
            /*PartSnake serpi = new PartSnake();
            serpi.piezaSnake();
        }*/
        public void cabeza(object sender, PaintEventArgs e)
        {
            
            cabeza_box.Name = ("cabeza");
            cabeza_box.Width = (divLin);
            cabeza_box.Height = (divLin);
            cabeza_box.Location = new Point(casilla, casilla);
            Bitmap flagCabe = new Bitmap(divLin, divLin);
            Graphics flagCabeza = Graphics.FromImage(flagCabe);
            Graphics cabe = e.Graphics;
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            RectangleF cabeRec = new RectangleF(casilla * divLin + 50, casilla * divLin + 50, divLin, divLin);
            flagCabeza.FillRectangle(greenBrush, cabeRec);
            //cabe.FillRectangle(greenBrush, cabeRec);
            Graphics ojo = e.Graphics;
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            RectangleF ojoCir = new RectangleF(casilla * divLin + 60, casilla * divLin + 57, 10, 10);
            flagCabeza.FillEllipse(blackBrush, ojoCir);
            cabeza_box.Image = flagCabe;
            this.Controls.Add(cabeza_box);
        }
        public void cuerpo(object sender, PaintEventArgs e)
        {
            cuerpo_box.Name = ("cuerpo");
            cuerpo_box.Width = (divLin);
            cuerpo_box.Height = (divLin);
            cuerpo_box.Location = new Point(casilla-divLin, casilla);
            Graphics cuer = e.Graphics;
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            RectangleF cuerRec = new RectangleF(casilla * divLin - (divLin) + 50, casilla * divLin + 50, divLin, divLin);
            cuer.FillRectangle(greenBrush, cuerRec);
        }
        public void cola(object sender, PaintEventArgs e)
        {
            cola_box.Name = ("cola");
            cola_box.Width = (divLin);
            cola_box.Height = (divLin);
            cola_box.Location = new Point(casilla-divLin*2, casilla);
            Graphics cuer = e.Graphics;
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            RectangleF cuerRec = new RectangleF(casilla * divLin - (divLin*2) + 50, casilla * divLin + 50, divLin, divLin);
            cuer.FillRectangle(greenBrush, cuerRec);
        }
    }
        public partial class PartSnake
    {
        public static int tama = 20, casilla = tama / 2;
        public static float divLin = 600 / tama;
        public void piezaSnake()
        {   
        }
    }
}
