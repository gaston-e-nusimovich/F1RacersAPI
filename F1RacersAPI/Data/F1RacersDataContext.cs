using F1RacersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace F1RacersAPI.Data
{
    public class F1RacersDataContext : DbContext
    {

        public F1RacersDataContext(DbContextOptions<F1RacersDataContext> options) : base(options) { }

        public DbSet<Racer> F1Racers { get; set; }
    }
}

