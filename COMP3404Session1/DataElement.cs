using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3404Session1
{
    /// <summary>
    /// DataElement - This class will be used to store text and images of a fishy note
    /// 
    /// Author - Bartek Siwak
    /// Date/Version - 21/09/22
    /// </summary>
    public class DataElement
    {
        //INITIALISE a string field that will store text
        public string _text;

        //INITALISE a image field that will store the image
        public readonly Image _image;

        public DataElement(string pText, string pImagePath)
        {
            _text = pText;
            try
            {
                _image = Bitmap.FromFile(Path.GetFullPath(pImagePath));
            }
            catch (Exception)
            {
                _image = new Bitmap(16,16);
            }

        }

    }
}
