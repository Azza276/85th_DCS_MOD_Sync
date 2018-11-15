using System;
using System.IO;

namespace OGN_DCS_Mod_Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine DCS Users Directory//
            // Find the directory path from C:\Users\[Username]\Saved Games\DCS or DCS Openbeta or DCS World or DCS Openalpha//
            // Copy that directory path into the "userpath" variable

            string userName = (Environment.UserName);
            string partialName = "Liveries";
            DirectoryInfo driveToSearch = new DirectoryInfo(@"c:\\Users\\" + userName + "\\");
            FileInfo[] filesInDir = driveToSearch.GetFiles("*" + partialName);

            foreach (FileInfo foundFile in filesInDir)
            {
                string userPath = foundFile.FullName;
                Console.WriteLine(userPath);
            }


            // Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
