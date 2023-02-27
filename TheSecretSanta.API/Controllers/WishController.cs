using Microsoft.AspNetCore.Mvc;
using TheSecretSanta.Application.Interfaces;
using TheSecretSanta.Domain.Models;

namespace TheSecretSanta.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WishController : ControllerBase
{
    private readonly IWishService _service;

    public WishController(IWishService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wish>>> Get(string? searchTerm, int take = 10, int skip = 0)
    {
        var userId = (HttpContext.Items["ApplicationUser"] as ApplicationUser).Id;

        if (searchTerm != null)
        {
            return Ok(ApiResult<IEnumerable<Wish>>
                .Success(await _service.GetBySearchTermAsync(userId, searchTerm, take, skip)));
        }
        var test = await _service.GetAllAsync(userId, take, skip);
        return Ok(ApiResult<IEnumerable<Wish>>
                .Success(await _service.GetAllAsync(userId, take, skip)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Wish>> Get(Guid id) =>
         Ok(ApiResult<Wish>.Success(await _service.GetWishByIdAsync(id)));
    

    [HttpPost]
    public async Task<IActionResult> Post(Dictionary<string, object> wish)
    {
        var userId = (HttpContext.Items["ApplicationUser"] as ApplicationUser).Id;

        return Ok(ApiResult<Wish>.Success(await _service.CreateAsync(wish, userId)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Dictionary<string, object> updatedWish, Guid id) =>
        Ok(ApiResult<Wish>.Success(await _service.UpdateAsync(updatedWish, id)));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(ApiResult<Guid>.Success(await _service.DeleteAsync(id)));
    }
}