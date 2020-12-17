using System;
using System.Collections.Generic;
using System.Text;
using _143___Criando_exceções_personalizadas.Entities.Exceptions;

namespace _143___Criando_exceções_personalizadas.Entities {
    class Reservation {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation() {
        }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut) {

            if(checkOut <= checkIn) {
                throw new DomainException("Check-out date must be after check-in date");
            }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration() {

            // Pegando a diferença entre instantes.
            TimeSpan duration = CheckOut.Subtract(CheckIn);

            // TotalDays() ou Days() pegará o número fracionado de dias que correspondem a duração
            // total da reserva. Levando em conta mes, dia, hora, minuto, segundo, e milissegundos.
            return duration.Days;
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut) {

            DateTime now = DateTime.Now;
            if(checkIn < now || checkOut < now) {
                throw new DomainException("Reservation dates for update must be future dates");
            }
            else if(checkOut <= checkIn) {
                throw new DomainException("Check-out date must be after check-in date");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString() {
            return "Room " + RoomNumber +
                ", Check-in: " + CheckIn.ToString("dd/MM/yyyy") +
                ", Check-out: " + CheckOut.ToString("dd/MM/yyyy") +
                ", Duration: " + Duration() + " nights";
        }
    }
}
