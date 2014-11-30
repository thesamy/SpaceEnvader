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
    public class KeyboardControl
    {
        public readonly SpaceShip theSpaceship;

        KeyboardState newKeyboardState;
        KeyboardState oldKeyboardState;

        public delegate void ButtonAction();

        public ButtonAction SpaceButtonFunction;
        public ButtonAction LeftArrowButtonFunction;
        public ButtonAction RightArrowButtonFunction;

        public KeyboardControl(SpaceShip _theSpaceship)
        {
            theSpaceship = _theSpaceship;
        }
       
        public KeyboardControl(SpaceShip _theSpaceship, ButtonAction _spaceButtonFunction, ButtonAction _leftArrowFunction, ButtonAction _rightArrowButton)
        {
            theSpaceship = _theSpaceship;
            SpaceButtonFunction = _spaceButtonFunction;
            LeftArrowButtonFunction = _leftArrowFunction;
            RightArrowButtonFunction = _rightArrowButton;
        }

        public void UpdateControlsActivity(GameTime gt)
        {
            newKeyboardState = Keyboard.GetState();

            if (newKeyboardState.IsKeyDown(Keys.Right))
                theSpaceship.OnRightArrowClick();

            if (newKeyboardState.IsKeyDown(Keys.Left))
                theSpaceship.OnLeftArrowClick();

            if (newKeyboardState.IsKeyDown(Keys.Space) && oldKeyboardState.IsKeyUp(Keys.Space))
                theSpaceship.OnSpaceClick();

            oldKeyboardState = newKeyboardState;
        }
    }
}
