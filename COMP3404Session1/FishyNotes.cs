namespace COMP3404Session1
{
    /// <summary>
    /// FishyNotes - This class will be in charge of creating new fishy note
    /// 
    /// Author - Bartek Siwak
    /// Date/Version - 21/09/2022
    /// </summary>
    public partial class FishyNotes : Form
    {
        private Form _newNote;
        // INITALISE a field which will store references to a FishyNote instance 

        public FishyNotes()
        {
            InitializeComponent();
        }

        // AddNote_Click - This method will occur when the button is clicked and it will create a note
        //
        // param sender - This is the object of the button
        // param e - This is the event that occurred 
        private void AddNote_Click(object sender, EventArgs e)
        {
            // IF a note doesn't exist
            if (_newNote == null || _newNote.IsDisposed)
            {
                // CREATE a fishy note and store it in _newNote field 
                _newNote = new FishyNote();
                // DISPLAY the _newNote
                _newNote.Show();
            }
        }
    }
}