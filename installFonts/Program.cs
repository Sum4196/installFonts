using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace InstallFonts
{
    class Program
    {
        static void Main(string[] args)
        {
               string fonts = "\\Fonts";
               string vaultFontDirectory = "";

               //Copies all files from source folder to destination folder.
               void copyFiles(string sourceDirectory, string destDirectory)
               {
                   string[] files = Directory.GetFiles(sourceDirectory);

                   foreach (var s in files)
                   {
                       string filename = Path.GetFileName(s);
                       string destFile = Path.Combine(destDirectory, filename);

                       try
                       {
                           if (filename.Contains("installFonts"))
                           {
                               Console.WriteLine("installFonts.exe found, not copying itself to Fonts folder.  Continuing...");
                           } else
                           {
                               File.Copy(s, destFile, false);
                               File.SetAttributes(destFile, FileAttributes.Normal);
                           }
                       }
                       catch (IOException copyError)
                       {
                           Console.WriteLine(copyError.Message);
                           System.Diagnostics.Debug.WriteLine(copyError.Message);
                       }

                   }
               }


               //System.Diagnostics.Debug.WriteLine("CURRENT USER DOCUMENTS FOLDER: " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
               string vaultPPLWFontsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CW_Vault\\PPLW\\Clearwater Paper\\Fonts";
               string vaultCPLWFontsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CW_Vault\\CPLW\\Clearwater Paper\\Fonts";
               //System.Diagnostics.Debug.WriteLine("PPLW Fonts folder exists?: " + System.IO.Directory.Exists(vaultPPLWFontsPath));
               //System.Diagnostics.Debug.WriteLine("CPLW Fonts folder exists?: " + System.IO.Directory.Exists(vaultCPLWFontsPath));

               //check for vault fonts and choose PPLW or CPLW fonts folder, else, alert user to download fonts from vault.
               if (Directory.Exists(vaultPPLWFontsPath))
               {
                   vaultFontDirectory = vaultPPLWFontsPath;
               }
               else if (Directory.Exists(vaultCPLWFontsPath))
               {
                   vaultFontDirectory = vaultCPLWFontsPath;
               }
               else
               {
                   MessageBox.Show("This program was unable to find a Fonts directory.\nPlease download the Fonts from Vault and re-run this program.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }

               string trueview2015Path = "C:\\Program Files\\Autodesk\\DWG TrueView 2015 - English";
               string trueview2019Path = "C:\\Program Files\\Autodesk\\DWG TrueView 2019 - English";
               string trueview2020Path = "C:\\Program Files\\Autodesk\\DWG TrueView 2020 - English";
               string autocad2015Path = "C:\\Program Files\\Autodesk\\AutoCAD 2015";
               string autocad2019Path = "C:\\Program Files\\Autodesk\\AutoCAD 2019";

               bool btrueview2015Path = Directory.Exists(trueview2015Path);
               bool btrueview2019Path = Directory.Exists(trueview2019Path);
               bool btrueview2020Path = Directory.Exists(trueview2020Path);
               bool bautocad2015Path = Directory.Exists(autocad2015Path);
               bool bautocad2019Path = Directory.Exists(autocad2019Path);

               //System.Diagnostics.Debug.WriteLine("TEST: " + trueview2015Path + fonts);

               if (btrueview2015Path == true)
               {
                   copyFiles(vaultFontDirectory, trueview2015Path+fonts);
               }
               if (btrueview2019Path == true)
               {
                   copyFiles(vaultFontDirectory, trueview2019Path + fonts);
               }
               if (btrueview2020Path == true)
               {
                   copyFiles(vaultFontDirectory, trueview2020Path + fonts);
               }
               if (bautocad2015Path == true)
               {
                   copyFiles(vaultFontDirectory, autocad2015Path + fonts);
               }
               if (bautocad2019Path == true)
               {
                   copyFiles(vaultFontDirectory, autocad2019Path+ fonts);
               }
               

        }
    }
}