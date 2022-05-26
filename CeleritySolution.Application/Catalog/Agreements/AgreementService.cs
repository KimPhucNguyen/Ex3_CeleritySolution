using CeleritySolution.Data.EF;
using CeleritySolution.Data.Entities;
using CeleritySolution.Utilities.Exceptions;
using CeleritySolution.ViewModels.Catalog.Agreements;
using CeleritySolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeleritySolution.Application.Catalog.Agreements
{
    public class AgreementService : IAgreementService
    {
        private readonly CelerityDbContext _context;
        public AgreementService(CelerityDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(AgreementCreateRequest request)
        {
            var agreement = new Agreement()
            {
                Status = request.Status,
                QuoteNumber = request.QuoteNumber,
                AgreementName = request.AgreementName,
                AgreementType = request.AgreementType,
                EffectiveDate = request.EffectiveDate,
                ExpirationDate = request.ExpirationDate,
                CreatedDate = request.CreatedDate,
                DistributorId = request.DistributorId,
                DaysUntilExplation = request.DaysUntilExplation,
            };
            _context.Agreements.Add(agreement);
            await _context.SaveChangesAsync();
            return agreement.Id;
        }

        public async Task<int> Delete(int AgreementId)
        {
            var agreement = await _context.Agreements.FindAsync(AgreementId);
            if (agreement == null) throw new CelerityExceptions($"Cannot find a chapter: {AgreementId}");

            _context.Agreements.Remove(agreement);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<AgreementViewModel>> GetAll(GetAgreementPagingRequest request)
        {
            var query = from agreement in _context.Agreements
                        join distributor in _context.Distributors on agreement.DistributorId equals distributor.Id
                        select new { agreement, distributor };

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new AgreementViewModel()
            {
                Id = x.agreement.Id,
                Status = x.agreement.Status,
                QuoteNumber = x.agreement.QuoteNumber,
                AgreementName = x.agreement.AgreementName,
                AgreementType = x.agreement.AgreementType,
                DistributorName = x.distributor.DistributorName,
                EffectiveDate = x.agreement.EffectiveDate,
                ExpirationDate = x.agreement.ExpirationDate,
                CreatedDate = x.agreement.CreatedDate,
                DaysUntilExplation = x.agreement.DaysUntilExplation,
            }).ToListAsync();

            var pagedResult = new PagedResult<AgreementViewModel>()
            {
                TotalRecord = totalRow,
                Data = data,
            };
            return pagedResult;
        }

        public async Task<List<AgreementViewModel>> GetByAgreementName(string AgreementName)
        {
            var query = from agreement in _context.Agreements
                        join distributor in _context.Distributors on agreement.DistributorId equals distributor.Id
                        select new { agreement, distributor };

            if (!string.IsNullOrEmpty(AgreementName))
                query = query.Where(x => x.agreement.AgreementName.Contains(AgreementName));

            var data = await query.Select(x => new AgreementViewModel()
            {
                Id = x.agreement.Id,
                Status = x.agreement.Status,
                QuoteNumber = x.agreement.QuoteNumber,
                AgreementName = x.agreement.AgreementName,
                AgreementType = x.agreement.AgreementType,
                DistributorName = x.distributor.DistributorName,
                EffectiveDate = x.agreement.EffectiveDate,
                ExpirationDate = x.agreement.ExpirationDate,
                CreatedDate = x.agreement.CreatedDate,
                DaysUntilExplation = x.agreement.DaysUntilExplation,
            }).ToListAsync();

            return data;
        }

        public async Task<AgreementViewModel> GetById(int AgreementId)
        {
            var agreement = await _context.Agreements.FindAsync(AgreementId);
            if(agreement == null)
            { return null; }
            var distributor = await _context.Distributors.FirstOrDefaultAsync(x => x.Id == agreement.DistributorId);
            var agreementViewModel = new AgreementViewModel()
            {
                Id = agreement.Id,
                Status = agreement.Status,
                QuoteNumber = agreement.QuoteNumber,
                AgreementName = agreement.AgreementName,
                AgreementType = agreement.AgreementType,
                DistributorName = distributor.DistributorName,
                EffectiveDate = agreement.EffectiveDate,
                ExpirationDate = agreement.ExpirationDate,
                CreatedDate = agreement.CreatedDate,
                DaysUntilExplation = agreement.DaysUntilExplation,
            };
            return agreementViewModel;
        }

        public async Task<int> Update(AgreementUpdateRequest request)
        {
            var agreement = _context.Agreements.Find(request.Id);
            if (agreement == null) throw new CelerityExceptions($"Cannot find a product with id: {request.Id}");

            agreement.Status = request.Status;
            agreement.QuoteNumber = request.QuoteNumber;
            agreement.AgreementName = request.AgreementName;
            agreement.AgreementType = request.AgreementType;
            agreement.EffectiveDate = request.EffectiveDate;
            agreement.ExpirationDate = request.ExpirationDate;
            agreement.CreatedDate = request.CreatedDate;
            agreement.DistributorId = request.DistributorId;
            agreement.DaysUntilExplation = request.DaysUntilExplation;

            return await _context.SaveChangesAsync();
        }
    }
}
