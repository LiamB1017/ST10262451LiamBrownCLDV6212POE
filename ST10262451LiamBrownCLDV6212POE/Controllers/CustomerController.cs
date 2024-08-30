using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class CustomerController : Controller
{
    private readonly AzureTableService _tableService;

    public CustomerController(AzureTableService tableService)
    {
        _tableService = tableService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CustomerProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            var customer = new CustomerProfile
            {
                PartitionKey = "Customers",
                RowKey = Guid.NewGuid().ToString(),
                Name = model.Name,
                Email = model.Email
            };
            await _tableService.AddCustomerProfileAsync(customer);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Index()
    {
        // Logic to list customer profiles
        return View();
    }
}
