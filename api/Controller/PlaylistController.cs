using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("/api/playlist")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistRepository _playlistRepo;

        public PlaylistController(IPlaylistRepository playlistRepo)
        {
            _playlistRepo = playlistRepo;
        }


        [HttpPost]
        public async Task<IActionResult> CreatePlaylistAsync([FromBody] CreatePlaylistDto playlistDto)
        {
            var playlist = playlistDto.ToPlaylistCreateDto();
            await _playlistRepo.CreateAsync(playlist);
            return CreatedAtAction(nameof(GetByID), new {ID = playlist.PlaylistId}, playlist.ToPlaylistEntityDto());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var playlist = await _playlistRepo.GetByIdAsync(id);

            if (playlist == null)
            {
                return NotFound();
            }

            return Ok(playlist.ToPlaylistEntityDto());
        }
        
        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var playlists = await _playlistRepo.GetAllAsync();

            var playlistDto = playlists.Select(s => s.ToPlaylistEntityDto());

            return Ok(playlistDto);
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, UpdatePlaylistDto updateDto)
        {
            var playlist = await _playlistRepo.UpdateAsync(id, updateDto);

            if(playlist == null)
            {
                return NotFound();
            }

            return Ok(playlist.ToPlaylistEntityDto());
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var playlist = await _playlistRepo.DeleteAsync(id);

            if (playlist == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPost("AddSongToPlaylist")]
        public async Task<IActionResult> AddSongToPlaylist(AddSongToPlaylistDto dto)
        {
            try
            {
                await _playlistRepo.AddSongToPlaylistAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}