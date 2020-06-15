using System;
using System.Collections.Generic;
using Spartane.Core;
using Spartane.Core.Domain.BusinessRule;

namespace Spartane.Services.BusinessRules
{
    public partial interface IBusinessRulesService
    {
        BusinessRule GetRuleById(int processId, int ruleId);
        List<BusinessRule> GetRulesByProcess(int porcessId);

    }
}
