using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class ToPlaylistDto
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; } = string.Empty;
    }
}