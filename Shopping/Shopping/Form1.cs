using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                if(textBox1.Text.Length >0)
                {
                    if (listBox1.Items.Contains(textBox1.Text))
                    {
                       DialogResult result = MessageBox.Show("You already added this item, wanna add again?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            return;
                        }

                    }

                    listBox1.Items.Add(textBox1.Text);
                    UpdateProgress();
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Missing Text!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Shopping is full!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i != -1)
            {
                listBox1.Items.RemoveAt(i);
                UpdateProgress();
            }
            else
            {
                MessageBox.Show("Choose item corretly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            UpdateProgress();

        }

        private void UpdateProgress()
        {
            int i = listBox1.Items.Count;
            progressBar1.Value = i * 10;
        }

    }
}
