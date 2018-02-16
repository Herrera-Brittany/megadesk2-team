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
using Newtonsoft.Json;

namespace MegaDesk_3_JTEmerson
{
    public partial class AddQuote : Form
    {
        public AddQuote()
        {
            InitializeComponent();

            comboBox1.DataSource = new int[] { 1, 2, 3, 4, 5, 6 };
            comboBox2.DataSource = Enum.GetNames(typeof(Material));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var desk = new Desk
            {
                Depth = Int32.Parse(textBox4.Text),
                Width = Int32.Parse(textBox5.Text),
                NumberOfDrawers = (int)comboBox1.SelectedValue
            };

            switch (comboBox2.SelectedItem)
            {
                case "laminate":
                    desk.Material = Material.laminate;
                    break;

                case "oak":
                    desk.Material = Material.oak;
                    break;

                case "pine":
                    desk.Material = Material.pine;
                    break;

                case "rosewood":
                    desk.Material = Material.rosewood;
                    break;

                case "veneer":
                    desk.Material = Material.veneer;
                    break;
            }

            var deskQuote = new DeskQuote
            {
                Desk = desk,
                CustomerName = textBox1.Text,
                QuoteDate = DateTime.Now
            };

            if (radioButton1.Checked)
            {
                deskQuote.RushDays = 0;
            }
            else if (radioButton2.Checked)
            {
                deskQuote.RushDays = 3;
            }
            else if (radioButton3.Checked)
            {
                deskQuote.RushDays = 5;
            }
            else if (radioButton4.Checked)
            {
                deskQuote.RushDays = 7;
            }
            else
            {
                MessageBox.Show("error with rush days baby");
            }

            try
            {
                // get quote amount
                var quote = deskQuote.CreateQuoteTotal(deskQuote);

                // add amount to quote
                deskQuote.QuoteAmount = quote;

                // add quote to file
                AddQuoteToFile(deskQuote);

                // show 'DisplayQuote' form
                DisplayQuote displayQuote = new DisplayQuote(deskQuote);
                displayQuote.Tag = this;
                displayQuote.Show(this);
                Hide();

            }
            catch (Exception err)
            {
                MessageBox.Show("There was an error creating the quote. {0}", err.Message);
            }

        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            //validate ints or strings
            if (!Int32.TryParse(textBox5.Text, out int result1))
            {
                MessageBox.Show("Width Must be a Number");
            }

            //validate width ranges
            if (Int32.TryParse(textBox5.Text, out int result3))
            {
                int width = int.Parse(textBox5.Text);

                if (width < 24 || width > 96)
                {
                    MessageBox.Show("Width must be between 24 and 96");
                }

            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (!Int32.TryParse(textBox4.Text, out int result2))
            {
                MessageBox.Show("Depth Must be a Number");
            }



            //validate for depth ranges
            if (Int32.TryParse(textBox4.Text, out int result4))
            {
                int depth = int.Parse(textBox4.Text);

                if (depth < 12 || depth > 48)
                {
                    MessageBox.Show("Depth must be between 12 and 48");
                }

            }
        }

        private void AddQuoteToFile(DeskQuote deskQuote)
        {
            var quotesFile = @"quotes.json";
            List<DeskQuote> deskQuotes = new List<DeskQuote>();

            // read existing quotes
            if (File.Exists(quotesFile))
            {
                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    // load existing quotes
                    string quotes = reader.ReadToEnd();

                    if (quotes.Length > 0)
                    {
                        // deserialize quotes
                        deskQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(quotes);
                    }

                    // add a new quote
                    deskQuotes.Add(deskQuote);
                }

                // save to file
                SaveQuotes(deskQuotes);
            }
            else
            {
                // create quote list
                deskQuotes = new List<DeskQuote> { deskQuote };

                // save to file
                SaveQuotes(deskQuotes);
            }
        }

        private void SaveQuotes(List<DeskQuote> quotes)
        {
            var quotesFile = @"quotes.json";

            // serilize quotes
            var serializedQuotes = JsonConvert.SerializeObject(quotes);

            // write quotes to file
            File.WriteAllText(quotesFile, serializedQuotes);
        }
    }
}
