using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Model;

namespace api.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<List<Playlist>> GetAllAsync();
        Task<Playlist?> GetByIdAsync(int id);

        Task<Playlist> CreateAsync(Playlist playlist);

        Task<Playlist?> UpdateAsync(int id, UpdatePlaylistDto updateDto);

        Task<Playlist?> DeleteAsync(int id);

        Task AddSongToPlaylistAsync(AddSongToPlaylistDto dto);
        
    }
}