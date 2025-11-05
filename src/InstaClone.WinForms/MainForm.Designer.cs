namespace InstaClone.WinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.postsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.postsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // postsDataGridView
            // 
            this.postsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.postsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.postsDataGridView.Name = "postsDataGridView";
            this.postsDataGridView.RowTemplate.Height = 25;
            this.postsDataGridView.Size = new System.Drawing.Size(800, 450);
            this.postsDataGridView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.postsDataGridView);
            this.Name = "MainForm";
            this.Text = "InstaClone WinForms Feed";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.postsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView postsDataGridView;
    }
}
