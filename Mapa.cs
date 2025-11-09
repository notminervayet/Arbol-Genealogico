using System;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Arbol_1
{
    public partial class Mapa : Form
    {
        private GMapControl mapa;

        public Mapa()
        {
            InitializeComponent();
            InicializarMapa();
        }

        private void InicializarMapa()
        {
            
            // Crear mapa
            mapa = new GMapControl();
            mapa.Dock = DockStyle.Fill;
            mapa.MinZoom = 2;
            mapa.MaxZoom = 18;
            mapa.Zoom = 13;
            mapa.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            mapa.Position = new PointLatLng(9.934739, -84.087502); // San José, Costa Rica
            mapa.CanDragMap = true;
            mapa.DragButton = MouseButtons.Left;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            mapa.ShowCenter = false;
            this.Controls.Add(mapa);

            // Capa para los marcadores
            var overlay = new GMapOverlay("marcadores");

            // marcador de prueba del mapa
            var marcador = new GMarkerGoogle(
                new PointLatLng(9.934739, -84.087502),
                GMarkerGoogleType.red_dot
            );
            marcador.ToolTipText = "Persona 1";
            marcador.ToolTipMode = MarkerTooltipMode.OnMouseOver;

            overlay.Markers.Add(marcador);
            mapa.Overlays.Add(overlay);

            // si se toca el marcador muestra el mensaje 
            mapa.OnMarkerClick += (item, e) =>
            {
                MessageBox.Show("Tocaste a " + item.ToolTipText);
            };
        }
    }
}
