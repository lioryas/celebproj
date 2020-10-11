namespace CelebsFormUI
{
    partial class CelebsForm
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
            System.Windows.Forms.ColumnHeader Gender;
            this.listViewCelebs = new System.Windows.Forms.ListView();
            this.FullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BirthDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonResetList = new System.Windows.Forms.Button();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCelebCount = new System.Windows.Forms.Label();
            Gender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Gender
            // 
            Gender.Text = "Gender";
            Gender.Width = 206;
            // 
            // listViewCelebs
            // 
            this.listViewCelebs.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listViewCelebs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FullName,
            this.BirthDate,
            Gender,
            this.Title});
            this.listViewCelebs.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewCelebs.HideSelection = false;
            this.listViewCelebs.Location = new System.Drawing.Point(10, 83);
            this.listViewCelebs.Margin = new System.Windows.Forms.Padding(1);
            this.listViewCelebs.Name = "listViewCelebs";
            this.listViewCelebs.Size = new System.Drawing.Size(974, 691);
            this.listViewCelebs.TabIndex = 0;
            this.listViewCelebs.UseCompatibleStateImageBehavior = false;
            this.listViewCelebs.View = System.Windows.Forms.View.Details;
            // 
            // FullName
            // 
            this.FullName.Text = "Celeb Name";
            this.FullName.Width = 301;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 195;
            // 
            // BirthDate
            // 
            this.BirthDate.Text = "Birth Date";
            this.BirthDate.Width = 219;
            // 
            // buttonResetList
            // 
            this.buttonResetList.BackColor = System.Drawing.Color.LightGreen;
            this.buttonResetList.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetList.Location = new System.Drawing.Point(458, 26);
            this.buttonResetList.Margin = new System.Windows.Forms.Padding(1);
            this.buttonResetList.Name = "buttonResetList";
            this.buttonResetList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonResetList.Size = new System.Drawing.Size(129, 44);
            this.buttonResetList.TabIndex = 1;
            this.buttonResetList.Text = "Reset List";
            this.buttonResetList.UseVisualStyleBackColor = false;
            this.buttonResetList.Click += new System.EventHandler(this.ResetCelebsList);
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.BackColor = System.Drawing.Color.Red;
            this.buttonRemoveItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveItem.Location = new System.Drawing.Point(277, 26);
            this.buttonRemoveItem.Margin = new System.Windows.Forms.Padding(1);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(129, 44);
            this.buttonRemoveItem.TabIndex = 2;
            this.buttonRemoveItem.Text = "Remove Celebs";
            this.buttonRemoveItem.UseVisualStyleBackColor = false;
            this.buttonRemoveItem.Click += new System.EventHandler(this.RemoveCelebs);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(619, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number Of Celebs:";
            // 
            // lblCelebCount
            // 
            this.lblCelebCount.AutoSize = true;
            this.lblCelebCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelebCount.Location = new System.Drawing.Point(777, 39);
            this.lblCelebCount.Name = "lblCelebCount";
            this.lblCelebCount.Size = new System.Drawing.Size(0, 18);
            this.lblCelebCount.TabIndex = 4;
            // 
            // CelebsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 784);
            this.Controls.Add(this.lblCelebCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRemoveItem);
            this.Controls.Add(this.buttonResetList);
            this.Controls.Add(this.listViewCelebs);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CelebsForm";
            this.Text = "Celebs Data List";
            this.Load += new System.EventHandler(this.CelebsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewCelebs;
        private System.Windows.Forms.ColumnHeader FullName;
        private System.Windows.Forms.ColumnHeader BirthDate;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.Button buttonResetList;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCelebCount;
    }
}

