using CommunityToolkit.Maui.Storage;

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
    }
}
