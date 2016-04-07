using System;

using Xamarin.Forms;
using System.Windows.Input;
using System.Globalization;

namespace ColorConverter
{
    public class ColorConverterViewModel : BaseViewModel
    {
        private INavigation _navigation; // HERE

        public ColorConverterViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        #region All Properties

        private ImageSource _effect = "Img1.png";
        public ImageSource Effect
        {
            get { return _effect; }
            set
            {
                _effect = value;
                OnPropertyChanged();
            }
        }
        private string _red = "00";
        public string RED
        {
            get { return _red; }
            set
            {

                _red = value;

                OnPropertyChanged();
            }
        }
        private string _green = "00";
        public string GREEN
        {
            get { return _green; }
            set
            {
                _green = value;
                OnPropertyChanged();
            }
        }
        private string _blue = "00";
        public string BLUE
        {
            get { return _blue; }
            set
            {
                _blue = value;
                OnPropertyChanged();
            }
        }
        private string _hexa = "000000";
        public string Hexa
        {
            get { return _hexa; }
            set
            {
                _hexa = value;
                OnPropertyChanged();
            }
        }

        private Color _color;
        public Color BoxColor
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("BoxColor");
            }
        }

        #endregion

        #region Command

        public void ChangeEffect(string id)
        {
            switch (id)
            {
                case "1":
                    Effect = "Img1.png";
                    break;
                case "2":
                    Effect = "Img2.png";
                    break;
                case "3":
                    Effect = "Img3.png";

                    break;
                case "4":
                    Effect = "Img1.png";

                    break;
                case "5":
                    Effect = "Img2.png";

                    break;
                case "6":
                    Effect = "Img3.png";

                    break;
            }
        }
        public ICommand Effectpage
        {
            get
            {
                return new Command(await =>
                   {
                       _navigation.PushModalAsync(new EffectPage(BoxColor));
                   }
                );
            }
        }
        public ICommand RGBtoHEX
        {
            get
            {
                return new Command(p =>
                   {
                       int r = Convert.ToInt32(RED);
                       int g = Convert.ToInt32(GREEN);
                       int b = Convert.ToInt32(BLUE);
                       if (r > 255 || b > 255 || g > 255)
                       {
                           App.Instance.Alert("RGB value should be less then 255 ", "RBG Alert", "OK");

                       }
                       else
                       {
                           Hexa = RGBtoHEXA(r, g, b);
                           ToColor(Hexa);
                       }
                   }
                );
            }
        }


        public ICommand HEXtoRGB
        {
            get
            {
                return new Command(p =>
                   {
                       try
                       {

                           if (Hexa.Length == 4 || Hexa.Length == 5 || Hexa.Length > 6)
                           {
                               App.Instance.Alert("Hexa length should be 3 or 6 ", "Hexa Alert", "OK");
                           }
                           else
                           {
                               string hexColor = Hexa;
                               //Remove # if present
                               if (hexColor.IndexOf('#') != -1)
                                   hexColor = hexColor.Replace("#", "");

                               int red = 0;
                               int green = 0;
                               int blue = 0;

                               if (hexColor.Length == 6)
                               {
                                   //#RRGGBB
                                   red = int.Parse(hexColor.Substring(0, 2),
                                      NumberStyles.AllowHexSpecifier);
                                   green = int.Parse(hexColor.Substring(2, 2),
                                       NumberStyles.AllowHexSpecifier);
                                   blue = int.Parse(hexColor.Substring(4, 2),
                                       NumberStyles.AllowHexSpecifier);
                               }
                               else if (hexColor.Length == 3)
                               {
                                   //#RGB
                                   red = int.Parse(hexColor[0].ToString() +
                                      hexColor[0].ToString(), NumberStyles.AllowHexSpecifier);
                                   green = int.Parse(hexColor[1].ToString() +
                                       hexColor[1].ToString(), NumberStyles.AllowHexSpecifier);
                                   blue = int.Parse(hexColor[2].ToString() +
                                       hexColor[2].ToString(), NumberStyles.AllowHexSpecifier);
                               }
                               RED = red.ToString();
                               GREEN = green.ToString();
                               BLUE = blue.ToString();
                               ToColor(Hexa);
                           }
                       }
                       catch (Exception ex)
                       {
                           App.Instance.Alert("Invalid hexa code! ", "Try Again", "OK");

                           Console.WriteLine("Error:", ex.Message);
                       }
                   }
                );
            }
        }

        #endregion

        public string RGBtoHEXA(int R, int G, int B)
        {
            string hex = "";
            try
            {
                Color myColor = Color.FromRgb(R, G, B);
                hex = R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error:" + ex.Message);
            }
            return hex;

        }

        public void ToColor(string hexColor)
        {
            //Remove # if present
            if (hexColor.IndexOf('#') != -1)
                hexColor = hexColor.Replace("#", "");

            int red = 0;
            int green = 0;
            int blue = 0;

            if (hexColor.Length == 6)
            {
                //#RRGGBB
                red = int.Parse(hexColor.Substring(0, 2),
                    NumberStyles.AllowHexSpecifier);
                green = int.Parse(hexColor.Substring(2, 2),
                    NumberStyles.AllowHexSpecifier);
                blue = int.Parse(hexColor.Substring(4, 2),
                    NumberStyles.AllowHexSpecifier);
            }
            else if (hexColor.Length == 3)
            {
                //#RGB
                red = int.Parse(hexColor[0].ToString() +
                    hexColor[0].ToString(), NumberStyles.AllowHexSpecifier);
                green = int.Parse(hexColor[1].ToString() +
                    hexColor[1].ToString(), NumberStyles.AllowHexSpecifier);
                blue = int.Parse(hexColor[2].ToString() +
                    hexColor[2].ToString(), NumberStyles.AllowHexSpecifier);
            }
            BoxColor = Color.FromRgb(red, green, blue);
        }
    }
}

