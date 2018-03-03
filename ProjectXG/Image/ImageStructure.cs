using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectXG
{
    //class thet implement all mthods of adding image to program
    class ImageStructure
    {
        static public string GetImageName(string fullPath)
        {
            
            if(string.IsNullOrEmpty(fullPath))
            {
                return null;
            }
            //normalize path(crossplatform code)
            var normalizePath = fullPath.Replace('\\','/');
            return fullPath.Substring(normalizePath.LastIndexOf('/') + 1);
        }
        // implement dialog thet ask the images paths, і dont know is it true
        static public List<string>  GetImagesPathWhithHelpOfDialog()
        {
            List<string> paths = new List<string>();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = true;
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
               paths.AddRange(dlg.FileNames);
            }
            return paths;
        }
    }
}