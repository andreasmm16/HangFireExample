using FireApp.Models;
using FireApp.Services;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace FireApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private static List<Player> drivers = new List<Player>{
            new Player
            {
                Id = 1,
                Name = "Lionel Messi" ,
                JerseyNumber = 10,
                Team = "Inter Miami" } ,
            new Player
              {
                Id = 2,
                Name = "Sergi Roberto",
                JerseyNumber= 20,
                Team = "FC Barcelona"
              },
            new Player
            {
                Id= 3,
                Name = "Neymar Jr",
                JerseyNumber = 10,
                Team = "Paris Saint-Germain"
            },
            new Player
            {
                Id= 4,
                Name = "Marco Asensio",
                JerseyNumber = 11,
                Team = "Real Madrid"
            }
        };


        [HttpPost]
        public IActionResult Post(Player player)
        {
            if (ModelState.IsValid)
            {
                drivers.Add(player);
                var jobId= BackgroundJob.Enqueue<IServiceManagement>(x => x.SendContract());
                return CreatedAtAction("GetPlayer", new { player.Id }, player);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetPlayer([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var driver = drivers.FirstOrDefault(d => d.Id == id.Value);
                if (driver == null)
                {
                    return NotFound();
                }
                return Ok(driver);
            }

            return Ok(drivers);
        }

        [HttpDelete]
        public IActionResult DeleteDriver(int id)
        {
            var driver = drivers.FirstOrDefault(d => d.Id == id);
            if (driver == null)
                return NotFound();
            RecurringJob.AddOrUpdate<IServiceManagement>("UpdateDatabaseId",x => x.GenerateMerchandise(),Cron.Minutely);
            return Ok("Jugador eliminado");
        }
    }
}
