using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Data;
using WebProject.Models;
using WebProject.Services.Exceptions;

namespace WebProject.Services
{
    public class SellerService
    {
        /*
         * Quando criamos um Controlador MVC com o Scaffold para a entidade Department,
         * não é criada uma classe para serviços.
         * Assim, ficam delegadas todas as regras de negócio ao controlador(o que não é uma boa prática).
         * 
         * Por isso, agora iremos criar toda a parte da entidade Seller "na mão".
         * Dividindo de melhor maneira as funções.
         * Deixando a parte de controladores mais limpa, e implementando as regras de negócio
         * nesta classe de serviço.
         * 
         * OBS: Não esquecer de definir esta classe como uma classe de serviço, no arquivo StartUp.
         * 
         * Quem acessa os dados, neste caso que utilizamos o EntityFramework, devem ser as classes de serviço,
         * uma vez que o nosso contexto implementa todas funcionalidades de repositories.
         */

        // readonly previne que a dependência não possa ser alterada.
        private readonly WebProjectContext _context;

        public SellerService(WebProjectContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsynt()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Seller.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FinfByIdAsync(int id)
        {
            // Include serve pra também trazermos os dados das classes associadas.
            return await _context.Seller.Include(seller => seller.Department).FirstOrDefaultAsync(seller => seller.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Seller seller = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(seller);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsynt(Seller seller)
        {

            bool hasAny = await _context.Seller.AnyAsync(sellerX => sellerX.Id == seller.Id);
            // Verificando se o Id do objeto já existe no banco.
            if(!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
