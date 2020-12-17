using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Services
{
    public class SalesRecordService
    {

        private readonly WebProjectContext _context;

        public SalesRecordService(WebProjectContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            IQueryable<SalesRecord> result = from salesRecord in _context.SalesRecord select salesRecord;

            if(minDate.HasValue)
            {
                result = result.Where(sale => sale.Date >= minDate.Value);
            }
            if(maxDate.HasValue)
            {
                result = result.Where(sale => sale.Date <= maxDate.Value);
            }

            return await result
                .Include(sales => sales.Seller)
                .Include(sale => sale.Seller.Department)
                .OrderByDescending(sales => sales.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            IQueryable<SalesRecord> result = from salesRecord in _context.SalesRecord select salesRecord;

            if(minDate.HasValue)
            {
                result = result.Where(sale => sale.Date >= minDate.Value);
            }
            if(maxDate.HasValue)
            {
                result = result.Where(sale => sale.Date <= maxDate.Value);
            }

            return await result
                .Include(sales => sales.Seller)
                .Include(sale => sale.Seller.Department)
                .OrderByDescending(sales => sales.Date)
                .GroupBy(sales => sales.Seller.Department)
                .ToListAsync();
        }
    }
}
