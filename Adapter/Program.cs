using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            AudioPlayer player = new AudioPlayer();

            player.play("mp3", "Justin Beiber - Baby.mp3");
            player.play("mp4", "Porter Robinson - Lionhearted.mp3");
            player.play("mp4", "Tiesto - Red Lights.mp3");
            player.play("vlc", "Com Truise - Cyanide Sisters.mp3");
            player.play("avi", "Afrojack - Stars.mp3");

            Console.Read();
        }
    }

    public interface IMediaPlayer
    {
        void play(string audioType, string fileName);
    }

    public interface IAdvancedMediaPlayer
    {
        void playVlc(string filename);
        void playMp4(string fileName);
    }

    public class VlcPlayer : IAdvancedMediaPlayer
    {
        public void playVlc(string fileName)
        {
            Console.WriteLine("Playing vlc filename {0}", fileName);
        }

        public void playMp4(string fileName)
        {
            // 
        }
    }

    public class Mp4Player : IAdvancedMediaPlayer
    {
        public void playVlc(string fileName)
        {
            // 
        }

        public void playMp4(string fileName)
        {
           Console.WriteLine("Playing mp4 filename {0}", fileName);
        }
    }

    public class MediaAdapter : IMediaPlayer
    {
        private IAdvancedMediaPlayer amp;

        public MediaAdapter(string audioType)
        {
            if (audioType.Equals("vlc"))
            {
                amp = new VlcPlayer();
            }
            else if (audioType.Equals("mp4"))
            {
                amp = new Mp4Player();
            }
        }

        public void play(string audioType, string fileName)
        {
            if (audioType.Equals("vlc"))
            {
                amp.playVlc(fileName);
            }
            else if (audioType.Equals("mp4"))
            {
                amp.playMp4(fileName);
            }
        }
    }

    public class AudioPlayer : IMediaPlayer
    {
        private MediaAdapter ma;
        public void play(string audioType, string fileName)
        {
            if (audioType.Equals("mp3"))
            {
                Console.WriteLine("Playing mp3 file. Name: " + fileName);
            }
            else if (audioType.Equals("vlc") || audioType.Equals("mp4"))
            {
                ma = new MediaAdapter(audioType);
                ma.play(audioType, fileName);
            }
        }
    }
}
