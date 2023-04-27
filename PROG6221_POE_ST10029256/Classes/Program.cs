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
            PlaySong("Sunrise-_Original-Mix_.wav");
            Worker_class worker = new Worker_class();
            worker.MainMenu();
    
        }

        private static void PlaySong(string song)
        {

            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = song;
            musicPlayer.Play();
            
        }
    }
}
