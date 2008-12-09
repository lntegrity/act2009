// Project: ACT2009, File: Sounds.cs
// Namespace: ACT2009, Class: Sounds
// Path: \ACT2009\Sounds
// Author: Ron Malcolm, Team 2
// Code lines: 152
// Creation date: 10.21.2008 10:05
// Last modified: 10.30.2008 11:15

#region Using Directives
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework.Media;
#endregion

namespace ACT2009
{
    class Sounds
    {
        //SoundEffect mySound;
        public static ContentManager Content;// As //ContentManager
        public static SoundEffectInstance sei;

        public Sounds(Game1 game)
        {
            //content = new ContentManager(content, "Content");
            //this.content = content;
            Content = new ContentManager(game.Services, "Content");
            Content.RootDirectory = "Content";
            Console.WriteLine("in sound");

            Console.WriteLine(Content);
        }

        public static SoundEffectInstance Play(string soundName, float pitch, Boolean loop)
        {
            Console.WriteLine("Sounds\\" + soundName);
            try
            {
                SoundEffect mySound = Content.Load<SoundEffect>("Sounds\\" + soundName);
                //Song mysong = Content.Load<Song>("Sounds\\" +soundName);
                SoundEffectInstance e = mySound.Play(1.0f, pitch, 0.0f, loop);
                setSoundEffectInstance(e);
                return e;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught "+ex.Message);
            }
            return null;
        }

        public static SoundEffectInstance Play(SoundEnum sound, float pitch, Boolean loop)
        {
            SoundEffectInstance e = Play(sound.ToString(), pitch, loop);
            return e;
        }
       
        public static void setSoundEffectInstance(SoundEffectInstance SoundEffectInstances)
        {
            sei = SoundEffectInstances;
        }

        public static SoundEffectInstance getSoundEffectInstance()
        {
            return sei;
        }

        public static SoundEffectInstance PlayBangSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.bang, pitch, loop);
            return e;
        }

        public static SoundEffectInstance PlayBirdSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.bird, pitch, loop);
            return e;
        }

        public static SoundEffectInstance PlayBrakesSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.brakes, pitch, loop);
            return e;
        }

        public static SoundEffectInstance PlayBurstSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.burst, pitch, loop);
            return e;
        }

        public static SoundEffectInstance PlayFinalDriveSound(float pitch, Boolean loop)
        {
            SoundEffectInstance e = Play(SoundEnum.finalDrive, pitch, loop);
            return e;
        }

        public static SoundEffectInstance PlayFinalIdleSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.finalIdle, pitch, loop);
            return e;
        }

        public static SoundEffectInstance PlayHornSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.horn, pitch, loop);
            return e;
        }

        public static void PlayMenuMusicSound(Boolean loop)
        {
            Song mysong = Content.Load<Song>("Sounds//menumusic");
            MediaPlayer.Play(mysong);
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = loop;
            //Play(SoundEnum.menumusic,loop);
            Console.WriteLine("in menuMusic");
        }

        public static void PlayGameMusic(Boolean loop)
        {
            Song gameSong = Content.Load<Song>("Sounds//Happy Racing");
            MediaPlayer.Play(gameSong);
            MediaPlayer.IsRepeating = loop;
            Console.WriteLine("In gameMusic");
        }

        public static void PlayWaterMusicSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.water,pitch,loop);
            Console.WriteLine("in menuMusic");
        }

        public static SoundEffectInstance PlayWindSound(Boolean loop)
        {
            float pitch = 0;

            SoundEffectInstance e = Play(SoundEnum.wind, pitch, loop);
            Console.WriteLine("in wind");
            return e;
        }


        public static void StartMusic(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.start,pitch,loop);
            //needs to be replaced with the Game Music
        }

        public static void StopMusic()
        {
            MediaPlayer.Stop();
            //musicCategory.Stop(AudioStopOptions.Immediate);
        }

        public static void Update()
        {
           
        }

        public enum SoundEnum
        {
            bang,
            bird,
            brakes,
            burst,
            finalDrive,
            finalIdle,
            game,
            horn,
            water,
            wind,
            start
        }
    }
}