using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoPortofolio.Models;
using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace PhotoPortofolio.Services;

public class GalleryService : IGalleryService
{
    private readonly Context _context;

    public GalleryService(Context context)
    {
        _context = context;
    }

    public async Task<Gallery?> GetGallery()
        => await _context.Galleries.
            Include(g => g.MainPicture)
            .Include(g => g.Pictures).
            FirstAsync();

    public async Task<bool> AddPictureToGallery(string pictureUrl)
    {
        if (string.IsNullOrEmpty(pictureUrl))
            return false;

        var gallery = await GetGallery();
        
        if (gallery == null)
            return false;

        var picture = new Picture
        {
            URL = pictureUrl
        };
        
        gallery.Pictures.Add(picture);
        _context.Entry(gallery).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface IGalleryService
{
    Task<Gallery?> GetGallery();
    Task<bool> AddPictureToGallery(string pictureUrl);
}