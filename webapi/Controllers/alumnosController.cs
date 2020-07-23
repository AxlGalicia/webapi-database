using webapi.Models;
using webapi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet]
        public IEnumerable<alumnos> GetAlumnosItems() 
        {
            return  context.alumnos.ToList();
        }
      
    }
}