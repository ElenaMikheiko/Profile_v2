using System.Collections.Generic;

namespace Profile.Service.Services.Interfaces
{
    public interface ITrainerService
    {
        IList<string> GetTrainerEmailsByRoleName(string roleName);
    }
}
