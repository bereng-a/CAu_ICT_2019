using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using T_Easy.Models;
using T_Easy.ViewModels;

namespace T_Easy.Views
{
    public partial class DocumentView : UserControl
    {
        DocumentViewModel _viewModel = new DocumentViewModel();
        public string UploadFilePath { get; set; }
        public string FileName { get; set; }

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
            }
        }

        private void Download(object sender, RoutedEventArgs e)
        {
            DownloadFile(((Button)sender).Tag.ToString());
            Process.Start(Path.GetTempPath() + "/T-Easy");
        }

        private void SaveFile(string localFilePath, string fileNameInS3)
        {
            IAmazonS3 client = new AmazonS3Client();
            TransferUtility utility = new TransferUtility(client);
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest
            {
                BucketName = "teasy",
                Key = fileNameInS3,
                FilePath = localFilePath
            };

            _viewModel.Path = fileNameInS3;
            utility.Upload(request);
        }

        private void DownloadFile(string fileNameInS3)
        {
            IAmazonS3 client = new AmazonS3Client();
            TransferUtility utility = new TransferUtility(client);
            TransferUtilityDownloadRequest request = new TransferUtilityDownloadRequest();

            request.Key = fileNameInS3;
            request.BucketName = "teasy";
            request.FilePath = Path.Combine(Path.GetTempPath(), "T-Easy/" + fileNameInS3);
            utility.Download(request);
        }

        private async void DeleteFile(string fileNameInS3)
        {
            IAmazonS3 client = new AmazonS3Client();
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = "teasy",
                Key = fileNameInS3
            };
            await client.DeleteObjectAsync(deleteObjectRequest);
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFile(UploadFilePath, FileName);
            _viewModel.CreateDocument();
            DestinationDialog.IsOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(((Button)sender).Tag.ToString());
            var tmp = _viewModel.Documents.Where(x => x.Id == id).First();
            DeleteFile(tmp.Path);
            _viewModel.DeleteDocument(id);
        }
    }
}