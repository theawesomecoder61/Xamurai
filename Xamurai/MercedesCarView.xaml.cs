using Prism.Commands;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace Xamurai
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MercedesCarView : ContentView, INotifyPropertyChanged
	{
		public MercedesCarView ()
		{
			IsExpanded = true;
			GridScaleY = 1;
			ToggleCollapseCommand = new DelegateCommand(ToggleCollapse);
			DeleteItemCommand = new Command(DeleteItem);
			InitializeComponent ();
		}

		private void ToggleCollapse()
		{
			//if (DeviceInfo.Platform == DevicePlatform.Android)
			//{
				//BUG iOS pre7+: doesn't collapse the section, only makes the label invisible

				IsExpanded = !IsExpanded;
				GridScaleY = GridScaleY == 1 ? 0 : 1;

				// before playing the expanding animation, trigger the IsVisible property
				if (GridScaleY == 1)
				{
					OnPropertyChanged(nameof(IsExpanded));
				}

				// expand/collapse by animating the scale Y property
				ContentGrid.ScaleYTo(GridScaleY, 250).ContinueWith((state) =>
				{
					// after playing the collapsing animation, trigger the IsVisible property
					if (GridScaleY == 0)
					{
						OnPropertyChanged(nameof(IsExpanded));
					}
				});
			//}
		}

		private async void DeleteItem(object sender)
		{
			bool shouldDelete = await App.Current.MainPage.DisplayAlert("Delete Item?", "Are you sure you want to delete this item?", "Yes", "No");
			if (shouldDelete)
			{
				ListViewPage.Cars.Remove((Car)sender);
			}
		}

		public ICommand ToggleCollapseCommand { get; }

		public bool IsExpanded { get; set; }

		private double GridScaleY { get; set; }

		public Command DeleteItemCommand { get; }
	}
}