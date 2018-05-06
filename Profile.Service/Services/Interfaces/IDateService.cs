using System.Collections.Generic;

namespace Profile.Service.Services.Interfaces
{
    public interface IDateService
    {
        IEnumerable<int> GetAllYears();

        Dictionary<int, string> GetAllMonths();
    }
}
