using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using ZakupowoMobile.ViewModels;
using ZakupowoMobile.Models;

namespace ZakupowoMobile.Views.Offer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOfferPage : ContentPage
    {
       
        public AddOfferPage()
        {
            InitializeComponent();
            BindingContext = new ListViewDataModel();
        }
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                //FileTypes = customFileType,
                PickerTitle = "Pick an image"
            });

            if (pickResult != null)
            {
                var stream = await pickResult.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
            }
        }

        async void Button1_Clicked(System.Object sender, System.EventArgs e)
        {
            var pickResult = await FilePicker.PickMultipleAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick image(s)"
            });

            if (pickResult != null)
            {
                var imageList = new List<ImageSource>();

                foreach (var image in pickResult)
                {
                    var stream = await image.OpenReadAsync();

                    imageList.Add(ImageSource.FromStream(() => stream));
                }

                collectionView.ItemsSource = imageList;
            }
        }
        async void Button2_Clicked(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                resultImage.Source = ImageSource.FromStream(() => stream);
            }
        }

        private void addOffer_Clicked(object sender, EventArgs e)
        {
            string title = 
            string categoryId = ((Category)CategoryBinder.SelectedItem).CategoryID;
            CrossFileUploader.Current.UploadFileAsync("<URL HERE>", new FilePathItem[]{
            new FilePathItem("file",path1),
            new FilePathItem("file",path2),
            new FilePathItem("file",path3)
         }, "Upload Tag 1");

        }
    }

}