using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP3404Session1
{
    /// <summary>
    /// FishyNote - This class will create the note which the user will be able to edit
    /// 
    /// Author - Bartek Siwak
    /// Date/Version - 21/09/22
    /// </summary>
    public partial class FishyNote : Form
    {
        //INITIALISE a DataElement field to hold a reference to the data element instance 
        private DataElement _data;

        //INITIALISE a string to hold the text that will be in the text box
        private string _text;

        //INITIALISE & ASSIGN a path to hold the filename of the required fish image 
        private string _fishImagePath = "..\\..\\..\\FishAssets\\OrangeFish.png";

        //INITALISE & ASSIGN a boolean field which will determine whether the note is shrunk or expanded
        // with the default value being expanded 
        private bool expanded = true;

        //INITALISE & ASSIGN the correct sizing of the expanded and shrunk window
        private int minSize = 60;
        private int maxSize = 420;

        public FishyNote()
        {
            InitializeComponent();
            try
            {
                _data = new DataElement(_text, _fishImagePath);
            }
            catch(InvalidStringException)
            {
                throw new InvalidStringException("oops!");
            }
            CollapseOpenBtn.Image = _data._image;
        }

        // DeleteButton_Click - This method will occur when the user clicks the delete button on the note
        //
        // param sender - This is the object that sent the command
        // param e - This is the event that occurs 
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //DESTROY the collapsable button image
            CollapseOpenBtn.Image.Dispose();
            // DISPOSE of the image held in the data element
            _data.Dispose();
            // DESTROY the fishy note instance 
            this.Dispose();
        }

        // DeleteButton_Click - This method will occur when the user clicks the collapse button on the note
        // and it will toggle between shrunk and expanded
        //
        // param sender - This is the object that sent the command
        // param e - This is the event that occurs 
        private void CollapseOpenBtn_Click(object sender, EventArgs e)
        {
            // IF the note is expanded 
            if (expanded)
            {
                // TOGGLE the expanded boolean to false 
                expanded = false;
                // RESIZE the window to minimise the text box
                ActiveForm.Height = minSize;
            }
            else
            {
                // TOGGLE the expanded boolean to true
                expanded = true;
                // RESIZE the window to it's original size
                ActiveForm.Height = maxSize;
            }
        }

        // DeleteButton_Click - This method will occur when the user clicks the text box and it will make 
        // text that was written before appear again
        //
        // param sender - This is the object that sent the command
        // param e - This is the event that occurs 
        private void TextBox_Click(object sender, EventArgs e)
        {
            // SET the existing text in the text box to the text in the data element
            TextBox.Text = _data._text;
        }

        // TextBow_TextChanged - This method will occur when the user edits the text box and it will make 
        // the existing text will be saved to be shown again
        //
        // param sender - This is the object that sent the command
        // param e - This is the event that occurs 
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // SET the text variable inside the data element to be what's in the box
            _data._text = TextBox.Text;
        }

        #region Code Snippet: makes this borderless window movable
        // Modified from https://stackoverflow.com/a/24561946 and attributed to user jay_t55

        // DECLARE a boolean that is set to true when a mouse down event is detected, call it _mouseDown:
        private bool _mouseDown = false;

        // DECLARE a Point object to store the last location of the window origin (ie memory), call it _lastLocation:
        private Point _lastLocation;

        // Mouse down event handler
        private void FishyNote_MouseDown(object sender, MouseEventArgs e)
        {
            // SET _mouseDown true:
            _mouseDown = true;

            // STORE current location to _lastLocation:
            _lastLocation = e.Location;
        }

        // Mouse move event handler
        private void FishyNote_MouseMove(object sender, MouseEventArgs e)
        {
            // Only act if mouse button is down...
            if (_mouseDown)
            {
                // SET new location according to mouse movement from _lastLocation:
                this.Location = new Point(
                    (this.Location.X - _lastLocation.X) + e.X, (this.Location.Y - _lastLocation.Y) + e.Y);

                // UPDATE this window:
                this.Update();
            }
        }

        // Mouse up event handler
        private void FishyNote_MouseUp(object sender, MouseEventArgs e)
        {
            // RESET _mouseDown to false:
            _mouseDown = false;
        }
        #endregion

    }
}
