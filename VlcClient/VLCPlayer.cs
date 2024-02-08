using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System.Numerics;

namespace VlcClient
{
    public partial class VLCPlayer : UserControl
    {
        private string _filePath = "";
        bool handChange = false;
        public bool endPlay = false;
        private Action _action;
        private Action<string> _addNewSnap;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private Media media;
        private bool _stop = false;
        LibVLC libvlc;

        public VLCPlayer(string filePath, bool modePlayer = false)
        {
            Core.Initialize();
            InitializeComponent();
            _filePath = filePath;
            libvlc = new LibVLC(enableDebugLogs: false, "--no-snapshot-preview", "--no-osd", "--file-caching=0", "--avcodec-fast");
            trackBar1.Maximum = 1000;
            if (modePlayer)
            {
                snapshotButton.Visible = !modePlayer;
                stopButton.Location = snapshotButton.Location;
            }

        }

        #region MediaPlayer Events
        private void VLCPlayer_Load(object sender, EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(ShortcutEvent);
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            this.MouseWheel += VLCPlayer_MouseWheel;
            Init();
        }

        private void VLCPlayer_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (videoView1 != null && videoView1.MediaPlayer != null)
            {
                if (e.Delta < 0)
                {
                    if (trackBar1.Value - 1 >= 0) trackBar1.Value--;
                }
                else
                {
                    if (trackBar1.Value + 1 <= 1000) trackBar1.Value++;
                }
                handChange = true;
                trackBar1_Scroll(new object(), new EventArgs());
                handChange = false;
            }
        }

        private void MediaPlayer_Stopped(object? sender, EventArgs e)
        {
            Invoke(() => lblMovieDuration.Text = "00:00:00");
            Invoke(() => lblTime.Text = "00:00:00");
        }

        private void MediaPlayer_LengthChanged(object? sender, MediaPlayerLengthChangedEventArgs e)
        {
            string time = TimeSpan.FromMilliseconds(e.Length).ToString(@"hh\:mm\:ss");
            Invoke(() => lblMovieDuration.Text = time);
        }

        private void MediaPlayer_PositionChanged(object? sender, MediaPlayerPositionChangedEventArgs e)
        {
            try
            {
                if (!handChange)
                {
                    var value = (int)(e.Position * 1000);
                    if (value >= 1000) value = 1000;
                    if (value < 0) value = 0;
                    Invoke(() => trackBar1.Value = value);
                }
            }
            catch (Exception)
            {

            }
        }
        private void MediaPlayer_TimeChanged(object? sender, MediaPlayerTimeChangedEventArgs e)
        {
            string time = TimeSpan.FromMilliseconds(e.Time).ToString(@"hh\:mm\:ss");
            Invoke(() => lblTime.Text = time);
        }

        private void MediaPlayer_EndReached(object? sender, EventArgs e)
        {
            endPlay = true;
            Task.Run(() => Replay());
        }
        #endregion

        #region Buttons Events
        private void playButton_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _stop = true;
            Stop();
            Invoke(() => trackBar1.Value = 0);
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            handChange = true;
            Forward();
            handChange = false;

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            handChange = true;
            Back();
            handChange = false;
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            if (!endPlay) Step();
        }

        private void snapshotButton_Click(object sender, EventArgs e)
        {
            Snap();
        }
        #endregion

        #region Other Events        

        private void timer_Tick(object? sender, EventArgs e)
        {
            SetTrackBar();
        }

        public void ShortcutEvent(object? sender, KeyEventArgs e)
        {
            if (videoView1 != null && videoView1.MediaPlayer != null)
            {
                if (e.KeyCode == Keys.Space)
                {
                    Snap();
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (handChange && videoView1 != null && videoView1.MediaPlayer != null)
                {
                    var val = (float)trackBar1.Value / 1000;
                    videoView1.MediaPlayer.Position = val;
                }
            }
            catch { }

        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            handChange = true;
            if (videoView1 != null && videoView1.MediaPlayer != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    var tBar = (TrackBar)sender;
                    int val = (e.X * 1000 / tBar.Width);
                    trackBar1.Value = val;
                    videoView1.MediaPlayer.Position = (float)trackBar1.Value / 1000;
                    videoView1.Refresh();
                    trackBar1.Refresh();
                }
            }
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            handChange = false;
            if (videoView1 != null && videoView1.MediaPlayer != null && videoView1.MediaPlayer.IsPlaying)
            {
                videoView1.MediaPlayer.Pause();
            }

        }

        private void videoView1_MouseClick(object sender, MouseEventArgs e)
        {
            VLCPlayer_MouseClick(sender, e);
        }

        private void VLCPlayer_MouseClick(object sender, MouseEventArgs e)
        {
            if (videoView1 != null && videoView1.MediaPlayer != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    PlayPause();
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    Snap();
                }
            }
        }

        #endregion

        #region Methods
        private void Init()
        {
            if (Path.Exists(_filePath))
            {
                var url = new Uri(_filePath);
                media = new Media(libvlc, url);
            }
            //LibVLCSharp.Shared.MediaPlayer mediaPlayer = new LibVLCSharp.Shared.MediaPlayer(media);
            //mediaPlayer.Play();
            //if (mediaPlayer != null) mediaPlayer.Dispose();
            //mediaPlayer = new MediaPlayer(media);
            videoView1.MediaPlayer = new MediaPlayer(media);// { EnableHardwareDecoding = true };
            //videoView1.MediaPlayer = mediaPlayer;
            videoView1.MediaPlayer.EndReached += new EventHandler<EventArgs>(MediaPlayer_EndReached);
            videoView1.MediaPlayer.TimeChanged += new EventHandler<MediaPlayerTimeChangedEventArgs>(MediaPlayer_TimeChanged);
            videoView1.MediaPlayer.PositionChanged += new EventHandler<MediaPlayerPositionChangedEventArgs>(MediaPlayer_PositionChanged);
            videoView1.MediaPlayer.LengthChanged += new EventHandler<MediaPlayerLengthChangedEventArgs>(MediaPlayer_LengthChanged);
            videoView1.MediaPlayer.Stopped += new EventHandler<EventArgs>(MediaPlayer_Stopped);

            videoView1.MediaPlayer.EnableMouseInput = false;
            videoView1.MediaPlayer.EnableKeyInput = false;
            media.Dispose();
            PlayPause();
        }
        private void Replay()
        {
            try
            {
                Thread.Sleep(500);
                Stop(false);
                PlayPause(false);
            }
            catch (Exception)
            {

                throw;
            }
            finally { endPlay = false; }
        }
        public void Close()
        {
            try
            {
                videoView1?.MediaPlayer?.Dispose();
                libvlc?.Dispose();
                //mediaPlayer?.Dispose();

                //if (videoView1 != null && videoView1.MediaPlayer != null)
                //{
                //    videoView1.MediaPlayer.Pause();
                //    videoView1.MediaPlayer.Stop();
                //    //videoView1.MediaPlayer.EndReached -= new EventHandler<EventArgs>(MediaPlayer_EndReached);
                //    //videoView1.MediaPlayer.TimeChanged -= new EventHandler<MediaPlayerTimeChangedEventArgs>(MediaPlayer_TimeChanged);
                //    //videoView1.MediaPlayer.PositionChanged -= new EventHandler<MediaPlayerPositionChangedEventArgs>(MediaPlayer_PositionChanged);
                //    //videoView1.MediaPlayer.LengthChanged -= new EventHandler<MediaPlayerLengthChangedEventArgs>(MediaPlayer_LengthChanged);
                //    //videoView1.MediaPlayer.Stopped -= new EventHandler<EventArgs>(MediaPlayer_Stopped);
                //    videoView1.MediaPlayer.Dispose();
                //    videoView1.MediaPlayer = null;
                //}
            }
            catch (Exception)
            {
            }
        }
        private void PlayPause(bool buttonsVisible = true)
        {
            try
            {
                timer.Stop();
                if (videoView1 != null && videoView1.MediaPlayer != null)
                {
                    if (videoView1.MediaPlayer.IsPlaying)
                    {
                        videoView1.MediaPlayer.Pause();
                        if (buttonsVisible)
                        {
                            pauseButton.Visible = false;
                            playButton.Visible = true;
                        }
                    }
                    else if (!_stop || !endPlay)
                    {
                        videoView1.MediaPlayer.Play();
                        if (buttonsVisible)
                        {
                            pauseButton.Visible = true;
                            playButton.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Play", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                _stop = false;
            }
        }
        public void Stop(bool buttonsVisible = true)
        {
            try
            {
                if (videoView1 != null && videoView1.MediaPlayer != null)
                {
                    if (buttonsVisible)
                    {
                        pauseButton.Visible = false;
                        playButton.Visible = true;
                    }
                    if (videoView1.MediaPlayer.IsPlaying) videoView1.MediaPlayer.Pause();// Invoke(() => videoView1.MediaPlayer.Pause());//videoView1.MediaPlayer.Pause()
                    videoView1.MediaPlayer.Stop();// Invoke(() => videoView1.MediaPlayer.Stop());//videoView1.MediaPlayer.Stop()

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Forward()
        {
            if (videoView1 != null && videoView1.MediaPlayer != null)
            {
                videoView1.MediaPlayer.Time += 1000;
                if (!videoView1.MediaPlayer.IsPlaying) SetTrackBar(true);
            }
        }
        private void Back()
        {
            if (videoView1 != null && videoView1.MediaPlayer != null)
            {
                videoView1.MediaPlayer.Time -= 1000;
                if (!videoView1.MediaPlayer.IsPlaying) SetTrackBar(true);
            }
        }
        private void Step()
        {
            try
            {
                if (videoView1 != null && videoView1.MediaPlayer != null)
                {
                    if (videoView1.MediaPlayer.IsPlaying)
                    {
                        videoView1.MediaPlayer.Pause();
                        pauseButton.Visible = false;
                        playButton.Visible = true;
                        videoView1.MediaPlayer.NextFrame();

                    }
                    else
                    {
                        videoView1.MediaPlayer.NextFrame();
                        videoView1.MediaPlayer.NextFrame();
                    }
                    SetTrackBar();
                }
            }
            catch { }
        }
        private void Snap()
        {
            if (videoView1 != null && videoView1.MediaPlayer != null && snapshotButton.Visible)
            {
                var path = getSnapshotPath();
                if (videoView1.MediaPlayer.IsPlaying)
                {
                    videoView1.MediaPlayer.Pause();
                    videoView1.MediaPlayer.TakeSnapshot(0, path, 0, 0);
                    videoView1.MediaPlayer.Play();
                }
                else
                {
                    videoView1.MediaPlayer.TakeSnapshot(0, path, 0, 0);
                }
                _addNewSnap?.Invoke(path);
                Task.Run(() => _action?.Invoke());
            }
        }
        //private void RefreshAllTime()
        //{
        //    try
        //    {
        //        if (videoView1 != null && videoView1.MediaPlayer != null)
        //        {
        //            while (handChange)
        //            {
        //                Invoke(() => videoView1.Refresh());
        //                Thread.Sleep(100);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
        private string getSnapshotPath()
        {
            var path = Path.Combine(new FileInfo(_filePath).Directory.FullName, $"snapshot{DateTime.Now.Ticks}_{lblTime.Text.Replace(":", "_")}.png");

            return path;
        }
        private void SetTrackBar(bool force = false)
        {
            try
            {
                if (!handChange || force)
                {
                    if (trackBar1.Value == trackBar1.Maximum || endPlay)
                    {
                        //Stop(false);
                        //videoView1?.MediaPlayer?.Stop();
                        //videoView1?.MediaPlayer?.Play();
                        //PlayPause(false);
                        //mediaPlayer?.Stop();

                        //ThreadPool.QueueUserWorkItem(_ => videoView1.MediaPlayer.Stop());
                        //ThreadPool.QueueUserWorkItem(_ => videoView1.MediaPlayer?.Play());
                        //Invoke(() => mediaPlayer?.Stop());
                        //Invoke(() => mediaPlayer?.Play());
                        trackBar1.Value = 0;
                        timer.Stop();
                        endPlay = false;
                    }
                    if (videoView1 != null && videoView1.MediaPlayer != null)
                    {
                        var value = (int)(videoView1.MediaPlayer.Position * 1000);
                        if (value >= 970) value = 1000;
                        if (value < 0) value = 0;
                        //lblMovieDuration.Text = videoView1.MediaPlayer.Time.ToString();
                        //lblTime.Text = videoView1.MediaPlayer.Position.ToString();
                        trackBar1.Value = value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Set TrackBar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                timer.Stop();
                endPlay = false;
            }
        }
        #endregion

        #region Add Actions
        public void RefreshMultimedia(Action action)
        {
            _action = action;
        }
        public void AddNameFilePhoto(Action<string> action)
        {
            _addNewSnap = action;
        }

        #endregion

    }
}
