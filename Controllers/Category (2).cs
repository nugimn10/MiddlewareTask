using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Logging;


namespace TaskWebApiIntro.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoriesControler : ControllerBase
    {
        private static List<Categories> categories = new List<Categories>(){
            new Categories(){Id=1,Name="Tulang Ekor", Description="Tulang ekor yang seperti buntut tapi literaly bukan"},
            new Categories(){Id=2,Name="Tulang Kering", Description="Tulang yang basah tapi gak tau kenapa di sebut kering"},
            new Categories(){Id=3,Name="Tulang Lunak", Description="tulang ini banyak betebaran di lampu merah"},
            new Categories(){Id=4,Name="Tulang Tak Nampak", Description="kalau tulang tak nampak biasanya dia lagi pergi main"},
            new Categories(){Id=5,Name="Tulang Punggung", Description="Aku padamu(hoeek)"}
        };


        private readonly ILogger<CategoriesControler> _logger;

        public CategoriesControler(ILogger<CategoriesControler> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Ge()
        {
            return Ok(categories);         
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(categories.Find( e => e.Id == id));
        }
        [HttpPost]
        public IActionResult ContactAdd(Categories category)
        {
            var addCategories = new Categories(){Id=category.Id, Name = category.Name, Description = category.Description};
            categories.Add(addCategories);

            return Ok(new {Status = "Success", Message ="SUccess Add Data", data =categories});
        }

        [HttpDelete("{id}")]
        public IActionResult delCategory(int id)
        {
            var x = categories.Find(e => e.Id == id);
            categories.Remove(x);
            return Ok(new {Status = "Success", Message ="SUccess Add Data", data =categories});
        }

        
        [HttpPatch("{id}")]
        public IActionResult patchCategories(int id, [FromBody]JsonPatchDocument<Categories> ptcCategories)
        {

            ptcCategories.ApplyTo(categories.Find(e => e.Id == id));
            return Ok(categories.Find(e => e.Id == id));

        }
    }
}
