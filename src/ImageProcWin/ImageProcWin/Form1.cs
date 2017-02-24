using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcWin
{
    public partial class Form1 : Form
    {
        string path = "D:\\HACK2015\\PICS";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap sourceImg = AForge.Imaging.Image.FromFile(Path.Combine(path, "CAM1.jpg")).Clone() as Bitmap;
                picSource.Image = sourceImg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            AugmentedMethod2();
        }

        private void AugmentedMethod2()
        {
            UnmanagedImage image = UnmanagedImage.FromManagedImage(new Bitmap(picSource.Image));

            // 1 - grayscaling
            UnmanagedImage grayImage = null;

            if (image.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                grayImage = image;
            }
            else
            {
                grayImage = UnmanagedImage.Create(image.Width, image.Height,
                    PixelFormat.Format8bppIndexed);
                Grayscale.CommonAlgorithms.BT709.Apply(image, grayImage);
            }

            // 2 - Edge detection
            DifferenceEdgeDetector edgeDetector = new DifferenceEdgeDetector();
            UnmanagedImage edgesImage = edgeDetector.Apply(grayImage);

            // 3 - Threshold edges
            Threshold thresholdFilter = new Threshold(40);
            thresholdFilter.ApplyInPlace(edgesImage);

            // create and configure blob counter
            BlobCounter blobCounter = new BlobCounter();

            blobCounter.MinHeight = 32;
            blobCounter.MinWidth = 32;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;

            // 4 - find all stand alone blobs
            blobCounter.ProcessImage(edgesImage);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            int counter = 0;

            // 5 - check each blob
            for (int i = 0, n = blobs.Length; i < n; i++)
            {
                // get edge points on the left and on the right side
                List<IntPoint> leftEdgePoints, rightEdgePoints;
                blobCounter.GetBlobsLeftAndRightEdges(blobs[i], out leftEdgePoints, out rightEdgePoints);

                // calculate average difference between pixel values from outside of the
                // shape and from inside
                float diff = CalculateAverageEdgesBrightnessDifference(
                    leftEdgePoints, rightEdgePoints, grayImage);

                // check average difference, which tells how much outside is lighter than
                // inside on the average
                if (diff >= 50)
                {
                    ++counter;
                }

                txtOut.AppendText(diff + ",");

                /*List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
                List<IntPoint> corners = null;

                // does it look like a quadrilateral ?
                if (shapeChecker.IsQuadrilateral(edgePoints, out corners))
                {
                    ++counter;
                }*/
            }

            txtOut.AppendText(Environment.NewLine);

            lblCount.Text = counter.ToString();
            picResult.Image = edgesImage.ToManagedImage();
        }

        private void btnWatch_Click(object sender, EventArgs e)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(path);
            watcher.Filter = "*.jpg";
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            watcher.Created += watcher_Changed;
            watcher.Changed += watcher_Changed;
            watcher.EnableRaisingEvents = true;
        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                Bitmap image = AForge.Imaging.Image.FromFile(e.FullPath).Clone() as Bitmap;
                int availableSlots = ProcessWithAugmentedMethod(image);
                string camName = e.Name.Replace(".jpg", "");
                switch (camName)
                {
                    case "CAM1":
                        //PostDataFile("CAM1", "P1", availableSlots);
                        PostData("1", availableSlots);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(Path.Combine(Application.StartupPath, "error.txt"), ex.ToString());
            }
        }

        private void PostDataFile(string camera, string parking, int availableSlots)
        {
            try
            {
                string data = String.Format("Camera: {0}; Parking: {1}; Availability: {2}{3}", camera, parking, availableSlots, Environment.NewLine);
                File.AppendAllText(Path.Combine(Application.StartupPath, "out.txt"), data);
                //txtOut.AppendText(data);
            }
            catch (Exception ex)
            {
                File.AppendAllText(Path.Combine(Application.StartupPath, "error.txt"), ex.ToString());
            }
        }

        private void PostData(string parking, int availableSlots)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string url = String.Format("http://192.168.0.149:8085/Service1.svc/InsertParkingAvailability?ParkingId={0}&Count={1}", parking, availableSlots);
                    string response = client.DownloadString(url);
                    File.AppendAllText(Path.Combine(Application.StartupPath, "error.txt"), response);
                }

                /*string data = String.Format("Camera: {0}; Parking: {1}; Availability: {2}{3}", camera, parking, availableSlots, Environment.NewLine);
                HttpWebRequest req = WebRequest.Create("") as HttpWebRequest;
                string result = null;
                using (HttpWebResponse resp = req.GetResponse()
                                              as HttpWebResponse)
                {
                    StreamReader reader =
                        new StreamReader(resp.GetResponseStream());
                    result = reader.ReadToEnd();
                }*/
            }
            catch (Exception ex)
            {
                File.AppendAllText(Path.Combine(Application.StartupPath, "error.txt"), ex.ToString());
            }
        }

        private int ProcessWithAugmentedMethod(Bitmap srcImage)
        {
            UnmanagedImage image = UnmanagedImage.FromManagedImage(srcImage.Clone() as Bitmap);

            // 1 - grayscaling
            UnmanagedImage grayImage = null;

            if (image.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                grayImage = image;
            }
            else
            {
                grayImage = UnmanagedImage.Create(image.Width, image.Height, PixelFormat.Format8bppIndexed);
                Grayscale.CommonAlgorithms.BT709.Apply(image, grayImage);
            }

            // 2 - Edge detection
            DifferenceEdgeDetector edgeDetector = new DifferenceEdgeDetector();
            UnmanagedImage edgesImage = edgeDetector.Apply(grayImage);

            // 3 - Threshold edges
            Threshold thresholdFilter = new Threshold(40);
            thresholdFilter.ApplyInPlace(edgesImage);

            // create and configure blob counter
            BlobCounter blobCounter = new BlobCounter();

            blobCounter.MinHeight = 32;
            blobCounter.MinWidth = 32;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;

            // 4 - find all stand alone blobs
            blobCounter.ProcessImage(edgesImage);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            int counter = 0;

            // 5 - check each blob
            for (int i = 0, n = blobs.Length; i < n; i++)
            {
                // get edge points on the left and on the right side
                List<IntPoint> leftEdgePoints, rightEdgePoints;
                blobCounter.GetBlobsLeftAndRightEdges(blobs[i], out leftEdgePoints, out rightEdgePoints);

                // calculate average difference between pixel values from outside of the
                // shape and from inside
                float diff = CalculateAverageEdgesBrightnessDifference(
                    leftEdgePoints, rightEdgePoints, grayImage);

                // check average difference, which tells how much outside is lighter than
                // inside on the average
                if (diff >= 50)
                {
                    ++counter;
                }


                /*List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
                List<IntPoint> corners = null;

                // does it look like a quadrilateral ?
                if (shapeChecker.IsQuadrilateral(edgePoints, out corners))
                {
                    ++counter;
                }*/
            }

            return counter;
        }

        const int stepSize = 3;

        // Calculate average brightness difference between pixels outside and
        // inside of the object bounded by specified left and right edge
        private float CalculateAverageEdgesBrightnessDifference(
            List<IntPoint> leftEdgePoints,
            List<IntPoint> rightEdgePoints,
            UnmanagedImage image)
        {
            // create list of points, which are a bit on the left/right from edges
            List<IntPoint> leftEdgePoints1 = new List<IntPoint>();
            List<IntPoint> leftEdgePoints2 = new List<IntPoint>();
            List<IntPoint> rightEdgePoints1 = new List<IntPoint>();
            List<IntPoint> rightEdgePoints2 = new List<IntPoint>();

            int tx1, tx2, ty;
            int widthM1 = image.Width - 1;

            for (int k = 0; k < leftEdgePoints.Count; k++)
            {
                tx1 = leftEdgePoints[k].X - stepSize;
                tx2 = leftEdgePoints[k].X + stepSize;
                ty = leftEdgePoints[k].Y;

                leftEdgePoints1.Add(new IntPoint(
                    (tx1 < 0) ? 0 : tx1, ty));
                leftEdgePoints2.Add(new IntPoint(
                    (tx2 > widthM1) ? widthM1 : tx2, ty));

                tx1 = rightEdgePoints[k].X - stepSize;
                tx2 = rightEdgePoints[k].X + stepSize;
                ty = rightEdgePoints[k].Y;

                rightEdgePoints1.Add(new IntPoint(
                    (tx1 < 0) ? 0 : tx1, ty));
                rightEdgePoints2.Add(new IntPoint(
                    (tx2 > widthM1) ? widthM1 : tx2, ty));
            }

            // collect pixel values from specified points
            byte[] leftValues1 = image.Collect8bppPixelValues(leftEdgePoints1);
            byte[] leftValues2 = image.Collect8bppPixelValues(leftEdgePoints2);
            byte[] rightValues1 = image.Collect8bppPixelValues(rightEdgePoints1);
            byte[] rightValues2 = image.Collect8bppPixelValues(rightEdgePoints2);

            // calculate average difference between pixel values from outside of
            // the shape and from inside
            float diff = 0;
            int pixelCount = 0;

            for (int k = 0; k < leftEdgePoints.Count; k++)
            {
                if (rightEdgePoints[k].X - leftEdgePoints[k].X > stepSize * 2)
                {
                    diff += (leftValues1[k] - leftValues2[k]);
                    diff += (rightValues2[k] - rightValues1[k]);
                    pixelCount += 2;
                }
            }

            return diff / pixelCount;
        }
    }
}
