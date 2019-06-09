using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MIPSInterpreter
{
    public partial class MainForm : Form
    {
        string[] AssemblyProgram;
        StateList States = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Assembly.txt"))
            {
                Application.Exit();
            }
            else
            {
                AssemblyProgram = File.ReadAllLines("Assembly.txt");
                ProgramBox.DataSource = AssemblyProgram;
                States = new StateList(AssemblyProgram);
                DisplayState();
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (States == null) return;
            States.RunAll();
            DisplayState();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (States == null) return;
            States.Next();
            DisplayState();
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (States == null) return;
            States.Previous();
            DisplayState();
        }

        private void DisplayState()
        {
            if (States == null) return;
            regView.DataSource = States.CurrentState.registers.ToList();
            InstructionTextBox.Text = States.CurrentState.instrString;
            errorBox.Text = States.eMessage;
            ProgramBox.SelectedIndex = States.CurrentState.line;
        }
    }
}
