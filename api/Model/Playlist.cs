using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; } = string.Empty;

        public List<PlaylistSong> Songs {get; set; } = new List<PlaylistSong>();

    }
}