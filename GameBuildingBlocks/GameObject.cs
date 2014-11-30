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

namespace SpaceEnvader.GameBuildingBlocks
{
    public abstract class GameObject
    {
        protected ContentManager content;
        protected Texture2D texture;
        protected Rectangle areaRect;
        public Rectangle AreaRect { get { return areaRect; } set { areaRect = value; } }

        protected Point location;
        public Point Location { get { return location; } set { location = value; } }
         
        protected int movmentSpeed;
         
        protected readonly int windowHeight, windowWidth;

        public GameObject(ContentManager content, string textureName, Point startLoc, int speed, int winHeight, int winWidth)
        {
            this.content = content;
            this.texture = content.Load<Texture2D>(textureName);
            this.areaRect = texture.Bounds;
            this.location = startLoc;
            this.areaRect.X = location.X;
            this.areaRect.Y = location.Y;

            this.movmentSpeed = speed;

            this.windowHeight = winHeight;
            this.windowWidth = winWidth;
        }


        public virtual bool CollsionWith(GameObject otherObject)
        {
            return areaRect.Intersects(otherObject.areaRect);
        }

        public virtual void Update(GameTime gt)
        {
            areaRect.X = location.X;
            areaRect.Y = location.Y;

        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, areaRect, Color.White);
        }
    }
}
