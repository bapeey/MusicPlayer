using MusicPlayer.Models;
using MusicPlayer.Services;
using MusicPlayer.Managers;
using System.ComponentModel;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        private AudioPlayer _player = new();
        private QueueManager _queue = new();
        private LibraryManager _library = new();

        private double _currentPositionSeconds = 0;
        private double _totalDurationSeconds = 0;

        private int _pauseCounter = 0;

        private const int SCROLL_SPEED = 2;
        private const int WAIT_TICKS = 30;

        private const string PLAY_TEXT = "▶";
        private const string PAUSE_TEXT = "⏸";
        private const string SELECT_SONG_TEXT = "Select a song...";

        public Form1()
        {
            InitializeComponent();

            lstLibrary.DataSource = _library.Library;
            lstQueue.DataSource = _queue.Queue;
        }

        // ================= UI =================

        private void ResetUI()
        {
            pnlProgressBar.Width = 0;
            pnlProgressKnob.Left = pnlProgressBg.Left - (pnlProgressKnob.Width / 2);

            lblCurrentTime.Text = "00:00";
            lblTotalTime.Text = "00:00";
            lblTitle.Text = SELECT_SONG_TEXT;

            btnPlayPause.Text = PLAY_TEXT;
        }

        private void StopPlaybackUI()
        {
            _player.Stop();
            _queue.SetIndex(-1);
            ResetUI();
        }

        private string FormatTime(double seconds)
            => TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss");

        // ================= Playback =================

        private void PlayFromQueue(int index)
        {
            if (!_queue.IsValidIndex(index))
            {
                StopPlaybackUI();
                return;
            }

            _queue.SetIndex(index);
            lstQueue.SelectedIndex = index;

            AudioFile track = _queue.Current!;

            _player.Play(track.FilePath, tkVolume.Value / 100f);

            _totalDurationSeconds = _player.TotalSeconds;

            lblTitle.Text = track.Title;
            lblTitle.Left = pnlTitleContainer.Width;

            tmrProgress.Start();
            btnPlayPause.Text = PAUSE_TEXT;
        }

        private void TogglePlayPause()
        {
            if (_player.IsPlaying)
            {
                _player.Pause();
                btnPlayPause.Text = PLAY_TEXT;
            }
            else if (_queue.Current != null)
            {
                _player.Resume();
                btnPlayPause.Text = PAUSE_TEXT;
            }
        }

        // ================= Progress =================

        private void SeekToMouse()
        {
            if (_queue.Current == null) return;

            double seconds = GetSecondsFromMouse();
            _player.Seek(seconds);
            SetProgress(seconds);
        }

        private double GetSecondsFromMouse()
        {
            Point relative = pnlProgressBg.PointToClient(Cursor.Position);
            int clampedX = Math.Clamp(relative.X, 0, pnlProgressBg.Width);

            double ratio = (double)clampedX / pnlProgressBg.Width;
            return _totalDurationSeconds * ratio;
        }

        private void SetProgress(double seconds)
        {
            if (_totalDurationSeconds <= 0) return;

            _currentPositionSeconds = seconds;

            double ratio = seconds / _totalDurationSeconds;
            int width = (int)(pnlProgressBg.Width * ratio);

            pnlProgressBar.Width = width;
            pnlProgressKnob.Left = pnlProgressBg.Left + width - (pnlProgressKnob.Width / 2);

            lblCurrentTime.Text = FormatTime(_currentPositionSeconds);
        }

        // ================= Timer =================

        private void tmrProgress_Tick(object sender, EventArgs e)
        {
            if (_player.IsPlaying)
            {
                SetProgress(_player.CurrentSeconds);
                lblTotalTime.Text = FormatTime(_player.TotalSeconds);
            }

            HandleScrollingTitle();
        }

        private void HandleScrollingTitle()
        {
            if (lblTitle.Width <= pnlTitleContainer.Width)
            {
                lblTitle.Left = 0;
                _pauseCounter = 0;
                return;
            }

            if (_pauseCounter < WAIT_TICKS)
            {
                lblTitle.Left = 0;
                _pauseCounter++;
                return;
            }

            lblTitle.Left -= SCROLL_SPEED;

            if (lblTitle.Left + lblTitle.Width <= pnlTitleContainer.Width)
            {
                lblTitle.Left = pnlTitleContainer.Width - lblTitle.Width;
                _pauseCounter++;

                if (_pauseCounter > WAIT_TICKS * 2)
                {
                    lblTitle.Left = 0;
                    _pauseCounter = 0;
                }
            }
        }

        // ================= Library =================

        private void LoadMusicFiles()
        {
            using OpenFileDialog dialog = new()
            {
                Multiselect = true,
                Filter = "Audio Files|*.mp3;*.wav;*.flac;*.m4a"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            foreach (string path in dialog.FileNames)
                _library.Add(path);
        }

        // ================= Events =================

        private void btnLoadSongs_Click(object sender, EventArgs e) => LoadMusicFiles();

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (_player.IsPlaying || _queue.Current != null)
            {
                TogglePlayPause();
                return;
            }

            PlayFromQueue(lstQueue.SelectedIndex >= 0 ? lstQueue.SelectedIndex : 0);
        }

        private void btnNext_Click(object sender, EventArgs e)
            => PlayFromQueue(_queue.CurrentIndex + 1);

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_player.IsPlaying && _player.CurrentSeconds > 5)
            {
                _player.Seek(0);
                return;
            }

            PlayFromQueue(_queue.CurrentIndex - 1);
        }

        private void btnStop_Click(object sender, EventArgs e)
            => StopPlaybackUI();

        private void tkVolume_Scroll(object sender, EventArgs e)
            => _player.SetVolume(tkVolume.Value / 100f);

        private void lstLibrary_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstLibrary.SelectedItem is AudioFile selected)
                _queue.Add(selected);
        }

        private void lstQueue_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstQueue.SelectedIndex != -1)
                PlayFromQueue(lstQueue.SelectedIndex);
        }

        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            if (lstLibrary.SelectedItem is AudioFile selected)
                _queue.Add(selected);
        }

        private void btnAddAllToQueue_Click(object sender, EventArgs e)
        {
            foreach (AudioFile audio in _library.Library)
                _queue.Add(audio);
        }

        private void btnQueueRemove_Click(object sender, EventArgs e)
        {
            int index = lstQueue.SelectedIndex;
            if (!_queue.IsValidIndex(index)) return;

            bool wasPlaying = index == _queue.CurrentIndex;

            _queue.RemoveAt(index);

            if (wasPlaying)
                StopPlaybackUI();
        }

        private void btnRemoveSong_Click(object sender, EventArgs e)
        {
            if (lstLibrary.SelectedItem is not AudioFile track) return;

            int index = _queue.Queue.IndexOf(track);

            if (index != -1)
            {
                bool wasPlaying = index == _queue.CurrentIndex;

                _queue.RemoveAt(index);

                if (wasPlaying)
                    StopPlaybackUI();
            }

            _library.Remove(track);
        }

        private void btnQueueShuffle_Click(object sender, EventArgs e)
        {
            if (_queue.Queue.Count < 2) return;

            AudioFile? current = _queue.Current;

            Random rng = new();
            List<AudioFile> shuffled = _queue.Queue.OrderBy(_ => rng.Next()).ToList();

            _queue.Clear();
            foreach (AudioFile track in shuffled)
                _queue.Add(track);

            if (current != null)
            {
                int newIndex = _queue.Queue.IndexOf(current);
                _queue.SetIndex(newIndex);
                lstQueue.SelectedIndex = newIndex;
            }
        }

        private void ProgressBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SeekToMouse();
        }

        private void ProgressBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SeekToMouse();
        }
    }
}