﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _131___Ex_01.Entities {
    class Employee {
        public string Name { get; set; }
        public int Hours { get; set; }
        public double ValuePerHour { get; set; }

        public Employee() {
        }

        public Employee(string name, int hours, double valuePerHour) {
            Name = name;
            Hours = hours;
            ValuePerHour = valuePerHour;
        }

        public virtual double Payment() {
            return Hours * ValuePerHour;
        }

        public override string ToString() {
            return $"Name: {Name}\nHours: {Hours}\nValue per hour: {ValuePerHour}\nPayment: {Payment()}";
        }
    }
}
