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
using SpaceEnvader.HelpClasses;
using SpaceEnvader.Audio;
namespace SpaceEnvader.GameBuildingBlocks.SpaceShipStuff
{
    public class Gun : GameObject
    {
        public List<Arrow> ArrowList;
        Arrow currentArrow;

        public ContentManager Content { get { return content; } }
        string arrowTextureName;

        public Point SpaceshipLocation { get; set; }
        public Size SpaceshipSize { get; set; }

        public bool gunShoting;
        Point orignalLocation;

        MasterSound gunShotSound;

        FpsTimer fpsTimer;

        bool arrowListNotEmpty { get { return ArrowList.Count > 0; } }

        public Gun(ContentManager content, string textureName, string arrowTextureName, Point startLoc, Size spaceshipSize, int speed, int winHeight, int winWidth)
            : base(content, textureName, startLoc, speed, winHeight, winWidth)
        {
            this.content = content;
            this.arrowTextureName = arrowTextureName;

            this.ArrowList = new List<Arrow>();

            orignalLocation = new Point(location.X, location.Y);
            SpaceshipSize = spaceshipSize;

            fpsTimer = new FpsTimer(30);
            fpsTimer.TheFunctionToRun = ShootingAnimation;
            fpsTimer.StartTimer();


            gunShotSound = new MasterSound(content, Sounds.GUN_SHOT);
        }

        public override void Update(GameTime gt)
        {
            updateArrowListChanges(gt);
            updateGunAnimation(gt);
            updateAndCenterGunLocationOnSpaceShip();

            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            if (arrowListNotEmpty)
            {
                foreach (var arrow in ArrowList)
                    arrow.Draw(sb);
            }
            base.Draw(sb);
        }

        #region Updating Arrows And Gun Location
        
        private void updateArrowListChanges(GameTime gt)
        {
            if (arrowListNotEmpty)
            {
                for (int i = 0; i < ArrowList.Count; i++)
                {
                    currentArrow = ArrowList[i];

                    currentArrow.Update(gt);
                    if (currentArrow.IsOverTheTop) ArrowList.RemoveAt(i);
                    else if (currentArrow.MonsterHit)
                    {
                        if (currentArrow.ExplostionAnimationEnded)
                            ArrowList.RemoveAt(i);
                    }
                }
            }
        }
        private void updateAndCenterGunLocationOnSpaceShip()
        {
            location.X = SpaceshipLocation.X + ((SpaceshipSize.Width / 2) - 5);
        }
        #endregion
       

        #region Shooting Mechnics and Functions
        internal void Shoot(Arrow arrow)
        {
            gunShoting = true;
            gunShotSound.Play();
            ArrowList.Add(arrow);
            
        }
        private void ShootingAnimation()
        {
            location.Y += 5;
            if (location.Y > orignalLocation.Y + 15)
            {
                location.Y = orignalLocation.Y - 10;
                gunShoting = false;
            }
        }
        private void updateGunAnimation(GameTime gt)
        {
            if(gunShoting)
                fpsTimer.UpdateTimer(gt);
        }
        #endregion
    }




}

