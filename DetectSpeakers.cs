using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using PluginContracts;
using OutputHelperLib;
using System.Text.RegularExpressions;


namespace DetectSpeakers
{
    public class DetectSpeakers : Plugin
    {


        public string[] InputType { get; } = { "String" };
        public string OutputType { get; } = "OutputArray";

        public Dictionary<int, string> OutputHeaderData { get; set; } = new Dictionary<int, string>() { { 0, "SpeakerTag" } };
        public bool InheritHeader { get; } = false;

        #region Plugin Details and Info

        public string PluginName { get; } = "Detect Speakers in Transcript";
        public string PluginType { get; } = "Dyads & Groups";
        public string PluginVersion { get; } = "1.0.0";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "Detects speakers in your input texts. You should connect the \"Save Output to CSV\" plugin to this plugin to save your detected speaker list. This will ensure that your detected Speaker List will be saved in an easily-usable format. A description of how this plugin's settings work are presented below:" + Environment.NewLine + Environment.NewLine +
           "The Speaker Tag Delimiter should be whatever character (or string of characters) is used across all of your files to denote the end of the Speaker Tag. It is super important that this be consistent across all speakers in all of your text files — this plugin isn’t super smart, so it only knows to look for whatever you tell it." + Environment.NewLine + Environment.NewLine +
           "The Maximum Speaker Tag Length number is something that you set so that this plugin can be a bit more discriminating in terms of what it believes to be a Speaker Tag. Take a look at the example text below:" + Environment.NewLine + Environment.NewLine +

            "Person 1: Hello, how are you doing today?" + Environment.NewLine +
            "Person 2: Well, that’s a great question." + Environment.NewLine +
            "You see, it all started like this: I was a young lad growing up in Ireland, and my father told me something…" + Environment.NewLine +
            "Person 1: \"Fine, yourself\" would have been an acceptable answer." + Environment.NewLine + Environment.NewLine +

          "In this example, we might use a colon (\":\") as the Speaker Tag delimiter. However, once this plugih gets to the line that starts with \"You see, it all started like this:\", it’s going to see the colon and think \"Hey, this looks like another Speaker! I should add ‘You see, it all started like this:’ to the Speaker Tags list!\"" + Environment.NewLine + Environment.NewLine +
          "The plugin tried its best. However, if we tell it that our Maximum Speaker Tag Length is 20 characters, it will know that any Speaker Tags that it finds that are longer than this should be ignored. Simple as that!";
        public string PluginTutorial { get; } = "https://youtu.be/f7zehjpYu_U";
        public bool TopLevel { get; } = false;


        public Icon GetPluginIcon
        {
            get
            {
                return Properties.Resources.icon;
            }
        }

        #endregion



        private string DelimiterString { get; set; } = ": ";
        private int MaxTagLengthInt { get; set; } = 20;
        private string regexRepl { get; set; } = "";
        private bool uniqueTagsOnly { get; set; } = false;

        public void ChangeSettings()
        {

            using (var form = new SettingsForm_DetectSpeakers(DelimiterString, MaxTagLengthInt, regexRepl, uniqueTagsOnly))
            {


                form.Icon = Properties.Resources.icon;
                form.Text = PluginName;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DelimiterString = form.DelimiterString;
                    MaxTagLengthInt = form.MaxTagLengthInt;
                    regexRepl = form.regexRepl;
                    this.uniqueTagsOnly = form.uniqueTagsOnly;
                }
            }


        }





        public Payload RunPlugin(Payload Input)
        {

            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            //pData.SegmentID = Input.SegmentID;


            for (int i = 0; i < Input.StringList.Count; i++)
            {


                HashSet<string> speakerListTransient = new HashSet<string>();

                string[] readText_Lines = NewlineClean.Split(Input.StringList[i]);
                int NumberOfLines = readText_Lines.Length;

                //loop through all of the lines in each text
                for (int j = 0; j < NumberOfLines; j++)
                {

                    string CurrentLine = readText_Lines[j];

                    if (regexRepl.Length > 0)
                    {
                        CurrentLine = CompiledRegex.Replace(CurrentLine, "").Trim();
                    }
                    else
                    {
                        CurrentLine = CurrentLine.Trim();
                    }


                    int IndexOfDelimiter = CurrentLine.IndexOf(DelimiterString);

                    if (IndexOfDelimiter > -1)
                    {
                        string SpeakerTag = CurrentLine.Substring(0, IndexOfDelimiter + DelimiterLength);


                        if (uniqueTagsOnly)
                        {
                            if (!speakerList.Contains(SpeakerTag) && SpeakerTag.Length <= MaxTagLengthInt)
                            {
                                speakerList.Add(SpeakerTag);
                                pData.StringArrayList.Add(new string[] { SpeakerTag });
                                pData.SegmentNumber.Add(Input.SegmentNumber[i]);
                                if (Input.SegmentID.Count > 0) pData.SegmentID.Add(Input.SegmentID[i]);
                            }
                        }
                        else
                        {
                            if (!speakerListTransient.Contains(SpeakerTag) && SpeakerTag.Length <= MaxTagLengthInt)
                            {
                                speakerListTransient.Add(SpeakerTag);
                                pData.StringArrayList.Add(new string[] { SpeakerTag });
                                pData.SegmentNumber.Add(Input.SegmentNumber[i]);
                                if (Input.SegmentID.Count > 0) pData.SegmentID.Add(Input.SegmentID[i]);
                            }
                        }

                        

                    }


                    //end of for loop through each line
                }


            }

            return (pData);

        }


        private Regex NewlineClean = new Regex(@"[\r\n]+", RegexOptions.Compiled);
        private Regex CompiledRegex { get; set; }
        ConcurrentHashSet<string> speakerList { get; set; }
        int DelimiterLength { get; set; }

        public void Initialize()
        {
            speakerList = new ConcurrentHashSet<string>();
            if (regexRepl.Length > 0) CompiledRegex = new Regex(regexRepl, RegexOptions.Compiled);
            DelimiterLength = DelimiterString.Length;

        }

        public bool InspectSettings()
        {
            return true;
        }


        public Payload FinishUp(Payload Input)
        {
            speakerList.Clear();
            return (Input);
        }






        #region Import/Export Settings
        public void ImportSettings(Dictionary<string, string> SettingsDict)
        {
            DelimiterString = SettingsDict["DelimiterString"];
            uniqueTagsOnly = Boolean.Parse(SettingsDict["uniqueTagsOnly"]);
            regexRepl = SettingsDict["regexRepl"];
            MaxTagLengthInt = int.Parse(SettingsDict["MaxTagLengthInt"]);
        }

        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();

            SettingsDict.Add("DelimiterString", DelimiterString);
            SettingsDict.Add("MaxTagLengthInt", MaxTagLengthInt.ToString());
            SettingsDict.Add("regexRepl", regexRepl);
            SettingsDict.Add("uniqueTagsOnly", uniqueTagsOnly.ToString());

            return (SettingsDict);
        }
        #endregion








    }
}
