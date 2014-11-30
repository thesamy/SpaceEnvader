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
using SpaceEnvader.Audio;

namespace SpaceEnvader.GameStateStuff
{
    public class OnCollsionEvents
    {
        SpaceShip player;
        Monsters monsters;

        public int MonsterCount { get { return monsters.MonstersList.Count; } }
        public bool MonsterHitTheFloor = false;
        public bool MonsterHitTheSpaceship = false;
        public OnCollsionEvents(SpaceShip _spaceShip, Monsters _monsters)
        {
            player = _spaceShip;
            monsters = _monsters;
        }

        public void Update(SpaceShip _spaceShip, Monsters _monsters)
        {
            List<Arrow> gameArrows = player.Gun.ArrowList;

            if (MonsterCount > 0)
            {
                    foreach (var monster in monsters.MonstersList)
                    {

                        if (monster.ReachedTheButtom)
                        {
                            MonsterHitTheFloor = true;
                        }

                        if (monster.CollsionWith(player))
                        {
                            MonsterHitTheSpaceship = true;
                        }

                        foreach (var currentArrow in gameArrows)
                        {
                            if (currentArrow.CollsionWith(monster))
                            {
                                currentArrow.MonsterHit = true;
                                currentArrow.Exploade(new Rectangle(monster.Location.X, monster.Location.Y, monster.AreaRect.Width, monster.AreaRect.Height));

                                monster.GotHit = true;
                            }

                           
                        }
                }
            }
            player = _spaceShip;
            monsters = _monsters;

        }
    }
}
