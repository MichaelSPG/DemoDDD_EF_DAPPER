using DemoDDD.Application.Rentals.GetRental;
using DemoDDD.Application.Rentals.ReserveRent;
using DemoDDD.Application.Vehicles.SearchVechicles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDDD.Api.Controllers.Rentals;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : ControllerBase
{
    private readonly ISender _sender;

    public RentalsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRental(
        Guid id,
        CancellationToken cancellationToken) 
    {
        var query = new GetRentalQuery(id);
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> ReserveRent(
        Guid id,
        RentRequest rentRequest,
        CancellationToken cancellationToken)
    {
        var command = new ReserveRentCommand
        (
            rentRequest.VechicleId,
            rentRequest.UserId,
            rentRequest.StartDate,
            rentRequest.EndDate                    
        );

        var result = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetRental), new {id = result.Value});
    }
}
