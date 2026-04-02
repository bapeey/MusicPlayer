namespace MusicPlayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlProgressBg = new Panel();
            pnlProgressBar = new Panel();
            pnlProgressKnob = new Panel();
            lstLibrary = new ListBox();
            btnLoadSongs = new Button();
            tmrProgress = new System.Windows.Forms.Timer(components);
            lblCurrentTime = new Label();
            lblTotalTime = new Label();
            btnPrevious = new Button();
            btnNext = new Button();
            btnPlayPause = new Button();
            btnStop = new Button();
            pnlTitleContainer = new Panel();
            lblTitle = new Label();
            tkVolume = new TrackBar();
            lblVolume = new Label();
            lblSongQueue = new Label();
            lstQueue = new ListBox();
            btnRemoveSong = new Button();
            btnAddToQueue = new Button();
            btnQueueRemove = new Button();
            btnQueueShuffle = new Button();
            btnAddAllToQueue = new Button();
            pnlProgressBg.SuspendLayout();
            pnlTitleContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tkVolume).BeginInit();
            SuspendLayout();
            // 
            // pnlProgressBg
            // 
            pnlProgressBg.BackColor = Color.Black;
            pnlProgressBg.BorderStyle = BorderStyle.FixedSingle;
            pnlProgressBg.Controls.Add(pnlProgressBar);
            pnlProgressBg.Cursor = Cursors.Hand;
            pnlProgressBg.Location = new Point(25, 131);
            pnlProgressBg.Name = "pnlProgressBg";
            pnlProgressBg.Size = new Size(500, 6);
            pnlProgressBg.TabIndex = 0;
            pnlProgressBg.MouseDown += ProgressBar_MouseDown;
            pnlProgressBg.MouseMove += ProgressBar_MouseMove;
            // 
            // pnlProgressBar
            // 
            pnlProgressBar.BackColor = Color.Lime;
            pnlProgressBar.Location = new Point(-1, -1);
            pnlProgressBar.Margin = new Padding(0);
            pnlProgressBar.Name = "pnlProgressBar";
            pnlProgressBar.Size = new Size(0, 6);
            pnlProgressBar.TabIndex = 1;
            pnlProgressBar.MouseDown += ProgressBar_MouseDown;
            pnlProgressBar.MouseMove += ProgressBar_MouseMove;
            // 
            // pnlProgressKnob
            // 
            pnlProgressKnob.BackColor = Color.White;
            pnlProgressKnob.BorderStyle = BorderStyle.FixedSingle;
            pnlProgressKnob.Cursor = Cursors.Hand;
            pnlProgressKnob.Location = new Point(25, 127);
            pnlProgressKnob.Name = "pnlProgressKnob";
            pnlProgressKnob.Size = new Size(10, 14);
            pnlProgressKnob.TabIndex = 1;
            pnlProgressKnob.MouseDown += ProgressBar_MouseDown;
            pnlProgressKnob.MouseMove += ProgressBar_MouseMove;
            // 
            // lstLibrary
            // 
            lstLibrary.BackColor = Color.DimGray;
            lstLibrary.BorderStyle = BorderStyle.FixedSingle;
            lstLibrary.ForeColor = Color.White;
            lstLibrary.FormattingEnabled = true;
            lstLibrary.Location = new Point(681, 71);
            lstLibrary.Name = "lstLibrary";
            lstLibrary.Size = new Size(242, 257);
            lstLibrary.TabIndex = 2;
            lstLibrary.MouseDoubleClick += lstLibrary_MouseDoubleClick;
            // 
            // btnLoadSongs
            // 
            btnLoadSongs.Location = new Point(681, 42);
            btnLoadSongs.Name = "btnLoadSongs";
            btnLoadSongs.Size = new Size(111, 23);
            btnLoadSongs.TabIndex = 3;
            btnLoadSongs.Text = "Load Songs";
            btnLoadSongs.UseVisualStyleBackColor = true;
            btnLoadSongs.Click += btnLoadSongs_Click;
            // 
            // tmrProgress
            // 
            tmrProgress.Tick += tmrProgress_Tick;
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Location = new Point(25, 144);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(34, 15);
            lblCurrentTime.TabIndex = 4;
            lblCurrentTime.Text = "00:00";
            // 
            // lblTotalTime
            // 
            lblTotalTime.AutoSize = true;
            lblTotalTime.Location = new Point(491, 144);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(34, 15);
            lblTotalTime.TabIndex = 5;
            lblTotalTime.Text = "00:00";
            lblTotalTime.TextAlign = ContentAlignment.TopRight;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(116, 171);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 22);
            btnPrevious.TabIndex = 6;
            btnPrevious.Text = "|<<";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(278, 171);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 7;
            btnNext.Text = ">>|";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPlayPause
            // 
            btnPlayPause.Location = new Point(197, 171);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(75, 23);
            btnPlayPause.TabIndex = 8;
            btnPlayPause.Text = "▶/⏸";
            btnPlayPause.UseVisualStyleBackColor = true;
            btnPlayPause.Click += btnPlayPause_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(359, 171);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 9;
            btnStop.Text = "■";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // pnlTitleContainer
            // 
            pnlTitleContainer.Controls.Add(lblTitle);
            pnlTitleContainer.Location = new Point(25, 40);
            pnlTitleContainer.Name = "pnlTitleContainer";
            pnlTitleContainer.Size = new Size(500, 61);
            pnlTitleContainer.TabIndex = 10;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(8, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(158, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Select a song";
            // 
            // tkVolume
            // 
            tkVolume.AutoSize = false;
            tkVolume.Location = new Point(561, 71);
            tkVolume.Maximum = 100;
            tkVolume.Name = "tkVolume";
            tkVolume.Orientation = Orientation.Vertical;
            tkVolume.Size = new Size(45, 129);
            tkVolume.TabIndex = 11;
            tkVolume.TickStyle = TickStyle.None;
            tkVolume.Value = 100;
            tkVolume.Scroll += tkVolume_Scroll;
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Location = new Point(583, 127);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(47, 15);
            lblVolume.TabIndex = 12;
            lblVolume.Text = "Volume";
            // 
            // lblSongQueue
            // 
            lblSongQueue.AutoSize = true;
            lblSongQueue.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSongQueue.Location = new Point(25, 267);
            lblSongQueue.Name = "lblSongQueue";
            lblSongQueue.Size = new Size(73, 15);
            lblSongQueue.TabIndex = 13;
            lblSongQueue.Text = "Song Queue";
            // 
            // lstQueue
            // 
            lstQueue.FormattingEnabled = true;
            lstQueue.Location = new Point(25, 285);
            lstQueue.Name = "lstQueue";
            lstQueue.Size = new Size(446, 244);
            lstQueue.TabIndex = 14;
            lstQueue.MouseDoubleClick += lstQueue_MouseDoubleClick;
            // 
            // btnRemoveSong
            // 
            btnRemoveSong.Location = new Point(812, 42);
            btnRemoveSong.Name = "btnRemoveSong";
            btnRemoveSong.Size = new Size(111, 23);
            btnRemoveSong.TabIndex = 15;
            btnRemoveSong.Text = "Remove Song";
            btnRemoveSong.UseVisualStyleBackColor = true;
            btnRemoveSong.Click += btnRemoveSong_Click;
            // 
            // btnAddToQueue
            // 
            btnAddToQueue.Location = new Point(681, 334);
            btnAddToQueue.Name = "btnAddToQueue";
            btnAddToQueue.Size = new Size(242, 23);
            btnAddToQueue.TabIndex = 16;
            btnAddToQueue.Text = "Add to queue";
            btnAddToQueue.UseVisualStyleBackColor = true;
            btnAddToQueue.Click += btnAddToQueue_Click;
            // 
            // btnQueueRemove
            // 
            btnQueueRemove.Location = new Point(477, 285);
            btnQueueRemove.Name = "btnQueueRemove";
            btnQueueRemove.Size = new Size(75, 23);
            btnQueueRemove.TabIndex = 17;
            btnQueueRemove.Text = "Remove";
            btnQueueRemove.UseVisualStyleBackColor = true;
            btnQueueRemove.Click += btnQueueRemove_Click;
            // 
            // btnQueueShuffle
            // 
            btnQueueShuffle.Location = new Point(477, 314);
            btnQueueShuffle.Name = "btnQueueShuffle";
            btnQueueShuffle.Size = new Size(75, 23);
            btnQueueShuffle.TabIndex = 18;
            btnQueueShuffle.Text = "Shuffle";
            btnQueueShuffle.UseVisualStyleBackColor = true;
            btnQueueShuffle.Click += btnQueueShuffle_Click;
            // 
            // btnAddAllToQueue
            // 
            btnAddAllToQueue.Location = new Point(681, 358);
            btnAddAllToQueue.Name = "btnAddAllToQueue";
            btnAddAllToQueue.Size = new Size(242, 23);
            btnAddAllToQueue.TabIndex = 19;
            btnAddAllToQueue.Text = "Add all to queue";
            btnAddAllToQueue.UseVisualStyleBackColor = true;
            btnAddAllToQueue.Click += btnAddAllToQueue_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 584);
            Controls.Add(btnAddAllToQueue);
            Controls.Add(btnQueueShuffle);
            Controls.Add(btnQueueRemove);
            Controls.Add(btnAddToQueue);
            Controls.Add(btnRemoveSong);
            Controls.Add(lstQueue);
            Controls.Add(lblSongQueue);
            Controls.Add(lblVolume);
            Controls.Add(tkVolume);
            Controls.Add(pnlTitleContainer);
            Controls.Add(btnStop);
            Controls.Add(btnPlayPause);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(lblTotalTime);
            Controls.Add(lblCurrentTime);
            Controls.Add(btnLoadSongs);
            Controls.Add(lstLibrary);
            Controls.Add(pnlProgressKnob);
            Controls.Add(pnlProgressBg);
            Name = "Form1";
            Text = "Form1";
            pnlProgressBg.ResumeLayout(false);
            pnlTitleContainer.ResumeLayout(false);
            pnlTitleContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tkVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlProgressBg;
        private Panel pnlProgressBar;
        private Panel pnlProgressKnob;
        private ListBox lstLibrary;
        private Button btnLoadSongs;
        private System.Windows.Forms.Timer tmrProgress;
        private Label lblCurrentTime;
        private Label lblTotalTime;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnPlayPause;
        private Button btnStop;
        private Panel pnlTitleContainer;
        private Label lblTitle;
        private TrackBar tkVolume;
        private Label lblVolume;
        private Label lblSongQueue;
        private ListBox lstQueue;
        private Button btnRemoveSong;
        private Button btnAddToQueue;
        private Button btnQueueRemove;
        private Button btnQueueShuffle;
        private Button btnAddAllToQueue;
    }
}
