using _201___Problema_do_diamante.entities;
using System;

namespace _201___Problema_do_diamante {
    class Program {
        static void Main(string[] args) {

            Scanner s = new Scanner();
            s.SerialNumber = "2020";
            s.ProcessDoc("processando");
            Console.WriteLine(s.Scan());

            Console.WriteLine();

            Printer p = new Printer();
            p.SerialNumber = "3030";
            p.ProcessDoc("processando");
            p.Print("doc");

            Console.WriteLine();

            ComboDevice cd = new ComboDevice();
            cd.SerialNumber = "4040";
            cd.ProcessDoc("processando");
            Console.WriteLine(cd.Scan());
            cd.Print("doc");
        }
    }
}
