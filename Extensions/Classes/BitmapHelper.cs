namespace Extensions.Classes
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public static class BitmapHelper
    {

        public static Bitmap CopyToSquareCanvas(this Bitmap sourceBitmap, Color canvasBackground)
        {
            int maxSide = sourceBitmap.Width > sourceBitmap.Height ? sourceBitmap.Width : sourceBitmap.Height;


            Bitmap bitmapResult = new Bitmap(maxSide, maxSide, PixelFormat.Format32bppArgb);


            using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
            {
                graphicsResult.Clear(canvasBackground);


                int xOffset = (sourceBitmap.Width - maxSide) / 2;
                int yOffset = (sourceBitmap.Height - maxSide) / 2;


                graphicsResult.DrawImage(sourceBitmap, new Point(xOffset, xOffset));
            }


            return bitmapResult;
        }

        public static Icon CreateIcon(Bitmap sourceBitmap, Enums.IconSizeDimensions iconSize)
        {
            return CreateIcon(sourceBitmap, (int)iconSize, (int)iconSize);
        }

        public static Icon CreateIcon(Bitmap sourceBitmap, int width, int height)
        {
            Bitmap squareCanvas = sourceBitmap.CopyToSquareCanvas(Color.Transparent);
            squareCanvas = (Bitmap)squareCanvas.GetThumbnailImage(width, height, null, new IntPtr());

            Icon iconResult = Icon.FromHandle(squareCanvas.GetHicon());

            return iconResult;
        }
    }
}
