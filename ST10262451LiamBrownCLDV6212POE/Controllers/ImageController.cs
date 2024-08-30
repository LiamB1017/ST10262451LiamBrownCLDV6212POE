using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

public class ImageController : Controller
{
    private readonly AzureBlobService _blobService;

    public ImageController(AzureBlobService blobService)
    {
        _blobService = blobService;
    }

    [HttpGet]
    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(ImageUploadViewModel model)
    {
        if (ModelState.IsValid)
        {
            using (var stream = model.ImageFile.OpenReadStream())
            {
                var blobUri = await _blobService.UploadImageAsync(model.ImageFile.FileName, stream);
                ViewBag.ImageUrl = blobUri;
            }
            return View();
        }
        return View(model);
    }
}
