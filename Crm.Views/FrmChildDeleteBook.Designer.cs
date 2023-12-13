namespace Crm.Views
{
    partial class FrmChildDeleteBook
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
            cbBooks = new ComboBox();
            btnDelete = new Button();
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
            label1.Size = new Size(108, 19);
            label1.TabIndex = 1;
            label1.Text = "Role => DELETE";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbBooks);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 10F);
            groupBox2.Location = new Point(20, 58);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(419, 164);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "New book";
            // 
            // cbBooks
            // 
            cbBooks.FormattingEnabled = true;
            cbBooks.Location = new Point(45, 55);
            cbBooks.Name = "cbBooks";
            cbBooks.Size = new Size(333, 25);
            cbBooks.TabIndex = 9;
            cbBooks.SelectedIndexChanged += BookToDeleteOnSelected;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(238, 103);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 26);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(45, 37);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 0;
            label2.Text = "Books";
            // 
            // FrmChildDeleteBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F);
            Name = "FrmChildDeleteBook";
            StartPosition = FormStartPosition.Manual;
            Text = "Delete a book";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox2;
        private Button btnDelete;
        private Label label2;
        private ComboBox cbBooks;
    }
}