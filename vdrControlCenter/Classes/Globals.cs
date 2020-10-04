using System.Drawing;
using System.IO;
using System.Windows.Forms;
using vdrControlCenterUI.Enums;

namespace vdrControlCenterUI.Classes
{
    public class Globals
    {
        public const string ImageFolder = "./Images";

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

        // SvdrpConnector
        public const string ConnectPng = "actions-network-connect-icon16x16.png";
        public const string DisconnectPng = "actions-network-disconnect-icon16x16.png";

        // EPGListView
        public const string FindPng = "zoom-icon16x16.png";
        public const string TimerPng = "clock-icon16x16.png";
        public const string RequestPng = "get-list-icon16x16.png";
        public const string FavouritesPng = "favourites-icon16x16.png";
        public const string RecordPng = "actions-media-record-icon16x16.png";


        // dlgFindEPG
        public const string Find_FindPng = FindPng;
        public const string Find_OkPng = "ok-icon16x16.png";
        public const string Find_CancelPng = ClosePng;

        // Allgemein
        public const string EmptyPng = "empty16x16.png";

        public static ImageList LoadImageList(ImageListType type)
        {
            ImageList imageList = new ImageList();
            string fileName = string.Empty;

            switch (type)
            {
                case ImageListType.MainForm:
                    imageList.ImageSize = new Size(24, 24);
                    fileName = $"{ImageFolder}/{ NavSetupPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{ NavSshPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{ NavServicePng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{ NavSvdrpPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{ NavVdrAdminPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{ NavEditPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{ NavEpgPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    break;
                case ImageListType.StationView:
                    imageList.ImageSize = new Size(16, 16);
                    fileName = $"{ImageFolder}/{RedPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{GreenPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    break;
                case ImageListType.EPGListView:
                    imageList.ImageSize = new Size(16, 16);
                    fileName = $"{ImageFolder}/{EmptyPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{FavouritesPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{TimerPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{RecordPng}";
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
