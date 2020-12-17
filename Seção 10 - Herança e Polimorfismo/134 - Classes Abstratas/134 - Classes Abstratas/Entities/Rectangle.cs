using System;
using System.Collections.Generic;
using System.Text;
using _134___Classes_Abstratas.Entities.Enums;

namespace _134___Classes_Abstratas.Entities {
    class Rectangle:Shape {

        public double width { get; set; }
        public double height { get; set; }

        public Rectangle(Color color, double width, double height) : base(color) {
            this.width = width;
            this.height = height;
        }

        public override double Area() {
            return width * height;
        }
    }
}
