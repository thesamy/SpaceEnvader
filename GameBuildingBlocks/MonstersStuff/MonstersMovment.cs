
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
#endregion
using SpaceEnvader.HelpClasses;

namespace SpaceEnvader.GameBuildingBlocks.MonstersStuff
{
    public class MonstersMovment
    {
        List<Monster> monsters;

        FpsTimer fpsTimer; 
        
        int stepsToTakeEachTime; 
        int stepsToke;
        bool goRight;
      
        public MonstersMovment(List<Monster>theMonsters, int _frameWaitTime, int _stepsToTake)
        {
            monsters = theMonsters;

            stepsToTakeEachTime = _stepsToTake;
            stepsToke = 0;
            goRight = true;

            fpsTimer = new FpsTimer(_frameWaitTime);
            fpsTimer.TheFunctionToRun = movingDown;
            
        }

        public void StartMovment(){
            fpsTimer.StartTimer();
        }

        public void UpdateMonstersMovment(GameTime gt)
        {
            fpsTimer.UpdateTimer(gt);
        }

        private void movingDown()
        {
                stepsToke++;

                if (goRight)
                {
                    foreach (var monster in monsters)
                    {
                        monster.MoveRight();
                    }
                }
                else
                {
                    foreach (var monster in monsters)
                    {
                        monster.MoveLeft();
                    }
                }

                if (stepsToke == stepsToTakeEachTime && goRight)
                {
                    stepsToke = 0;
                    goRight = false;
                    foreach (var monster in monsters)
                    {
                        monster.MoveDown();
                    }
                }
                else if (stepsToke == stepsToTakeEachTime && goRight == false)
                {
                    stepsToke = 0;
                    goRight = true;
                    foreach (var monster in monsters)
                    {
                        monster.MoveDown();
                    }
                }

                if (stepsToke == stepsToTakeEachTime)
                {
                    foreach (var monster in monsters)
                    {
                        monster.MoveDown();
                    }
                }
                foreach (var monster in monsters)
                {
                    monster.MoveDown();
                }
            }
        }
    }

