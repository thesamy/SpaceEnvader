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

using SpaceEnvader.GameBuildingBlocks.SpaceShipStuff;
using SpaceEnvader.GameBuildingBlocks.MonstersStuff;
using SpaceEnvader.Animations;
using SpaceEnvader.GameBuildingBlocks;

namespace SpaceEnvader.GameStateStuff

{
    public class GeneralGameState
    {
        readonly int windowHeight;
        readonly int windowWidth;

        MsgSplashScren msgSpalshScreen;

        ContentManager content;
        OnCollsionEvents collisionEvents;

        public bool PuaseGame = false;

        public GeneralGameState(ContentManager Content,Monsters monsters, SpaceShip spaceship, int windowWidth, int windowHeight)
        {
            this.content = Content;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            collisionEvents = new OnCollsionEvents(spaceship, monsters);
        }


        public void Update(SpaceShip spaceship,Monsters monsters)
        {
            collisionEvents.Update(spaceship, monsters);

            if (collisionEvents.MonsterHitTheFloor || collisionEvents.MonsterHitTheSpaceship)
            {
                PuaseGame = true;
                ShowMsg("Sorry, you lost");
            }

            if (collisionEvents.MonsterCount == 0)
            {
                PuaseGame = true;
                ShowMsg("You won");
            }

        }

        private void ShowMsg(string msg)
        {
            msgSpalshScreen = new MsgSplashScren(content, new Rectangle(windowWidth / 3 - 20,  windowHeight /3 , 0, 0), msg);
            msgSpalshScreen.toShow = true;
        }

        public void Draw(SpriteBatch sb)
        {
            if (msgSpalshScreen != null)
                msgSpalshScreen.Draw(sb);
        }

      
    }
}
