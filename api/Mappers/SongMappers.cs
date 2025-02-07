using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagLib; 
using api.Dtos;
using api.Model;

namespace api.Mappers
{
    public static class SongMappers
    {
        public static SongDto ToSongDto(this Song songData)
        {
            return new SongDto{
                SongId = songData.SongId,
                Title = songData.Title,
                Artists = songData.Artist,
                Album = songData.Album,
                Year = songData.Year,
                Genere = songData.Genere,
                Comments = songData.Comments,
                FilePath = songData.FilePath,
            };
        }
    }
}