using _134___Classes_Abstratas.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _134___Classes_Abstratas.Entities {
    abstract class Shape {

        public Color Color { get; set; }

        protected Shape(Color color) {
            Color = color;
        }

        // Os métodos abstratos servem para que nós possamos utiliza-lo
        // em quaisquer subclasses, independente da implementação(Polimorfismo)
        // que ocorrer nas subclasses.
        public abstract double Area();
    }
}
