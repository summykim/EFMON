using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EFM_INK
{
    /// <summary>
    /// Simple file formats handling, here I wanted the simplest interface I could for the main window class to have the ability to save from or two
    /// a variety of formats. Right now, saving to jpg/png and xaml is support, reading from jpg/png is mostly function.
    /// Lots of rough edges as it's the simplest tutoring project possible that would have enough interest to cover a wide variety of C# and WPF.
    /// </summary>
    
    public static class FileExports
    {
        
        private static InkCanvas surface { get; set; }
        public static string ExportBase64(this InkCanvas canvas, int format)
        {
            surface = canvas;
            string base64img = null ;
            switch (format)
            {
                case 1:
                    base64img=ExportToBase64( new PngBitmapEncoder());
                    break;
                case 2:
                    base64img=ExportToBase64( new JpegBitmapEncoder());
                    break;
            }
            return base64img;
        }
        public static void ExportFile(this InkCanvas canvas, string filename, int format)
        {
            surface = canvas;
            switch (format)
            {
                case 1: ExportToPng(new Uri( filename), new PngBitmapEncoder());
                    break;
                case 2: ExportToPng(new Uri(filename), new JpegBitmapEncoder());
                    break;
            }
        }


        public static void OpenFile(this InkCanvas canvas, string filename, int format)
        {
            surface = canvas;
            switch (format)
            {
                case 1: OpenPng(  new BitmapImage( new Uri(filename, UriKind.Relative))  );
                    break;
                case 2:
                    OpenPng(new BitmapImage(new Uri(filename, UriKind.Relative)));
                    break;
            }
        }


        private static void OpenPng(BitmapImage bitmapImage)
        {

            var brush = new ImageBrush {ImageSource = bitmapImage};  
            
            surface.Background = brush;
        }
        private static void ExportToPng(  Uri path, BitmapEncoder encoder)
        {
            if (path == null) return;

            // Save current canvas transform
            Transform transform = surface.LayoutTransform;
            // reset current transform (in case it is scaled or rotated)
            surface.LayoutTransform = null;
            double w = surface.Width.CompareTo(double.NaN) == 0 ? surface.ActualWidth : surface.Width;
            double h = surface.Height.CompareTo(double.NaN) == 0 ? surface.ActualHeight : surface.Height;
            // Get the size of canvas
            Size size = new Size(w, h);
            // Measure and arrange the surface
            // VERY IMPORTANT
            surface.Measure(size);
            surface.Arrange(new Rect(size));

            // Create a render bitmap and push the surface to it
            RenderTargetBitmap renderBitmap =
              new RenderTargetBitmap(
                (int)size.Width,
                (int)size.Height,
                96d,
                96d,
                PixelFormats.Pbgra32);
            renderBitmap.Render(surface);

            // Create a file stream for saving image
            using (FileStream outStream = new FileStream(path.LocalPath, FileMode.Create))
            {
                // Use png encoder for our data -imjected the dependency
            //    PngBitmapEncoder encoder = new PngBitmapEncoder();
                // push the rendered bitmap to it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                // save the data to the stream
                encoder.Save(outStream);
            }

            // Restore previously saved layout
            surface.LayoutTransform = transform;

        }


        private static string  ExportToBase64( BitmapEncoder encoder)
        {
      
            // Save current canvas transform
            Transform transform = surface.LayoutTransform;
            // reset current transform (in case it is scaled or rotated)
            surface.LayoutTransform = null;
            double w = surface.Width.CompareTo(double.NaN) == 0 ? surface.ActualWidth : surface.Width;
            double h = surface.Height.CompareTo(double.NaN) == 0 ? surface.ActualHeight : surface.Height;
            // Get the size of canvas
            Size size = new Size(w, h);
            // Measure and arrange the surface
            // VERY IMPORTANT
            surface.Measure(size);
            surface.Arrange(new Rect(size));

            // Create a render bitmap and push the surface to it
            RenderTargetBitmap renderBitmap =
              new RenderTargetBitmap(
                (int)size.Width,
                (int)size.Height,
                96d,
                96d,
                PixelFormats.Pbgra32);
            renderBitmap.Render(surface);
            string base64Img = "";
            using (MemoryStream outStream = new MemoryStream())
            {
                // Use png encoder for our data -imjected the dependency
                //    PngBitmapEncoder encoder = new PngBitmapEncoder();
                // push the rendered bitmap to it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                // save the data to the stream
                encoder.Save(outStream);

                byte[] myBinary = outStream.ToArray();

                base64Img = Convert.ToBase64String(myBinary);

                base64Img = "data:image/jpg;base64," + base64Img;
                Console.WriteLine(base64Img);
            }

            // Restore previously saved layout
            surface.LayoutTransform = transform;
            return base64Img;
        }
    }
}
