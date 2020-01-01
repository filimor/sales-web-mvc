using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Resources;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync().ConfigureAwait(false);
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).
                FirstOrDefaultAsync(obj => obj.Id == id).ConfigureAwait(false);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Seller obj = await _context.Seller.FindAsync(id).ConfigureAwait(false);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateException)
            {
                //throw new IntegrityException(e.Message);
                throw new IntegrityException("Can't delete seller because he/she has sales");
            }
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id).ConfigureAwait(false);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            // Intercepta uma execão na camada de acesso a dados
            catch (DbUpdateConcurrencyException e)
            {
                // Relança usando a exceção a nível de serviço
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}