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
            Console.WriteLine(driveToSearch);
            FileInfo[] dir = driveToSearch.GetFiles(searchPattern: partialName);


            Console.WriteLine(dir);

            // Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
