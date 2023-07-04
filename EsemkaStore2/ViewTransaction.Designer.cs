namespace EsemkaStore2
{
    partial class ViewTransaction
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
            this.dgv_Users = new System.Windows.Forms.DataGridView();
            this.dgv_ProductTransactionDetail = new System.Windows.Forms.DataGridView();
            this.btb_Back = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Users)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProductTransactionDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Users
            // 
            this.dgv_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Users.Location = new System.Drawing.Point(12, 44);
            this.dgv_Users.Name = "dgv_Users";
            this.dgv_Users.Size = new System.Drawing.Size(622, 150);
            this.dgv_Users.TabIndex = 0;
            this.dgv_Users.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Users_CellClick);
            // 
            // dgv_ProductTransactionDetail
            // 
            this.dgv_ProductTransactionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProductTransactionDetail.Location = new System.Drawing.Point(12, 229);
            this.dgv_ProductTransactionDetail.Name = "dgv_ProductTransactionDetail";
            this.dgv_ProductTransactionDetail.Size = new System.Drawing.Size(622, 150);
            this.dgv_ProductTransactionDetail.TabIndex = 1;
            // 
            // btb_Back
            // 
            this.btb_Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.btb_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btb_Back.ForeColor = System.Drawing.Color.White;
            this.btb_Back.Location = new System.Drawing.Point(12, 12);
            this.btb_Back.Name = "btb_Back";
            this.btb_Back.Size = new System.Drawing.Size(75, 26);
            this.btb_Back.TabIndex = 3;
            this.btb_Back.Text = "Back";
            this.btb_Back.UseVisualStyleBackColor = false;
            this.btb_Back.Click += new System.EventHandler(this.btb_Back_Click);
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(487, 18);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(147, 20);
            this.txt_Search.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(435, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search";
            // 
            // ViewTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(646, 391);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btb_Back);
            this.Controls.Add(this.dgv_ProductTransactionDetail);
            this.Controls.Add(this.dgv_Users);
            this.Name = "ViewTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EsemkaStore";
            this.Load += new System.EventHandler(this.ViewTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Users)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProductTransactionDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Users;
        private System.Windows.Forms.DataGridView dgv_ProductTransactionDetail;
        private System.Windows.Forms.Button btb_Back;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label3;
    }
}