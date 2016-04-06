using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ColorConverter.Pages
{
	public class ColorConverterPage : ContentPage
	{
		public Button btnRtoH, btnHtoR;
		public Label lblHexa;
		public BoxView boxColor;
		public Entry txtHexa;
		int w= App.ScreenWidth;
		int h= App.ScreenHeight;
		private ColorConverterViewModel ViewModel
		{
			get { return BindingContext as ColorConverterViewModel; } //Type cast BindingContex as ColorConverterViewModel to access binded properties
		}

		#endregion

		public ColorConverterPage ()
		{
			BindingContext = new ColorConverterViewModel(this.Navigation);
			btnHtoR = new Button
			{
				Text="Convert Hexa to RGB",
				BackgroundColor=Color.Lime,
				Command=ViewModel.HEXtoRGB
			};
			btnRtoH = new Button
			{
				Text="Convert RGB to Hexa",
				BackgroundColor=Color.Lime,
				Command=ViewModel.RGBtoHEX				
			};

			lblHexa = new Label
			{
				Text="Hexa Color",
				TextColor=Color.Blue					
			};

			txtHexa = new Entry
			{
				Text="000000",
				TextColor=Color.Blue					
			};
			txtHexa.SetBinding (Entry.TextProperty,"Hexa");
			boxColor = new BoxView
			{
				BackgroundColor=Color.Black,
				WidthRequest=w/3,
				HeightRequest=w/3
			};
			boxColor.SetBinding (BoxView.ColorProperty,"BoxColor");
			var boxColortap = new TapGestureRecognizer(OnboxColorTapped);
			boxColortap.NumberOfTapsRequired = 1;
			boxColor.IsEnabled = true;
			boxColor.GestureRecognizers.Clear();
			boxColor.GestureRecognizers.Add(boxColortap);
			Content = new StackLayout
			{
				HorizontalOptions=LayoutOptions.CenterAndExpand,
				VerticalOptions=LayoutOptions.CenterAndExpand,
				Children =
                {
					GenEventTablelGrid(),
					btnRtoH,
					new StackLayout
					{
						Orientation=StackOrientation.Horizontal,
						Children=
						{
							lblHexa,txtHexa	
						}
					},
					btnHtoR,
					boxColor

                }
			};
		}
		void OnboxColorTapped(View view, object sender)
		{
			ViewModel.Effectpage.Execute (null);		
		}
		public Label label(string ID,string text,Color color)
        {
            Label lbl = new Label
			{
				Text=text,
				TextColor=color,
				ClassId=ID

			};
            return lbl;
        }

		public Entry entry(string ID,string binding)
        {
			Entry txt = new Entry
			{
				Text="0",
				TextColor=Color.Black,
				ClassId=ID
			};
			txt.SetBinding (Entry.TextProperty,binding);
            return txt;
        }

		private Grid GenEventTablelGrid()
		{
			Color clr;
			string name;
			string binding;
			var grid = new Grid()
			{
				ColumnSpacing = 3,
				RowSpacing = 3,	
			};
				
			int i = 0;
			int j = 0;
			for (int x = 0; x <3 ; x++) 
			{
				if (i < 3) 
				{
					if (i = 0) {
						clr = Color.Red;
						name = "R";
						binding="RED";
					} else if (i = 1) {
						clr = Color.Green;	
						name = "G";
						binding="GREEN";
					} else {
						clr = Color.Blue;	
						name = "B";
						binding="BLUE";

					}
					grid.Children.Add (label (i.ToString,name,clr), i, j);
					i++;
				} else {
					i = 0;
					j = 1;
					grid.Children.Add (entry (i.ToString,binding), i, j);
					i++;
				}
			}
			return grid;
		}
    }
}
