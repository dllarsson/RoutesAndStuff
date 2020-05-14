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
    public partial class FormRouteCity : Form
    {

        Graphics drawGraphics;
        Graph graph;
        List<int[]> coords;

        public FormRouteCity()
        {
            InitializeComponent();
            drawGraphics = drawArea.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GenerateGraph(int numberOfVertices)
        {
            GraphGenerator graphGenerator = new GraphGenerator();
            Graph graph = graphGenerator.Generate(numberOfVertices);
            coords = getRandomCoords(graph.NumberOfVertices);
            this.graph = graph;
        }

        private Graphics PaintGraph()
        {
            Graphics graphics;
            Pen blackPen = new Pen(Color.Black);
            Pen redPen = new Pen(Color.Red);
            Pen bluePen = new Pen(Color.Blue);


            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                int[] xyCoords = coords[i];

                var vertexName = graph.Vertices[i].Name;

                drawGraphics.DrawEllipse(blackPen, xyCoords[0], xyCoords[1], 100, 100);
                drawGraphics.DrawString(vertexName, new System.Drawing.Font("Arial", 30), redPen.Brush, xyCoords[0] + 25, xyCoords[1] + 25);



            }
            for (int k = 0; k < graph.NumberOfVertices; k++)
            {
                for (int l = 0; l < graph.NumberOfVertices; l++)
                {
                    if (graph.AdjacenyMatrix[k, l] > 0) //Edge between vertex k and vertex l
                    {
                        int[] firstVertexCoords = coords[k];
                        int[] secondVertexCoords = coords[l];
                        int weightX = 0;
                        int weightY = 0;
                        if (secondVertexCoords[0] > firstVertexCoords[0])
                        {
                            weightX = (firstVertexCoords[0] + secondVertexCoords[0]) / 2;
                            weightY = (firstVertexCoords[1] + secondVertexCoords[1]) / 2;
                        }
                        else
                        {
                            weightX = (secondVertexCoords[0] + firstVertexCoords[0]) / 2;
                            weightY = (secondVertexCoords[1] + firstVertexCoords[1]) / 2;
                        }
                        int weight = graph.AdjacenyMatrix[k, l];

                        drawGraphics.DrawString(weight.ToString(), new System.Drawing.Font("Arial", 30), bluePen.Brush, weightX, weightY);

                        drawGraphics.DrawLine(blackPen, firstVertexCoords[0] + 50, firstVertexCoords[1] + 50, secondVertexCoords[0] + 50, secondVertexCoords[1] + 50);
                    }
                }
            }
            return graphics = drawGraphics;
        }

        private List<int[]> getRandomCoords(int numberOfVertices)
        {
            Random randomCoords = new Random();
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
                var x = xCoords[randomCoords.Next(xCoords.Count)];
                var y = yCoords[randomCoords.Next(yCoords.Count)];

                xCoords.Remove(x);
                yCoords.Remove(y);

                coords.Add(new int[] { x * 90, y * 60 });

            }


            return coords;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            int start = -1;
            int end = -1;
            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                if (graph.Vertices[i].Name == tbStartNode.Text.ToUpper())
                {
                    start = i;
                }
                if (graph.Vertices[i].Name == tbEndNode.Text.ToUpper())
                {
                    end = i;
                }
            }


            
            Dijkstra dijkstra = new Dijkstra(graph,start);
            var path = dijkstra.SearchFromTo(start, end);
            tbResult.Clear();
            for (int i = graph.NumberOfVertices - 1; i > -1; i--)
            {
                tbResult.AppendText("\r\n" + graph.Vertices[i].Name + "  Distance: " + dijkstra.ShortestDistances[i] + " via vertex: " + graph.Vertices[dijkstra.PreviousVertices[i]].Name);
            }
            PrintShortestPath(path);
        }

        public void PrintShortestPath(List<int> path)
        {
            drawArea.Refresh();
            PaintGraph();
            Pen redPen = new Pen(Color.Red, 5);
            for (int i = 0; i < path.Count -1; i++)
            {
                int[] firstVertexCoords = coords[path[i]];
                int[] secondVertexCoords = coords[path[i + 1]];
                
                drawGraphics.DrawLine(redPen, firstVertexCoords[0] + 50, firstVertexCoords[1] + 50, secondVertexCoords[0] + 50, secondVertexCoords[1] + 50);


            }
        }


        private void brnGenerateGraph_Click(object sender, EventArgs e)
        {
            GenerateGraph(trackBar.Value + 5);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            lblVerticesNumber.Text = (5+trackBar.Value).ToString();
            GenerateGraph(trackBar.Value + 5);
            drawArea.Refresh();
            PaintGraph();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            drawArea.Refresh();
        }
    }
}
