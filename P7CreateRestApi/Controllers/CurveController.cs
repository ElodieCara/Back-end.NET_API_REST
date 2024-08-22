using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurveController : ControllerBase
    {
        private readonly ICurvePointService _service;

        public CurveController(ICurvePointService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Home()
        {
           
            return Ok();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCurvePoint([FromBody] CurvePoint curvePoint)
        {
            if (ModelState.IsValid)
            {
                _service.AddCurvePoint(curvePoint);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("validate")]
        public IActionResult Validate([FromBody] CurvePoint curvePoint)
        {
            if (ModelState.IsValid)
            {
                _service.AddCurvePoint(curvePoint);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            var curvePoint = _service.GetCurvePointById(id);
            if (curvePoint == null)
            {
                return NotFound();
            }
            return Ok(curvePoint);
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateCurvePoint(int id, [FromBody] CurvePoint curvePoint)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCurvePoint(curvePoint);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBid(int id)
        {
            var curvePoint = _service.GetCurvePointById(id);
            if (curvePoint == null)
            {
                return NotFound();
            }
            _service.DeleteCurvePoint(id);
            return Ok();
        }
    }
}
