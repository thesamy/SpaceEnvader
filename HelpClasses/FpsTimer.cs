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
#endregion;

namespace SpaceEnvader.HelpClasses
{
    public class FpsTimer
    {
        int currentFrameTimePassed;
        int frameWaitTime;
        public int FrameWaitTime
        {
            get { return frameWaitTime; }
            set
            {
                if (value < 0)
                {
                    frameWaitTime = 0;
                }
                else
                {
                    frameWaitTime = value;
                }
            }
        }
        bool working;

        public delegate void FunctionToRun();
        public FunctionToRun TheFunctionToRun;

        public FpsTimer(int _frameWaitTime, FunctionToRun _theFunctionToRun)
        {
            currentFrameTimePassed = 0;
            FrameWaitTime = _frameWaitTime;
            TheFunctionToRun = new FunctionToRun(_theFunctionToRun);
        }
        public FpsTimer(int _frameWaitTime)
        {
            currentFrameTimePassed = 0;
            FrameWaitTime = _frameWaitTime;
        }

        public void StartTimer()
        {
            working = true;
        }
        public void StopTimer()
        {
            working = false;
        }
        public void UpdateTimer(GameTime gt)
        {
            if (working)
            {
                currentFrameTimePassed += gt.ElapsedGameTime.Milliseconds;
                if (currentFrameTimePassed >= FrameWaitTime)
                {
                    currentFrameTimePassed -= FrameWaitTime;

                    TheFunctionToRun();
                }
            }
        }

      
    }
}
