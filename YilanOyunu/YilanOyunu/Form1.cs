using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YilanOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Panel parca;
        Panel elma = new Panel();
        List<Panel> yilan = new List<Panel>();//Yilan oluşturan her liste buraya atılır.
        string yon = "sağ";


        private void label3_Click(object sender, EventArgs e)
        {
            PanelTemizle();
            label2.Text = "0";
            parca = new Panel();
            parca.Location = new Point(200, 200);
            parca.Size = new Size(20, 20);
            parca.BackColor = Color.Gray;
            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);



            timer1.Start();
            ElmaOlustur();
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ElmaYedimi();
            hareket();
            carpisma();
            int locx = yilan[0].Location.X;
            int locy = yilan[0].Location.Y;

            if (yon == "Sağ")
            {
                if (locx < 580)
                {
                    locx += 20;
                }
                else
                {
                    locx = 0;
                }
            }

            if (yon == "Sol")
            {
                if (locx > 0)
                {
                    locx -= 20;
                }
                else
                {
                    locx = 580;
                }
            }

            if (yon == "Aşağı")
            {
                if (locy < 580)
                {
                    locy += 20;
                }
                else
                {
                    locy = 0;
                }
            }

            if (yon == "Yukarı")
            {
                if (locy > 0)
                {
                    locy -= 20;
                }
                else
                {
                    locy = 580;
                }
            }

            yilan[0].Location = new Point(locx, locy);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                yon = "Sağ";
            }
            if (e.KeyCode == Keys.Left)
            { 
                yon = "Sol"; 
            }
            if (e.KeyCode == Keys.Up)
            {
                yon = "Yukarı"; 
            }

            if (e.KeyCode == Keys.Down)
            { 
                yon = "Aşağı"; 
            }

        }

        void ElmaOlustur()
        {
            Random rnd = new Random();
            int ElmaX, ElmaY;
            ElmaX=rnd.Next(580);
            ElmaY = rnd.Next(580);

            ElmaX -= ElmaX % 20;
            ElmaY -= ElmaY % 20;

            elma.Size = new Size(20, 20);
            elma.BackColor=Color.Red;
            elma.Location=new Point(ElmaX, ElmaY);

            panel1.Controls.Add(elma);
        }

        void ElmaYedimi()
        {

            int puan = Convert.ToInt32(label2.Text);
            if (yilan[0].Location==elma.Location)
            {
                panel1.Controls.Remove(elma);
                ElmaOlustur();
                puan += 50;
                label2.Text =puan.ToString();
                ParcaEkle();
            }
        }
        void ParcaEkle()
        {
            Panel ekparca = new Panel();
            ekparca.BackColor = Color.Gray;
            ekparca.Size = new Size(20, 20);

            yilan.Add(ekparca);
            panel1.Controls.Add (ekparca);
        }
        void hareket()
        {
            for(int i=yilan.Count-1;i>0;i--)
            {
                yilan[i].Location = yilan[i - 1].Location;

            }
        }
        void carpisma()
        {
            for(int i=2;i<yilan.Count;i++)
            {
                if (yilan[0].Location==yilan[i].Location)
                {
                    label4.Text = "KAYBETTİNİZ";
                    label4.Visible = true;
                    timer1.Stop();
                }

            }
        }
        void PanelTemizle()
        {
            panel1.Controls.Clear();
            yilan.Clear();
            label4.Visible=false;
            label2.Text = "0";
        }
    }
}
