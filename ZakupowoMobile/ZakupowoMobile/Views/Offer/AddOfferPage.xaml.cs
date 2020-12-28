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
using System.Diagnostics;

namespace ZakupowoMobile.Views.Offer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOfferPage : ContentPage
    {
       
        public AddOfferPage()
        {
            InitializeComponent();
            BindingContext = new AddOfferViewModel();
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

         async void addOffer_Clicked(object sender, EventArgs e)
        {
            string title = titleEntry.Text;
            string description = descriptionEntry.Text;
            int categoryId = Convert.ToInt32(((Category)CategoryBinder.SelectedItem).CategoryID);
            int quantity = Convert.ToInt32(quantityEntry.Text);
            string price = priceEntry.Text;

            var offerItem = new Models.BindingModels.OfferBindingModel
            {
                Title = title,
                Description = description,
                CategoryID = categoryId,
                InStockOriginaly = quantity,
                Price = price,
                UserID = Session.user.UserID

            };

            if (string.IsNullOrEmpty(titleEntry.Text) || string.IsNullOrEmpty(descriptionEntry.Text))
            {
                await DisplayAlert("Enter data", "Enter valid data", "Ok");
            }
            else
            {
                try
                {

                    OfferItem response = await AddOfferViewModel.AddOfferAsync(offerItem);

                    if (response != null)
                    {

                        output.Text = "Oferta dodana pomyślnie!";
                    }
                    else
                    {

                        
                    }
                }
                catch (AggregateException err)
                {
                    foreach (var errInner in err.InnerExceptions)
                    {
                        Debug.WriteLine(errInner); //this will call ToString() on the inner execption and get you message, stacktrace and you could perhaps drill down further into the inner exception of it if necessary 
                    };
                }
            }

        }
    }

}