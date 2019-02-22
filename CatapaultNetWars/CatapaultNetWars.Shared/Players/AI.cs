#region File Description
//-----------------------------------------------------------------------------
// AI.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region File Information
//-----------------------------------------------------------------------------
// AI.cs
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace CatapaultGame
{
    class AI : Human
    {
        #region Fields
        Random random;
        #endregion

        #region Initialization
        public AI(Game game)
            : base(game)
        {
        }

        public AI(Game game, SpriteBatch screenSpriteBatch)
            : base(game, screenSpriteBatch, PlayerSide.Right)
        {
            Catapault = new Catapault(game, screenSpriteBatch,
                            "Textures/Catapults/Red/redIdle/redIdle",
                            new Vector2(600, 332), SpriteEffects.FlipHorizontally, true);
        }

        public override void Initialize()
        {
            //Initialize randomizer
            random = new Random();
			IsAI = true;
            //Catapault.Initialize();

            base.Initialize();
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            // Check if it is time to take a shot
            if (Catapault.CurrentState == CatapaultState.Aiming &&
                !Catapault.AnimationRunning)
            {
                // Fire at a random strength
                float shotVelocity =
                    random.Next((int)MinShotStrength, (int)MaxShotStrength);

                Catapault.ShotStrength = (shotVelocity / MaxShotStrength);
                Catapault.ShotVelocity = shotVelocity;
            }
            base.Update(gameTime);
        }
        #endregion
    }
}
