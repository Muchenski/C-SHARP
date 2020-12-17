using System;
using System.Collections.Generic;
using System.Text;

namespace _131___Ex_01.Entities {
    sealed class OutsourceEmployee:Employee {
        public double AdditionalCharge { get; set; }

        public OutsourceEmployee() {
        }

        public OutsourceEmployee(string name, int hours, double valuePerHour, double additionalCharge)
            : base(name, hours, valuePerHour) {
            AdditionalCharge = additionalCharge;
        }

        public override double Payment() {
            return base.Payment() + AdditionalCharge * 1.10;
        }

        public override string ToString() {
            return $"{base.ToString()}\nAdditional charge: {AdditionalCharge}";
        }
    }
}
