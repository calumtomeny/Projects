using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConverter
{
    using System.Diagnostics;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the source directory.");
            string sourceFolderName = Console.ReadLine();
            Console.WriteLine("Please enter the destination directory.");
            string destinationFolder = Console.ReadLine();
            Console.WriteLine("Please enter the location of ffmpeg.");
            string ffmpegPath = Console.ReadLine();

            if (!Directory.Exists(sourceFolderName))
            {
                throw new FileNotFoundException(sourceFolderName);
            }
            if (!Directory.Exists(destinationFolder))
            {
                throw new DirectoryNotFoundException(destinationFolder);
            }

            //Get all files in source directory

            var filesToConvert = Directory.GetFiles(sourceFolderName, "*.*", SearchOption.AllDirectories);

            foreach (var s in filesToConvert)
            {
                string destinationFileName = Path.Combine(destinationFolder, Path.GetFileNameWithoutExtension(s)) + ".mp4";
                if (File.Exists(destinationFileName))
                {
                    continue;
                }

                try
                {
                    FFmpeg.ConvertToMP4(s, destinationFolder, ffmpegPath);
                }
                catch (Exception e)
                {
                    using (StreamWriter writer = new StreamWriter("error.txt", true))
                    {
                        writer.WriteLine("Failed to convert file: " + s);
                    }
                }
            }
        }
    }

    public static class FFmpeg
    {
        public static string ConvertToMP4(string sourceFileName, string destinationPath, string FFmpegPath)
        {
            string ffmpeg = FFmpegPath;

            if (string.IsNullOrEmpty(ffmpeg))
            {
                throw new FFMpegException("Couldn't find FFMpeg path.");
            }

            string destination = Path.Combine(destinationPath, Path.GetFileNameWithoutExtension(sourceFileName) + ".mp4");

            if (File.Exists(destinationPath))
            {
                return Path.GetFileName(destination);
            }

            var psi = new ProcessStartInfo(
                ffmpeg, string.Format(@"-i ""{0}"" -ar 44100 -y ""{1}""", sourceFileName, destinationPath + "\\" + Path.GetFileNameWithoutExtension(sourceFileName) + ".mp4"))
            {
                UseShellExecute =
                    false,
            };

            using (var process = new Process { StartInfo = psi })
            {
                process.Start();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new FFMpegException(
                        string.Format("Couldn't convert [{0}], error code [{1}].", sourceFileName, process.ExitCode));
                }
            }

            return Path.GetFileName(destination);
        }
    }

    public class FFMpegException : Exception
    {
        public FFMpegException()
        {
        }

        public FFMpegException(string message)
            : base(message)
        {
        }

        public FFMpegException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
