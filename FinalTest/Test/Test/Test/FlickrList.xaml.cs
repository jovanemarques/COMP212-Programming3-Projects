using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlickrList : ContentPage
	{
        private static HttpClient flickrClient = new HttpClient();
        Task<string> flickrTask = null;
        private const string KEY = "6595c3873f34eb30943d093fd560ebcc";
        private string tags;

        public FlickrList ()
		{
			InitializeComponent ();
		}
        public FlickrList(string tags):this()
        {
            this.tags = tags;
            search();
        }

        private async void search()
        {                      
            var flickrURL = "https://api.flickr.com/services/rest/?method=" +
               $"flickr.photos.search&api_key={KEY}&" +
               $"tags={tags.Replace(" ", ",")}" +
               "&tag_mode=all&per_page=500&privacy_filter=1";

            IList<string> lstMsg = new List<string>();
            lstMsg.Add("Loading...");

            lstImages.ItemsSource = lstMsg;

            //imagesListBox.DataSource = null; // remove prior data source
            //imagesListBox.Items.Clear(); // clear imagesListBox
            //pictureBox.Image = null; // clear pictureBox
            //imagesListBox.Items.Add("Loading..."); // display Loading...

            //// invoke Flickr web service to search Flick with user's tags
            flickrTask = flickrClient.GetStringAsync(flickrURL);

            //// await flickrTask then parse results with XDocument and LINQ
            XDocument flickrXML = XDocument.Parse(await flickrTask);

            //// gather information on all photos
            var flickrPhotos =
               from photo in flickrXML.Descendants("photo")
               let id = photo.Attribute("id").Value
               let title = photo.Attribute("title").Value
               let secret = photo.Attribute("secret").Value
               let server = photo.Attribute("server").Value
               let farm = photo.Attribute("farm").Value
               select new FlickrResult
               {
                   Title = title,
                   URL = $"https://farm{farm}.staticflickr.com/" +
                     $"{server}/{id}_{secret}.jpg"
               };

            lstImages.ItemsSource = null;

            // set ListBox properties only if results were found
            if (flickrPhotos.Any())
            {
                lstImages.ItemsSource = flickrPhotos;

            }
            else // no matches were found
            {
                lstMsg.Add("Not Found");
                lstImages.ItemsSource = lstMsg;
            }
        }

        private void lstImages_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var s = sender;
            //Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(FlickrDetail)));
            //IsPresented = false;
            //await Navigation.PushAsync(new FlickrResult());
            imgViewer.Source = ImageSource.FromUri(new Uri(((FlickrResult)e.SelectedItem).URL));
            //e.SelectedItem.URL
        }
    }
}