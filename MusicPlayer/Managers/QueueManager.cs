using System.ComponentModel;
using MusicPlayer.Models;

namespace MusicPlayer.Managers
{
    public class QueueManager
    {
        public BindingList<AudioFile> Queue { get; } = new();

        public int CurrentIndex { get; private set; } = -1;

        public AudioFile? Current =>
            IsValidIndex(CurrentIndex) ? Queue[CurrentIndex] : null;

        public bool IsValidIndex(int index)
            => index >= 0 && index < Queue.Count;

        public void SetIndex(int index)
        {
            CurrentIndex = IsValidIndex(index) ? index : -1;
        }

        public void Add(AudioFile file)
        {
            if (!Queue.Any(t => t.FilePath.Equals(file.FilePath, StringComparison.OrdinalIgnoreCase)))
                Queue.Add(file);
        }

        public void RemoveAt(int index)
        {
            if (!IsValidIndex(index)) return;

            if (index < CurrentIndex)
                CurrentIndex--;

            if (index == CurrentIndex)
                CurrentIndex = -1;

            Queue.RemoveAt(index);
        }

        public void Clear()
        {
            Queue.Clear();
            CurrentIndex = -1;
        }
    }
}