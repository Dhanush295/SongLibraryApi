using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
   
  
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly ApplicationDBContext _context;

        public PlaylistRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Playlist> CreateAsync(Playlist playlist)
        {
            await _context.Playlists.AddAsync(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task<Playlist?> DeleteAsync(int id)
        {
            var playlist = await _context.Playlists.FirstOrDefaultAsync(x => x.PlaylistId == id);

            if (playlist == null)
            {
                return null;
            }

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
            return playlist;

        }

        public async Task<List<Playlist>> GetAllAsync()
        {
            return await _context.Playlists.ToListAsync();
        }

        public async Task<Playlist?> GetByIdAsync(int id)
        {
            return await _context.Playlists.FindAsync(id);
        }

        public async Task<Playlist?> UpdateAsync(int id, UpdatePlaylistDto updateDto)
        {
            var playlist = await _context.Playlists.FirstOrDefaultAsync(x => x.PlaylistId == id);

            if (playlist == null)
            {
                return null;
            }

            playlist.PlaylistName = updateDto.PlaylistName;

            await _context.SaveChangesAsync();

            return playlist;
        }
    }
}