using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamurai
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
        public static ObservableCollection<Car> Cars { get; private set; }


        public ListViewPage()
        {
            BindingContext = new SampleViewModel();
            Cars = ((SampleViewModel)BindingContext).Cars;

            InitializeComponent();
        }

        // detect orientation changes
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            // landscape: width > height, portrait otherwise
            if (width > height)
            {
                CarScrollView.Orientation = ScrollOrientation.Horizontal;
                CarLayout.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                CarScrollView.Orientation = ScrollOrientation.Vertical;
                CarLayout.Orientation = StackOrientation.Vertical;
            }
        }
    }

    public class CarDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultCarTemplate { get; set; }
        public DataTemplate MercedesCarTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Car)item).Make == CarMake.Mercedes ? MercedesCarTemplate : DefaultCarTemplate;
        }
    }
}