using HaveLunch.Models;
using HaveLunch.Services;
using Microsoft.AspNetCore.Mvc;

namespace HaveLunch.Controllers;

[ApiController]
[Route("attendance")]
public class EmployeeAttendanceController(IEmployeeAttendanceService employeeAttendanceService) : Controller
{
    [HttpGet("{employeeId:int}")]
    public async Task<IActionResult> GetAttendanceDetail(int employeeId, string date = "")
    {
        try
        {
            if(!DateOnly.TryParse(date, out var dateOnly))
            {
                dateOnly = DateOnly.FromDateTime(DateTime.Today);
            }
            return Ok(await employeeAttendanceService.GetEmployeeAttendanceDetail(employeeId, dateOnly));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdateEmployeeAttendanceDetail(EmployeeAttendanceRequest request)
    {
        try
        {
            return Ok(await employeeAttendanceService.CreateOrUpdateEmployeeAttendance(request));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("history/{employeeId:int}")]
    public async Task<IActionResult> GetEmployeeAttendanceHistory(int employeeId, int page = 1)
    {
        try
        {
            return Ok(await employeeAttendanceService.GetEmployeeAttendanceHistory(employeeId, page));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
