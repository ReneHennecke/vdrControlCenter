using System.Drawing;
using System.IO;
using System.Windows.Forms;
using vdrControlCenterUI.Enums;

namespace vdrControlCenterUI.Classes
{
    public class Globals
    {
        public const string ImageFolder = "Images";

        // Navigation TreeView
        public const string NavSetupPng = "setup-icon24x24.png";
        public const string NavSshPng = "ssh-console-icon24x24.png";
        public const string NavServicePng = "network-service-icon24x24.png";
        public const string NavVdrAdminPng = "system-icon24x24.png";
        public const string NavSvdrpPng = "dail-connection-connect-icon24x24.png";
        public const string NavEditPng = "document-edit-icon24x24.png";
        public const string NavEpgPng = "tv-guide-icon24x24.png";

        // TabPages in Workspace
        public const string ClosePng = "cancel-icon16x16.png";

        // ListView
        public const string RedPng = "red-icon16x16.png";
        public const string GreenPng = "green-icon16x16.png";

        public static ImageList LoadImageList(ImageListType type)
        {
            ImageList imageList = new ImageList();
            string fileName = string.Empty;

            switch (type)
            {
                case ImageListType.MainForm:
                    imageList.ImageSize = new Size(24, 24);
                    fileName = $"{ Globals.ImageFolder}/{ Globals.NavSetupPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ Globals.ImageFolder}/{ Globals.NavSshPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ Globals.ImageFolder}/{ Globals.NavServicePng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ Globals.ImageFolder}/{ Globals.NavSvdrpPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ Globals.ImageFolder}/{ Globals.NavVdrAdminPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ Globals.ImageFolder}/{ Globals.NavEditPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ Globals.ImageFolder}/{ Globals.NavEpgPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    break;
                case ImageListType.StationView:
                    imageList.ImageSize = new Size(16, 16);
                    fileName = $"{ImageFolder}/{RedPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{RedPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    break;
            }

            return imageList;
        }

        public static Image LoadImage(string fileName)
        {
            Image image = null;
            if (File.Exists(fileName))
                image = Image.FromFile(fileName);
            return image;
        }
    }
}
