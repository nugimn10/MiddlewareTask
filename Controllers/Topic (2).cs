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
    [Route("topic")]
    public class TopicControler : ControllerBase
    {
        private static List<Topic> topics = new List<Topic>(){
            new Topic(){Id=1,Content="Tulang Ekor", Title="Tulang ekor yang seperti buntut tapi literaly bukan", Member_id=1},
            new Topic(){Id=2,Content="Tulang Kering", Title="Tulang yang basah tapi gak tau kenapa di sebut kering", Member_id=1},
            new Topic(){Id=3,Content="Tulang Lunak", Title="tulang ini banyak tersebar di lampu merah",Member_id=2}
        };


        private readonly ILogger<TopicControler> _logger;

        public TopicControler(ILogger<TopicControler> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Ge()
        {
            return Ok(topics);         
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(topics.Find( e => e.Id == id));
        }
        [HttpPost]
        public IActionResult topicAdd(Topic topic)
        {
            var addTopics = new Topic(){Id=topic.Id, Content = topic.Content, Title = topic.Title, Member_id=topic.Member_id};
            topics.Add(addTopics);

            return Ok(new {Status = "Success", Message ="SUccess Add Data", data =topics});
        }
        [HttpDelete("{id}")]
        public IActionResult delTopic(int id)
        {
            var x = topics.Find(e => e.Id == id);
            topics.Remove(x);
            return Ok(new {Status = "Success", Message ="SUccess Delete Data", data =topics});
        }

        [HttpPatch("{id}")]
        public IActionResult patchTopic(int id, [FromBody]JsonPatchDocument<Topic> ptcTopic)
        {

            ptcTopic.ApplyTo(topics.Find(e => e.Id == id));
            return Ok(topics.Find(e => e.Id == id));

        }
    }
}
