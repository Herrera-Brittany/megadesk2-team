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
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();

            comboBox1.DataSource = Enum.GetNames(typeof(Material));

            dataGridView1.Rows.Clear();

            var searchTerm = comboBox1.SelectedValue;

            string[] deskQuotes = File.ReadAllLines(@"quotes.txt");

            foreach (string deskQuote in deskQuotes)
            {
                if (deskQuote.Contains(searchTerm.ToString()))
                {
                    string[] arrRow = deskQuote.Split(new char[] { ',' });
                    dataGridView1.Rows.Add(arrRow);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            var searchTerm = comboBox1.SelectedValue;

            string[] deskQuotes = File.ReadAllLines(@"quotes.txt");

            foreach (string deskQuote in deskQuotes)
            {
                if (deskQuote.Contains(searchTerm.ToString()))
                {
                    string[] arrRow = deskQuote.Split(new char[] { ',' });
                    dataGridView1.Rows.Add(arrRow);
                }
            }
        }
    }
}
