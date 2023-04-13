using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F1RacersAPI.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace F1RacersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class F1RacerController : ControllerBase
    {
        private static List<Racer> theRacers = RacersFactory();


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

        public F1RacerController() {




        }
        [HttpGet]

        public async Task<ActionResult<List<Racer>>> GetAllF1Racers()
        {

            return Ok(F1RacerController.theRacers);

        }

        [HttpGet("country")]

        public async Task<ActionResult<List<Racer>>> GetRacersByCountry(string country)
        {

            var racersByCountry = F1RacerController.theRacers.Where(r => r.Country == country).OrderBy(r => r.Lastname).ThenBy(r => r.Firstname).ToList();

            if (racersByCountry.Count == 0)
            {

                return NotFound($"No racers from '{country}' were found.");

            }

            return Ok(racersByCountry);
        }

        [HttpPost]

        public async Task<ActionResult<Racer>> AddRacer([FromBody] Racer racer)
        {

            F1RacerController.theRacers.Add(racer);

            return Ok(F1RacerController.theRacers);


        }

        [HttpGet("id")]

        public async Task<ActionResult<Racer>> GetRacer(int id)
        {

            var result = F1RacerController.theRacers.Find(r => r.Id == id);

            if (result == null)
            {

                return NotFound("Racer not found!");
            }

            return Ok(result);


        }


        [HttpPut]

        public async Task<ActionResult<List<Racer>>> UpdateRacer([FromBody] Racer racer)
        {

            var result = F1RacerController.theRacers.Find(r => r.Id == racer.Id);

            if (result == null)
            {

                return BadRequest("Racer not found!");

            }

            result.Firstname = racer.Firstname;
            result.Lastname = racer.Lastname;
            result.Starts = racer.Starts;
            result.Wins = racer.Wins;
            result.Country = racer.Country;


            return Ok(F1RacerController.theRacers);
        }

        [HttpDelete("id")]

        public async Task<ActionResult<List<Racer>>> DeleteRacer(int id)
        {
            var result = F1RacerController.theRacers.Find(r => r.Id == id);

            if (result == null)
            {

                return NotFound("Racer not found!");
            }

            F1RacerController.theRacers.Remove(result);

            return Ok(F1RacerController.theRacers);

        }
    }
}
