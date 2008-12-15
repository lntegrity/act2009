// Project: ACT2009, File: Sounds.cs
// Namespace: ACT2009, Class: Sounds
// Path: \ACT2009\Sounds
// Author: Jasmin Paszko, Team 2
// Code lines: 152
// Creation date: 10.21.2008 10:05
// Last modified: 12.14.2008 7:24

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

    /// <summary>
    /// This class plays the sound to be heard in the game
    /// </summary>
    public class Sounds
    {
        public static ContentManager Content;       
        public static SoundEffectInstance FDsei;
        public static SoundEffectInstance Bsei;
        public static SoundEffectInstance BangSEI;


        /// <summary>
        /// Initializes the Sound
        /// </summary>
        /// <param name="game">Parameter from the Game1-Class</param>
        public Sounds(Game1 game)
        {
            Content = new ContentManager(game.Services, "Content");
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Inititalizes the Sound
        /// </summary>
        /// <param name="soundName">Sound to be played</param>
        /// <param name="pitch">Volume of the Sound</param>
        /// <param name="loop">defines if Sound-Effect is looped or not</param>
        /// <returns></returns>
        public static SoundEffectInstance Play(string soundName, float pitch, Boolean loop)
        {
            try
            {
                SoundEffect mySound = Content.Load<SoundEffect>("Sounds\\" + soundName);
                SoundEffectInstance e = mySound.Play(pitch,1.0f, 0.0f, loop);
                return e;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught "+ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Plays the Sound
        /// </summary>
        /// <param name="sound">Name of the Sound</param>
        /// <param name="pitch">Volume of the Sound</param>
        /// <param name="loop">defines if Sound-Effect is looped or not</param>
        /// <returns></returns>
        public static SoundEffectInstance Play(SoundEnum sound, float pitch, Boolean loop)
        {
            SoundEffectInstance e = Play(sound.ToString(), pitch, loop);
            return e;
        }
       
       /// <summary>
       /// set the SoundEffectInstance for the FinalDrive-Sound-Effect
       /// </summary>
       /// <param name="SoundEffectInstances">change properties of SoundEffect</param>
       
        public static void setFinalDriveSEI(SoundEffectInstance SoundEffectInstances)
        {
            FDsei = SoundEffectInstances;
        }

        /// <summary>
        /// sets the SoundEffectInstance for the Brakes-Sound-Effect
        /// </summary>
        /// <param name="SoundEffectInstances">change properties of SoundEffect</param>
        
        public static void setBrakesSEI(SoundEffectInstance SoundEffectInstances)
        {
           Bsei = SoundEffectInstances;
        }

        /// <summary>
        /// sets SoundEffectInstances for Bang
        /// </summary>
        /// <param name="SoundEffectInstances">change properties of SoundEffect</param>
        public static void setBangSEI(SoundEffectInstance SoundEffectInstances)
        {
            BangSEI = SoundEffectInstances;
        }

        /// <summary>
        /// returns SoundEffectInstance of FinalDrive
        /// </summary>
        /// <returns>change properties of SoundEffect</returns>
        
        public static SoundEffectInstance getFinalDriveSEI()
        {
            return FDsei;
        }

        /// <summary>
        /// returns SoundEffectInstance of Brakes
        /// </summary>
        /// <returns>change properties of SoundEffect</returns>
        
        public static SoundEffectInstance getBrakesSEI()
        {
            return Bsei;
        }

        /// <summary>
        /// returns SoundEffectInstance for Bang
        /// </summary>
        /// <returns>change properties of SoundEffect</returns>
        public static SoundEffectInstance getBangSEI()
        {
            return BangSEI;
        }

        /// <summary>
        /// quits all currently running SoundEffectInstances
        /// </summary>
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

            if (getBangSEI() != null)
            {
                getBangSEI().Stop();
            }
        }

        /// <summary>
        /// plays Bang Sound
        /// </summary>
        /// <param name="loop">defines if Sound is looped</param>
        /// <returns>SoundEffectInstance</returns>
        public static void PlayBangSound(Boolean loop)
        {
            float pitch = 0;
            MediaPlayer.Volume = 1f;
            SoundEffectInstance e = Play(SoundEnum.bang, pitch, loop);
            setBangSEI(e);
        }
        /*
        /// <summary>
        /// plays Bird Sound
        /// </summary>
        /// <param name="loop">defines if Sound is looped</param>
        /// <returns>SoundEffectInstance</returns>
        public static SoundEffectInstance PlayBirdSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.bird, pitch, loop);
            return e;
        }*/

        /// <summary>
        /// plays Brakes Sound
        /// </summary>
        /// <param name="loop">defines if Sound is looped</param>
        public static void PlayBrakesSound(Boolean loop)
        {
            float pitch = 0.7f;
            SoundEffectInstance e = Play(SoundEnum.brakes, pitch, loop);
            setBrakesSEI(e);
        }

        /*
        /// <summary>
        /// plays Burst Sound
        /// </summary>
        /// <param name="loop">defines if Sound is looped</param>
        /// <returns>SoundEffectInstance</returns>
        public static SoundEffectInstance PlayBurstSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.burst, pitch, loop);
            return e;
        }*/

        /// <summary>
        /// plays FinalDriveSound
        /// </summary>
        /// <param name="pitch">defines Volume of the Sound</param>
        /// <param name="loop">defines is SoundEffect is looped</param>
        public static void PlayFinalDriveSound(float pitch, Boolean loop)
        {
            SoundEffectInstance e = Play(SoundEnum.finalDrive, pitch, loop);
            setFinalDriveSEI(e);
        }
        /*
        /// <summary>
        /// plays PlayFinalIdleSound
        /// </summary>
        /// <param name="loop">defines if SoundEffect is looped</param>
        /// <returns>SoundEffectInstance</returns>
        public static SoundEffectInstance PlayFinalIdleSound(Boolean loop)
        {
            float pitch = 0;
            SoundEffectInstance e = Play(SoundEnum.finalIdle, pitch, loop);
            return e;
        }

        /// <summary>
        /// plays HornSound
        /// </summary>
        /// <param name="loop">defines if SoundEffect is looped</param>
        /// <returns>SoundEffectInstance</returns>
        public static SoundEffectInstance PlayHornSound(Boolean loop)
        {
            float pitch = 0;
            MediaPlayer.Volume = 1f;
            SoundEffectInstance e = Play(SoundEnum.horn, pitch, loop);
            return e;
        }*/

        /// <summary>
        /// plays MenuMusic
        /// </summary>
        /// <param name="loop">defines if Music is looped</param>
        public static void PlayMenuMusicSound(Boolean loop)
        {
            Song mysong = Content.Load<Song>("Sounds//menumusic");

            MediaPlayer.Play(mysong);         //needs to be switched on
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = loop;
        }

        /// <summary>
        /// plays GameMusic
        /// </summary>
        /// <param name="loop">defines if music is looped</param>
        public static void PlayGameMusic(Boolean loop)
        {
            Song gameSong = Content.Load<Song>("Sounds//Happy Racing");
            MediaPlayer.Play(gameSong);
            MediaPlayer.Volume = 0.8f;
            MediaPlayer.IsRepeating = loop;
        }
        /*
        /// <summary>
        /// plays WaterSound
        /// </summary>
        /// <param name="loop">defines if SoundEffect is looped</param>
        public static void PlayWaterMusicSound(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.water,pitch,loop);
        }

        /// <summary>
        /// plays WindSound
        /// </summary>
        /// <param name="loop">defines if SoundEffect is looped</param>
        /// <returns></returns>
        public static SoundEffectInstance PlayWindSound(Boolean loop)
        {
            float pitch = 0;

            SoundEffectInstance e = Play(SoundEnum.wind, pitch, loop);
            return e;
        }*/
        /*
        /// <summary>
        /// starts StartMusic
        /// </summary>
        /// <param name="loop">defines if Sound is looped</param>
        public static void StartMusic(Boolean loop)
        {
            float pitch = 0;
            Play(SoundEnum.start,pitch,loop);
        }*/

        /// <summary>
        /// stops Music
        /// </summary>
        public static void StopMusic()
        {
            MediaPlayer.Stop();
        }
        
        /// <summary>
        /// Updates Music
        /// </summary>
        public static void Update()
        {
           
        }

        /// <summary>
        /// defines the Sounds
        /// </summary>
        public enum SoundEnum
        {
            bang,
            //bird,
            brakes,
            //burst,
            finalDrive,
            //finalIdle,
            game,
            //horn,
            //water,
            //wind,
            start
        }
    }
}