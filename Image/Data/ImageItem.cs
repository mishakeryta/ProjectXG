using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectXG
{
    class ImageItem
    {
        //path to the image
        public string FullPath { get; set; }
        // name of the image
        public string Name { get { return ImageStructure.GetImageName(FullPath); } }
    }
}
