﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notatnik
{
    public partial class Form1 : Form
    {
        string nazwaplik;
        public Form1()
        {
            nazwaplik = null;
            InitializeComponent();
            zawijanieCzcionkiToolStripMenuItem.Checked = true;
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Zmiany nie zostaną zapisane", "Uwaga!");
            if (result == DialogResult.OK)
            {
                richTextBox1.Text = "";
                nazwaplik = null;
            }
            else if (result == DialogResult.Abort) { }
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Na pewno chcesz otworzć inny plik? Zmiany zostaną nie zapisane", "Uwaga!", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                try
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.Text = "";
                        richTextBox1.LoadFile(openFileDialog1.FileName);
                        nazwaplik = openFileDialog1.FileName;
                    }
                }
                catch
                {
                    MessageBox.Show("Nie jest to poprawny plik ***.rtf");
                }
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nazwaplik == null)
            {
                zapiszjakoToolStripMenuItem_Click(sender, e);
            }
            else
            {

                richTextBox1.SaveFile(nazwaplik);
            }
        }

        private void zapiszjakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                nazwaplik = saveFileDialog1.FileName.ToString();
            }
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Czy chcesz zapisać?", "Zakończ", MessageBoxButtons.YesNoCancel);

            if (response == DialogResult.No)
                Application.Exit();
            if (response == DialogResult.Yes)
                zapiszjakoToolStripMenuItem_Click(sender, e);
            if (response == DialogResult.Cancel) { }
        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void czcionkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void zawijanieCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zawijanieCzcionkiToolStripMenuItem.Checked)
            {
                richTextBox1.WordWrap = true;
            }
            else
                richTextBox1.WordWrap = false;
        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-|| Made by JB ||-", "Pomoc");
        }
    }
}
