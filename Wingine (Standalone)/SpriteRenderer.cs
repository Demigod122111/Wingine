using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wingine
{
    [Serializable]
    public class SpriteRenderer : IComponent
    {
        public string ImageData;

        [ActionButton(true)]
        public Action GetImageDataFromFile;


        public SpriteRenderer()
        {
            GetImageDataFromFile = () =>
            {
                GetImageData();
            };
        }


        void GetImageData()
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image File: ";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imageFilePath = ofd.FileName;

                byte[] imageArray = System.IO.File.ReadAllBytes(imageFilePath);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                ImageData = base64ImageRepresentation;
            }
        }

        public Bitmap GetImage()
        {
            try
            {
                return new Bitmap(Image.FromStream(new MemoryStream(Convert.FromBase64String(ImageData))));
            }
            catch
            {
                return new Bitmap(32, 32);
            }
        }


        public override void Begin()
        {

        }

        public override void Tick()
        {

        }
    }
}
