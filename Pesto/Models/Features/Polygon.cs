using System.Collections.ObjectModel;

namespace ColinBaker.Pesto.Models.Features
{
    class Polygon : Shape
    {
        public Polygon() : base(ShapeType.Polygon)
        {
            this.Vertices = new Collection<Geolocation.Location>();
        }

        public Collection<Geolocation.Location> Vertices { get; set; }
    }
}
