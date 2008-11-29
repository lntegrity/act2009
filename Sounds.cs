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

        public static void Play(string soundName)
        {
            Console.WriteLine("Sounds\\" + soundName);
            try
            {
                Song mysong = Content.Load<Song>("Sounds\\" +soundName);
                MediaPlayer.Play(mysong);
                MediaPlayer.IsRepeating = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught "+ex.Message);
            }
        }

        public static void Play(SoundEnum sound)
        {
            Play(sound.ToString());
        }

        
        public static void PlayBangSound()
        {
            Play(SoundEnum.bang);
            Console.WriteLine("in bang");
        }

        public static void PlayBirdSound()
        {
            Play(SoundEnum.bird);
            Console.WriteLine("in birds");
        }

        public static void PlayBrakesSound()
        {
            Play(SoundEnum.brakes);
            Console.WriteLine("in brakes");
        }

        public static void PlayBurstSound()
        {
            Play(SoundEnum.burst);
            Console.WriteLine("in burst");
        }

        public static void PlayFinalDriveSound()
        {
            Play(SoundEnum.finalDrive);
            Console.WriteLine("in finalDrive");
        }
        
        public static void PlayFinalIdleSound()
        {
            Play(SoundEnum.finalIdle);
            Console.WriteLine("in finalIdle");
        }

        public static void PlayHornSound()
        {
            Play(SoundEnum.horn);
            Console.WriteLine("in horn");
        }

        public static void PlayMenuMusicSound()
        {
            Play(SoundEnum.menumusic);
            Console.WriteLine("in menuMusic");
        }

        public static void PlayWaterMusicSound()
        {
            Play(SoundEnum.water);
            Console.WriteLine("in menuMusic");
        }

        public static void PlayWindSound()
        {
            Play(SoundEnum.wind);
            Console.WriteLine("in wind");
        }
        

        public static void StartMusic()
        {
            Play(SoundEnum.start);
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