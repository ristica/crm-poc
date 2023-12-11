namespace Crm.Views
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            panel1 = new Panel();
            lblCurrentRole = new Label();
            label1 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            menuRole_No = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuRole_Read = new ToolStripMenuItem();
            menuRole_ReadWrite = new ToolStripMenuItem();
            menuRole_ReadWriteDelete = new ToolStripMenuItem();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            menuForms_Read = new ToolStripMenuItem();
            menuForms_ReadWrite = new ToolStripMenuItem();
            menuForms_ReadWriteDelete = new ToolStripMenuItem();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblCurrentRole);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 329);
            panel1.Name = "panel1";
            panel1.Size = new Size(818, 23);
            panel1.TabIndex = 2;
            // 
            // lblCurrentRole
            // 
            lblCurrentRole.AutoSize = true;
            lblCurrentRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCurrentRole.Location = new Point(97, 3);
            lblCurrentRole.Name = "lblCurrentRole";
            lblCurrentRole.Size = new Size(0, 15);
            lblCurrentRole.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            label1.Location = new Point(13, 3);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 5, 0);
            label1.Size = new Size(78, 15);
            label1.TabIndex = 0;
            label1.Text = "Current role:";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripDropDownButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(818, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { menuRole_No, toolStripSeparator1, menuRole_Read, menuRole_ReadWrite, menuRole_ReadWriteDelete });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(43, 22);
            toolStripDropDownButton1.Text = "Role";
            // 
            // menuRole_No
            // 
            menuRole_No.Name = "menuRole_No";
            menuRole_No.Size = new Size(183, 22);
            menuRole_No.Text = "No Role";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(180, 6);
            // 
            // menuRole_Read
            // 
            menuRole_Read.Name = "menuRole_Read";
            menuRole_Read.Size = new Size(183, 22);
            menuRole_Read.Text = "Read";
            // 
            // menuRole_ReadWrite
            // 
            menuRole_ReadWrite.Name = "menuRole_ReadWrite";
            menuRole_ReadWrite.Size = new Size(183, 22);
            menuRole_ReadWrite.Text = "Read / Write";
            // 
            // menuRole_ReadWriteDelete
            // 
            menuRole_ReadWriteDelete.Name = "menuRole_ReadWriteDelete";
            menuRole_ReadWriteDelete.Size = new Size(183, 22);
            menuRole_ReadWriteDelete.Text = "Read / Write / Delete";
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { menuForms_Read, menuForms_ReadWrite, menuForms_ReadWriteDelete });
            toolStripDropDownButton2.Image = (Image)resources.GetObject("toolStripDropDownButton2.Image");
            toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(53, 22);
            toolStripDropDownButton2.Text = "Forms";
            // 
            // menuForms_Read
            // 
            menuForms_Read.Name = "menuForms_Read";
            menuForms_Read.Size = new Size(193, 22);
            menuForms_Read.Text = "Books (R)";
            // 
            // menuForms_ReadWrite
            // 
            menuForms_ReadWrite.Name = "menuForms_ReadWrite";
            menuForms_ReadWrite.Size = new Size(193, 22);
            menuForms_ReadWrite.Text = "Add new book (R/W)";
            // 
            // menuForms_ReadWriteDelete
            // 
            menuForms_ReadWriteDelete.Name = "menuForms_ReadWriteDelete";
            menuForms_ReadWriteDelete.Size = new Size(193, 22);
            menuForms_ReadWriteDelete.Text = "Delete a book (R/W/D)";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 352);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            IsMdiContainer = true;
            Name = "FrmMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MVVM";
            FormClosing += FrmMainOnClosing;
            Load += FrmMainOnLoad;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private Label lblCurrentRole;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem menuRole_No;
        private ToolStripMenuItem menuRole_Read;
        private ToolStripMenuItem menuRole_ReadWrite;
        private ToolStripMenuItem menuRole_ReadWriteDelete;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem menuForms_Read;
        private ToolStripMenuItem menuForms_ReadWrite;
        private ToolStripMenuItem menuForms_ReadWriteDelete;
        private ToolStripSeparator toolStripSeparator1;
    }
}