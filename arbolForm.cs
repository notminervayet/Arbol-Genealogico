using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol_1
{
    public partial class arbolForm : Form
    {
        private GrafoGenealogico grafo;
        public arbolForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            grafo = new GrafoGenealogico();
            this.Load += ArbolForm_Load;
            this.Paint += ArbolForm_Paint;
        }

        private void ArbolForm_Load(object sender, EventArgs e)
        {
            var fundador = new Person("Juan", "001", new DateTime(1950, 1, 1), "ejemplo");
            var hijo1 = new Person("Carlos", "002", new DateTime(1980, 3, 12), "ejemplo");
            var hija2 = new Person("Ana", "003", new DateTime(1982, 6, 5), "ejemplo");
            var padre = new Person("Pablo", "005", new DateTime(1940, 6, 5), "ejemplo");
            grafo.AddPerson(fundador);
            grafo.AddChildren(fundador, hijo1);
            grafo.AddChildren(fundador, hija2);
            grafo.AddFather(fundador, padre);
            grafo.CalculatePositions();
            this.Invalidate();
        }

        private void ArbolForm_Paint(object sender, PaintEventArgs e)
        {
            grafo.Draw(e.Graphics);
        }
    }
}
