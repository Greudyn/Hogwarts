using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hogwarts.Data;
using Hogwarts.Models;

namespace Hogwarts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentModelsController : ControllerBase
    {
        private readonly HogwartsContext _context;

        public StudentModelsController(HogwartsContext context)
        {
            _context = context;
        }

        // GET: api/StudentModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudentModel()
        {
            return await _context.StudentModel.ToListAsync();
        }

        // GET: api/StudentModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudentModel(string id)
        {
            var studentModel = await _context.StudentModel.FindAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return studentModel;
        }

        // PUT: api/StudentModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentModel(string id, StudentModel studentModel)
        {
            if (id != studentModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudentModel(StudentModel studentModel)
        {
            _context.StudentModel.Add(studentModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentModelExists(studentModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentModel", new { id = studentModel.Id }, studentModel);
        }

        // DELETE: api/StudentModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentModel>> DeleteStudentModel(string id)
        {
            var studentModel = await _context.StudentModel.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            _context.StudentModel.Remove(studentModel);
            await _context.SaveChangesAsync();

            return studentModel;
        }

        private bool StudentModelExists(string id)
        {
            return _context.StudentModel.Any(e => e.Id == id);
        }
    }
}
