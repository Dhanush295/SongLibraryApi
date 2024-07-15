using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Model;

namespace api.Mappers
{
    public static class PlaylistMappers
    {
        public static Playlist ToPlaylistCreateDto(this CreatePlaylistDto playlist)
        {
            return new Playlist
            {
                PlaylistName = playlist.PlaylistName,
            };
        }

        public static ToPlaylistDto ToPlaylistEntityDto(this Playlist playlist)
        {
            return new ToPlaylistDto 
            {
                PlaylistId = playlist.PlaylistId,
                PlaylistName = playlist.PlaylistName,
            };
        }
    }
}