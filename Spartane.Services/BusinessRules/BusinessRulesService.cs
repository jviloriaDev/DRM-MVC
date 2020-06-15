using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core;
using Spartane.Core.Domain.BusinessRule;

namespace Spartane.Services.BusinessRules
{
    public partial class BusinessRulesService: IBusinessRulesService
    {
        List<BusinessRule> _businessRulesRepository = new List<BusinessRule>()
        { 
        };
        public BusinessRule GetRuleById(int processId, int ruleId)
        {
            return _businessRulesRepository.FirstOrDefault((p) => p.IdProcess == processId && p.IdRule == ruleId);
        }

        public List<Core.Domain.BusinessRule.BusinessRule> GetRulesByProcess(int porcessId)
        {
            return _businessRulesRepository;
        }
    }
}
