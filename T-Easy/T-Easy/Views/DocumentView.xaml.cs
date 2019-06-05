using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using T_Easy.Utils;
using T_Easy.ViewModels;

namespace T_Easy.Views
{
    public partial class DocumentView : UserControl
    {
        public string UploadFilePath { get; set; }
        public string FileName { get; set; }
        public string TargetFilePath { get; set; }

        public DocumentView()
        {
            InitializeComponent();
            base.DataContext = new DocumentViewModel();
        }

        private void Upload(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) {
                UploadFilePath = openFileDialog.FileName;
                FileName = openFileDialog.SafeFileName;
                sendMyFileToS3(UploadFilePath, "teasy", null, FileName);
            }
        }

        public bool sendMyFileToS3(string localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)
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
            utility.Upload(request);

            return true;
        }
    }
}