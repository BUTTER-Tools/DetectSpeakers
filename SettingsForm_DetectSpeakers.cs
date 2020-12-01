using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DetectSpeakers
{
    internal partial class SettingsForm_DetectSpeakers : Form
    {


        #region Get and Set Options

        public string DelimiterString { get; set; }
        public int MaxTagLengthInt { get; set; }
        public string regexRepl { get; set; }
        public bool uniqueTagsOnly { get; set; }

        #endregion



        public SettingsForm_DetectSpeakers(string speakListDelim, int maxLen, string regExp, bool uniqueTags)
        {
            InitializeComponent();

            SpeakerDelimiterTextBox.Text = speakListDelim;
            MaxSpeakerLenUpDown.Value =  (decimal)maxLen;
            RegexTextBox.Text = regExp;
            UniqueTagsCheckbox.Checked = uniqueTags;



        }






        

        private void OKButton_Click(object sender, System.EventArgs e)
        {


            this.DelimiterString = SpeakerDelimiterTextBox.Text;
            this.MaxTagLengthInt = (int)MaxSpeakerLenUpDown.Value;
            this.uniqueTagsOnly = UniqueTagsCheckbox.Checked;

            try
            {
                Regex Test = new Regex(SpeakerDelimiterTextBox.Text, RegexOptions.Compiled);
            }
            catch
            {
                MessageBox.Show("Your regular expression does not appear to be valid.", "Segmentation Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.regexRepl = RegexTextBox.Text;



            this.DialogResult = DialogResult.OK;
        }



        private void RegexTextBox_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
