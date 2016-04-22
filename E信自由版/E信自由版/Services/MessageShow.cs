using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E信自由版.Services
{
    public static class MessageShow
    {
        public static void Display(string text)
        {
            MessageBox.Show(text);
        }

        public static void Display(string text, string caption)
        {
            MessageBox.Show(text, caption);
        }

        public static DialogResult Display(string text, string caption, MessageBoxButtons button)
        {
            return MessageBox.Show(text, caption,button);
        }

    }
}
