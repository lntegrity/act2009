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

        public static void Play(string soundName, Boolean loop)
        {
            Console.WriteLine("Sounds\\" + soundName);
            try
            {
                Song mysong = Content.Load<Song>("Sounds\\" +soundName);
                MediaPlayer.Play(mysong);
                MediaPlayer.IsRepeating = loop;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught "+ex.Message);
            }
        }

        public static void Play(SoundEnum sound, Boolean loop)
        {
            Play(sound.ToString(), loop);
        }


        public static void PlayBangSound(Boolean loop)
        {
            Play(SoundEnum.bang,loop);
            Console.WriteLine("in bang");
        }

        public static void PlayBirdSound(Boolean loop)
        {
            Play(SoundEnum.bird,loop);
            Console.WriteLine("in birds");
        }

        public static void PlayBrakesSound(Boolean loop)
        {
            Play(SoundEnum.brakes,loop);
            Console.WriteLine("in brakes");
        }

        public static void PlayBurstSound(Boolean loop)
        {
            Play(SoundEnum.burst,loop);
            Console.WriteLine("in burst");
        }

        public static void PlayFinalDriveSound(Boolean loop)
        {
            Play(SoundEnum.finalDrive,loop);
            Console.WriteLine("in finalDrive");
        }

        public static void PlayFinalIdleSound(Boolean loop)
        {
            Play(SoundEnum.finalIdle,loop);
            Console.WriteLine("in finalIdle");
        }

        public static void PlayHornSound(Boolean loop)
        {
            Play(SoundEnum.horn,loop);
            Console.WriteLine("in horn");
        }

        public static void PlayMenuMusicSound(Boolean loop)
        {
            Play(SoundEnum.menumusic,loop);
            Console.WriteLine("in menuMusic");
        }

        public static void PlayWaterMusicSound(Boolean loop)
        {
            Play(SoundEnum.water,loop);
            Console.WriteLine("in menuMusic");
        }

        public static void PlayWindSound(Boolean loop)
        {
            Play(SoundEnum.wind, loop);
            Console.WriteLine("in wind");
        }


        public static void StartMusic(Boolean loop)
        {
            Play(SoundEnum.start,loop);
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
            menumusic,
            water,
            wind,
            start
        }
    }
}