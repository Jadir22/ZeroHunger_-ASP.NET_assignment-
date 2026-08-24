using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectRequestController : ControllerBase
    {
        CollectRequestService service;

        public CollectRequestController(CollectRequestService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            return Ok(data);
        }

        [HttpPost("create")]
        public IActionResult Create(CollectRequestModel model)
        {
            var data = service.Create(model);
            return Ok(data);
        }

        [HttpPut("update")]
        public IActionResult Update(CollectRequestModel model)
        {
            var data = service.Update(model);
            return Ok(data);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = service.Delete(id);
            return Ok(data);
        }

        [HttpPut("accept/{id}")]
        public IActionResult Accept(int id)
        {
            var data = service.AcceptRequest(id);

            if (!data) return NotFound();

            return Ok(data);
        }

        [HttpPut("assign/{requestId}/{employeeId}")]
        public IActionResult AssignEmployee(int requestId, int employeeId)
        {
            var data = service.AssignEmployee(requestId, employeeId);

            if (!data) return NotFound();

            return Ok(data);
        }

        [HttpPut("collected/{id}")]
        public IActionResult Collected(int id)
        {
            var data = service.Collected(id);

            if (!data) return NotFound();

            return Ok(data);
        }

        [HttpPut("completed/{id}")]
        public IActionResult Completed(int id)
        {
            var data = service.Completed(id);

            if (!data) return NotFound();

            return Ok(data);
        }
    }
}
