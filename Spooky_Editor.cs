using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New Document"); //creates a new tab page
            RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
            rtb.Dock = DockStyle.Fill; //docks rich text box 
            tp.Controls.Add(rtb); // adds rich text box to the tab page
            tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
        }


        private RichTextBox GetRichTextBox()
        {
            RichTextBox rtb = null; 
            TabPage tp = tabControl1.SelectedTab; 
            if (tp != null)
            {
                rtb = tp.Controls[0] as RichTextBox; //sets the selected rich text box index as primary
            }
            return rtb;
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New Document"); //creates a new tab page
            RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
            rtb.Dock = DockStyle.Fill; //docks rich text box 
            tp.Controls.Add(rtb); // adds rich text box to the tab page
            tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string filename = openFileDialog1.FileName;//copies the path of the file into a variable
                    string readfiletext = File.ReadAllText(filename);//reads all the text from the opened file
                    TabPage tp = new TabPage("New Document"); //creates a new tab page
                    RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
                    rtb.Dock = DockStyle.Fill; //docks rich text box 
                    tp.Controls.Add(rtb); // adds rich text box to the tab page
                    tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
                    rtb.Text = readfiletext;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the TXT extension for the file.
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "TXT Files|*.txt";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                GetRichTextBox().SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine if last operation can be undone in text box.   
            if (GetRichTextBox().CanUndo == true)
            {
                // Undo the last operation.
                GetRichTextBox().Undo();
                // Clear the undo buffer to prevent last action from being redone.
                GetRichTextBox().ClearUndo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetRichTextBox().CanRedo == true)
            {
                // Undo the last operation.
                GetRichTextBox().Redo();

            }
        }

        private void color1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If the TextBox contains text, change its foreground and background colors.
            if (GetRichTextBox().Text != String.Empty)
            {
                GetRichTextBox().ForeColor = Color.White;
                GetRichTextBox().BackColor = Color.Black;
                // Move the selection pointer to the end of the text of the control.
                GetRichTextBox().Select(GetRichTextBox().Text.Length, 0);
            }
        }

        private void color2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If the TextBox contains text, change its foreground and background colors.
            if (GetRichTextBox().Text != String.Empty)
            {
                GetRichTextBox().ForeColor = Color.Yellow;
                GetRichTextBox().BackColor = Color.Black;
                // Move the selection pointer to the end of the text of the control.
                GetRichTextBox().Select(GetRichTextBox().Text.Length, 0);
            }
        }

        private void color3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetRichTextBox().Text != String.Empty)
            {
                GetRichTextBox().ForeColor = Color.Purple;
                GetRichTextBox().BackColor = Color.White;
                // Move the selection pointer to the end of the text of the control.
                GetRichTextBox().Select(GetRichTextBox().Text.Length, 0);
            }

        }



        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

       

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetRichTextBox().SelectionFont != null)
            {
                System.Drawing.Font currentFont = GetRichTextBox().SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (GetRichTextBox().SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                GetRichTextBox().SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetRichTextBox().SelectionFont != null)
            {
                System.Drawing.Font currentFont = GetRichTextBox().SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (GetRichTextBox().SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                }

                GetRichTextBox().SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetRichTextBox().SelectionFont != null)
            {
                System.Drawing.Font currentFont = GetRichTextBox().SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (GetRichTextBox().SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                }

                GetRichTextBox().SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New Document"); //creates a new tab page
            RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
            rtb.Dock = DockStyle.Fill; //docks rich text box 
            tp.Controls.Add(rtb); // adds rich text box to the tab page
            tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string filename = openFileDialog1.FileName;//copies the path of the file into a variable
                    string readfiletext = File.ReadAllText(filename);//reads all the text from the opened file
                    TabPage tp = new TabPage("New Document"); //creates a new tab page
                    RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
                    rtb.Dock = DockStyle.Fill; //docks rich text box 
                    tp.Controls.Add(rtb); // adds rich text box to the tab page
                    tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
                    rtb.Text = readfiletext;
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the TXT extension for the file.
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "TXT Files|*.txt";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                GetRichTextBox().SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            // Determine if last operation can be undone in text box.   
            if (GetRichTextBox().CanUndo == true)
            {
                // Undo the last operation.
                GetRichTextBox().Undo();
                // Clear the undo buffer to prevent last action from being redone.
                GetRichTextBox().ClearUndo();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (GetRichTextBox().CanRedo == true)
            {
                // Undo the last operation.
                GetRichTextBox().Redo();

            }
        }

       

     

    }
}
