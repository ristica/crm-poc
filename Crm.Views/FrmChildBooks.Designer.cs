namespace Crm.Views
{
    partial class FrmChildBooks
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
            groupBox1 = new GroupBox();
            lbBooks = new ListBox();
            groupBox2 = new GroupBox();
            txtYear = new TextBox();
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            txtIsbn = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Italic | FontStyle.Underline);
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(98, 19);
            label1.TabIndex = 0;
            label1.Text = "Role => READ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbBooks);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(20, 55);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(362, 236);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Books";
            // 
            // lbBooks
            // 
            lbBooks.Font = new Font("Segoe UI", 9F);
            lbBooks.FormattingEnabled = true;
            lbBooks.ItemHeight = 15;
            lbBooks.Location = new Point(28, 26);
            lbBooks.Name = "lbBooks";
            lbBooks.Size = new Size(306, 184);
            lbBooks.TabIndex = 0;
            lbBooks.SelectedIndexChanged += CurrentBookOnChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtYear);
            groupBox2.Controls.Add(txtAuthor);
            groupBox2.Controls.Add(txtTitle);
            groupBox2.Controls.Add(txtIsbn);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 10F);
            groupBox2.Location = new Point(414, 55);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(362, 236);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Details";
            // 
            // txtYear
            // 
            txtYear.Font = new Font("Segoe UI", 9F);
            txtYear.Location = new Point(20, 191);
            txtYear.Name = "txtYear";
            txtYear.ReadOnly = true;
            txtYear.Size = new Size(150, 23);
            txtYear.TabIndex = 7;
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 9F);
            txtAuthor.Location = new Point(20, 142);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.ReadOnly = true;
            txtAuthor.Size = new Size(325, 23);
            txtAuthor.TabIndex = 6;
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 9F);
            txtTitle.Location = new Point(20, 91);
            txtTitle.Name = "txtTitle";
            txtTitle.ReadOnly = true;
            txtTitle.Size = new Size(325, 23);
            txtTitle.TabIndex = 5;
            // 
            // txtIsbn
            // 
            txtIsbn.Font = new Font("Segoe UI", 9F);
            txtIsbn.Location = new Point(18, 40);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.ReadOnly = true;
            txtIsbn.Size = new Size(150, 23);
            txtIsbn.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(17, 173);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 3;
            label5.Text = "Year";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(17, 124);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 2;
            label4.Text = "Author";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(17, 73);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 1;
            label3.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(17, 23);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 0;
            label2.Text = "ISBN";
            // 
            // FrmChildBooks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 386);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "FrmChildBooks";
            StartPosition = FormStartPosition.Manual;
            Text = "Books";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListBox lbBooks;
        private TextBox txtYear;
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private TextBox txtIsbn;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}