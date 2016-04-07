using System;

using Xamarin.Forms;

namespace ColorConverter
{
	public class EffectPage : ContentPage
	{
		public Image imgMain, btn1,btn2,btn3,btn4,btn5,btn6;
        public string Id;

        int w = App.ScreenWidth;
        int h = App.ScreenHeight;
		private ColorConverterViewModel ViewModel
		{
			get { return BindingContext as ColorConverterViewModel; } //Type cast BindingContex as ColorConverterViewModel to access binded properties
		}


		public EffectPage (Color clr)
		{
            BindingContext = new ColorConverterViewModel(this.Navigation);
            this.BackgroundImage = "Bg.png";

            imgMain = new Image
            {
                WidthRequest=w/2,
                HeightRequest =w/2,
                BackgroundColor=clr
            };
            imgMain.SetBinding(Image.SourceProperty, "Effect");


            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Spacing = h / 10,
                Children =
				{
					imgMain,
					new StackLayout
					{
						HorizontalOptions=LayoutOptions.CenterAndExpand,
						Orientation=StackOrientation.Horizontal,
                        Spacing=w/10,
						Children=
						{
                            Effect("Img1.png","1"),
                            Effect("Img2.png","2"),
                            Effect("Img3.png","3")
                        }
                    },new StackLayout
                    {
                        HorizontalOptions=LayoutOptions.CenterAndExpand,
                        Orientation=StackOrientation.Horizontal,
                        Spacing=w/10,
                        Children=
                        {
                            Effect("Img1.png","4"),
                            Effect("Img2.png","5"),
                            Effect("Img3.png","6")
                        }
                    }

                }
			};
		}
        public Image Effect(string img, string ID)
        {
            Image btn = new Image
            {
                ClassId = ID,
                Source = img,
                BackgroundColor = Color.White,
                Aspect = Aspect.AspectFit,
                WidthRequest = w / 5
            };
            tap(ID);
            var BtnColortap = new TapGestureRecognizer(OnBtnColorTapped);
            BtnColortap.NumberOfTapsRequired = 1;
            btn.IsEnabled = true;
            btn.GestureRecognizers.Clear();
            btn.GestureRecognizers.Add(BtnColortap);
            return btn;
        }
        void OnBtnColorTapped(View view, object sender)
        {
            
            ViewModel.ChangeEffect(Id);
        }
        string tap(string TapID)
        {
            Id = TapID;
            return TapID;     
        }

    }
}


