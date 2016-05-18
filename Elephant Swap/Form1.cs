using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elephant_Swap
{
    public partial class Form1 : Form
    {
        Elephant lucinda;
        Elephant lloyd;

        public Form1()
        {
            InitializeComponent();

            lucinda = new Elephant()
            { Name = "Lucinda", EarSize = 33 };

            lloyd = new Elephant()
            { Name = "Lloyd", EarSize = 40 };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lloyd.WhoAmI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lucinda.WhoAmI();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Elephant holder;
            holder = lloyd;
            lloyd = lucinda;
            lucinda = holder;
            MessageBox.Show("Objects swapped");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lloyd.TellMe("Hi", lucinda);
            lloyd.SpeakTo(lucinda, "Hello");

            lloyd = lucinda;
            lloyd.EarSize = 4321;
            lloyd.WhoAmI();
        }
    }
}

class Elephant
{
    public int EarSize;
    public string Name;

    public void WhoAmI()
    {
        MessageBox.Show("My ears are " + EarSize + " inches tall.", Name + " says...");
    }

    public void TellMe(string message, Elephant whoSaidIt)
    {
        MessageBox.Show(whoSaidIt.Name + " says: " + message);
    }

    public void SpeakTo(Elephant whoToTalkTo, string message)
    {
        // When Lloyd's SpeakTo() method is called, it uses it's whoToTalkTo parameter (which has a reference
        // to Lucinda) to call Lucinda's TellMe() method.

        /*
         * whoToTalkTo.TellMe(message, this);
         * 
         * Lloyd uses whoToTalkTo (which has a reference to lucinda) to call TellMe()
         *      VVVVV
         *       VVV        'this' is replaced with a reference to Lloyd's object
         *        V                    VVVVV
         * lucinda.TellMe(message, [a reference to Lloyd]);
         * 
         * So Linda acts as if she was called with ("Hello", lloyd), and shows the message "Lloyd says: Hello"
         * 
         */

        whoToTalkTo.TellMe(message, this);
    }
}
