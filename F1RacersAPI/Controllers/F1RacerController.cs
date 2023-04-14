using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F1RacersAPI.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using F1RacersAPI.Services.F1RacersService;

namespace F1RacersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class F1RacerController : ControllerBase
    {
        //private static List<Racer> theRacers = RacersFactory();

        private readonly IF1RacersService _racersService;

        public F1RacerController(IF1RacersService service)
        {
            _racersService = service; 
        }

        /*
        private static List<Racer> RacersFactory()
        {
            List<Racer> racers = new List<Racer>();

            //Stub (Mock) for the racers data
            racers.Add(new Racer(1, "Nino", "Farina", "Italy", 33, 5));
            racers.Add(new Racer(2, "Alberto", "Ascari", "Italy", 32, 10));
            racers.Add(new Racer(3, "Juan Manuel", "Fangio", "Argentina", 51, 24));
            racers.Add(new Racer(4, "Mike", "Hawthorn", "England", 45, 3));
            racers.Add(new Racer(5, "Phil", "Hill", "USA", 48, 3));
            racers.Add(new Racer(6, "John", "Surtees", "England", 111, 6));
            racers.Add(new Racer(7, "Jim", "Clark", "Scotland", 72, 25));
            racers.Add(new Racer(8, "Jack", "Brabham", "Australia", 125, 14));
            racers.Add(new Racer(9, "Denny", "Hulme", "New Zealand", 112, 8));
            racers.Add(new Racer(10, "Graham", "Hill", "England", 176, 14));
            racers.Add(new Racer(11, "Jochen", "Rindt", "Austria", 60, 6));
            racers.Add(new Racer(12, "Jackie", "Stewart", "Scotland", 99, 27));
            racers.Add(new Racer(13, "Emerson", "Fittipaldi", "Brazil", 143, 14));
            racers.Add(new Racer(14, "James", "Hunt", "England", 91, 10));
            racers.Add(new Racer(15, "Mario", "Andretti", "USA", 128, 12));
            racers.Add(new Racer(16, "Jody", "Scheckter", "South Africa", 112, 10));
            racers.Add(new Racer(17, "Alan", "Jones", "Australia", 115, 12));
            racers.Add(new Racer(18, "Keke", "Rosberg", "Finland", 114, 5));
            racers.Add(new Racer(19, "Niki", "Lauda", "Austria", 170, 25));
            racers.Add(new Racer(20, "Nelson", "Piquet", "Brazil", 204, 23));
            racers.Add(new Racer(21, "Ayrton", "Senna", "Brazil", 161, 41));
            racers.Add(new Racer(22, "Nigel", "Mansell", "England", 187, 31));
            racers.Add(new Racer(23, "Alain", "Prost", "France", 197, 51));
            racers.Add(new Racer(24, "Damon", "Hill", "England", 114, 22));
            racers.Add(new Racer(25, "Jacques", "Villeneuve", "Canada", 165, 11));
            racers.Add(new Racer(26, "Mika", "Hakkinen", "Finland", 160, 20));
            racers.Add(new Racer(27, "Michael", "Schumacher", "Germany", 250, 91));
            racers.Add(new Racer(28, "Fernando", "Alonso", "Spain", 88, 15));

            return racers;
        }
        */


        [HttpGet]

        public async Task<ActionResult<List<Racer>>> GetAllF1Racers()
        {

            var racers = await _racersService.GetAllF1Racers();

            if (racers == null)
            {

                return NotFound("Racers not found!");
            }

            return Ok(racers);

        }

        [HttpGet("ByCountry")]

        public async Task<ActionResult<List<Racer>>> GetRacersByCountry(string country)
        {

            var racersByCountry = await _racersService.GetRacersByCountry(country);
                
            if (racersByCountry is null)
            {

                return NotFound($"No racers from '{country}' were found.");

            }

            return Ok(racersByCountry);
        }

        [HttpPost]

        public async Task<ActionResult<Racer>> AddRacer([FromBody] Racer racer)
        {

            var racers = await _racersService.AddRacer(racer);

            if (racers == null)
            {

                return NotFound("Racers not found!");
            }

            return Ok(racers);


        }

        [HttpGet("id")]

        public async Task<ActionResult<Racer>> GetRacer(long id)
        {

            var racer = await _racersService.GetRacer(id);

            if (racer == null)
            {

                return NotFound("Racer not found!");
            }

            return Ok(racer);


        }


        [HttpPut]

        public async Task<ActionResult<List<Racer>>> UpdateRacer([FromBody] Racer racer)
        {

            Task<bool> retVal;

            retVal = _racersService.UpdateRacer(racer);



            if (!retVal.Result)
            {

                return NotFound("Racer not found!");
            }

            var racers = await _racersService.GetAllF1Racers();

            return Ok(racers);
        }

        [HttpDelete("id")]

        public async Task<ActionResult<List<Racer>>> DeleteRacer(long id)
        {
            Task<bool> retVal;

            retVal =   _racersService.DeleteRacer(id);

            

            if (!retVal.Result)
            {

                return NotFound("Racer not found!");
            }

            var racers = await _racersService.GetAllF1Racers();

            return Ok(racers);

        }
    }
}
