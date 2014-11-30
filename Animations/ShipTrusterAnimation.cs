#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using SpaceEnvader.GameBuildingBlocks;
#endregion

namespace SpaceEnvader.Animations
{
    public class ShipTrusterAnimation : SpriteAnimation
    {
        public TrusterState TrusterState;

        public ShipTrusterAnimation(ContentManager _content, string _textureName, Rectangle _locAndSize,
            int _frameWaiteTime, int _frameWidth, int _frameHeight,
            int _rows, int _culloms, int _rotation)
            : base(_content, _textureName, _locAndSize, _frameWaiteTime, _frameWidth, _frameHeight, _rows, _culloms, _rotation)
        { 

        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }

        protected override void animationProgress()
        {
            currentFrameTimePassedX += frameWidth;

            if (currentFrameTimePassedX >= frameWidth * culloms)
            {
                currentFrameTimePassedX = 0;
                currentFrameTimePassedY += frameHeight;
            }

            sourceRectangle.Y = currentFrameTimePassedY;

            if (currentFrameTimePassedY >= frameHeight * rows)
            {
                animationIsOver = true;
                currentFrameTimePassedY = 0;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
             if (TrusterState == TrusterState.MOVING_RIGHT)
                 sb.Draw(texture, SizeAndLocationRect, sourceRectangle, Color.White, 9.45f , Vector2.Zero, SpriteEffects.None, 0);

             if (TrusterState == TrusterState.MOVING_LEFT)
                sb.Draw(texture, SizeAndLocationRect, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            else
                return;
        }
    }
    public enum TrusterState { MOVING_RIGHT, MOVING_LEFT, STANDING };
}
