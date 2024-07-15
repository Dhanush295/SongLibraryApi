using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class SongDisplayDto
    {
        public int SongId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artists { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Genere { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
    }
}