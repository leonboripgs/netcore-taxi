using ApiDomain.Entities;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class MotivoCancelacionCriteria : ICriteria<MotivoCancelacion>
    {
        public Expression<Func<MotivoCancelacion, bool>> Criteria { get; private set; }

        private MotivoCancelacionCriteria() { }
        public static MotivoCancelacionCriteria Create() => new MotivoCancelacionCriteria();
        public MotivoCancelacionCriteria ById(int id)
        {
            Criteria = c => c.Id == id;
            return this;
        }
    }
}
