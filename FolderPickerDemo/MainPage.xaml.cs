﻿using CommunityToolkit.Maui.Storage;

namespace FolderPickerDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
               var result = await FolderPicker.Default.PickAsync();

                if (result != null)
                {
                    this.result.Text = result.IsSuccessful ? "folder picked: " + result.Folder.ToString() : "no folder picked";
                }
            });
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            try
            {
                var defaultFolder = AppDomain.CurrentDomain.BaseDirectory;
                // Convert the directory path to a file URL with the "file://" scheme
                var folderUri = new Uri($"file://{defaultFolder}");

                Microsoft.Maui.ApplicationModel.Launcher.Default.OpenAsync(folderUri);
            }
            catch (Exception ex)
            {
                this.result.Text = "Error: " + ex.Message;
            }
        }
    }
}
