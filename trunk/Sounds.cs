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
#endregion

namespace ACT2009
{
    class Sounds
    {
        static AudioEngine audioEngine;
        static WaveBank waveBank;
        static SoundBank soundBank;
        static AudioCategory musicCategory;
        
        static Sounds()
        {
            Console.WriteLine("in sound");
            try
            {
                //string dir = Directory.
                audioEngine = new AudioEngine("Content\\ACT2009.xgs");
                waveBank = new WaveBank(audioEngine, "Content\\Wave Bank.xwb");

                if (waveBank != null)
                {
                    soundBank = new SoundBank(audioEngine, "Content\\Sound Bank.xsb");
                }
                musicCategory = audioEngine.GetCategory("Music");
            }
            catch (Exception e)
            {
                Console.Write("ERROR: Failed to create sound class: " + e.ToString());
            }
        }

        public static void Play(string soundName)
        {
            if (soundBank == null)
                return;
            Console.WriteLine("im in??");

            try
            {
                soundBank.PlayCue(soundName);
            }
            catch (Exception e)
            {
                Console.Write("ERROR: Playing sound " + soundName + " failed: " + e.ToString());
            }
        }

        public static void Play(SoundEnum sound)
        {
            Console.Write("I'm in Play enum");
            Play(sound.ToString());
        }

        
        public static void PlayBirdSound()
        {
            Play(SoundEnum.bird);
            Console.WriteLine("in birds");
        }

        public static void PlayWaterSound()
        {
            Play(SoundEnum.water);
        }

        public static void PlayBangSound()
        {
            Play(SoundEnum.bang);
        }

        public static void PlayBrakes()
        {
            Play(SoundEnum.brakes);
        }

        public static void PlayDriveSound()
        {
            Play(SoundEnum.finalDrive);
        }

        public static void PlayHornSound()
        {
            Play(SoundEnum.horn);
        }

        public static void PlayIdleSound()
        {
            Play(SoundEnum.finalIdle);
        }

        public static void PlayWindSound()
        {
            Play(SoundEnum.wind);
        }
        

        public static void StartMusic()
        {
            //Play(SoundEnum.start);
            //needs to be replaced with the Game Music
        }

        public static void StopMusic()
        {
            musicCategory.Stop(AudioStopOptions.Immediate);
        }

        public static void Update()
        {
            if (audioEngine != null)
            {
                audioEngine.Update();
            }
        }

        public enum SoundEnum
        {
            wind,
            water,
            horn,
            finalIdle,
            finalDrive,
            burst,
            brakes,
            bird,
            bang
        }
    }
}