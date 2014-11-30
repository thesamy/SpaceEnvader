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


namespace SpaceEnvader.GameStateStuff
{
    public class MsgSplashScren
    {
        string message;
        Rectangle AreaRect;
        SpriteFont spriteFont;
        public bool toShow = false;
        
        public MsgSplashScren(ContentManager content, Rectangle SizeAndLoc, string msg)
        {
            message = msg;
            AreaRect = SizeAndLoc;
            spriteFont = content.Load<SpriteFont>("myFonts");
        }

        public void Draw(SpriteBatch sb)
        {
            if (toShow)
                sb.DrawString(spriteFont,message,new Vector2(AreaRect.X,AreaRect.Y),Color.White,0,Vector2.Zero,3,SpriteEffects.None,0);
        }
    }
}
