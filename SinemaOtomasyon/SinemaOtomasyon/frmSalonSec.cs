using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SinemaOtomasyon.model;
using System.Data.SqlClient;
using SinemaOtomasyon.Class;

namespace SinemaOtomasyon
{
    public partial class frmSalonSec : Form
    {
        public frmSalonSec()
        {
            InitializeComponent();
        }
        Kampanya k = new Kampanya();
        private void frmSalonSec_Load(object sender, EventArgs e)
        {
            
            tslKullaniciAdi.Text = Genel.kullaniciadi2;
            k.KampanyaGetir(cbKampanyalar);
            Salonsec sa = new Salonsec();
           
            DinamikButonOlusturma();
            cbKampanyalar.SelectedIndex = 0;
         
            if (sa.KoltukVarmi(Convert.ToInt32(Genel.SalonID), Genel.seans))
            {
             
             
                sa.say(textBox1, textBox2, Genel.SalonID, Genel.seans);
               

            }
            else
            {
                
              

                if (sa.koltuklarikaydet(lbKoltukName, lbKoltukName.Items.Count, Genel.SalonID, Genel.seans))
                {

                  
                    sa.say(textBox1, textBox2, Genel.SalonID, Genel.seans);
                }
                else
                {

                }
               


            }
         
            timer1.Interval = 1000;
            timer1.Start();       
            txtFilmTarih.Text = DateTime.Now.ToShortDateString();
            txtFilm.Text = Genel.FilmAdi;       
            txtSalon.Text = Genel.salon;
            txtSeans.Text = Genel.seans;       
            this.Top = 1;
            this.Left = 0;               
            txtTarih.Focus();
            yenile();
            lbKoltukName.Items.Clear();

          
            
        }
        private void DinamikButonOlusturma()
        {

            Salonsec sa = new Salonsec();

            int butonSayisi = 120;
            int sol = 0; //formun sol tarafından atanan değer
            int alt = 0; // formun üst tarafından atanan değer
            int bol; // bolme işlemindeki amaç formun boyutuna göre butonları sıralı bir şekilde görebilmek için
            bol = 4;           
            int I = 1;
            int H = 1;
            int G = 1;
            int F = 1;
            int E = 1;
            int D = 1;
            int C = 1;
            int B = 1;
            int A = 1;

            for (int i = 1; i <= butonSayisi; i++)  // girilen buton sayısına göre döngü şartı sağlanana kadar oluşturmakta
            {
                
                Button btn = new System.Windows.Forms.Button();
                btn.Name = i.ToString();
                btn.AutoSize = false;
                btn.Size = new Size(groupBox2.Width / (5* bol), groupBox2.Height);
                //btn.Text =  i.ToString();
                btn.BackColor = Color.Green;

                btn.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
           
                btn.Location = new Point(sol, alt);
                sol += btn.Width + 20;
                if (i == 3 || i == 16 || i == 29 || i == 42 || i == 55 || i == 68 || i == 81)
                {
                    
                }
              
                else if (i == 6||i==19||i==32||i==45||i==58||i==71||i==84||i==96||i==108)
                {
                    sol += 15;
                }
                else if (i == 9 || i == 22 || i == 35|| i == 48 || i == 61 || i == 74 || i == 87||i==99||i==111)
                {
                    sol += 55;
                }
                else if (i == 105||i==93)
                {
                   
                }
                

                if (i <= 12)
                {

                    btn.Text = I.ToString();
                    groupBox2.Controls.Add(btn);
                    I++;

                }
                else if (i == 13)
                {

                    sol = 0; //formun sol tarafından atanan değer
                    alt = 0; // formun üst tarafından atanan değer
                    btn.Location = new Point(sol, alt);
                }
                else if (i >= 13 && i < 26)
                {
                    btn.Text = H.ToString();
                    groupBox3.Controls.Add(btn);
                    H++;
                }
                else if (i == 26)
                {

                    sol = 0; //formun sol tarafından atanan değer
                    alt = 0; // formun üst tarafından atanan değer
                    btn.Location = new Point(sol, alt);

                }
                else if (i >= 26 && i < 39)
                {
                    btn.Text = G.ToString();
                    groupBox4.Controls.Add(btn);
                    G++;
                }

                else if (i == 39)
                {
                    sol = 0; //formun sol tarafından atanan değer
                    alt = 0; // formun üst tarafından atanan değer
                    btn.Location = new Point(sol, alt);
                }
                else if (i >= 39 && i < 52)
                {
                    btn.Text = F.ToString();
                    groupBox5.Controls.Add(btn);
                    F++;
                }
                else if (i == 52)
                {
                    sol = 0; //formun sol tarafından atanan değer
                    alt = 0; // formun üst tarafından atanan değer
                    btn.Location = new Point(sol, alt);
                }
                else if (i >= 52 && i < 65)
                {

                    btn.Text = E.ToString();
                    groupBox6.Controls.Add(btn);
                    E++;

                }
                else if (i == 65)
                {
                    sol = 0; //formun sol tarafından atanan değer
                    alt = 0; // formun üst tarafından atanan değer
                    btn.Location = new Point(sol, alt);
                }
                else if (i >= 65 && i < 78)
                {
                    btn.Text = D.ToString();
                    groupBox7.Controls.Add(btn);
                    D++;
                }
                else if (i == 78)
                {
                    sol = 0; //formun sol tarafından atanan değer
                    alt = 0; // formun üst tarafından atanan değer
                    btn.Location = new Point(sol, alt);
                }
                else if (i >= 78 && i < 91)
                {
                    btn.Text = C.ToString();
                    groupBox8.Controls.Add(btn);
                    C++;
                }
                else if (i == 91)
                {
                    sol = 60; //formun sol tarafından atanan değer
                    alt = 0; // formun üst tarafından atanan değer
                    btn.Location = new Point(sol, alt);
                }
                else if (i >= 91 && i < 102)
                {
                    btn.Text = B.ToString();
                    groupBox9.Controls.Add(btn);
                    B++;
                }
                else if (i == 104)
                {
                    sol = 125; //formun sol tarafından atanan değer
                    alt = 0; // formun üst tarafından atanan değer
                    btn.Location = new Point(sol, alt);
                }
                else if (i >= 104 && i < 113)
                {
                    btn.Text = A.ToString();
                    groupBox10.Controls.Add(btn);
                    A++;
                }
                //else if (i == 117)
                //{
                //    sol = 0; //formun sol tarafından atanan değer
                //    alt = 0; // formun üst tarafından atanan değer
                //    btn.Location = new Point(sol, alt);
                //    groupBox11.Controls.Add(btn);
                //}
                //else if (i > 117 && i < 130)
                //{
                //    groupBox11.Controls.Add(btn);
                //}

                btn.Click += new EventHandler(dinamikMetod); // dinamik olarak oluşturulan butonu kontrol etmek için her oluşturulan butonun clik olayına atıyoruz

                sa.koltukgetir(btn, Genel.SalonID, i, Genel.seans);

              
               lbKoltukName.Items.Add(btn.Name);
                
              

            }
        }

   
        private void dinamikMetod(object sender, EventArgs e)
        {
           
            Button dinamikButon = (sender as Button);
           
            //MessageBox.Show(dinamikButon.Text + " isimli butona tıkladınız");
            if (dinamikButon.BackColor == Color.Red)
            {
             
                dinamikButon.BackColor = Color.Green;               
                lbSecilenSira.Items.Remove(txtSira.Text);
                lbSecilenKoltuk.Items.Remove(dinamikButon.Text);
                lbKoltukName.Items.Remove(dinamikButon.Name);
                txtBiletSayisi.Text = lbSecilenKoltuk.Items.Count.ToString();
                lbFiyat.Items.Remove(txtkampanyaFiyat.Text);
                int topla = 0;

                for (int i = 0; i < lbFiyat.Items.Count; i++)
                {

                    topla += Convert.ToInt32(lbFiyat.Items[i].ToString());
                }
                txtFiyati.Text = topla.ToString();
              

                            
            }
            else if (dinamikButon.BackColor == Color.Green)
            {

             
                dinamikButon.BackColor = Color.Red;             
                lbSecilenSira.Items.Add(txtSira.Text);
                lbSecilenKoltuk.Items.Add(dinamikButon.Text);
                lbKoltukName.Items.Add(dinamikButon.Name);
                txtBiletSayisi.Text = lbSecilenKoltuk.Items.Count.ToString();
                lbFiyat.Items.Add(txtkampanyaFiyat.Text);

                int topla = 0;

                for (int i = 0; i < lbFiyat.Items.Count ; i++)
                {

                    topla += Convert.ToInt32(lbFiyat.Items[i].ToString());
                }
                txtFiyati.Text = topla.ToString();

            }
         
            
        }
        

        private void Salon1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            txtSira.Text = groupBox2.Text.ToString() +"  -" ;          
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {
            txtSira.Text = groupBox8.Text.ToString() + "  -";
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            txtSira.Text = groupBox3.Text.ToString() + "  -";
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            txtSira.Text =  groupBox4.Text.ToString() + "  -";
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

            txtSira.Text = groupBox5.Text.ToString() + "  -";
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {
            txtSira.Text = groupBox6.Text.ToString() + "  -";
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

            txtSira.Text = groupBox7.Text.ToString() + "  -";
           
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {
            txtSira.Text =  groupBox9.Text.ToString() + "  -";
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {
            txtSira.Text = groupBox10.Text.ToString() + "  -";
        }


    

        private void btnBiletAl_Click(object sender, EventArgs e)
        {
            Salonsec sa = new Salonsec();
            if (lbSecilenKoltuk.Items.Count.ToString()=="0")
            {
                MessageBox.Show("Koltuk Seçiniz","DİKKAT !");
            }
            else
            {
               
                    if (sa.KoltuklariDegistir(lbKoltukName, Convert.ToInt32(txtBiletSayisi.Text), Genel.SalonID, Genel.seans))
                   {



                       
                        MessageBox.Show("Koltuklar Değişti!");
           
                        lbKoltukName.Items.Clear();
                        lbFiyat.Items.Clear();
                        sa.say(textBox1, textBox2, Genel.SalonID, Genel.seans);
                    }
                    else
                    {
                        MessageBox.Show("Koltuklar Değişmedi!!!");
                    }


            //        BiletSatis bs = new BiletSatis();
            //        //bs.Biletsatisadet = Convert.ToInt32(txtBiletSayisi.Text);
            //        bs.Filmadi = txtFilm.Text;
            //        bs.Satistarihi = txtFilmTarih.Text;
            //        bs.Seans = txtSeans.Text;
            //        bs.Salonno = Genel.SalonID;
            //        bs.Calisanadi = tslKullaniciAdi.Text;
            //        bs.Tutar = Convert.ToDouble(txtFiyati.Text);
            //    for (int i = 0; i < lbSecilenSira.Items.Count; i++)
            //{
            //    bs.Koltukno = lbSecilenSira.Items[i].ToString() +"-"+ lbSecilenKoltuk.Items[i].ToString();

            //}
            //    if (bs.BiletSatisEkle(bs))
            //    {
            //        MessageBox.Show("eklendi");
            //    }
            //    else
            //    {
            //        MessageBox.Show("eklenemedi!!!");
            //    }


                    printPreviewDialog1.ShowDialog();

                    yenile();
                 
                  
                
                

           


            }

            

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            yenile();
            
        }
        private void yenile()
        {
            lbSecilenSira.Items.Clear();
            lbSecilenKoltuk.Items.Clear();
            lbKoltukName.Items.Clear();
            txtBiletSayisi.Clear();
            groupBox2.Controls.Clear();
            groupBox3.Controls.Clear();
            groupBox4.Controls.Clear();
            groupBox5.Controls.Clear();
            groupBox6.Controls.Clear();
            groupBox7.Controls.Clear();
            groupBox8.Controls.Clear();
            groupBox9.Controls.Clear();
            groupBox10.Controls.Clear();
            DinamikButonOlusturma();
            lbKoltukName.Items.Clear();
            lbFiyat.Items.Clear();
            txtFiyati.Clear();
        }

        private void btnKoltukBosalt_Click(object sender, EventArgs e)
        {
            Salonsec sa = new Salonsec();


              DialogResult result = MessageBox.Show("Gerçekten Oturumu Sonlandırmak İstiyor musunuz?", "DİKKAT!", 
              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
             if(result == DialogResult.Yes)
             {
                 sa.KoltuklariBosalt(Genel.SalonID, Genel.seans);
                 yenile();
               
                 textBox2.Text = "";

  
             }
     
           

        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            
                txtTarih.Text = DateTime.Now.ToString();   
           
           
        }

        private void btnKoltukEkle_Click(object sender, EventArgs e)
        {
           
               
        }

        private void cbKampanyalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kampanya k = (Kampanya)cbKampanyalar.SelectedItem;
            txtkampanyaFiyat.Text = Convert.ToString(k._kampanyaFiyat);
            
        }

        private void btnfiyat_Click(object sender, EventArgs e)
        {
          



        }

        private void txtBiletSayisi_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void txtFiyati_TextChanged(object sender, EventArgs e)
        {

        }
        int a, b;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            


                Font myFont = new Font("Calibri", 40);
                Font myFilmfont = new Font("Calibri", 40);

                SolidBrush sbrush = new SolidBrush(Color.Black);
                SolidBrush sbrushh = new SolidBrush(Color.Red);
                Pen myPen = new Pen(Color.Black);

                //Bu kısımda sipariş formu yazısını ve çizgileri yazdırıyorum
                e.Graphics.DrawLine(myPen, 120, 120, 750, 120);
                e.Graphics.DrawLine(myPen, 120, 180, 750, 180);
                e.Graphics.DrawString("CINEWISSEN", myFont, sbrush,120, 115);

                e.Graphics.DrawLine(myPen, 120, 320, 750, 320);

                myFont = new Font("Calibri", 12, FontStyle.Bold);
                myFilmfont = new Font("Calibri", 30, FontStyle.Bold);

                e.Graphics.DrawString(txtFilm.Text, myFilmfont, sbrushh, 120, 210);
             
                e.Graphics.DrawString("BİLET ADET :" + "   " + txtBiletSayisi.Text, myFont, sbrush, 120, 378);
                e.Graphics.DrawString("FİYAT :" + "   " + txtFiyati.Text+"  TL", myFont, sbrush, 120, 628);
                e.Graphics.DrawString("BİLET TÜRÜ :" + "   " + cbKampanyalar.SelectedItem.ToString(), myFont, sbrush, 120, 478);
                e.Graphics.DrawString("SEANS :" + "   " + txtSeans.Text, myFont, sbrush, 120, 528);
                e.Graphics.DrawString("SALON :" + "   " + txtSalon.Text, myFont, sbrush, 120, 578);
                e.Graphics.DrawString("KOLTUK NO : " + "   " , myFont, sbrush, 120, 428);

                for (int i = 0; i < lbSecilenSira.Items.Count; i++)
                {
                    if (i >= 6)
                    {
                        e.Graphics.DrawString("   "+ lbSecilenSira.Items[i].ToString() + "  " + lbSecilenKoltuk.Items[i].ToString() + "  ,  ", myFont, sbrush, 210 + ((i-6) * 50), 458);
                    }
                    else
                    {
                        e.Graphics.DrawString("   "+lbSecilenSira.Items[i].ToString() + "  " + lbSecilenKoltuk.Items[i].ToString() + "  ,  ", myFont, sbrush, 210 + (i * 50), 428);
                    }
                }
                


                //e.Graphics.DrawLine(myPen, 120, 400, 750, 348);





  
      

            
 
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }




    
    }
}
