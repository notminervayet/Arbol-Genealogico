using System.Drawing;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace Arbol_1
{
    public class MarcadorPersonalizado : GMapMarker
    {
        public Persona persona;
        private Image foto;

        public MarcadorPersonalizado(Persona persona)
            : base(new PointLatLng(persona.Latitud, persona.Longitud))
        {
            this.persona = persona;

            // Cargar foto con manejo de errores
            try
            {
                if (System.IO.File.Exists(persona.fotoPath))
                    foto = Image.FromFile(persona.fotoPath);
                else
                    foto = CrearFotoPorDefecto();
            }
            catch
            {
                foto = CrearFotoPorDefecto();
            }

            Size = new Size(50, 60);

        
            this.ToolTipText = $"{persona.GetName}\nCédula: {persona.id}";
        }

        private Image CrearFotoPorDefecto()
        {
            var bmp = new Bitmap(40, 40);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                g.DrawRectangle(Pens.Black, 0, 0, 39, 39);
            }
            return bmp;
        }

        public override void OnRender(Graphics g)
        {
            // Fondo y borde
            g.FillRectangle(Brushes.White, LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height);
            g.DrawRectangle(Pens.Black, LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height);

            // Foto
            g.DrawImage(foto, LocalPosition.X + 5, LocalPosition.Y + 5, 40, 40);
        }

      
        public override void OnMouseEnter()
        {
      //caca
        }
    }
}