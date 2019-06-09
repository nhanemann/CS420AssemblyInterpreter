namespace MIPSInterpreter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadButton = new System.Windows.Forms.Button();
            this.regView = new System.Windows.Forms.DataGridView();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.ProgramBox = new System.Windows.Forms.ListBox();
            this.PrevButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.InstructionTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.regView)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(55, 0);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(136, 23);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load Assembly.txt";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // regView
            // 
            this.regView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.regView.Location = new System.Drawing.Point(456, 12);
            this.regView.Name = "regView";
            this.regView.Size = new System.Drawing.Size(281, 544);
            this.regView.TabIndex = 2;
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(255, 113);
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(195, 20);
            this.errorBox.TabIndex = 3;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(256, 97);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(78, 13);
            this.errorLabel.TabIndex = 4;
            this.errorLabel.Text = "Error Message:";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(12, 29);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 7;
            this.RunButton.Text = "Run All";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // ProgramBox
            // 
            this.ProgramBox.FormattingEnabled = true;
            this.ProgramBox.Location = new System.Drawing.Point(12, 58);
            this.ProgramBox.Name = "ProgramBox";
            this.ProgramBox.Size = new System.Drawing.Size(237, 498);
            this.ProgramBox.TabIndex = 8;
            // 
            // PrevButton
            // 
            this.PrevButton.Location = new System.Drawing.Point(93, 29);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.Size = new System.Drawing.Size(75, 23);
            this.PrevButton.TabIndex = 9;
            this.PrevButton.Text = "Previous";
            this.PrevButton.UseVisualStyleBackColor = true;
            this.PrevButton.Click += new System.EventHandler(this.PrevButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(174, 29);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 10;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Location = new System.Drawing.Point(256, 58);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(96, 13);
            this.InstructionLabel.TabIndex = 11;
            this.InstructionLabel.Text = "Current Instruction:";
            // 
            // InstructionTextBox
            // 
            this.InstructionTextBox.Location = new System.Drawing.Point(256, 74);
            this.InstructionTextBox.Name = "InstructionTextBox";
            this.InstructionTextBox.ReadOnly = true;
            this.InstructionTextBox.Size = new System.Drawing.Size(195, 20);
            this.InstructionTextBox.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 568);
            this.Controls.Add(this.InstructionTextBox);
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PrevButton);
            this.Controls.Add(this.ProgramBox);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.regView);
            this.Controls.Add(this.LoadButton);
            this.Name = "MainForm";
            this.Text = "Assembly Interpreter";
            ((System.ComponentModel.ISupportInitialize)(this.regView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.DataGridView regView;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.ListBox ProgramBox;
        private System.Windows.Forms.Button PrevButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.TextBox InstructionTextBox;
    }
}

