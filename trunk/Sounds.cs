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
        public static SoundEffectInstance FDsei;
        public static SoundEffectInstance Bsei;

        public Sounds(Game1 game)
        {
            //content = new ContentManager(content, "Content");
            //this.content = content;
            Content = new ContentManager(game.Services, "Content");
            Content.RootDirectory = "Content";
            //Console.WriteLine("in sound");

            //Console.WriteLine(Content);
        }

        public static SoundEffectInstance Play(string soundName, float pitch, Boolean loop)
        {
            //Console.WriteLine("Sounds\\" + soundName);
            try
            {
                SoundEffect mySound = Content.Load<SoundEffect>("Sounds\\" + soundName);
                //Song mysong = Content.Load<Song>("Sounds\\" +soundName);
                SoundEffectInstance e = mySound.Play(pitch,1.0f, 0.0f, loop);
                //setSoundEffectInstance(e);
                return e;
            }
            catch(Exception ex)
            {
                //Console.WriteLine("Exception caught "+ex.Message);
            }
            return null;
        }

        public static SoundEffectInstance Play(SoundEnum sound, float pitch, Boolean loop)
        {
            SoundEffectInstance e = Play(sound.ToString(), pitch, loop);
            return e;
        }
       
        public static void setFinalDriveSEI(SoundEffectInstance SoundEffectInstances)
        {
            FDsei = SoundEffectInstances;
        }

        public static void setBrakesSEI(SoundEffectInstance SoundEffectInstances)
        {
           Bsei = SoundEffectInstances;
        }

        public static SoundEffectInstance getFinalDriveSEI()
        {
            return FDsei;
        }

        public static SoundEffectInstance getBrakesSEI()
        {
            return Bsei;
        }

        public static void quitAllSEI()
        {
            if (getBrakesSEI() != null)
            {
                getBrakesSEI().Stop();
            }

            if (getFinalDriveSEI() != null)
            {
                getFinalDriveSEI().Stop();
            }

        }

        public static SoundEffectInstance PlayBangSound(Boolean loop)
        {
            float pitch = 0;
            MediaPlayer.Volume = 1f;
            SoundEffectInstance e = Play(SoundEnum.bang, pitch, loop);
            return e;
        }

        public static SoundEffectInstance PlayBirdSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.bird, pitch, loop);
            return e;
        }

        public static void PlayBrakesSound(Boolean loop)
        {
            float pitch = 0.7f;
            SoundEffectInstance e = Play(SoundEnum.brakes, pitch, loop);
            setBrakesSEI(e);
        }

        public static SoundEffectInstance PlayBurstSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.burst, pitch, loop);
            return e;
        }

        public static void PlayFinalDriveSound(float pitch, Boolean loop)
        {
            //Console.Write("FINALDRIVE");
            SoundEffectInstance e = Play(SoundEnum.finalDrive, pitch, loop);
            setFinalDriveSEI(e);
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
            MediaPlayer.Volume = 1f;
            SoundEffectInstance e = Play(SoundEnum.horn, pitch, loop);
            return e;
        }

        public static void PlayMenuMusicSound(Boolean loop)
        {
            Song mysong = Content.Load<Song>("Sounds//menumusic");

            MediaPlayer.Play(mysong);         //needs to be switched on
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = loop;
            //Console.WriteLine("in menuMusic");
        }

        public static void PlayGameMusic(Boolean loop)
        {
            Song gameSong = Content.Load<Song>("Sounds//Happy Racing");
            MediaPlayer.Play(gameSong);
            MediaPlayer.Volume = 0.8f;
            MediaPlayer.IsRepeating = loop;
            //Console.WriteLine("In gameMusic");
        }

        public static void PlayWaterMusicSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.water,pitch,loop);
            //Console.WriteLine("in menuMusic");
        }

        public static SoundEffectInstance PlayWindSound(Boolean loop)
        {
            float pitch = 0;

            SoundEffectInstance e = Play(SoundEnum.wind, pitch, loop);
            //Console.WriteLine("in wind");
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