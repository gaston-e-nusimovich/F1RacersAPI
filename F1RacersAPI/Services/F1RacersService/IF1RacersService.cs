using F1RacersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace F1RacersAPI.Services.F1RacersService
{
    public interface IF1RacersService
    {
        Task<List<Racer>> GetAllF1Racers();

        Task<List<Racer>> GetRacersByCountry(string country);

        Task<List<Racer>> AddRacer(Racer racer);

        Task<Racer> GetRacer(long id);

        Task<bool> UpdateRacer(Racer racer);

        Task<bool> DeleteRacer(long id);
    }
}
