using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class PlaylistSong
    {
        public int PlaylistSongId { get; set; }

        public int PlaylistId { get; set; }
        
        public int SongId { get; set; }



        public Playlist Playlist {get; set; }

        public Song Song {get; set; }
    }
}