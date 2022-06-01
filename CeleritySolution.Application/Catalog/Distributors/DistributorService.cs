using CeleritySolution.Data.EF;
using CeleritySolution.Data.Entities;
using CeleritySolution.Utilities.Exceptions;
using CeleritySolution.ViewModels.Catalog.Distributors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeleritySolution.Application.Catalog.Distributors
{
    public class DistributorService : IDistributorService
    {
        private readonly CelerityDbContext _context;
        public DistributorService(CelerityDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DistributorCreateRequest request)
        {
            var distributor = new Distributor()
            {
                DistributorName = request.DistributorName,
            };
            _context.Distributors.Add(distributor);
            await _context.SaveChangesAsync();
            return distributor.Id;
        }

        public async Task<int> Delete(int DistributorId)
        {
            var distributor = await _context.Distributors.FindAsync(DistributorId);
            if (distributor == null) throw new CelerityExceptions($"Cannot find a chapter: {DistributorId}");

            _context.Distributors.Remove(distributor);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DistributorViewModel>> GetAll()
        {
            var query = from distributor in _context.Distributors
                        select new { distributor };

            var data = await query.Select(x => new DistributorViewModel()
            {
                Id = x.distributor.Id,
                DistributorName = x.distributor.DistributorName
            }).ToListAsync();

            return data;
        }

        public async Task<int> Update(DistributorUpdateRequest request)
        {
            var distributor = _context.Distributors.Find(request.Id);
            if (distributor == null) throw new CelerityExceptions($"Cannot find a product with id: {request.Id}");

            distributor.DistributorName = request.DistributorName;

            return await _context.SaveChangesAsync();
        }
    }
}
