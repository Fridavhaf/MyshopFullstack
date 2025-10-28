using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Myshop.Models;
using Myshop.DAL;

namespace Myshop.Controllers;

public class CustomerController : Controller
{
    private readonly ItemDbContext _itemDbContext;

    public CustomerController(ItemDbContext itemDbContext)
    {
        _itemDbContext = itemDbContext;
    }

    public async Task<IActionResult> Table()
    {
        List<Customer> customers = await _itemDbContext.Customers.ToListAsync();
        return View(customers);
    }
}