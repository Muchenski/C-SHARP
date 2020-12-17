using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_01.Entities {
    class Department {
        public string Name { get; set; }

        public Department() {

        }

        public Department(string name) {
            Name = name;
        }

        public override string ToString() {
            return Name;
        }
    }
}
