namespace SoldHelper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.TextBox percentBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNextRotation;
        private System.Windows.Forms.DateTimePicker checkStartDate;
        private System.Windows.Forms.DateTimePicker checkEndDate;
        private System.Windows.Forms.Button btnCheckPeriod;
        private System.Windows.Forms.CheckBox checkExtend30;
        private System.Windows.Forms.LinkLabel linkSupport;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private void InitializeComponent()
        {
            nameBox = new TextBox();
            urlBox = new TextBox();
            dateStart = new DateTimePicker();
            dateEnd = new DateTimePicker();
            percentBox = new TextBox();
            btnAdd = new Button();
            btnRemove = new Button();
            listBox = new ListBox();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            StartDate = new Label();
            label1 = new Label();
            label2 = new Label();
            btnUpdate = new Button();
            btnNextRotation = new Button();
            checkStartDate = new DateTimePicker();
            checkEndDate = new DateTimePicker();
            btnCheckPeriod = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            checkExtend30 = new CheckBox();
            linkSupport = new LinkLabel();
            btnCopyToClipboard = new Button();
            checkCustomEndDate = new CheckBox();
            label6 = new Label();
            label7 = new Label();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // nameBox
            // 
            nameBox.Location = new Point(20, 40);
            nameBox.Name = "nameBox";
            nameBox.PlaceholderText = "Nom du produit";
            nameBox.Size = new Size(300, 23);
            nameBox.TabIndex = 0;
            // 
            // urlBox
            // 
            urlBox.Location = new Point(326, 40);
            urlBox.Name = "urlBox";
            urlBox.PlaceholderText = "URL";
            urlBox.Size = new Size(585, 23);
            urlBox.TabIndex = 1;
            // 
            // dateStart
            // 
            dateStart.Format = DateTimePickerFormat.Short;
            dateStart.Location = new Point(89, 69);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(200, 23);
            dateStart.TabIndex = 2;
            // 
            // dateEnd
            // 
            dateEnd.Enabled = false;
            dateEnd.Format = DateTimePickerFormat.Short;
            dateEnd.Location = new Point(364, 69);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(200, 23);
            dateEnd.TabIndex = 3;
            // 
            // percentBox
            // 
            percentBox.Location = new Point(657, 69);
            percentBox.Name = "percentBox";
            percentBox.Size = new Size(100, 23);
            percentBox.TabIndex = 4;
            percentBox.Text = "50";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(657, 480);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(129, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add product";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(792, 480);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(129, 23);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Delete Product";
            btnRemove.Click += btnRemove_Click;
            // 
            // listBox
            // 
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.Font = new Font("Segoe UI", 9F);
            listBox.ItemHeight = 15;
            listBox.Location = new Point(20, 185);
            listBox.Name = "listBox";
            listBox.Size = new Size(901, 289);
            listBox.TabIndex = 7;
            listBox.DrawItem += listBox_DrawItem;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(933, 24);
            menuStrip.TabIndex = 8;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importToolStripMenuItem, exportToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(153, 22);
            importToolStripMenuItem.Text = "Import Sale file";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(153, 22);
            exportToolStripMenuItem.Text = "Export Sale file";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // StartDate
            // 
            StartDate.AutoSize = true;
            StartDate.Location = new Point(20, 74);
            StartDate.Name = "StartDate";
            StartDate.Size = new Size(63, 15);
            StartDate.TabIndex = 9;
            StartDate.Text = "Start date :";
            StartDate.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(299, 75);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 10;
            label1.Text = "End date :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(578, 72);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 11;
            label2.Text = "Discount % :";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(777, 98);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(129, 23);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Edit line";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnNextRotation
            // 
            btnNextRotation.Location = new Point(777, 67);
            btnNextRotation.Name = "btnNextRotation";
            btnNextRotation.Size = new Size(129, 25);
            btnNextRotation.TabIndex = 0;
            btnNextRotation.Text = "Next rotation";
            btnNextRotation.Click += btnNextRotation_Click;
            // 
            // checkStartDate
            // 
            checkStartDate.Format = DateTimePickerFormat.Short;
            checkStartDate.Location = new Point(89, 144);
            checkStartDate.Name = "checkStartDate";
            checkStartDate.Size = new Size(126, 23);
            checkStartDate.TabIndex = 0;
            // 
            // checkEndDate
            // 
            checkEndDate.Format = DateTimePickerFormat.Short;
            checkEndDate.Location = new Point(286, 142);
            checkEndDate.Name = "checkEndDate";
            checkEndDate.Size = new Size(126, 23);
            checkEndDate.TabIndex = 1;
            // 
            // btnCheckPeriod
            // 
            btnCheckPeriod.Location = new Point(777, 142);
            btnCheckPeriod.Name = "btnCheckPeriod";
            btnCheckPeriod.Size = new Size(129, 23);
            btnCheckPeriod.TabIndex = 2;
            btnCheckPeriod.Text = "Check Sale period";
            btnCheckPeriod.Click += btnCheckPeriod_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(221, 148);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 12;
            label3.Text = "End date :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 150);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 13;
            label4.Text = "Start date :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 126);
            label5.Name = "label5";
            label5.Size = new Size(198, 15);
            label5.TabIndex = 14;
            label5.Text = "Check period if a product is on sale :";
            label5.Click += label5_Click;
            // 
            // checkExtend30
            // 
            checkExtend30.AutoSize = true;
            checkExtend30.Location = new Point(434, 144);
            checkExtend30.Name = "checkExtend30";
            checkExtend30.Size = new Size(217, 19);
            checkExtend30.TabIndex = 0;
            checkExtend30.Text = "Add 30 day (for cooldown after sale)";
            checkExtend30.CheckedChanged += checkExtend30_CheckedChanged;
            // 
            // linkSupport
            // 
            linkSupport.Location = new Point(20, 483);
            linkSupport.Name = "linkSupport";
            linkSupport.Size = new Size(131, 20);
            linkSupport.TabIndex = 0;
            linkSupport.TabStop = true;
            linkSupport.Text = "Fab : Sale request link";
            linkSupport.LinkClicked += linkSupport_LinkClicked;
            // 
            // btnCopyToClipboard
            // 
            btnCopyToClipboard.Location = new Point(157, 480);
            btnCopyToClipboard.Name = "btnCopyToClipboard";
            btnCopyToClipboard.Size = new Size(147, 23);
            btnCopyToClipboard.TabIndex = 0;
            btnCopyToClipboard.Text = "Copy data to clipboard";
            btnCopyToClipboard.Click += btnCopyToClipboard_Click;
            // 
            // checkCustomEndDate
            // 
            checkCustomEndDate.Location = new Point(400, 97);
            checkCustomEndDate.Name = "checkCustomEndDate";
            checkCustomEndDate.Size = new Size(120, 20);
            checkCustomEndDate.TabIndex = 0;
            checkCustomEndDate.Text = "Custom end date";
            checkCustomEndDate.CheckedChanged += checkCustomEndDate_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 126);
            label6.Name = "label6";
            label6.Size = new Size(198, 15);
            label6.TabIndex = 14;
            label6.Text = "Check period if a product is on sale :";
            label6.Click += label5_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(402, 486);
            label7.Name = "label7";
            label7.Size = new Size(166, 15);
            label7.TabIndex = 15;
            label7.Text = "Created by Wildfox interactive";
            label7.Click += label7_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(933, 511);
            Controls.Add(label7);
            Controls.Add(checkCustomEndDate);
            Controls.Add(btnCopyToClipboard);
            Controls.Add(linkSupport);
            Controls.Add(checkExtend30);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(checkStartDate);
            Controls.Add(checkEndDate);
            Controls.Add(btnCheckPeriod);
            Controls.Add(btnNextRotation);
            Controls.Add(btnUpdate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(StartDate);
            Controls.Add(nameBox);
            Controls.Add(urlBox);
            Controls.Add(dateStart);
            Controls.Add(dateEnd);
            Controls.Add(percentBox);
            Controls.Add(btnAdd);
            Controls.Add(btnRemove);
            Controls.Add(listBox);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales Management Tool for FAB";
            Load += Form1_Load_1;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label StartDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
