using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_3_JTEmerson
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();

            string[] deskQuotes = File.ReadAllLines(@"quotes.txt");

            foreach (string deskQuote in deskQuotes)
            {
                string[] arrRow = deskQuote.Split(new char[] { ',' });
                dataGridView1.Rows.Add(arrRow);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }
    }
}
