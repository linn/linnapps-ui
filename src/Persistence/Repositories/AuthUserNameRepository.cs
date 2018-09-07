namespace Linn.LinnappsUi.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Common;
    using Domain.Repositories;

    public class AuthUserNameRepository : IAuthUserNameRepository
    {
        private readonly ServiceDbContext serviceDbContext;

        public AuthUserNameRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public AuthUserName GetByNumber(int userNumber)
        {
            return this.serviceDbContext.AuthUserName
                .SingleOrDefault(s => s.UserNumber == userNumber);
        }

        public IEnumerable<AuthUserName> GetValidAuthUsers()
        {
            return this.serviceDbContext.AuthUserName
                .Where(a => a.DateInvalid == null).OrderBy(d => d.Name);
        }
    }
}