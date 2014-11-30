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
using SpaceEnvader.Animations;
using SpaceEnvader.Audio;

namespace SpaceEnvader.GameBuildingBlocks.MonstersStuff
{
    public class Monsters
    {
        ContentManager content;
        string monsterTextureName;

        public SpaceShip PlayerSpaceship;
        List<Monster> monsters;
        public List<Monster> MonstersList { get { return monsters; } }

        MonstersMovment monstersMovment;
     
        static int MONSTER_WIDTH = 52;
        static int MONSTER_HEIGHT = 50;

        MasterSound monsterGotHitSounds;
    
        public bool AllMonstersAreDestoryed { get { return MonstersList.Count <= 0; } }

        int windowWidth, windowHeight;

        public Monsters(ContentManager _content,string _monsterTextureName ,int _windowWidth, int _windowHeight)
        {
            content = _content;
            monsterTextureName = _monsterTextureName;

            windowWidth = _windowWidth;
            windowHeight = _windowHeight;
         
            initMonsters();

            monstersMovment = new MonstersMovment(monsters, 800,10);
            monstersMovment.StartMovment();

            monsterGotHitSounds = new MasterSound(_content, Sounds.MONSTER_WAS_HIT);
        }

        private void initMonsters()
        {
            monsters = new List<Monster>(21);
         
            for (int i = 0; i < 21; i++)
            {
                //Creating and adding monsters to list
                monsters.Add(new Monster(content, "MonsterAnimation.png", Point.Zero, 5, windowWidth, windowHeight));
                //Setting thire size
                setSelectedMonsterSize(monsters[i], MONSTER_WIDTH, MONSTER_HEIGHT);
            }
            //Setting monsters Location in Selected formation
            MonstersFormation.FormationStyle = FormationStyles.NORMAL;
            MonstersFormation.SetMonstersLocations(monsters);
        }
        private void setSelectedMonsterSize(Monster selectedMonster, int _width, int _height)
        {
            selectedMonster.AreaRect = new Rectangle(0, 0, _width, _height);
        }

        public void Update(GameTime gt)
        {
            updateAndRemoveMonstersWhoGotHit(gt);
            monstersMovment.UpdateMonstersMovment(gt);
        }

        private void updateAndRemoveMonstersWhoGotHit(GameTime gt)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].Update(gt);
                if (monsters[i].GotHit)
                {
                    monsterGotHitSounds.Play();
                    monsters.RemoveAt(i);
                }
            }
        }
       
        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].Draw(sb);
            }
        }
    }
}
