using System;

namespace _21___Conversão_implícita_e_casting {
    class Program {
        static void Main(string[] args) {

            // EX 01:

            // Conversão implícita de tipos:

            // Como o float(4) tem menos bytes que double(8)
            // e os tipos são numéricos, conseguimos fazer esta conversão de forma IMPLÍCITA.

            float x = 4.5f;

            double y = x;

            // Conversão explícita(Casting):

            // Se tentarmos apenas "x = y", resultará em um erro.
            // Pois o compilador irá perceber que de 8(double) para 4(float) bytes
            // informações serão perdidas.

            // Por este motivo, devemos explicitar que, mesmo que ocorra perda de informações
            // ainda sim queremos realizar a conversão.

            x = (float)y;

            // EX 02:

            double b = 5.1;

            int a;

            a = (int) b;

            // EX 03:

            int k = 5;
            int g = 2;

            // Isso resultará no resultado 2, pois o tipo das duas variáveis que geram o resultado são int.
            // Mesmo que res seja double.
            double res = k / g;

            // Isso resultará no resultado 2.5.
            res = (double) k / g;
        }
    }
}
