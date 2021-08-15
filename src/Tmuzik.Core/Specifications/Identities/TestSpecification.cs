using System;
using Ardalis.Specification;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Identities
{
    public class TestSpecification : Specification<User, LoginResponseData>
    {
        public TestSpecification(string email)
        {
            Query
                .Where(x => x.Email == email)
                .Include(x => x.Profile);

            Func<User, LoginResponseData> x = (x) => new LoginResponseData{};    
        }
    }
}