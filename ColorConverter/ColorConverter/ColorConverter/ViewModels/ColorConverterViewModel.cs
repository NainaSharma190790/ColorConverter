using System;

using Xamarin.Forms;
using System.Windows.Input;
using System.Globalization;

namespace ColorConverter
{
	public class ColorConverterViewModel :BaseViewModel
	{
		private INavigation _navigation; // HERE

		public ColorConverterViewModel(INavigation navigation)
		{
			_navigation = navigation;
		}

		#region All Properties

		private Image _effect;
		public Image Effect
		{
			get { return _effect; }
			set
			{
				_effect = value;
				OnPropertyChanged();
			}
		}
		private string _red;
		public string RED
		{
			get { return _red; }
			set
			{
				_red = value;
				OnPropertyChanged();
			}
		}
		private string _green;
		public string Green
		{
			get { return _green; }
			set
			{
				_green= value;
				OnPropertyChanged();
			}
		}
		private string _blue;
		public string Blue
		{
			get { return _blue; }
			set
			{
				_blue = value;
				OnPropertyChanged();
			}
		}
		private string _hexa;
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
				OnPropertyChanged();
			}
		}

		#endregion

		#region Command

		public ICommand ChangeEffect
		{
			get
			{
				return new Command (async () =>
					{
						Effect=Effect;
					}
				);
			}
		}
		public ICommand Effectpage
		{
			get
			{
				return new Command (async () =>
					{
						_navigation.PushModalAsync(new EffectPage ());
					}
				);
			}
		}
		public ICommand RGBtoHEX
		{
			get
			{
				return new Command (async () =>
					{
						int r = Convert.ToInt32(RED);
						int g = Convert.ToInt32(Green);
						int b = Convert.ToInt32(Green);
						Hexa = RGBtoHEXA(r, g, b);
						ToColor(Hexa);
					}
				);
			}
		}


		public ICommand HEXtoRGB
		{
			get
			{
				return new Command (async () =>
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
						Green = green.ToString();
						Blue = blue.ToString();
						ToColor(Hexa);
					}
				);
			}
		}

		#endregion

		public string RGBtoHEXA(int R,int G,int B)
		{
			Color myColor = Color.FromRgb(R, G, B);
			string hex = myColor.R.ToString("X2") + 
				myColor.G.ToString("X2") + myColor.B.ToString("X2");
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


