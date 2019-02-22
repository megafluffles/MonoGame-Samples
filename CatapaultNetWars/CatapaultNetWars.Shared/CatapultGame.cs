#region File Description
//-----------------------------------------------------------------------------
// CatapaultGame.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using GameStateManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Net;

#endregion

namespace CatapaultGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class CatapaultGame : Game
	{
        #region Fields
		GraphicsDeviceManager graphics;
		ScreenManager screenManager;

		// By preloading any assets used by UI rendering, we avoid framerate glitches
		// when they suddenly need to be loaded in the middle of a menu transition.
		static readonly string[] preloadAssets =
		{
			"gradient",
			"cat",
			"chat_ready",
			"chat_able",
			"chat_talking",
			"chat_mute",
		};

        #endregion

        #region Initialization Methods
		public CatapaultGame ()
		{
			graphics = new GraphicsDeviceManager (this);
			//graphics.SynchronizeWithVerticalRetrace = false;
			Content.RootDirectory = "Content";

			// Frame rate is 30 fps by default for Windows Phone.
			TargetElapsedTime = TimeSpan.FromTicks (333333);

			//Create a new instance of the Screen Manager
			screenManager = new ScreenManager (this);
			
			Components.Add (screenManager);

			Components.Add (new MessageDisplayComponent (this));
			Components.Add (new GamerServicesComponent (this));
			
			//Add two new screens
			screenManager.AddScreen (new BackgroundScreen (), null);
			screenManager.AddScreen (new MainMenuScreen (), null);

			// Listen for invite notification events.
			NetworkSession.InviteAccepted += (sender, e) => NetworkSessionComponent.InviteAccepted (screenManager, e);

			IsMouseVisible = true;
#if !WINDOWS && !XBOX && !MONOMAC && !LINUX
			//Switch to full screen for best game experience
			graphics.IsFullScreen = true;
#else
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1280;
#endif
			AudioManager.Initialize (this);
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			base.Initialize ();
		}
        #endregion

        #region Loading
		protected override void LoadContent ()
		{
			AudioManager.LoadSounds ();
			base.LoadContent ();
		}
        #endregion
	}
}
