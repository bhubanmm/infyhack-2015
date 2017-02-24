using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoFeed
{
    public partial class frmMain : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCapabilities[] videoCapabilities;
        private VideoCaptureDevice videoDevice;

        public frmMain()
        {
            InitializeComponent();
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            EnumerateVideoDevices();
        }

        private void EnumerateVideoDevices()
        {
            if (videoDevices.Count > 0)
            {
                foreach (FilterInfo device in videoDevices)
                {
                    cmbSources.Items.Add(device.Name);
                }
            }
            else
            {
                cmbSources.Items.Add("No DirectShow devices found");
            }

            cmbSources.SelectedIndex = 0;
        }

        private void cmbSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[cmbSources.SelectedIndex].MonikerString);
                EnumerateVideoModes(videoDevice);
            }
        }

        private void EnumerateVideoModes(VideoCaptureDevice videoDevice)
        {
            this.Cursor = Cursors.WaitCursor;

            cmbModes.Items.Clear();

            try
            {
                videoCapabilities = videoDevice.VideoCapabilities;

                foreach (VideoCapabilities capabilty in videoCapabilities)
                {
                    if (!cmbModes.Items.Contains(capabilty.FrameSize))
                    {
                        cmbModes.Items.Add(capabilty.FrameSize);
                    }
                }

                if (videoCapabilities.Length == 0)
                {
                    cmbModes.Items.Add("Not supported");
                }

                cmbModes.SelectedIndex = 0;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (videoDevice != null)
            {
                if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                {
                    videoDevice.DesiredFrameSize = (Size)cmbModes.SelectedItem;
                }

                videoSourcePlayer.VideoSource = videoDevice;
                videoSourcePlayer.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                // stop video device
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                videoSourcePlayer.VideoSource = null;
            }

            timer.Stop();
        }

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            try
            {
                (image.Clone() as Bitmap).Save(Path.Combine("D:\\HACK2015\\PICS", "CAM1.jpg"), ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                videoSourcePlayer.NewFrame -= videoSourcePlayer_NewFrame;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (videoSourcePlayer.VideoSource != null)
                videoSourcePlayer.NewFrame += videoSourcePlayer_NewFrame;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            timer.Interval = Convert.ToInt32(TimeSpan.FromSeconds(Convert.ToDouble(nudInterval.Value)).TotalMilliseconds);
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (videoSourcePlayer.GetCurrentVideoFrame() as Bitmap).Save(Path.Combine("D:\\HACK2015\\PICS", "CAM1s.jpg"), ImageFormat.Jpeg);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnStop_Click(null, null);
        }
    }
}
