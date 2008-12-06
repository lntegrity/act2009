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

        public Sounds(Game1 game)
        {
            //content = new ContentManager(content, "Content");
            //this.content = content;
            Content = new ContentManager(game.Services, "Content");
            Content.RootDirectory = "Content";
            Console.WriteLine("in sound");

            Console.WriteLine(Content);
        }

        public static void Play(string soundName, float pitch, Boolean loop)
        {
            Console.WriteLine("Sounds\\" + soundName);
            try
            {
                SoundEffect mySound = Content.Load<SoundEffect>("Sounds\\" + soundName);
                //Song mysong = Content.Load<Song>("Sounds\\" +soundName);
                mySound.Play(1.0f, pitch, 0.0f, loop);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught "+ex.Message);
            }
        }

        public static void Play(SoundEnum sound, float pitch, Boolean loop)
        {
            Play(sound.ToString(), pitch, loop);
        }


        public static void PlayBangSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.bang, pitch ,loop);
            Console.WriteLine("in bang");
        }

        public static void PlayBirdSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.bird, pitch, loop);
            Console.WriteLine("in birds");
        }

        public static void PlayBrakesSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.brakes,pitch,loop);
            Console.WriteLine("in brakes");
        }

        public static void PlayBurstSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.burst,pitch,loop);
            Console.WriteLine("in burst");
        }

        public static void PlayFinalDriveSound(float pitch, Boolean loop)
        {
            Play(SoundEnum.finalDrive,pitch,loop);
            Console.WriteLine("in finalDrive");
        }

        public static void PlayFinalIdleSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.finalIdle,pitch,loop);
            Console.WriteLine("in finalIdle");
        }

        public static void PlayHornSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.horn,pitch,loop);
            Console.WriteLine("in horn");
        }

        public static void PlayMenuMusicSound(Boolean loop)
        {
            Song mysong = Content.Load<Song>("Sounds//menumusic");
            MediaPlayer.Play(mysong);
            MediaPlayer.IsRepeating = loop;
            //Play(SoundEnum.menumusic,loop);
            Console.WriteLine("in menuMusic");
        }

        public static void PlayWaterMusicSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.water,pitch,loop);
            Console.WriteLine("in menuMusic");
        }

        public static void PlayWindSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.wind, pitch, loop);
            Console.WriteLine("in wind");
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
            horn,
            water,
            wind,
            start
        }
    }
}