using Guide.Entity.Context;
using Guide.Entity.Entity;
using Guide.Entity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide.Entity.Repositories
{
    public class CurrentTradingPeriodRepository : Repository<CurrentTradingPeriodEntity>, ICurrentTradingPeriodRepository
    {
        private GuideContext _appContext => (GuideContext)_context;

        public CurrentTradingPeriodRepository(GuideContext context) : base(context)
        { }

    }
}
