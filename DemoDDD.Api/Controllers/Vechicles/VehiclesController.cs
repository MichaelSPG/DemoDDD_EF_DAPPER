using DemoDDD.Application.Vehicles.SearchVechicles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDDD.Api.Controllers.Vechicles;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly ISender _sender;

    public VehiclesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVechicles(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken = default) 
    {
        var query = new SearchVehiclesQuery(startDate, endDate);
        var vechicles = await _sender.Send(query, cancellationToken);
        return Ok(vechicles);
    }
}
