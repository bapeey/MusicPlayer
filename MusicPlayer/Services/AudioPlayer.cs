using NAudio.Wave;

namespace MusicPlayer.Services
{
    public class AudioPlayer
    {
        private WaveOutEvent? _outputDevice;
        private AudioFileReader? _audioFile;

        public bool IsPlaying =>
            _outputDevice != null && _outputDevice.PlaybackState == PlaybackState.Playing;

        public double CurrentSeconds => _audioFile?.CurrentTime.TotalSeconds ?? 0;
        public double TotalSeconds => _audioFile?.TotalTime.TotalSeconds ?? 0;

        public void Play(string path, float volume)
        {
            Stop();

            _audioFile = new AudioFileReader(path);

            _outputDevice = new WaveOutEvent
            {
                Volume = volume
            };

            _outputDevice.Init(_audioFile);
            _outputDevice.Play();
        }

        public void Pause() => _outputDevice?.Pause();
        public void Resume() => _outputDevice?.Play();

        public void Seek(double seconds)
        {
            if (_audioFile != null)
                _audioFile.CurrentTime = TimeSpan.FromSeconds(seconds);
        }

        public void SetVolume(float volume)
        {
            if (_outputDevice != null)
                _outputDevice.Volume = volume;
        }

        public void Stop()
        {
            _outputDevice?.Stop();
            _outputDevice?.Dispose();
            _outputDevice = null;

            _audioFile?.Dispose();
            _audioFile = null;
        }
    }
}