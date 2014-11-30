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

using SpaceEnvader.HelpClasses;

namespace SpaceEnvader.Animations
{
    public abstract class SpriteAnimation
    {
        public FpsTimer fpsTimer;

        protected Texture2D texture;
        protected Rectangle sourceRectangle;

        protected bool animationIsOver;
        public bool AnimationIsOver { get { return animationIsOver; } }

        public Rectangle SizeAndLocationRect;
        
        protected readonly int frameWidth ,frameHeight;
        protected readonly int rows ,culloms;

        float rotation;
        public float Rotation
        {
            get { return rotation; }
            set
            {
                if (value <= 0) rotation = 0; else { rotation = value; }
            }
        }

        protected int currentFrameTimePassedX, currentFrameTimePassedY;

        public SpriteAnimation(ContentManager _content, string _textureName,Rectangle _locAndSize,
            int _frameWaiteTime, int _frameWidth, int _frameHeight,
            int _rows, int _culloms, int _rotation)
        {
            frameWidth = _frameWidth;
            frameHeight = _frameHeight;

            rows = _rows;
            culloms = _culloms;

            rotation = _rotation;

            texture = _content.Load<Texture2D>(_textureName);
            sourceRectangle = new Rectangle(0, 0, frameWidth, frameHeight);
            SizeAndLocationRect = _locAndSize;

            animationIsOver = false;

            fpsTimer = new FpsTimer(_frameWaiteTime);
            fpsTimer.TheFunctionToRun = animationProgress;
            fpsTimer.StartTimer();

        }
       
        public virtual void Update(GameTime gt)
        {
            fpsTimer.UpdateTimer(gt);
        }

        protected virtual void animationProgress()
        {
            currentFrameTimePassedX += frameWidth;

            if (currentFrameTimePassedX >= frameWidth * culloms)
            {
                currentFrameTimePassedX = 0;
                currentFrameTimePassedY += frameHeight;
            }

            sourceRectangle.X = currentFrameTimePassedX;
            sourceRectangle.Y = currentFrameTimePassedY;

            if (currentFrameTimePassedY >= frameHeight * rows)
                animationIsOver = true;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, SizeAndLocationRect, sourceRectangle, Color.White, Rotation, Vector2.Zero, SpriteEffects.None, 0);
        }

    }
}
