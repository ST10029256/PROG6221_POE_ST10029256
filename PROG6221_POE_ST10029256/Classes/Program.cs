﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace PROG6221_POE_ST10029256
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker_class worker = new Worker_class();
            worker.PrintWelcomeMessage();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();

            Music();
            worker.MainMenu();
    
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method will ask the user if the user wants to listern to music
        /// </summary>
        private static void Music()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Would you like to listern to music? (YES/NO): ");
            string choice = (Console.ReadLine()).ToUpper();
            bool reAsk = false;
            do
            {

                if ((choice.Equals("YES")) || (choice.Equals("NO")))
                {
                    reAsk = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please provide a YES or NO to listern to music: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    choice = (Console.ReadLine()).ToUpper();
                    reAsk = false;
                }

            } while (reAsk == false);

            if (choice.Equals("YES"))
            {
                //Calling the method PlaySong, and sending the songs file name as a parameter
                PlaySong("Sunrise.wav");
            }
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method will play the song
        /// </summary>
        /// <param name="song"></param>
        private static void PlaySong(string song)
        {

            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = song;
            musicPlayer.Play();
            
        }
    }
}//----------------------------------------------------END OF FILE------------------------------------------------------------------//
