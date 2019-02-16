using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Xna.Framework;
using Android.Content.PM;

namespace CatapaultWarsNet
{
	
	[Activity (Label = "CatapaultWarsNet"
	           , MainLauncher = true
	           ,Icon = "@drawable/icon"
	           , Theme = "@style/Theme.Splash"
	           ,ScreenOrientation=ScreenOrientation.Landscape
	           ,ConfigurationChanges=ConfigChanges.Orientation|ConfigChanges.Keyboard|ConfigChanges.KeyboardHidden)]
	public class Activity1 : AndroidGameActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			CatapaultGame.CatapaultGame.Activity = this;
			var g = new CatapaultGame.CatapaultGame();
			SetContentView(g.Window);
			g.Run();
		}
	}
}


