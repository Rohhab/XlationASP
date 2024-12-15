using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XlationASP.Data;
using XlationASP.Dtos;
using XlationASP.Models;

namespace XlationASP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class XlatorsController : ControllerBase
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;

        public XlatorsController(DomainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/xlators
        public IActionResult GetXlators()
        {
            var xlators = _context.Xlators.ToList();
            var xlatorsDto = _mapper.Map<IEnumerable<XlatorDto>>(xlators);

            return Ok(xlatorsDto);
        }

        // GET /api/xlators/id
        [HttpGet("{id}")]
        public IActionResult GetXlator(int id)
        {
            var xlatorInDb = _context.Xlators.Find(id);

            if (xlatorInDb == null)
                return NotFound("Xlator not found.");

            var xlatorDto = _mapper.Map<XlatorDto>(xlatorInDb);

            return Ok(xlatorDto);
        }

        // POST /api/xlators
        [HttpPost]
        public IActionResult CreateXlator(XlatorDto xlatorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var xlator = _mapper.Map<Xlator>(xlatorDto);

            _context.Add(xlator);
            _context.SaveChanges();

            xlatorDto.Id = xlator.Id;

            var uri = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}/{xlatorDto.Id}");

            return Created(uri, xlatorDto);
        }

        // PUT /api/xlators/id
        [HttpPut("{id}")]
        public IActionResult UpdateXlator(int id, XlatorDto xlatorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var xlatorInDb = _context.Xlators.Find(id);

            if (xlatorInDb == null)
                return NotFound(new { message = "Xlator not found." });

            _mapper.Map(xlatorDto, xlatorInDb);
            _context.SaveChanges();

            xlatorDto.Id = xlatorInDb.Id;

            return Ok(xlatorDto);
        }

        // DELETE /api/xlators/id
        [HttpDelete("{id}")]
        public IActionResult DeleteXlator(int id)
        {
            var xlatorInDb = _context.Xlators.Find(id);

            if (xlatorInDb == null)
                return NotFound(new { message = "Xlator not found." });

            _context.Remove(xlatorInDb);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
