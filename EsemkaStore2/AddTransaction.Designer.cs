namespace EsemkaStore2
{
    partial class AddTransaction
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
            this.components = new System.ComponentModel.Container();
            this.dgv_Produck = new System.Windows.Forms.DataGridView();
            this.dgv_TransactionDetail = new System.Windows.Forms.DataGridView();
            this.btb_Back = new System.Windows.Forms.Button();
            this.lbl_DateTime = new System.Windows.Forms.Label();
            this.Product = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Harga = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.btn_MinProduck = new System.Windows.Forms.Button();
            this.btn_PlusProduct = new System.Windows.Forms.Button();
            this.btn_AddtoCart = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_MinCart = new System.Windows.Forms.Button();
            this.btn_PlusCart = new System.Windows.Forms.Button();
            this.txt_ValueProduck = new System.Windows.Forms.TextBox();
            this.txt_ValueCart = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Produck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TransactionDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Produck
            // 
            this.dgv_Produck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Produck.Location = new System.Drawing.Point(12, 82);
            this.dgv_Produck.Name = "dgv_Produck";
            this.dgv_Produck.Size = new System.Drawing.Size(400, 150);
            this.dgv_Produck.TabIndex = 0;
            this.dgv_Produck.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Produck_CellClick);
            // 
            // dgv_TransactionDetail
            // 
            this.dgv_TransactionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TransactionDetail.Location = new System.Drawing.Point(443, 82);
            this.dgv_TransactionDetail.Name = "dgv_TransactionDetail";
            this.dgv_TransactionDetail.Size = new System.Drawing.Size(400, 150);
            this.dgv_TransactionDetail.TabIndex = 1;
            this.dgv_TransactionDetail.DataSourceChanged += new System.EventHandler(this.dgv_TransactionDetail_DataSourceChanged);
            this.dgv_TransactionDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TransactionDetail_CellClick);
            // 
            // btb_Back
            // 
            this.btb_Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.btb_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btb_Back.ForeColor = System.Drawing.Color.White;
            this.btb_Back.Location = new System.Drawing.Point(12, 12);
            this.btb_Back.Name = "btb_Back";
            this.btb_Back.Size = new System.Drawing.Size(75, 26);
            this.btb_Back.TabIndex = 2;
            this.btb_Back.Text = "Back";
            this.btb_Back.UseVisualStyleBackColor = false;
            this.btb_Back.Click += new System.EventHandler(this.btb_Back_Click);
            // 
            // lbl_DateTime
            // 
            this.lbl_DateTime.AutoSize = true;
            this.lbl_DateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DateTime.Location = new System.Drawing.Point(606, 17);
            this.lbl_DateTime.Name = "lbl_DateTime";
            this.lbl_DateTime.Size = new System.Drawing.Size(88, 15);
            this.lbl_DateTime.TabIndex = 3;
            this.lbl_DateTime.Text = "Date and Time";
            this.lbl_DateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Product
            // 
            this.Product.AutoSize = true;
            this.Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Product.Location = new System.Drawing.Point(12, 57);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(49, 15);
            this.Product.TabIndex = 4;
            this.Product.Text = "Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(213, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(440, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cart";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(645, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Total :";
            // 
            // lbl_Harga
            // 
            this.lbl_Harga.AutoSize = true;
            this.lbl_Harga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Harga.Location = new System.Drawing.Point(717, 282);
            this.lbl_Harga.Name = "lbl_Harga";
            this.lbl_Harga.Size = new System.Drawing.Size(14, 15);
            this.lbl_Harga.TabIndex = 8;
            this.lbl_Harga.Text = "0";
            this.lbl_Harga.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(265, 56);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(147, 20);
            this.txt_Search.TabIndex = 9;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // btn_MinProduck
            // 
            this.btn_MinProduck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.btn_MinProduck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MinProduck.ForeColor = System.Drawing.Color.White;
            this.btn_MinProduck.Location = new System.Drawing.Point(12, 238);
            this.btn_MinProduck.Name = "btn_MinProduck";
            this.btn_MinProduck.Size = new System.Drawing.Size(25, 25);
            this.btn_MinProduck.TabIndex = 10;
            this.btn_MinProduck.Text = "-";
            this.btn_MinProduck.UseVisualStyleBackColor = false;
            this.btn_MinProduck.Click += new System.EventHandler(this.btn_MinProduck_Click);
            // 
            // btn_PlusProduct
            // 
            this.btn_PlusProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.btn_PlusProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlusProduct.ForeColor = System.Drawing.Color.White;
            this.btn_PlusProduct.Location = new System.Drawing.Point(110, 238);
            this.btn_PlusProduct.Name = "btn_PlusProduct";
            this.btn_PlusProduct.Size = new System.Drawing.Size(25, 25);
            this.btn_PlusProduct.TabIndex = 11;
            this.btn_PlusProduct.Text = "+";
            this.btn_PlusProduct.UseVisualStyleBackColor = false;
            this.btn_PlusProduct.Click += new System.EventHandler(this.btn_PlusProduct_Click);
            // 
            // btn_AddtoCart
            // 
            this.btn_AddtoCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.btn_AddtoCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddtoCart.ForeColor = System.Drawing.Color.White;
            this.btn_AddtoCart.Location = new System.Drawing.Point(337, 238);
            this.btn_AddtoCart.Name = "btn_AddtoCart";
            this.btn_AddtoCart.Size = new System.Drawing.Size(75, 26);
            this.btn_AddtoCart.TabIndex = 12;
            this.btn_AddtoCart.Text = "Add to Cart";
            this.btn_AddtoCart.UseVisualStyleBackColor = false;
            this.btn_AddtoCart.Click += new System.EventHandler(this.btn_AddtoCart_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.btn_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Remove.ForeColor = System.Drawing.Color.White;
            this.btn_Remove.Location = new System.Drawing.Point(443, 239);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(75, 26);
            this.btn_Remove.TabIndex = 13;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = false;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_MinCart
            // 
            this.btn_MinCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.btn_MinCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MinCart.ForeColor = System.Drawing.Color.White;
            this.btn_MinCart.Location = new System.Drawing.Point(720, 238);
            this.btn_MinCart.Name = "btn_MinCart";
            this.btn_MinCart.Size = new System.Drawing.Size(25, 25);
            this.btn_MinCart.TabIndex = 14;
            this.btn_MinCart.Text = "-";
            this.btn_MinCart.UseVisualStyleBackColor = false;
            this.btn_MinCart.Click += new System.EventHandler(this.btn_MinCart_Click);
            // 
            // btn_PlusCart
            // 
            this.btn_PlusCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.btn_PlusCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlusCart.ForeColor = System.Drawing.Color.White;
            this.btn_PlusCart.Location = new System.Drawing.Point(818, 238);
            this.btn_PlusCart.Name = "btn_PlusCart";
            this.btn_PlusCart.Size = new System.Drawing.Size(25, 25);
            this.btn_PlusCart.TabIndex = 15;
            this.btn_PlusCart.Text = "+";
            this.btn_PlusCart.UseVisualStyleBackColor = false;
            this.btn_PlusCart.Click += new System.EventHandler(this.btn_PlusCart_Click);
            // 
            // txt_ValueProduck
            // 
            this.txt_ValueProduck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValueProduck.Location = new System.Drawing.Point(43, 241);
            this.txt_ValueProduck.Name = "txt_ValueProduck";
            this.txt_ValueProduck.Size = new System.Drawing.Size(61, 20);
            this.txt_ValueProduck.TabIndex = 16;
            this.txt_ValueProduck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ValueCart
            // 
            this.txt_ValueCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValueCart.Location = new System.Drawing.Point(751, 240);
            this.txt_ValueCart.Name = "txt_ValueCart";
            this.txt_ValueCart.Size = new System.Drawing.Size(61, 20);
            this.txt_ValueCart.TabIndex = 17;
            this.txt_ValueCart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(768, 324);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 26);
            this.btn_Save.TabIndex = 18;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(691, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Rp";
            // 
            // AddTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(855, 359);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_ValueCart);
            this.Controls.Add(this.txt_ValueProduck);
            this.Controls.Add(this.btn_PlusCart);
            this.Controls.Add(this.btn_MinCart);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_AddtoCart);
            this.Controls.Add(this.btn_PlusProduct);
            this.Controls.Add(this.btn_MinProduck);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.lbl_Harga);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Product);
            this.Controls.Add(this.lbl_DateTime);
            this.Controls.Add(this.btb_Back);
            this.Controls.Add(this.dgv_TransactionDetail);
            this.Controls.Add(this.dgv_Produck);
            this.Name = "AddTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EsemkaStore";
            this.Load += new System.EventHandler(this.AddTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Produck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TransactionDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Produck;
        private System.Windows.Forms.DataGridView dgv_TransactionDetail;
        private System.Windows.Forms.Button btb_Back;
        private System.Windows.Forms.Label lbl_DateTime;
        private System.Windows.Forms.Label Product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Harga;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button btn_MinProduck;
        private System.Windows.Forms.Button btn_PlusProduct;
        private System.Windows.Forms.Button btn_AddtoCart;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_MinCart;
        private System.Windows.Forms.Button btn_PlusCart;
        private System.Windows.Forms.TextBox txt_ValueProduck;
        private System.Windows.Forms.TextBox txt_ValueCart;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}