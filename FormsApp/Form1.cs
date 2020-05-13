using GraphDataStructureAndDijkstra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        List<int[]> coords;

        public Form1()
        {
            InitializeComponent();
            drawGraphics = drawArea.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GenerateGraph(int numberOfVertices)
        {
            GraphGenerator gg = new GraphGenerator();
            Graph g = gg.Generate(numberOfVertices);
            coords = getRandomCoords(g.NumberOfVertices);
            this.g = g;
        }

        private Graphics PaintGraph()
        {
            Graphics graphics;
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
            return graphics = drawGraphics;
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

                coords.Add(new int[] { x * 90, y * 60 });

            }


            return coords;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int start = -1;
            int end = -1;
            for (int i = 0; i < g.NumberOfVertices; i++)
            {
                if (g.Vertices[i].Name == tbStartNode.Text.ToUpper())
                {
                    start = i;
                }
                if (g.Vertices[i].Name == tbEndNode.Text.ToUpper())
                {
                    end = i;
                }
            }
            Dijkstra d = new Dijkstra(g,start, end);
            var path = d.SearchFromTo(start, end);
            tbResult.Clear();
            for (int i = path.Count - 1; i > -1; i--)
            {
                tbResult.AppendText("\r\n" + g.Vertices[path[i]].Name);
            }
            tbResult.AppendText("\r\n" + d.ShortestDistances[end]);
            PrintShortestPath(path);
        }

        public void PrintShortestPath(List<int> path)
        {
            drawArea.Refresh();
            PaintGraph();
            Pen pen = new Pen(Color.Red, 5);
            for (int i = 0; i < path.Count -1; i++)
            {
                int[] kVertex = coords[path[i]];
                int[] lVertex = coords[path[i + 1]];
                int x1, x2, y1, y2;
                x1 = kVertex[0];
                x2 = lVertex[0];
                y1 = kVertex[1];
                y2 = lVertex[1];

                
                drawGraphics.DrawLine(pen, kVertex[0] + 50, kVertex[1] + 50, lVertex[0] + 50, lVertex[1] + 50);


            }
        }


        private void brnGenerateGraph_Click(object sender, EventArgs e)
        {
            GenerateGraph(trackBar.Value + 5);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = (5+trackBar.Value).ToString();
            GenerateGraph(trackBar.Value + 5);
            drawArea.Refresh();
            PaintGraph();
        }
    }
}
