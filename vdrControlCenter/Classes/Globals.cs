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

        // SvdrpChannelsView
        // Left
        public const string ScvlRadioPng = "radio-icon16.x16.png";
        public const string ScvlTvPng = "tv-set-retro-icon16x16.png";
        // Right
        public const string ScvrEmptyPng = "empty16x16.png";
        public const string ScvrFavouritesPng = "favourites-icon16x16.png";
        // Rest
        public const string ScvNewPng = "new-file-icon16x16.png";
        public const string ScvDelPng = "recycle-bin-icon16x16.png";
        public const string ScvRequestPng = "get-list-icon16x16.png";
        public const string ScvNoLogoPng = "empty16x16.png";

        // SvdrpTimersView
        public const string StvPassivePng = "cancel-icon16x16.png";
        public const string StvActivePng = "ok-icon16x16.png";
        public const string StvNewPng = "new-file-icon16x16.png";
        public const string StvDelPng = "recycle-bin-icon16x16.png";
        public const string StvRequestPng = "get-list-icon16x16.png";

        // SvdrpRecordingsView
        public const string SrvEmptyPng = "empty16x16.png";
        public const string SrvCutPng = "actions-edit-cut-icon16x16.png";
        public const string SrvNewPng = "new-file-icon16x16.png";
        public const string SrvDelPng = "recycle-bin-icon16x16.png";
        public const string SrvRequestPng = "get-list-icon16x16.png";

        // SvdrpEpgView
        public const string SevFindPng = "zoom-icon16x16.png";
        public const string SevTimerPng = "clock-icon16x16.png";
        public const string SevRequestPng = "get-list-icon16x16.png";
        public const string SevFavouritesPng = "favourites-icon16x16.png";
        public const string SevRecordPng = "actions-media-record-icon16x16.png";
        public const string SevSelectPng = "ok-icon16x16.png";

        // SvdrpStatusInfoView
        public const string SsivRequestPng = "get-list-icon16x16.png";

        // dlgFindEPG
        public const string Find_FindPng = "zoom-icon16x16.png";
        public const string Find_TimerPng = "clock-icon16x16.png";
        public const string Find_CancelPng = "cancel-icon16x16.png";

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
                case ImageListType.SvdrpChannelsViewLeft:
                    imageList.ImageSize = new Size(16, 16);
                    fileName = $"{ImageFolder}/{ScvlRadioPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{ScvlTvPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    break;
                case ImageListType.SvdrpChannelsViewRight:
                    imageList.ImageSize = new Size(16, 16);
                    fileName = $"{ImageFolder}/{ScvrEmptyPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{ScvrFavouritesPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    break;
                case ImageListType.SvdrpChannelLogos:
                    imageList.ImageSize = new Size(16, 16);
                    DirectoryInfo di = new DirectoryInfo("D:\\channellogos");
                    foreach (FileInfo fi in di.GetFiles("*.png"))
                    {
                        Image image = Image.FromFile(fi.FullName);
                        imageList.Images.Add(fi.Name.ToLower(), image);
                    }
                    break;
                case ImageListType.SvdrpTimersView:
                    imageList.ImageSize = new Size(16, 16);
                    fileName = $"{ImageFolder}/{StvActivePng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{StvPassivePng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    break;
                case ImageListType.SvdrpRecordingsView:
                    imageList.ImageSize = new Size(16, 16);
                    fileName = $"{ImageFolder}/{SrvEmptyPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{SrvCutPng}";
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
                case ImageListType.SvdrpEpgView:
                    imageList.ImageSize = new Size(16, 16);
                    fileName = $"{ImageFolder}/{EmptyPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{SevFavouritesPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{SevTimerPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{SevRecordPng}";
                    if (File.Exists(fileName))
                        imageList.Images.Add(Image.FromFile(fileName));
                    fileName = $"{ImageFolder}/{SevSelectPng}";
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
