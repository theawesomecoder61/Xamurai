# Xamurai
Want to work with MultiTracks.com? You have found the right place :)

## Dojo

see the [DOJO](Xamurai/.Docs/Dojo.md) document for instructions

## Notes from Andrew
- I chose and completed Challenge #2.
- I targeted Android 11 R (platform 30).
- I could not achieve the stretch goal since I do not believe hiding the status bar on Android is possible with Xamarin.
- Since I chose to use a StackLayout, I was unable to use ContextActions for deleting an item.
	- Instead, I installed Xamarin.CommunityToolkit from NuGet and used it to register a long press event that deletes the item. I made this long-press-to-delete present in both portrait and landscape orientations.
- Lastly, I included the OpenSans font in this project. Therefore installing it on your computer is not needed.

## Demos
![](https://t-poses.com/static/img/mt/1.gif)
![](https://t-poses.com/static/img/mt/2.gif)