namespace _50HertzDataAPI.Controller;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services;

[Route("api/measurements")]
[ApiController]
public class MeasurementController : ControllerBase
{
    private readonly MongoDbService _mongoDbService;

    public MeasurementController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Measurement>>> Get()
    {
        var records = await _mongoDbService.GetAllAsync();
        return Ok(records);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Measurement measurement)
    {
        await _mongoDbService.InsertAsync(measurement);
        return CreatedAtAction(nameof(Get), new { id = measurement.Id }, measurement);
    }
}
