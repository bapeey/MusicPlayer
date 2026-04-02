using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Models
{
    public class AudioFile
    {
        public string Title { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;

        public override string ToString() => Title;
    }
}
