using System;

namespace _88___Funções_interessantes_para_Strings {
    class Program {
        static void Main(string[] args) {

            string original = "Olá, meu nome é Henrique";

            string maiuscula = original.ToUpper;

            string minuscula = original.ToLower;

            string fatiada = original.Substring(2, 10);

            string semEspacosDesnecessarios = original.Trim;

            int indexItem = original.IndexOf("ri");

            int indexItem = original.LastIndexOf("ri");

            string novoNome = original.Replace("Henrique", "Joao");

            bool nulaOuVazia = String.IsNullOrEmpty(original); // null or ""

            bool nulaOuEspacos = String.IsNullOrWhiteSpace(original); // null or "      "
        }
    }
}
