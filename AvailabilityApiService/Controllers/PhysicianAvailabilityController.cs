using FluentApi;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Microsoft.Data.SqlClient;
using FluentApi.Entities;

namespace AvailabilityApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicianAvailabilityController : ControllerBase
    {
        ILogic logic;
        public PhysicianAvailabilityController(ILogic logic) 
        {
            this.logic = logic;
        }


        [HttpGet("GetSchedule")]

        public IActionResult Get([FromQuery] string day)
        {
            try
            {
                var schedule = logic.GetSchedule(day);
                if (schedule != null)
                    return Ok(schedule);
                else
                    return BadRequest("No schedules found");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("AddSchedule")]

        public IActionResult Add([FromBody] DoctorSchedule doctorSchedule)
        {
            try
            {
                logic.AddSchedule(doctorSchedule);
                return CreatedAtAction("Add", doctorSchedule);
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("UpdateSchedule")]

        public IActionResult Update([FromQuery] int day,[FromBody] DoctorSchedule doctorSchedule)
        {
            try
            {
                if (doctorSchedule != null)
                {
                    logic.UpdateSchedule(day, doctorSchedule);
                    return Ok(doctorSchedule);
                }
                else
                    return BadRequest("Null data couldn't be updated");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
