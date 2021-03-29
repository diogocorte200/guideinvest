using Guide.Domain.Domain;
using Guide.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Guide.Domain.Interfaces
{
    public interface IFinanceService
    {
        IEnumerable<FinanceEntity> GetFinances();
        Task<Finance> InsertFinances();
    }
}
