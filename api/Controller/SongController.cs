using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{

    [Route("api/song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _songRepo;

        public SongController(ISongRepository songRepo)
        {
            _songRepo = songRepo;  
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Upload a Valid MP3 File.");
            }

            try
            {
                var song = await _songRepo.UploadAsync(file);
                var songDto = song.ToSongDto();

                return Ok(songDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var songs = await _songRepo.GetAllAsync();
            var songDto = songs.Select(s => s.ToSongDispalyDto());

            return Ok(songDto);
        }
    }
}