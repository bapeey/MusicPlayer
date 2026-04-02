using System.ComponentModel;
using MusicPlayer.Models;

namespace MusicPlayer.Managers
{
    public class LibraryManager
    {
        public BindingList<AudioFile> Library { get; } = new();

        public void Add(string path)
        {
            if (Contains(path)) return;

            Library.Add(new AudioFile
            {
                Title = Path.GetFileNameWithoutExtension(path),
                FilePath = path
            });
        }

        public bool Contains(string path)
        {
            return Library.Any(t =>
                t.FilePath.Equals(path, StringComparison.OrdinalIgnoreCase));
        }

        public void Remove(AudioFile track)
        {
            Library.Remove(track);
        }
    }
}