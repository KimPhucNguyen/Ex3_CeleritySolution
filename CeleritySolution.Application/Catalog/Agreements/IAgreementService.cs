using CeleritySolution.ViewModels.Catalog.Agreements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeleritySolution.Application.Catalog.Agreements
{
    public interface IAgreementService
    {
        Task<int> Create(AgreementCreateRequest request);
        Task<int> Update(AgreementUpdateRequest request);
        Task<int> Delete(int AgreementId);
        Task<List<AgreementViewModel>> GetAll();
    }
}
