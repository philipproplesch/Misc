using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Web;

namespace BlogSamples.TextHandler
{
    /// <summary>
    /// Summary description for TextHandler
    /// </summary>
    public class TextHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";

            string text = context.Request["text"];
            string fontName = context.Request["font"];
            float size = Convert.ToSingle(context.Request["size"]);
            string color = !string.IsNullOrWhiteSpace(context.Request["color"])
                               ? context.Request["color"]
                               : "#000000";

            if (!color.StartsWith("#"))
                color = string.Concat("#", color);

            if(string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(fontName))
                return;

            var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);

            #region Get custom font.
            var privateFontCollection =
                new PrivateFontCollection();

            privateFontCollection.AddFontFile(
                context.Server.MapPath(
                    string.Concat("~/App_Data/", fontName, ".ttf")));

            var font = new Font(privateFontCollection.Families[0], size);
            #endregion
            
            // Get the required size for the image.
            var imageDimensions = graphics.MeasureString(text, font);

            // Recreate the image with the correct dimensions.
            bitmap = new Bitmap((int) imageDimensions.Width,
                                (int) imageDimensions.Height);
            graphics = Graphics.FromImage(bitmap);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphics.DrawString(text, font,
                                new SolidBrush(ColorTranslator.FromHtml(color)),
                                0, 0);

            // Write the image to the output stream.
            bitmap.Save(context.Response.OutputStream, ImageFormat.Png);

            bitmap.Dispose();
            graphics.Dispose();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}