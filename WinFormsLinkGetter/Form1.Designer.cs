namespace WinFormsLinkGetter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelURL = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.webBrowserPage = new System.Windows.Forms.WebBrowser();
            this.buttonLoadURL = new System.Windows.Forms.Button();
            this.buttonFindLinks = new System.Windows.Forms.Button();
            this.checkedListBoxLinks = new System.Windows.Forms.CheckedListBox();
            this.labelLinkCount = new System.Windows.Forms.Label();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonDeselectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(599, 696);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(148, 56);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Location = new System.Drawing.Point(16, 9);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(737, 120);
            this.labelInstructions.TabIndex = 0;
            this.labelInstructions.Text = resources.GetString("labelInstructions.Text");
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(117, 142);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(0, 20);
            this.labelPage.TabIndex = 0;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(20, 696);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(148, 56);
            this.buttonExport.TabIndex = 10;
            this.buttonExport.Text = "&Export links";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(16, 159);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(46, 20);
            this.labelURL.TabIndex = 1;
            this.labelURL.Text = "&URL:";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(68, 156);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(659, 26);
            this.textBoxURL.TabIndex = 2;
            // 
            // webBrowserPage
            // 
            this.webBrowserPage.Location = new System.Drawing.Point(20, 270);
            this.webBrowserPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPage.Name = "webBrowserPage";
            this.webBrowserPage.ScriptErrorsSuppressed = true;
            this.webBrowserPage.Size = new System.Drawing.Size(727, 135);
            this.webBrowserPage.TabIndex = 4;
            // 
            // buttonLoadURL
            // 
            this.buttonLoadURL.Location = new System.Drawing.Point(20, 197);
            this.buttonLoadURL.Name = "buttonLoadURL";
            this.buttonLoadURL.Size = new System.Drawing.Size(148, 56);
            this.buttonLoadURL.TabIndex = 3;
            this.buttonLoadURL.Text = "&Load URL";
            this.buttonLoadURL.UseVisualStyleBackColor = true;
            this.buttonLoadURL.Click += new System.EventHandler(this.buttonLoadURL_Click);
            // 
            // buttonFindLinks
            // 
            this.buttonFindLinks.Location = new System.Drawing.Point(20, 426);
            this.buttonFindLinks.Name = "buttonFindLinks";
            this.buttonFindLinks.Size = new System.Drawing.Size(148, 56);
            this.buttonFindLinks.TabIndex = 5;
            this.buttonFindLinks.Text = "&Find links";
            this.buttonFindLinks.UseVisualStyleBackColor = true;
            this.buttonFindLinks.Click += new System.EventHandler(this.buttonFindLinks_Click);
            // 
            // checkedListBoxLinks
            // 
            this.checkedListBoxLinks.FormattingEnabled = true;
            this.checkedListBoxLinks.Location = new System.Drawing.Point(20, 501);
            this.checkedListBoxLinks.Name = "checkedListBoxLinks";
            this.checkedListBoxLinks.Size = new System.Drawing.Size(733, 119);
            this.checkedListBoxLinks.TabIndex = 7;
            // 
            // labelLinkCount
            // 
            this.labelLinkCount.AutoSize = true;
            this.labelLinkCount.Location = new System.Drawing.Point(187, 445);
            this.labelLinkCount.Name = "labelLinkCount";
            this.labelLinkCount.Size = new System.Drawing.Size(0, 20);
            this.labelLinkCount.TabIndex = 6;
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(20, 639);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(148, 41);
            this.buttonSelectAll.TabIndex = 8;
            this.buttonSelectAll.Text = "&Select all";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonDeselectAll
            // 
            this.buttonDeselectAll.Location = new System.Drawing.Point(174, 639);
            this.buttonDeselectAll.Name = "buttonDeselectAll";
            this.buttonDeselectAll.Size = new System.Drawing.Size(148, 41);
            this.buttonDeselectAll.TabIndex = 9;
            this.buttonDeselectAll.Text = "&Deselect all";
            this.buttonDeselectAll.UseVisualStyleBackColor = true;
            this.buttonDeselectAll.Click += new System.EventHandler(this.buttonDeselectAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 771);
            this.Controls.Add(this.labelInstructions);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.buttonLoadURL);
            this.Controls.Add(this.webBrowserPage);
            this.Controls.Add(this.buttonFindLinks);
            this.Controls.Add(this.labelLinkCount);
            this.Controls.Add(this.checkedListBoxLinks);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.buttonDeselectAll);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Link Getter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.WebBrowser webBrowserPage;
        private System.Windows.Forms.Button buttonLoadURL;
        private System.Windows.Forms.Button buttonFindLinks;
        private System.Windows.Forms.CheckedListBox checkedListBoxLinks;
        private System.Windows.Forms.Label labelLinkCount;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonDeselectAll;
    }
}

