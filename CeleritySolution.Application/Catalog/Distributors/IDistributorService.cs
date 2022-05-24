using CeleritySolution.ViewModels.Catalog.Distributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeleritySolution.Application.Catalog.Distributors
{
    public interface IDistributorService
    {
        Task<int> Create(DistributorCreateRequest request);
        Task<int> Update(DistributorUpdateRequest request);
        Task<int> Delete(int DistributorId);
        Task<List<DistributorViewModel>> GetAll();
    }
}
