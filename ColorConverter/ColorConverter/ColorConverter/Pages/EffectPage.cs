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
                            Effect("Img1.png","1","Tap1"),
                            Effect("Img2.png","2","Tap2"),
                            Effect("Img3.png","3","Tap3")
                        }
                    },new StackLayout
                    {
                        HorizontalOptions=LayoutOptions.CenterAndExpand,
                        Orientation=StackOrientation.Horizontal,
                        Spacing=w/10,
                        Children=
                        {
                            Effect("Img4.png","4","Tap4"),
                            Effect("Img5.png","5","Tap5"),
                            Effect("Img6.png","6","Tap6")
                        }
                    }

                }
			};
		}
        public Image Effect(string img, string ID, string binding)
        {
            Image btn = new Image
            {
                ClassId = ID,
                Source = img,
                BackgroundColor = Color.White,
                Aspect = Aspect.AspectFit,
                WidthRequest = w / 5
            };
            switch (ID)
            {
                case "1":
                    var BtnColortap1 = new TapGestureRecognizer(BtnColortap1_Tapped);
                    BtnColortap1.NumberOfTapsRequired = 1;
                    btn.IsEnabled = true;
                    btn.GestureRecognizers.Clear();
                    btn.GestureRecognizers.Add(BtnColortap1);
                    break;
                case "2":
                    var BtnColortap2 = new TapGestureRecognizer(BtnColortap2_Tapped);
                    BtnColortap2.NumberOfTapsRequired = 1;
                    btn.IsEnabled = true;
                    btn.GestureRecognizers.Clear();
                    btn.GestureRecognizers.Add(BtnColortap2);
                    break;
                case "3":
                    var BtnColortap3 = new TapGestureRecognizer(BtnColortap3_Tapped);
                    BtnColortap3.NumberOfTapsRequired = 1;
                    btn.IsEnabled = true;
                    btn.GestureRecognizers.Clear();
                    btn.GestureRecognizers.Add(BtnColortap3);
                    break;
                case "4":
                    var BtnColortap4 = new TapGestureRecognizer(BtnColortap4_Tapped);
                    BtnColortap4.NumberOfTapsRequired = 1;
                    btn.IsEnabled = true;
                    btn.GestureRecognizers.Clear();
                    btn.GestureRecognizers.Add(BtnColortap4);
                    break;
                case "5":
                    var BtnColortap5 = new TapGestureRecognizer(BtnColortap5_Tapped);
                    BtnColortap5.NumberOfTapsRequired = 1;
                    btn.IsEnabled = true;
                    btn.GestureRecognizers.Clear();
                    btn.GestureRecognizers.Add(BtnColortap5);
                    break;
                case "6":
                    var BtnColortap6 = new TapGestureRecognizer(BtnColortap6_Tapped);
                    BtnColortap6.NumberOfTapsRequired = 1;
                    btn.IsEnabled = true;
                    btn.GestureRecognizers.Clear();
                    btn.GestureRecognizers.Add(BtnColortap6);
                    break;
            }

            return btn;
        }

        private void BtnColortap1_Tapped(View view, object sender)
        {
            ViewModel.Tap1.Execute(null);
        }
        private void BtnColortap2_Tapped(View view, object sender)
        {
            ViewModel.Tap2.Execute(null);

        }
        private void BtnColortap3_Tapped(View view, object sender)
        {
            ViewModel.Tap3.Execute(null);

        }
        private void BtnColortap4_Tapped(View view, object sender)
        {
            ViewModel.Tap4.Execute(null);

        }
        private void BtnColortap5_Tapped(View view, object sender)
        {
            ViewModel.Tap5.Execute(null);

        }
        private void BtnColortap6_Tapped(View view, object sender)
        {
            ViewModel.Tap6.Execute(null);
        }

    }
}


