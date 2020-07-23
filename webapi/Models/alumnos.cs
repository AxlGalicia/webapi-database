
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class alumnos
    {
          [Key]
          public int id { get; set;}
          public string nombre { get; set; }
          public int edad { get; set; }
      
    }
}