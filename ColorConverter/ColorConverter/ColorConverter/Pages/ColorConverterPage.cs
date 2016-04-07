using ColorConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ColorConverter
{
	public class ColorConverterPage : ContentPage
	{
		public Button btnRtoH, btnHtoR;
		public Label lblHexa;
		public BoxView boxColor;
		public CustomEntry txtHexa;
		int w= App.ScreenWidth;
        int h = App.ScreenHeight;
        public Colors clr;
        public string name;
        public string binding;
        private ColorConverterViewModel ViewModel
		{
			get { return BindingContext as ColorConverterViewModel; } //Type cast BindingContex as ColorConverterViewModel to access binded properties
		}


		public ColorConverterPage ()
		{
			BindingContext = new ColorConverterViewModel(this.Navigation);
            this.BackgroundImage = "Bg.png";
			btnHtoR = new Button
			{
				Text="Convert Hexa to RGB",
                TextColor  = Colors.CCBtn.ToFormsColor(),
                BackgroundColor = Color.White,
                Command = ViewModel.HEXtoRGB
			};
			btnRtoH = new Button
			{
				Text="Convert RGB to Hexa",
                TextColor = Colors.CCBtn.ToFormsColor(),
                BackgroundColor = Color.White,
                Command = ViewModel.RGBtoHEX				
			};

            lblHexa = new Label
            {
                Text = "Hexa Color",
                FontSize = h / 22,
                TextColor = Colors.CCBtn.ToFormsColor(),
                YAlign = TextAlignment.Start
			};
            CustomEntry txt = 

            txtHexa = new CustomEntry(new CustomEntryParams
            { MaxLength = 6 })
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,

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
                Padding= new Thickness(w/10,w/10,w/10,w/10),
                HorizontalOptions =LayoutOptions.CenterAndExpand,
				VerticalOptions=LayoutOptions.FillAndExpand,
                Spacing=w/10,
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
		public Label label(string ID,string text,Colors color)
        {
            Label lbl = new Label
			{
				Text=text,
                FontSize=h/20,
				TextColor=color.ToFormsColor(),
				ClassId=ID,
                XAlign=TextAlignment.Center,
                FontAttributes=FontAttributes.Bold
                

			};
            return lbl;
        }

		public CustomEntry entry(string ID,string bind)
        {
            CustomEntry txt = new CustomEntry(new CustomEntryParams { MaxLength = 3 });

            txt.ClassId = ID;
            txt.Keyboard = Keyboard.Numeric;			
			txt.SetBinding (Entry.TextProperty,bind);
            txt.WidthRequest = w / 10;
            txt.HeightRequest = w / 10;

            return txt;
        }
        

        private Grid GenEventTablelGrid()
		{
			
			var grid = new Grid()
			{
				ColumnSpacing = 3,
				RowSpacing = 3,	
             
			};
				
			int i = 0;
			int j = 0;
            int k = 0;

            for (int x = 0; x <6 ; x++) 
			{
				if (i < 3) 
				{
					if (i== 0) {
                        clr = Colors.RED;
						name = "R";
					} else if (i== 1) {
                        clr = Colors.GREEN;
                        name = "G";
					} else {
                        clr = Colors.BLUE;
                        name = "B";
					}
					grid.Children.Add (label (i.ToString(),name,clr), i, j);
					i++;
				}
                else
                {
                    if (k == 0)
                    {                        
                        binding = "RED";
                    }
                    else if (k == 1)
                    {                       
                        binding = "GREEN";
                    }
                    else
                    {                        
                        binding = "BLUE";

                    }
                    j = 1;
					grid.Children.Add (entry (k.ToString(),binding), k, j);
					k++;
				}
			}
			return grid;
		}
    }
}
