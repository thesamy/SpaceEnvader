#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;

using SpaceEnvader.GameBuildingBlocks.SpaceShipStuff;
using SpaceEnvader.Animations;
#endregion
namespace SpaceEnvader.Audio
{
    public class MasterSound
    {
        SoundEffect soundEffect;

        public MasterSound(ContentManager content, Sounds soundsEffect)
        {
            switch (soundsEffect)
            {
                case Sounds.MONSTER_WAS_HIT:
                    soundEffect = content.Load<SoundEffect>(@"Audio/MonsterGotHit");
                    break;
                case Sounds.ARROW_GOT_DESTROYED:
                    soundEffect = content.Load<SoundEffect>(@"Audio/arrowDestoyed");
                    break;
                case Sounds.GUN_SHOT:
                    soundEffect = content.Load<SoundEffect>(@"Audio/arrowShot");
                    break;
                case Sounds.GUN_SHOTv2:
                    soundEffect = content.Load<SoundEffect>(@"Audio/wavMissile_Fire_War-SoundBible");
                    break;

                case Sounds.SHIP_WAS_HIT:
                    //TODO
                    break;

                case Sounds.SHIP_DESTROYED:
                    //TODO
                    break;

                default:
                    break;
            }
        }

        public void Play()
        {
            soundEffect.Play();
        }
        
    }

    public enum Sounds { 
                         MONSTER_WAS_HIT,
                         ARROW_GOT_DESTROYED, 
                         GUN_SHOT,
                         GUN_SHOTv2,
                         SHIP_WAS_HIT, 
                         SHIP_DESTROYED,
                         THRUSTER_TEST
                       }
}
