using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_3_JTEmerson
{
    public partial class DisplayQuote : Form
    {
        public DisplayQuote(DeskQuote deskQuote)
        {
            InitializeComponent();
            //set all values for display
            label8.Text = deskQuote.CustomerName;
            label9.Text = deskQuote.Desk.Width.ToString();
            label10.Text = deskQuote.Desk.Depth.ToString();
            label11.Text = deskQuote.Desk.NumberOfDrawers.ToString();
            label12.Text = deskQuote.Desk.Material.ToString();

            if(deskQuote.RushDays == 7)
            {
                label13.Text = "7 Days";
            }
            else if (deskQuote.RushDays == 3)
            {
                label13.Text = "3 Days";
            }
            else if (deskQuote.RushDays == 5)
            {
                label13.Text = "5 Days";
            }
            else
            {
                label13.Text = "0 Days";
            }

            label7.Text = deskQuote.QuoteAmount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addQuote = (AddQuote)Tag;
            addQuote.Show();
            Close();
        }

        private void DisplayQuote_Load(object sender, EventArgs e)
        {

        }
    }
}
