using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagLib;
using api.Data;
using api.Interfaces;
using api.Model;
using api.Mappers;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class SongRepository : ISongRepository
    {
        private ApplicationDBContext _context;
        public SongRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Song>> GetAllAsync()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song> UploadAsync(IFormFile file)
        {
            if(file == null || file.Length == 0){
                throw new ArgumentException("Upload a valid MP3 file.");
            }

            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "UploadedMp3Files");
            Directory.CreateDirectory(uploads);
            var filePath = Path.Combine(uploads, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var song = ExtractMetaData(filePath);

            if (song == null)
            {
                throw new Exception("Failed to extract metadata from the MP3 file.");
            }


            _context.Songs.Add(song);

            await _context.SaveChangesAsync();

            return song;
 
        }


        private Song ExtractMetaData(string filePath)
        {
            var file = TagLib.File.Create(filePath);

            // Extract metadata properties from the file
            var title = file.Tag.Title;
            var artists = string.Join(", ", file.Tag.Performers);
            var album = file.Tag.Album;
            var year = (int)file.Tag.Year;
            var genres = string.Join(", ", file.Tag.Genres);
            var comments = file.Tag.Comment;

            // Create a new Song object with extracted metadata
            var song = new Song
            {
                Title = title,
                Artist = artists,
                Album = album,
                Year = year,
                Genere = genres,
                Comments = comments,
                FilePath = filePath
            };
            return song;
            }
    }
}