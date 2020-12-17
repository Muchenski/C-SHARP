using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebProject.Models
{
    public class Seller
    {
        public int Id { get; set; }

        // Transformando este campo em obrigatório.
        [Required(ErrorMessage = "{0} required!")]
        // Definindo limite de caracteres e uma mensagem customizada de erro.
        // 0 pega o nome do atributo, 1 pega o primeiro parâmetro e assim sucessivamente.
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} size shold be between {2} and {1}!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required!")]
        [EmailAddress(ErrorMessage = "Enter a valid email!")]
        // Definindo o tipo email para este atributo, na aplicação.
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required!")]
        // Customizando o que irá aparecer no display(DisplayNameFor) das labels da aplicação.
        [Display(Name = "Birth Date")]
        // Definindo que apenas será Data, sem horário, nos forms da aplicação.
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required!")]
        // Definindo um limite para o salário.
        [Range(1000.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}!")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        // Definindo a Chave estrangeira não nula. <NomeTabelaId>
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            SalesRecords.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            SalesRecords.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(sales => sales.Date >= initial && sales.Date <= final).Sum(sales => sales.Amount);
        }
    }
}
