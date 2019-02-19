#region File Description
//-----------------------------------------------------------------------------
// BackgroundScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameStateManagement;
#endregion

namespace CatapaultGame
{
    class BackgroundScreen : GameScreen
    {
        #region Fields
        Texture2D background;
        #endregion

        #region Initialization
        public BackgroundScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.0);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }
        #endregion

        #region Loading
        public override void LoadContent()
        {
            background = Load<Texture2D>("Textures/Backgrounds/title_screen");           
        }
        #endregion

        #region Render
        /// <summary>
        /// Updates the background screen. Unlike most screens, this should not
        /// transition off even if it has been covered by another screen: it is
        /// supposed to be covered, after all! This overload forces the
        /// coveredByOtherScreen parameter to false in order to stop the base
        /// Update method wanting to transition off.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin(transformMatrix: ScreenManager.ViewportAdapter.GetScaleMatrix());

            // Draw Background
            spriteBatch.Draw(background, new Vector2(0, 0),
                 new Color(255, 255, 255, TransitionAlpha));

            spriteBatch.End();
        }
        #endregion
    }
}
