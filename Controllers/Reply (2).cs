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
    [Route("replies")]
    public class RepliesController : ControllerBase
    {
        private static List<Replies> replies = new List<Replies>(){
            new Replies(){Id=1,Content="NNbesar", Member_id=1, Topic_id =1},

        };


        private readonly ILogger<RepliesController> _logger;

        public RepliesController(ILogger<RepliesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(replies);         
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(replies.Find( e => e.Id == id));
        }
        [HttpPost]
        public IActionResult RepliesAdd(Replies reply)
        {
            var addReplies = new Replies(){Id=reply.Id, Content = reply.Content, Member_id=reply.Member_id, Topic_id=reply.Topic_id };
            replies.Add(addReplies);

            return Ok(new {Status = "Success", Message ="SUccess Add Data", data =replies});
        }

        [HttpDelete("{id}")]
        public IActionResult delReplies(int id)
        {
            var x = replies.Find(e => e.Id == id);
            replies.Remove(x);
            return Ok(new {Status = "Success", Message ="SUccess Add Data", data =replies});
        }

        
        [HttpPatch("{id}")]
        public IActionResult patchReplies(int id, [FromBody]JsonPatchDocument<Replies> ptcReplies)
        {

            ptcReplies.ApplyTo(replies.Find(e => e.Id == id));
            return Ok(replies.Find(e => e.Id == id));

        }
    }
}
