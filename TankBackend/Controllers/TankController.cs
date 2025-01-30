using Microsoft.AspNetCore.Mvc;
using TankBackend.Models;
using TankBackend.Services;

namespace TankBackend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TankController : Controller
{
    private readonly TankService _tankService;
    public TankController(TankService tankService)
    {
        _tankService = tankService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllTanks()
    {
        var tanks = await _tankService.GetAllTanksAsync();
        return Ok(tanks);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTankById(string id)
    {
        var tank = await _tankService.GetTankByIdAsync(id);
        return tank is null ? NotFound() : Ok(tank);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTank(TankModel tank)
    {
        await _tankService.AddUserAsync(tank);
        return CreatedAtAction(nameof(GetTankById), new { id = tank.Id }, tank);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTank(string id, TankModel tank)
    {
        await _tankService.UpdateTankAsync(id, tank);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTank(string id)
    {
        await _tankService.DeleteTankAsync(id);
        return NoContent();
    }
}
