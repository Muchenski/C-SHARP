using System;
using System.Collections.Generic;
using System.Text;
using _134___Classes_Abstratas.Entities.Enums;

namespace _134___Classes_Abstratas.Entities {
    class Circle:Shape {

        public double Radius { get; set; }

        public Circle(Color color, double radius): base(color) {
            Radius = radius;
        }

        public override double Area() {
            return Math.PI * (Radius * Radius);
        }
    }
}
