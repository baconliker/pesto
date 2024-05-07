using System;

namespace ColinBaker.Pesto.Models.Features
{
	internal class Point : Shape
	{
		public Point(Geolocation.Location location) : base(ShapeType.Point)
		{
			Location = location;
		}

		public Point() : base(ShapeType.Point)
		{
		}

		public Geolocation.Location Location { get; set; }
	}
}
