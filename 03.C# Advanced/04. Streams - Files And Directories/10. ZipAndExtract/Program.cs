using System;
using System.IO;
using System.IO.Compression;

namespace _10._ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = "../../../ArchiveDemo/archiveFolder";
            string zipPath = "../../../ArchiveDemo/Archived.zip";
            string extractPath = "../../../ArchiveDemo/extractToFolder";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
