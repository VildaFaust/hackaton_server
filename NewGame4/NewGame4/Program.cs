using System;
using System.IO;
using System.IO.Compression;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NewGame4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // FileHelper.CreateFile("newfile.txt");
            // FileHelper.CreateDirectory("NewTestDirectory");

            // FileHelper.DeleteFile("newfile.txt");
            // FileHelper.DeleteDirectory("NewTestDirectory");

            // FileHelper.CompressFile("newfile.txt", "compressednewfile.zip");
            // FileHelper.DecompressFile("compressednewfile.zip", "uncompressednewfile.txt");
            // DeleteCompressedFile(compressedFile);
            
            // FileHelper.CompressDirectory("NewTestDirectory", "CompressedNewTestDirectory.zip");
            // FileHelper.DecompressDirectory("CompressedNewTestDirectory.zip", "UncompressedNewTestDirectory");

            // CompressFileArray(files);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nServer started\n");
            CreateHostBuilder(args).Build().Run();
            Console.Read();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}