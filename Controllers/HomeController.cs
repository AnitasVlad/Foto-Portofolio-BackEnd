using Microsoft.AspNetCore.Mvc;
using PhotoPortofolio.Models;
using PhotoPortofolio.Services;

namespace PhotoPortofolio.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IGalleryService _galleryService;

    public HomeController(IGalleryService galleryService)
    {
        _galleryService = galleryService;
    }

    [HttpGet]
    public async Task<ActionResult<Gallery>> GetGallery()
    {
        var galleryFromDb = await _galleryService.GetGallery();
        return galleryFromDb == null ? NotFound() : galleryFromDb;
    }

    [HttpPut]
    public async Task<ActionResult> AddPictureToGallery(string pictureUrl)
    {
        if (!await _galleryService.AddPictureToGallery(pictureUrl))
        {
            return BadRequest();
        }

        return NoContent();
    }
}