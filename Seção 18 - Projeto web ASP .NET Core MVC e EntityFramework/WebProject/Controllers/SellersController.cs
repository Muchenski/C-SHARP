using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WebProject.Models;
using WebProject.Models.ViewModels;
using WebProject.Services;
using WebProject.Services.Exceptions;

namespace WebProject.Controllers
{
    public class SellersController:Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        // Injetando a dependência.
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _sellerService.FindAllAsynt());
        }

        public async Task<IActionResult> Create()
        {
            return View(new SellerFormViewModel { Departments = await _departmentService.FindAllAsync() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            /*
             * Caso o Javascript do navegador do usuário esteja desabilitado,
             * todas validações definidas na classe de Modelo não serão checadas,
             * fazendo com que também devamos realizar uma checagem na camada de controladores.
             * 
             * Nós apenas devemos incluir um If, verificando se a requisição realizada
             * detém o ModelState(validações definidas na classe de modelo do objeto) validado.
             */
            if(!ModelState.IsValid)
            {
                return View(new SellerFormViewModel { Seller = seller, Departments = await _departmentService.FindAllAsync() });
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided!" });
            }

            Seller seller = await _sellerService.FinfByIdAsync(id.Value);
            if(seller == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found!" });
            }

            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { Message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided!" });
            }

            Seller seller = await _sellerService.FinfByIdAsync(id.Value);
            if(seller == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found!" });
            }

            return View(seller);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided!" });
            }

            Seller seller = await _sellerService.FinfByIdAsync(id.Value);

            if(seller == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found!" });
            }

            return View(new SellerFormViewModel { Seller = seller, Departments = await _departmentService.FindAllAsync() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Seller seller)
        {
            if(!ModelState.IsValid)
            {
                return View(new SellerFormViewModel { Seller = seller, Departments = await _departmentService.FindAllAsync() });
            }

            if(id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id mismatch!" });
            }

            try
            {
                await _sellerService.UpdateAsynt(seller);
                return RedirectToAction(nameof(Index));

            }
            catch(NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { Message = e.Message });
            }
            catch(DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { Message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            ErrorViewModel error = new ErrorViewModel
            {
                Message = message,
                // Pegando o id interno da conexão
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(error);
        }
    }
}
