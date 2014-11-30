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

using SpaceEnvader.GameBuildingBlocks.MonstersStuff;
using SpaceEnvader.Animations;
using SpaceEnvader.Audio;
namespace SpaceEnvader.GameBuildingBlocks.SpaceShipStuff
{
    public class Arrow : GameObject
    {
        public bool MonsterHit;
        public bool playAnimation;
   
        ExpolsionAnimation ex;
       
        public bool ExplostionAnimationEnded { get { return ex.AnimationIsOver; } }
        public bool IsOverTheTop { get { return areaRect.Bottom < -1; } }

        public Arrow(ContentManager content, string textureName, Point startLoc, int speed, int winHeight, int winWidth)
            : base(content, textureName, startLoc, speed, winHeight, winWidth)
        {
            MonsterHit = false;
        
        }
      
        public override void Update(GameTime gt)
        {
            if (playAnimation == false)
            {
                if (!MonsterHit)
                    this.location.Y -= movmentSpeed;
            }
           
            if (playAnimation)
                ex.Update(gt);

            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            if (playAnimation)
                ex.Draw(sb);
            else
                base.Draw(sb);
        }

        public override bool CollsionWith(GameObject otherObject)
        {
            Monster monster = otherObject as Monster;
            if (areaRect.Intersects(monster.AreaRect))
            {
                return true;
            }

            return false;
        }

        public void Exploade(Rectangle explosionRect)
        {
            ex = new ExpolsionAnimation(content, "Explsion4", explosionRect,
                _frameWaiteTime: 50,
                _frameWidth: 90, _frameHeight: 45,
                _rows: 4, _culloms: 3,
                _rotation: 0
                );

            playAnimation = true;
        }


       
    }
}
