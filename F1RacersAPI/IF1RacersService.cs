using F1RacersAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace F1RacersAPI.Services.F1RacersService
{
    public interface IF1RacersService
    {
        Task<List<Racer>> GetAllF1Racers();

        Task<List<Racer>> GetRacersByCountry(string country);

        Task<Racer> AddRacer(Racer racer);

        Task<Racer> GetRacer(int id);

        Task<List<Racer>> UpdateRacer(Racer racer);

        Task<List<Racer>> DeleteRacer(int id);
    }
}
