using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepperTask.DTO;
using StepperTask.Models;
using StepperTask.Utilities;

namespace StepperTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpPost]
        public IActionResult post(ItemDTO model)
        {
            try
            {
                using (var db = new StepperTaskDBContext())
                {
                    Items item = ConfigMapper.Map<ItemDTO, Items>(model);
                    db.Items.Add(item);
                    db.SaveChanges();
                    return Ok(item);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        public IActionResult put(ItemDTO model)
        {
            try
            {
                using (var db = new StepperTaskDBContext())
                {
                    Items item = db.Items.Where(item => item.Id == model.Id).FirstOrDefault();
                    if (item != null)
                    {
                        item.Title = model.Title;
                        item.Description = model.Description;
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

        [HttpDelete("{itemId}")]
        public IActionResult delete(int itemId)
        {
            try
            {
                using (var db = new StepperTaskDBContext())
                {
                    Items item = db.Items.Where(item => item.Id == itemId).FirstOrDefault();
                    if (item != null)
                    {
                        db.Items.Remove(item);
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