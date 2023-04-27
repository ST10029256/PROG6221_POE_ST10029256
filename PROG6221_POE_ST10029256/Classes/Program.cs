using System;
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
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Music();
            
            Worker_class worker = new Worker_class();
            worker.MainMenu();
    
        }


        private static void Music()
        {
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
                    Console.Write("Please provide a YES or NO to listern to music ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    choice = (Console.ReadLine()).ToUpper();
                    reAsk = false;
                }

            } while (reAsk == false);

            if (choice.Equals("YES"))
            {
                PlaySong("Sunrise-_Original-Mix_.wav");
            }
        }

        private static void PlaySong(string song)
        {

            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = song;
            musicPlayer.Play();
            
        }
    }
}
