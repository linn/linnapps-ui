namespace Linn.LinnappsUi.Domain.Repositories
{
    using System.Collections.Generic;
    using Common;

    public interface IAuthUserNameRepository
    {
        AuthUserName GetByNumber(int userNumber);

        IEnumerable<AuthUserName> GetValidAuthUsers();
    }
}