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
    [Route("member")]
    public class MemberController : ControllerBase
    {
        private static List<Member> members = new List<Member>(){
            new Member(){Id=1,Username="NNbesar", Password="BeTheOneThatYouWantToBe", Email ="nugi.mn@gmail.com", FullName ="Nugi Mulya Nugraha", Popularity ="Very Popular"},
            new Member(){Id=2,Username="NNbesar", Password="BeTheOneThatYouWantToBe", Email ="nugi.mn@gmail.com", FullName ="Nugi Mulya Nugraha", Popularity ="Very Popular"},
            new Member(){Id=3,Username="NNbesar", Password="BeTheOneThatYouWantToBe", Email ="nugi.mn@gmail.com", FullName ="Nugi Mulya Nugraha", Popularity ="Very Popular"},
            new Member(){Id=4,Username="NNbesar", Password="BeTheOneThatYouWantToBe", Email ="nugi.mn@gmail.com", FullName ="Nugi Mulya Nugraha", Popularity ="Very Popular"},
            new Member(){Id=5,Username="NNbesar", Password="BeTheOneThatYouWantToBe", Email ="nugi.mn@gmail.com", FullName ="Nugi Mulya Nugraha", Popularity ="Very Popular"},
              
        };


        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (members == null)
            {
            return NotFound();
            }
            return Ok(members);         
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (members == null)
            {
            return NotFound();
            }else {
            return Ok(members.Find( e => e.Id == id));
            }


        }
        [HttpPost]
        public IActionResult MemberAdd(Member member)
        {
            if (members == null)
            {
            return NotFound();
            }
            var addMembers = new Member(){Id=member.Id, Username = member.Username, Password = member.Password, Email=member.Email, FullName = member.FullName, Popularity = member.Popularity};
            members.Add(addMembers);

            return Ok(new {Status = "Success", Message ="SUccess Add Data", data =members});
        }
        [HttpPatch("{id}")]
        public IActionResult patchMember(int id, [FromBody]JsonPatchDocument<Member> ptcMember)
        {
            if (members == null)
            {
            return NotFound();
            } 
            ptcMember.ApplyTo(members.Find(e => e.Id == id));
            return Ok(members.Find(e => e.Id == id));
            

            

        }
    }
}
