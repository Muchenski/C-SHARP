using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_03.Entities {
    class Client {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public Client() {
        }

        public Client(int id, string name, string email, DateTime birthDate) {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override string ToString() {
            return $"Client:\n\nId: {Id}\nName: {Name}\nEmail: {Email}\nBirthDate: {BirthDate}";
        }
    }
}
