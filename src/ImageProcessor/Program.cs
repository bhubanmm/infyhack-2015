using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace ImageProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = "D:\\HACK2015\\PICS";
                Bitmap sourceImage = AForge.Imaging.Image.FromFile(Path.Combine(path, "CAM1s.jpg"));
                Difference differenceFilter = new Difference(); //AForge.Imaging.Filters.Difference
                differenceFilter.OverlayImage = sourceImage;

                Bitmap sourceImg = AForge.Imaging.Image.FromFile(Path.Combine(path, "CAM1.jpg"));
                Bitmap tempImg = sourceImg.Clone() as Bitmap;
                tempImg = differenceFilter.Apply(tempImg);
                FiltersSequence seq = new FiltersSequence();
                seq.Add(Grayscale.CommonAlgorithms.BT709);
                seq.Add(new OtsuThreshold());
                tempImg = seq.Apply(tempImg);
                tempImg.Save(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "CAM1.jpg"));

                int objectCount = 0;

                BlobCounter blobCounter = new BlobCounter();
                blobCounter.FilterBlobs = true;
                blobCounter.MinHeight = 60;
                blobCounter.MinWidth = 40;
                blobCounter.ProcessImage(tempImg);
                Blob[] blobs = blobCounter.GetObjectsInformation();
                for (int i = 0; i < blobs.Length; i++)
                {
                    List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
                    List<IntPoint> corners = null;
                    SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
                    if (shapeChecker.IsQuadrilateral(edgePoints, out corners))
                        ++objectCount;
                }

                Console.WriteLine("No. of BLOBS: " + blobCounter.GetObjectsInformation().Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
