using MGDockerBlazorApp.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MGDockerBlazorApp.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        //private readonly MGDatabaseContext _dbContext;

        //public HomeController(MGDatabaseContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //[HttpPost]
        //public async Task<IActionResult> SampleMethodAsync(string firstName, string lastName)
        //{
        //    await _dbContext.TestTable.AddAsync(new TestTable() {FirstName= firstName , LastName= lastName});
        //    await _dbContext.SaveChangesAsync();

        //    return Ok();
        //}

        //[Authorize]
        //[HttpGet]
        //public async Task<IActionResult> GetData()
        //{
        //    var data = await _dbContext.TestTable.ToListAsync();

        //    return Ok(data);
        //}
    }
}
