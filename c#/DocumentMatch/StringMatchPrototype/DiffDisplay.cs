using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StringMatchPrototype
{



    public partial class DiffDisplay : Form
    {
        private string fName1;
        private string fName2;
        private List<int> tokenIdList1;
        private List<string> tokenStrList1;
        private List<int> tokenIdList2;
        private List<string> tokenStrList2;

        public DiffDisplay(string f1, string f2, 
                           List<int> tList1, List<int> tList2, 
                           List<string> tStrList1, List<string> tStrList2, 
                           int k)
        {
            fName1 = f1;
            fName2 = f2;
            tokenIdList1 = tList1;
            tokenIdList2 = tList2;
            tokenStrList1 = tStrList1;
            tokenStrList2 = tStrList2;

            docDupDiff.appStrMatch s = new docDupDiff.appStrMatch();
            int dis = s.kStrDistance(tokenIdList1.ToArray(), tokenIdList2.ToArray(), k);
            Console.WriteLine(dis);
            s.findDif();
            InitializeComponent();
            richTextBox1.BindScroll(richTextBox2);

            fileName1.Text = fName1;
            fileName2.Text = fName2;
            richTextBox1.Text = string.Join(" ", tokenStrList1);
            richTextBox2.Text = string.Join(" ", tokenStrList2);
            this.Text = "Document Difference:   " + k + " (Edit Distance)";

            Font font = new Font("Verdana", 10F, FontStyle.Italic, GraphicsUnit.Point);
            for (int i = 0; i < s.DF.Count; i++)
            {
                int startSel;
                if (s.DF[i].doc == 0)   // substitute
                {
                    FindSelectionText(out startSel, s.DF[i].idx1-1, tokenStrList1);
                    richTextBox1.SelectionStart = startSel;
                    richTextBox1.SelectionLength = tokenStrList1[s.DF[i].idx1-1].Length;
                    richTextBox1.SelectionFont = font;
                    richTextBox1.SelectionColor = Color.Blue;

                    FindSelectionText(out startSel, s.DF[i].idx2-1, tokenStrList2);
                    richTextBox2.SelectionStart = startSel;
                    richTextBox2.SelectionLength = tokenStrList2[s.DF[i].idx2-1].Length;
                    richTextBox2.SelectionFont = font;
                    richTextBox2.SelectionColor = Color.Blue;

                }
                else if (s.DF[i].doc == 1)   // delete from first doc
                {
                    FindSelectionText(out startSel, s.DF[i].idx1-1, tokenStrList1);
                    richTextBox1.SelectionStart = startSel;
                    richTextBox1.SelectionLength = tokenStrList1[s.DF[i].idx1-1].Length;
                    richTextBox1.SelectionFont = font;
                    richTextBox1.SelectionColor = Color.Red;
                }
                else if(s.DF[i].doc == 2)  // delete from second doc
                {
                    FindSelectionText(out startSel, s.DF[i].idx2-1, tokenStrList2);
                    richTextBox2.SelectionStart = startSel;
                    richTextBox2.SelectionLength = tokenStrList2[s.DF[i].idx2-1].Length;
                    richTextBox2.SelectionFont = font;
                    richTextBox2.SelectionColor = Color.Red;
                }
                Logger.writeLog(s.DF[i].doc + " " + s.DF[i].dType + " " + s.DF[i].idx1 + " " + s.DF[i].idx2, LogType.LOG_INFO);
            }
        }

        private void FindSelectionText(out int startSel, int index, List<string> tStrList)
        {
            startSel = 0;
            for (int i = 0; i < index; i++)
            {
                startSel = tStrList[i].Length + 1 + startSel;
            }
        }
    }
}
