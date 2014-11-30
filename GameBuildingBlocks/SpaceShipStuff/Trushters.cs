#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion
using SpaceEnvader.Animations;
using SpaceEnvader.HelpClasses;

namespace SpaceEnvader.GameBuildingBlocks.SpaceShipStuff
{
    public class Trushters : GameObject
    {
        public Point SpaceshipLocation { get; set; }
        public Size SpaceshipSize { get; set; }

        ShipTrusterAnimation trusterAnimation;

        TrusterState state;
        public TrusterState State { get { return state; } set { state = value; } }

        public Trushters(ContentManager content, string textureName, Point startLoc, int speed, int winHeight, int winWidth)
            : base(content, textureName, startLoc, speed, winHeight, winWidth)
        {
            this.trusterAnimation = new ShipTrusterAnimation(content, textureName, new Rectangle(0, 0, 20, 20),
                _frameWaiteTime: 50,
                _frameWidth: 90, _frameHeight: 64,
                _rows: 7, _culloms: 1,
                _rotation: 0);
        }

        public override void Update(GameTime gt)
        {
            trusterAnimation.TrusterState = this.State;

            location.X = SpaceshipLocation.X ;
            location.Y = SpaceshipLocation.Y ;

            if(trusterAnimation.TrusterState == TrusterState.MOVING_LEFT)
                trusterAnimation.SizeAndLocationRect = new Rectangle(location.X - 8 , location.Y + 15 , 50, 50);

            if (trusterAnimation.TrusterState == TrusterState.MOVING_RIGHT)
                trusterAnimation.SizeAndLocationRect = new Rectangle(location.X + SpaceshipSize.Width + 5, location.Y + 66, 50, 50);


            trusterAnimation.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            trusterAnimation.Draw(sb);
        }
    }
}
