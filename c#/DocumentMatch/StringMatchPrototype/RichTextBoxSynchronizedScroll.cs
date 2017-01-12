
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
    /// Subclass RichTextBox to add the capability to bind scrolling for multiple RichTextBoxs.
    /// This is useful for 'parallel' RTBs that require synchronized scrolling.
    /// Taken from https://gist.github.com/593809
    /// Added WM_HSCROLL 
    /// Added BindScroll() to form a two-way linkage between RichTextBoxes.
    /// Example usage showing how to bind 3 RichTextBoxes together:
    ///    rtb1.BindScroll(rtb2);
    ///    rtb2.BindScroll(rtb3);
    ///    rtb3.BindScroll(rtb1);
    class RichTextBoxSynchronizedScroll : RichTextBox
    {

        private const int WM_VSCROLL = 0x115;
        private const int WM_HSCROLL = 0x114;

        private List<RichTextBoxSynchronizedScroll> peers = new List<RichTextBoxSynchronizedScroll>();

        /// <summary>
        /// Establish a 2-way binding between RTBs for scrolling.
        /// </summary>
        /// <param name="arg">Another RTB</param>
        public void BindScroll(RichTextBoxSynchronizedScroll arg)
        {
            if (peers.Contains(arg) || arg == this) { return; }
            peers.Add(arg);
            arg.BindScroll(this);
        }

        private void DirectWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL)
            {
                foreach (RichTextBoxSynchronizedScroll peer in this.peers)
                {
                    Message peerMessage = Message.Create(peer.Handle, m.Msg, m.WParam, m.LParam);
                    peer.DirectWndProc(ref peerMessage);
                }
            }

            base.WndProc(ref m);
        }
    }

}
