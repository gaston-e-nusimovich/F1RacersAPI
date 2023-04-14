using F1RacersAPI.Data;
using F1RacersAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace F1RacersAPI.Services.F1RacersService
{
    public class F1RacersService : IF1RacersService
    {
        private readonly F1RacersDataContext _dataContext;
        public F1RacersService(F1RacersDataContext context) {
        
            _dataContext = context;
        }
        public async Task<List<Racer>> AddRacer(Racer racer)
        {
            try
            {
                _dataContext.Add(racer);

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());


            }

            return _dataContext.F1Racers.ToList();

        }

        public async Task<bool> DeleteRacer(long id)
        {

            bool retVal = false;

            try
            {
                var racer = _dataContext.F1Racers.Where(r => r.Id == id).FirstOrDefault();

                if (racer == null) {

                    return retVal;
                }


                _dataContext.Remove(racer);

                await _dataContext.SaveChangesAsync();


                retVal = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());


            }

            return retVal;

        }

        public async Task<List<Racer>> GetAllF1Racers()
        {
            var racers = await _dataContext.F1Racers.ToListAsync();

            return racers;
        }

        public async Task<Racer> GetRacer(long id)
        {

            Racer? racer = null;

            try
            {
                racer = await _dataContext.F1Racers.FindAsync(id);

                if (racer == null)
                {

                    return null;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());


            }

            return racer;

        }

        public async Task<List<Racer>> GetRacersByCountry(string country)
        {
            List<Racer> racers = new List<Racer>();
            try
            {
                racers = await _dataContext.F1Racers.Where(r => r.Country == country).OrderBy(r => r.Lastname).ThenBy(r => r.Firstname).ToListAsync();

                if (racers.Count() == 0)
                {

                    return null;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

            return  racers;
        }

        public async Task<bool> UpdateRacer(Racer racer)
        {
            bool retVal = false;

            var someRacer = _dataContext.F1Racers.Where(r => r.Id == racer.Id);
            if (someRacer == null) {

                return retVal;
            
            }
            try
            {
                _dataContext.Update(racer);

                await _dataContext.SaveChangesAsync();

                retVal = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());


            }

            return retVal;

        }
    }
}
