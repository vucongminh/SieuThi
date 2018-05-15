namespace BanHangSieuTHi
{
    partial class frmCheckOut
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhaiTra = new System.Windows.Forms.TextBox();
            this.txtDaTra = new System.Windows.Forms.TextBox();
            this.txtSoDu = new System.Windows.Forms.TextBox();
            this.btnTT = new System.Windows.Forms.Button();
            this.btnTT_In = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(120, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "THANH TOÁN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(20, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số tiền phải trả:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(20, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số dư:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(20, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số tiền đã trả:";
            // 
            // txtPhaiTra
            // 
            this.txtPhaiTra.BackColor = System.Drawing.Color.Cyan;
            this.txtPhaiTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhaiTra.Location = new System.Drawing.Point(142, 66);
            this.txtPhaiTra.Name = "txtPhaiTra";
            this.txtPhaiTra.ReadOnly = true;
            this.txtPhaiTra.Size = new System.Drawing.Size(219, 29);
            this.txtPhaiTra.TabIndex = 4;
            this.txtPhaiTra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDaTra
            // 
            this.txtDaTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDaTra.Location = new System.Drawing.Point(142, 101);
            this.txtDaTra.Name = "txtDaTra";
            this.txtDaTra.Size = new System.Drawing.Size(219, 29);
            this.txtDaTra.TabIndex = 5;
            this.txtDaTra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSoDu
            // 
            this.txtSoDu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSoDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDu.Location = new System.Drawing.Point(142, 136);
            this.txtSoDu.Name = "txtSoDu";
            this.txtSoDu.ReadOnly = true;
            this.txtSoDu.Size = new System.Drawing.Size(219, 29);
            this.txtSoDu.TabIndex = 6;
            this.txtSoDu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnTT
            // 
            this.btnTT.Location = new System.Drawing.Point(124, 203);
            this.btnTT.Name = "btnTT";
            this.btnTT.Size = new System.Drawing.Size(75, 43);
            this.btnTT.TabIndex = 7;
            this.btnTT.Text = "Thanh toán";
            this.btnTT.UseVisualStyleBackColor = true;
            this.btnTT.Click += new System.EventHandler(this.btnTT_Click);
            // 
            // btnTT_In
            // 
            this.btnTT_In.Location = new System.Drawing.Point(205, 203);
            this.btnTT_In.Name = "btnTT_In";
            this.btnTT_In.Size = new System.Drawing.Size(75, 43);
            this.btnTT_In.TabIndex = 8;
            this.btnTT_In.Text = "Thanh toán và In";
            this.btnTT_In.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(286, 203);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 43);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(139, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "(!) Lưu ý : Nhấn \"Enter\" để xem số tiền dư .\r\n";
            // 
            // frmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 250);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnTT_In);
            this.Controls.Add(this.btnTT);
            this.Controls.Add(this.txtSoDu);
            this.Controls.Add(this.txtDaTra);
            this.Controls.Add(this.txtPhaiTra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCheckOut";
            this.Text = "Thanh Toán";
            this.Load += new System.EventHandler(this.frmCheckOut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhaiTra;
        private System.Windows.Forms.TextBox txtDaTra;
        private System.Windows.Forms.TextBox txtSoDu;
        private System.Windows.Forms.Button btnTT;
        private System.Windows.Forms.Button btnTT_In;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label5;
    }
}