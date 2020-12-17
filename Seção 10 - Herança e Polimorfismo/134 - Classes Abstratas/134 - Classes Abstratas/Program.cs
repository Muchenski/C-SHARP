using _134___Classes_Abstratas.Entities;
using _134___Classes_Abstratas.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace _134___Classes_Abstratas {
    class Program {
        static void Main(string[] args) {

            List<Shape> shapes = new List<Shape>();

            Console.Write("Enter the number of shapes: ");
            int numberOfShapes = int.Parse(Console.ReadLine());

            for(int i=0; i < numberOfShapes; i++) {

                Console.Write("\nRectangle[R] or Circle[C]? : ");
                char rectangleOrCircle = char.Parse(Console.ReadLine().Substring(0, 1).ToUpper());

                Console.Write("\nColor [BLACK-RED-BLUE]: ");
                Color color = Enum.Parse<Color>(Console.ReadLine().ToUpper());

                if(rectangleOrCircle.Equals('R')) {
                    Console.Write("\nWidth: ");
                    double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Console.Write("\nHeight: ");
                    double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Shape r = new Rectangle(color, width, height);
                    shapes.Add(r);
                
                } else if(rectangleOrCircle.Equals('C')) {
                    Console.Write("\nRadius: ");
                    double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Shape c = new Circle(color, radius);
                    shapes.Add(c);
                }

                Console.WriteLine("\n===============================");
            }

            Console.WriteLine("\n===============================");
            foreach(Shape s in shapes) {
                Console.WriteLine(s.GetType().Name + " = " + s.Area().ToString("F2", CultureInfo.InvariantCulture) + "\n");
            }
        }
    }
}
