using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class AddSongToPlaylistDto
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
    }
}