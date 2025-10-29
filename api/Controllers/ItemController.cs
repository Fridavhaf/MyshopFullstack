using Microsoft.AspNetCore.Mvc;
using Myshop.Models;
using Myshop.ViewModels;
using Myshop.DAL;
using Microsoft.AspNetCore.Authorization;
using Myshop.DTOs;



namespace Myshop.Controllers;



[ApiController]
[Route("api/[controller]")]
public class ItemAPIController : ControllerBase  // ControllerBase is sufficient for API controllers, avoiding View-related features
{
    private readonly IItemRepository _itemRepository;
    private readonly ILogger<ItemAPIController> _logger;

    public ItemAPIController(IItemRepository itemRepository, ILogger<ItemAPIController> logger)
    {
        _itemRepository = itemRepository;
        _logger = logger;
    }

    [HttpGet("itemlist")]
    public async Task<IActionResult> ItemList()
    {
        var items = await _itemRepository.GetAll();
        if (items == null)
        {
            _logger.LogError("[ItemAPIController] Item list not found while executing _itemRepository.GetAll()");
            return NotFound("Item list not found");
        }
        var itemDtos = items.Select(item => new ItemDto
        {
            ItemId = item.ItemId,
            Name = item.Name,
            Price = item.Price,
            Description = item.Description,
            ImageUrl = item.ImageUrl
        });
        return Ok(itemDtos);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] ItemDto itemDto)
    {
        if (itemDto == null)
        {
            return BadRequest("Item cannot be null");
        }

        var newItem = new Item
        {
            Name = itemDto.Name,
            Price = itemDto.Price,
            Description = itemDto.Description,
            ImageUrl = itemDto.ImageUrl
        };

        bool returnOk = await _itemRepository.Create(newItem);
        if (returnOk)
            return CreatedAtAction(nameof(ItemList), new { id = newItem.ItemId }, newItem);

        _logger.LogWarning("[ItemAPIController] Item creation failed {@item}", newItem);
        return StatusCode(500, "Internal server error");
    }

}