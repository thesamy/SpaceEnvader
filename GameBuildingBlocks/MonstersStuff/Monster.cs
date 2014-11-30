#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using SpaceEnvader.GameBuildingBlocks.SpaceShipStuff;
using SpaceEnvader.Animations;
#endregion
using SpaceEnvader.Audio;

namespace SpaceEnvader.GameBuildingBlocks.MonstersStuff
{
    public class Monster : GameObject
    {
        public bool GotHit = false;
        public MonsterAnimation animation;
        

        public bool ReachedTheButtom
        {
            get
            {
                if (areaRect.Bottom >= windowHeight) 
                    return true;

                return false;
            }
        }

        public Monster(ContentManager content, string textureName, Point startLoc, int speed, int winHeight, int winWidth)
            : base(content, textureName, startLoc, speed, winHeight, winWidth)
        {
            animation = new MonsterAnimation(content, textureName, new Rectangle(0, 0, startLoc.X, startLoc.Y),
               _frameWaiteTime: 100,
               _frameWidth: 60, _frameHeight: 60,
               _rows: 4, _culloms: 4,
               _rotation: 0
               );
        }

        #region Movment Functions 
        public void MoveLeft()
        {
            this.location.X -= movmentSpeed;
        }

        public void MoveRight()
        {
            this.location.X += movmentSpeed;
        }

        public void MoveDown() 
        {
            this.location.Y += movmentSpeed;
          
        }
        #endregion

        public override void Update(GameTime gt)
        {
            animation.SizeAndLocationRect = areaRect;
            animation.Update(gt);
            
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            animation.Draw(sb);
        }

        public override bool CollsionWith(GameObject otherObject)
        {
            if (otherObject.GetType() == typeof(Arrow))
            {
                Arrow arrow = otherObject as Arrow;
                return arrow.AreaRect.Intersects(this.areaRect);
            }

            if (otherObject.GetType() == typeof(SpaceShip))
            {
                SpaceShip spaceShip = otherObject as SpaceShip;
                return spaceShip.AreaRect.Intersects(this.areaRect);
            }

            return false;
        }
    }
}
