namespace Crm.Views
{
    partial class FrmChildAddBook
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
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnSave = new Button();
            txtYear = new TextBox();
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            txtIsbn = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Italic | FontStyle.Underline);
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(103, 19);
            label1.TabIndex = 1;
            label1.Text = "Role => WRITE";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSave);
            groupBox2.Controls.Add(txtYear);
            groupBox2.Controls.Add(txtAuthor);
            groupBox2.Controls.Add(txtTitle);
            groupBox2.Controls.Add(txtIsbn);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 10F);
            groupBox2.Location = new Point(20, 55);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(419, 334);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "New book";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(233, 264);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 26);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtYear
            // 
            txtYear.Font = new Font("Segoe UI", 9F);
            txtYear.Location = new Point(48, 205);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(150, 23);
            txtYear.TabIndex = 7;
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 9F);
            txtAuthor.Location = new Point(48, 156);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(325, 23);
            txtAuthor.TabIndex = 6;
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 9F);
            txtTitle.Location = new Point(48, 105);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(325, 23);
            txtTitle.TabIndex = 5;
            // 
            // txtIsbn
            // 
            txtIsbn.Font = new Font("Segoe UI", 9F);
            txtIsbn.Location = new Point(46, 54);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(150, 23);
            txtIsbn.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(45, 187);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 3;
            label5.Text = "Year";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(45, 138);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 2;
            label4.Text = "Author";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(45, 87);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 1;
            label3.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(45, 37);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 0;
            label2.Text = "ISBN";
            // 
            // FrmChildAddBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Name = "FrmChildAddBook";
            StartPosition = FormStartPosition.Manual;
            Text = "Add a new book";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox2;
        private TextBox txtYear;
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private TextBox txtIsbn;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnSave;
    }
}