namespace SinemaOtomasyon
{
    partial class frmYeniSifreOluştur
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
            this.txtyenisifre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsifretekrar = new System.Windows.Forms.TextBox();
            this.btnSifreyiOlustur = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtkullanciadi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Yeni Şifre ";
            // 
            // txtyenisifre
            // 
            this.txtyenisifre.Location = new System.Drawing.Point(177, 112);
            this.txtyenisifre.Name = "txtyenisifre";
            this.txtyenisifre.PasswordChar = '*';
            this.txtyenisifre.Size = new System.Drawing.Size(158, 20);
            this.txtyenisifre.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Şifreyi Tekrarla";
            // 
            // txtsifretekrar
            // 
            this.txtsifretekrar.Location = new System.Drawing.Point(177, 147);
            this.txtsifretekrar.Name = "txtsifretekrar";
            this.txtsifretekrar.PasswordChar = '*';
            this.txtsifretekrar.Size = new System.Drawing.Size(158, 20);
            this.txtsifretekrar.TabIndex = 8;
            // 
            // btnSifreyiOlustur
            // 
            this.btnSifreyiOlustur.Location = new System.Drawing.Point(264, 200);
            this.btnSifreyiOlustur.Name = "btnSifreyiOlustur";
            this.btnSifreyiOlustur.Size = new System.Drawing.Size(71, 39);
            this.btnSifreyiOlustur.TabIndex = 10;
            this.btnSifreyiOlustur.Text = "Şifreyi Oluştur";
            this.btnSifreyiOlustur.UseVisualStyleBackColor = true;
            this.btnSifreyiOlustur.Click += new System.EventHandler(this.btnSifreyiOlustur_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kullanıcı Adı";
            // 
            // txtkullanciadi
            // 
            this.txtkullanciadi.Location = new System.Drawing.Point(177, 77);
            this.txtkullanciadi.Name = "txtkullanciadi";
            this.txtkullanciadi.ReadOnly = true;
            this.txtkullanciadi.Size = new System.Drawing.Size(158, 20);
            this.txtkullanciadi.TabIndex = 11;
            this.txtkullanciadi.TextChanged += new System.EventHandler(this.txtkullanciadi_TextChanged);
            // 
            // frmYeniSifreOluştur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 299);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtkullanciadi);
            this.Controls.Add(this.btnSifreyiOlustur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsifretekrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtyenisifre);
            this.Name = "frmYeniSifreOluştur";
            this.Text = "frmYeniSifreOluştur";
            this.Load += new System.EventHandler(this.frmYeniSifreOluştur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtyenisifre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsifretekrar;
        private System.Windows.Forms.Button btnSifreyiOlustur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtkullanciadi;
    }
}