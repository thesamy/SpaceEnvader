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
    public class SpaceShip : GameObject
    {
        Gun gun;
        public Gun Gun {get{return gun;}}
        Trushters trusters;
       
        string arrowTextureName;

        KeyboardControl keyboardControl;

        public SpaceShip(ContentManager content, string textureName, string gunTextureName, string arrowTextureName, Point startLoc, int speed, int winHeight, int winWidth)
            : base(content, textureName, startLoc, speed, winHeight, winWidth)
        {
            this.content = content;

            this.gun = new Gun(content, gunTextureName, arrowTextureName
              ,new Point(
                 this.location.X + (this.areaRect.Width / 2) - 5,
                 this.location.Y - 6)
                 ,new Size(this.AreaRect.Width,this.AreaRect.Height)
                 , 5, windowHeight, windowWidth);

            this.arrowTextureName = arrowTextureName;

            trusters = new Trushters(content, "thruster", new Point(0, 0), 0, windowHeight, windowWidth);
            
            keyboardControl = new KeyboardControl(this);
            keyboardControl.SpaceButtonFunction      = OnSpaceClick;
            keyboardControl.RightArrowButtonFunction = OnRightArrowClick;
            keyboardControl.SpaceButtonFunction      = OnLeftArrowClick;
        }

        public override void Update(GameTime gt)
        {
            trusters.State = TrusterState.STANDING;
            keyboardControl.UpdateControlsActivity(gt);
          
            gun.SpaceshipLocation = this.location;
            gun.Update(gt);
       
            trusters.SpaceshipLocation = this.location;
            trusters.SpaceshipSize = new Size(AreaRect.Width, AreaRect.Height);
            trusters.Update(gt);

            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            gun.Draw(sb);
            trusters.Draw(sb);

            base.Draw(sb);
        }

        public override bool CollsionWith(GameObject otherObject)
        {
            return base.CollsionWith(otherObject);
        }

        #region OnMovmentControls Functions For Space, LeftArrow, RightArrow Buttons
     
        public void OnRightArrowClick()
        {
            if (location.X + areaRect.Width >= windowWidth)
                return;

            location.X += movmentSpeed;
            trusters.State = TrusterState.MOVING_LEFT;
        }

        public void OnLeftArrowClick()
        {
            if (location.X <= 0)
                return;

            location.X -= movmentSpeed;
            trusters.State = TrusterState.MOVING_RIGHT;
        }

        public void OnSpaceClick()
        {
            gun.Shoot((new Arrow(content, arrowTextureName, gun.Location, 5, windowHeight, windowWidth)));
        }
        #endregion

   
    }
}
