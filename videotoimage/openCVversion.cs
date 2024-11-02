using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace videotoimage
{
    public class openCVversion
    {
        public static bool VideoToImage(string VideoUrl)
        {
            var videoFile = VideoUrl;
            System.IO.Directory.CreateDirectory("frames");

            var capture = new VideoCapture(videoFile);
            //     var window = new Window("El Bruno - OpenCVSharp Save Video Frame by Frame");
            var image = new Mat();

            var i = 0;
            while (capture.IsOpened())
            {
                capture.Read(image);
                if (image.Empty())
                    break;

                i++;
                if (i % 15 == 0)
                {
                    var imgNumber = i.ToString().PadLeft(8, '0');

                    var frameImageFileName = $@"frames\\{Path.GetFileName(VideoUrl)}{imgNumber}.png";
                    Cv2.ImWrite(frameImageFileName, image);

                    //window.ShowImage(image);
                    if (Cv2.WaitKey(1) == 113) // Q
                        break;
                }
            }

            Console.WriteLine("Complete !");
            return true;
        }
    }
}