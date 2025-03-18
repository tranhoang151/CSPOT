using CSPOT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSPOT.Services
{
    public interface ITongHopCspotService
    {
        Task CalculateAndSaveTongHopCspotAsync();
        Task<List<TongHopCspot>> GetTongHopCspotDataAsync();
    }
}