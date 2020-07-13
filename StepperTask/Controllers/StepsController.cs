using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StepperTask.DTO;
using StepperTask.Models;
using StepperTask.Utilities;

namespace StepperTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            using (var db = new StepperTaskDBContext())
            {
                List<Steps> steps = db.Steps.Include(step => step.Items).ToList();
                List<StepDTO> result = ConfigMapper.MapList<Steps, StepDTO>(steps);

                return Ok(result);
            }
        }

        [HttpPost]
        public IActionResult post()
        {
            using (var db = new StepperTaskDBContext())
            {
                int stepsCount = db.Steps.Count();

                Steps newStep = new Steps()
                {
                    Name = "Step " + (stepsCount + 1).ToString()
                };
                db.Add(newStep);
                db.SaveChanges();
                return Ok(newStep);
            }
        }

        [HttpDelete("{stepId}")]
        public IActionResult delete(int stepId)
        {
            try
            {
                using (var db = new StepperTaskDBContext())
                {
                    Steps step = db.Steps.Where(step => step.Id == stepId).FirstOrDefault();
                    if (step != null)
                    {
                        db.Remove(step);
                        db.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}