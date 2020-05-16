using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [ApiController]
     [Route("[controller]")]
    public class ValuesController:ControllerBase
    {
        private readonly DataContext _db;
        public ValuesController(DataContext db)
        {
            _db=db;
        }
        public async Task<IActionResult> Get(){
            var modelList=await _db.Values.ToListAsync();
            return Ok(modelList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id){
            var model=await _db.Values.FirstOrDefaultAsync(x=>x.Id==id);
            return Ok(model);
        }
    }
}