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

namespace SimpleTextEditor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
             if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                //ładowanie tekstu do rich text box
                LoadToEditor(openFileDialog.FileName);
            }
        }

        private String currentFile = null;

        private void LoadToEditor(string fileName)
        {
            try
            {
                String s = File.ReadAllText(fileName);
                richTextBox.Text = s;
                mnuSave.Enabled = true;
                mnuSaveAs.Enabled = true;
                tsFileName.Text = fileName;
                currentFile = fileName;
            } catch (IOException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            SaveToFile(currentFile);
        }

        private void SaveToFile(string currentFile)
        {
            try
            {
                File.WriteAllText(currentFile, richTextBox.Text);
                MessageBox.Show($"Zapisano do pliku {currentFile}", "Informacja", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            } catch (IOException exc)
            {
                MessageBox.Show(exc.Message, "Błąd", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                //zapisz jako...
                String newFile = saveFileDialog.FileName;
                SaveToFile(newFile);
                tsFileName.Text = newFile;
                currentFile = newFile;
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
