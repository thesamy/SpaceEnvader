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
    public class ExpolsionAnimation : SpriteAnimation
    {
        public ExpolsionAnimation(ContentManager _content, string _textureName, Rectangle _locAndSize,
            int _frameWaiteTime, int _frameWidth, int _frameHeight,
            int _rows, int _culloms, int _rotation)
            : base(_content, _textureName, _locAndSize, _frameWaiteTime, _frameWidth, _frameHeight, _rows, _culloms, _rotation) { }

      
    }
}
