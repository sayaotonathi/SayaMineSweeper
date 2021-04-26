using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweaper
{
    public partial class Form1 : Form
    {
        int xCount = 9;
        int yCount = 9;
        Button[,] btn ;
        GameClass theGame = GameClass.Instance();
        int[,] mineMap = new int[9, 9];

        public Form1()
        {
            InitializeComponent();
            generateButtons();
        }

        

        private void generateButtons()
        {
            btn = new Button[xCount, yCount];
            this.SuspendLayout();
            for (int y = 0; y < yCount; y++)
            {
                for (int x = 0; x < xCount; x++)
                {
                    btn[x, y] = new Button();
                    btn[x, y].Size = new Size(30, 30);
                    btn[x, y].Location = new Point(10 + 31 * x, 10 + 31 * y);
                    btn[x, y].Name = ((x + 1) * (y + 1)).ToString();
                    btn[x, y].Click += new System.EventHandler(btn_Click);
                    btn[x, y].EnabledChanged += new System.EventHandler(this.btn_EnabledChanged);
                    this.splitContainer1.Panel2.Controls.Add(btn[x, y]);
                    theGame.setMine(mineMap);
                    //theGame.scanMine(xCount, yCount, mineMap);
                }
            }
            this.ResumeLayout();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            //MessageBox.Show(btn.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            theGame.setMine(mineMap);
            string s = "";
            theGame.scanMine(xCount, yCount, mineMap);
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    s += mineMap[i, j].ToString().PadLeft(2,' ' ) + " ";
                }
                s += "\n";
            }
            Console.WriteLine(s);
        }

        private void btn_EnabledChanged(object sender, EventArgs e)
        {
            theGame.autoFlip(xCount, yCount, mineMap, btn);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "";
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    s += mineMap[i, j].ToString().PadLeft(2, ' ') + " ";
                }
                s += "\n";
            }
            Console.WriteLine(s);
        }
    }
}
