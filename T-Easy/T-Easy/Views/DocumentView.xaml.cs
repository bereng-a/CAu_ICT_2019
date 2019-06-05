using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using T_Easy.ViewModels;

namespace T_Easy.Views
{
    public partial class DocumentView : UserControl
    {
        DocumentViewModel _viewModel = new DocumentViewModel();
        public string UploadFilePath { get; set; }
        public string FileName { get; set; }
        public string TargetFilePath { get; set; }

        public DocumentView()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }

        private void Upload(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) {
                UploadFilePath = openFileDialog.FileName;
                FileName = openFileDialog.SafeFileName;
                SendMyFileToS3(UploadFilePath, "teasy", null, FileName);
            }
        }

        private void Download(object sender, RoutedEventArgs e)
        {
            DownloadFile("teasy", ((Button)sender).Tag.ToString());
            Process.Start(Path.GetTempPath() + "/T-Easy");
        }

        private void SendMyFileToS3(string localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)
        {
            IAmazonS3 client = new AmazonS3Client();
            TransferUtility utility = new TransferUtility(client);
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

            if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
            {
                request.BucketName = bucketName;
            }
            request.Key = fileNameInS3;
            request.FilePath = localFilePath;
            _viewModel.Path = fileNameInS3;
            utility.Upload(request);
        }

        private void DownloadFile(string bucketName, string fileNameInS3)
        {
            IAmazonS3 client = new AmazonS3Client();
            TransferUtility utility = new TransferUtility(client);
            TransferUtilityDownloadRequest request = new TransferUtilityDownloadRequest();

            request.Key = fileNameInS3;
            request.BucketName = bucketName;
            request.FilePath = Path.Combine(Path.GetTempPath(), "T-Easy/" + fileNameInS3);
            utility.Download(request);
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CreateDocument();
            DestinationDialog.IsOpen = false;
        }
    }
}