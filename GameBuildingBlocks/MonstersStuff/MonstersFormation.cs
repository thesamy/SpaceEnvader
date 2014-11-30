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

namespace SpaceEnvader.GameBuildingBlocks.MonstersStuff
{
    public static class MonstersFormation
    {
        public static FormationStyles FormationStyle;

        public static Monster lastMonster;

        public static int MONSTERS_TOP_LINE = 20;
        public static int MonsterSpace;

        static int yLoc = MONSTERS_TOP_LINE;
        static int xLoc;

        //Normal Formation
        public static void SetMonstersLocations(List<Monster> monsterList)
        {
            int monsterWidth = monsterList[0].AreaRect.Width;
            int monsterHeight = monsterList[0].AreaRect.Height;
            int monstersWidthSpace = monsterWidth + 10;

            Point monstersStartPoint = new Point(monstersWidthSpace - 20, MONSTERS_TOP_LINE);
        
            monsterList[0].Location = monstersStartPoint;

            for (int i = 1; i < monsterList.Count; i++)
            {
                xLoc = monsterList[i - 1].Location.X + monstersWidthSpace + 10;

                if (i == 7)
                {
                    yLoc = monsterList[0].Location.Y + monsterHeight;
                    xLoc = monsterList[0].Location.X;
                }

                if (i == 14)
                {
                    yLoc = monsterList[0].Location.Y + monsterList[0].AreaRect.Height * 2;
                    xLoc = monsterList[0].Location.X;
                }

                monsterList[i].Location = new Point(x: xLoc,
                                                    y: yLoc);
                
            }
           
            
        }
    }

    public enum FormationStyles {NORMAL, RECTANGLE, CIRCAL, TRIANGLE, STAR };
}
