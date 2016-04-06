using System;

using Xamarin.Forms;

namespace ColorConverter
{
	public class EffectPage : ContentPage
	{
		public Image imgMain;

		private ColorConverterViewModel ViewModel
		{
			get { return BindingContext as ColorConverterViewModel; } //Type cast BindingContex as ColorConverterViewModel to access binded properties
		}

		#endregion

		public EffectPage ()
		{
			BindingContext = new ColorConverterViewModel(this.Navigation);
			imgMain = new Image ();
			imgMain.SetBinding (Image.SourceProperty, "Effect");
			imgMain.SetBinding (Image.BackgroundColorProperty, "BoxColor");

			Content = new StackLayout
			{ 					
				HorizontalOptions=LayoutOptions.CenterAndExpand,				
				Children =
				{
					imgMain,
					new StackLayout
					{
						HorizontalOptions=LayoutOptions.CenterAndExpand,
						Orientation=StackOrientation.Horizontal,
						Children=
						{
							Effect("icon.png","1"),
							Effect("icon.png","2"),
							Effect("icon.png","3"),
							Effect("icon.png","4"),
							Effect("icon.png","5"),
						}
					}
					
				}
			};
		}

		public Button Effect(string img, string ID)
		{
			Button btn = new Button
			{ 
				Image=img,
				ClassId=ID,
				BackgroundColor=Color.Transparent,
				Command=ViewModel.ChangeEffect
			};
			btn.SetBinding (Button.ImageProperty, "Effect");
			return btn;
		}
	}
}


