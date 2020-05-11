using GraphDataStructureAndDijkstra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class Form1 : Form
    {

        Graphics drawGraphics;

        Graph g;

        public Form1()
        {
            InitializeComponent();
            drawGraphics = drawArea.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_GenerateGraph(object sender, EventArgs e)
        {
            GraphGenerator gg = new GraphGenerator();
            Graph g = gg.Generate(int.Parse(tbNumberOfVertices.Text));
            this.g = g;
            var coords = getRandomCoords(g.NumberOfVertices);
            Pen pen = new Pen(Color.Black);
            Pen pen2 = new Pen(Color.Red);
            Pen pen3 = new Pen(Color.Blue);


            for (int i = 0; i < g.Vertices.Count; i++)
            {
                int[] xy = coords[i];

                var vertexName = g.Vertices[i].Name;

                drawGraphics.DrawEllipse(pen, xy[0], xy[1], 100, 100);
                drawGraphics.DrawString(vertexName, new System.Drawing.Font("Arial", 30), pen2.Brush, xy[0] + 25, xy[1] + 25);


             
            }
            for (int k = 0; k < g.NumberOfVertices; k++)
            {
                for (int l = 0; l < g.NumberOfVertices; l++)
                {
                    if (g.AdjacenyMatrix[k, l] > 0) //Edge between vertex k and vertex l
                    {
                        int[] kVertex = coords[k];
                        int[] lVertex = coords[l];
                        int weightX = 0;
                        int weightY = 0;
                        if (lVertex[0] > kVertex[0])
                        {
                            weightX = (kVertex[0] + lVertex[0]) / 2;
                             weightY = (kVertex[1] + lVertex[1]) / 2;
                        }
                        else
                        {
                             weightX = (lVertex[0] + kVertex[0]) / 2;
                             weightY = (lVertex[1] + kVertex[1]) / 2;
                        }
                        int weight = g.AdjacenyMatrix[k, l];

                        drawGraphics.DrawString(weight.ToString(), new System.Drawing.Font("Arial", 30), pen3.Brush, weightX, weightY);

                        drawGraphics.DrawLine(pen, kVertex[0] + 50, kVertex[1] + 50, lVertex[0] + 50, lVertex[1] + 50);
                    }
                }
            }

        }

        private List<int[]> getRandomCoords(int numberOfVertices)
        {
            Random r = new Random();
            List<int[]> coords = new List<int[]>();
            List<int> xCoords = new List<int>();
            List<int> yCoords = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                xCoords.Add(i);
                yCoords.Add(i);
            }
            for (int i = 0; i < numberOfVertices; i++)
            {
                var x = xCoords[r.Next(xCoords.Count)];
                var y = yCoords[r.Next(yCoords.Count)];

                xCoords.Remove(x);
                yCoords.Remove(y);

                coords.Add(new int[] { x * 50, y * 50 });

            }


            return coords;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.g = null;
            drawArea.Image = null;
        }
    }
}
