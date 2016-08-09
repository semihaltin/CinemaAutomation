namespace SinemaOtomasyon
{
    partial class SifreUnuttum
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
            this.btnsifreolus = new System.Windows.Forms.Button();
            this.txtkullaniciadi1 = new System.Windows.Forms.TextBox();
            this.txtcevap = new System.Windows.Forms.TextBox();
            this.cbguvenliksorulari = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnsifreolus
            // 
            this.btnsifreolus.Location = new System.Drawing.Point(251, 221);
            this.btnsifreolus.Name = "btnsifreolus";
            this.btnsifreolus.Size = new System.Drawing.Size(75, 23);
            this.btnsifreolus.TabIndex = 0;
            this.btnsifreolus.Text = "Şifre Oluştur";
            this.btnsifreolus.UseVisualStyleBackColor = true;
            this.btnsifreolus.Click += new System.EventHandler(this.btnsifreolus_Click);
            // 
            // txtkullaniciadi1
            // 
            this.txtkullaniciadi1.Location = new System.Drawing.Point(202, 51);
            this.txtkullaniciadi1.Name = "txtkullaniciadi1";
            this.txtkullaniciadi1.Size = new System.Drawing.Size(158, 20);
            this.txtkullaniciadi1.TabIndex = 1;
            // 
            // txtcevap
            // 
            this.txtcevap.Location = new System.Drawing.Point(202, 150);
            this.txtcevap.Name = "txtcevap";
            this.txtcevap.Size = new System.Drawing.Size(158, 20);
            this.txtcevap.TabIndex = 3;
            // 
            // cbguvenliksorulari
            // 
            this.cbguvenliksorulari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbguvenliksorulari.FormattingEnabled = true;
            this.cbguvenliksorulari.Items.AddRange(new object[] {
            "İlk Okul Öğretmeninizin Adı",
            "Annenizin Kızlık Soyadı",
            "En Sevdiğiniz Renk"});
            this.cbguvenliksorulari.Location = new System.Drawing.Point(202, 102);
            this.cbguvenliksorulari.Name = "cbguvenliksorulari";
            this.cbguvenliksorulari.Size = new System.Drawing.Size(158, 21);
            this.cbguvenliksorulari.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Güvenlik Soru Cevabı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Güvenlik Sorusu";
            // 
            // SifreUnuttum
            // 
            this.ClientSize = new System.Drawing.Size(508, 343);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbguvenliksorulari);
            this.Controls.Add(this.txtcevap);
            this.Controls.Add(this.txtkullaniciadi1);
            this.Controls.Add(this.btnsifreolus);
            this.Name = "SifreUnuttum";
            this.Load += new System.EventHandler(this.SifreUnuttum_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSifreOlustur;
        private System.Windows.Forms.TextBox txtkullanici;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnsifreolus;
        private System.Windows.Forms.TextBox txtcevap;
        private System.Windows.Forms.ComboBox cbguvenliksorulari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtkullaniciadi1;
    }
}