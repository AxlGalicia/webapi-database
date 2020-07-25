using webapi.Models;
using webapi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class alumnosController : ControllerBase
    {
        private readonly alumnosContext context;

        public alumnosController(alumnosContext contexto)
        {
            context = contexto;
        }

       /* [HttpGet]
        public IEnumerable<alumnos> GetAlumnosItems() 
        {
            return  context.alumnos.ToList();
        }*/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<alumnos>>>GetAlumnosItemsAll()
        {
            return await context.alumnos.ToListAsync();
        }

        [HttpGet("{id2}")]
        public async Task<ActionResult<alumnos>> GetAlumnosItems(int id2)
        {
            var PersonaItem = await context.alumnos.FirstOrDefaultAsync(x => x.id.Equals(id2));
            if (PersonaItem == null)
            {
                return NoContent();
            }
            return PersonaItem;
        }

        [HttpPost]
        public async Task<ActionResult<alumnos>> PostAlumnosItems(alumnos item)
        {
            context.alumnos.Add(item);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlumnosItems),new { id2 = item.id}, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteAlumnosItems(int id)
        {
            var AlumnoItem = await context.alumnos.FindAsync(id);

            if (AlumnoItem == null) {
                return NotFound();
            }

            context.alumnos.Remove(AlumnoItem);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuestionarioItem(int id, alumnos item)
        {
            if (id != item.id) 
            {
                return BadRequest();
            }

            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }


      
    }
}