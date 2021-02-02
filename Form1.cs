using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tc = Convert.ToInt64(textBox1.Text);
            // ilk beş Rakam
           var a = textBox1.Text.Substring(0,1);

         //   Console.WriteLine("tc kimlik numarasını girin=");
           // tc = Convert.ToInt64(Console.ReadLine());
            long İlk_basamak = tc / 10000000000;
          //  Console.WriteLine("tc kimlik numarasını girin " + İlk_basamak);
            long tc_iki = tc % 10000000000;
            long iki_basamak = tc_iki / 1000000000;
          //  Console.WriteLine("  2= " + iki_basamak);
            long tc_uc = tc_iki % 1000000000;
            long uc_basamak = tc_uc / 100000000;
          //  Console.WriteLine("3= " + uc_basamak);
            long tc_dort = tc_uc % 100000000;
            long dort_Basamak = tc_dort / 10000000;
          //  Console.WriteLine("4= " + dort_Basamak);
            long tc_bes = tc_dort % 10000000;
            long bes_basamak = tc_bes / 1000000;
           // Console.WriteLine("5= " + bes_basamak);
            //sonraki dört Rakamı
            long tc_alti = tc_bes % 1000000;
            long alti_basamak = tc_alti / 100000;
          //  Console.WriteLine("6= " + alti_basamak);
            long tc_yedi = tc_alti % 100000;
            long yedi_basamak = tc_yedi / 10000;
        //    Console.WriteLine("7= " + yedi_basamak);
            long tc_sekiz = tc_yedi % 10000;
            long sekiz_basamak = tc_sekiz / 1000;
          //  Console.WriteLine("8= " + sekiz_basamak);
            long tc_dokuz = tc_sekiz % 1000;
            long dokuz_basamak = tc_dokuz / 100;
            //Console.WriteLine("9= " + dokuz_basamak);
            long tc_on = tc_dokuz % 100;
            long onuncu_basamak = tc_on / 10;
           // Console.WriteLine("10= " + onuncu_basamak);
            long onbir_basanak = tc_on % 10;

            // Console.WriteLine("11= " + onbir_basanak);
            long İlk_Bes_Basamak = ((İlk_basamak * 10000) + (iki_basamak * 1000) + (uc_basamak * 100) + (dort_Basamak * 10) + (bes_basamak * 1) + 3);

            //Console.WriteLine("birinci kısım" + İlk_Bes_Basamak);


            long deger1 = İlk_Bes_Basamak % 10000;
            long count1 = İlk_Bes_Basamak / 10000;
           // Console.WriteLine("count1" + count1);
            long deger2 = deger1 % 1000;
            long count2 = deger1 / 1000;
           // Console.WriteLine("count2" + count2);
            long deger3 = deger2 % 100;

            long count3 = deger2 / 100;
         //   Console.WriteLine("count3" + count3);
            long deger4 = deger3 % 10;//son basamak

          //  Console.WriteLine("deger4" + deger4);
            long count4 = deger3 / 10;
            // Console.WriteLine("count4" + count4);
         //   Console.WriteLine("degerr " + deger3);

            if (uc_basamak != count3)
            {
                if (onbir_basanak < 4)
                {

                    onbir_basanak += 10;
                    onbir_basanak -= 6;
                }
                else
                {
                    onbir_basanak -= 6;
                }

            }
            else
            {
                if (onbir_basanak < 4)
                {

                    onbir_basanak += 10;
                    onbir_basanak -= 4;
                }
                else
                {
                    onbir_basanak -= 4;
                }

            }


            long Sonraki_Dort_Rakam = (alti_basamak * 1000 + yedi_basamak * 100 + sekiz_basamak * 10 + dokuz_basamak - 1);
          //  Console.WriteLine("tc ikinci kısım" + Sonraki_Dort_Rakam);


            long sayi = Sonraki_Dort_Rakam % 1000;

            long twovaalue1 = sayi / 100;



            if (yedi_basamak != twovaalue1)
            {
                onbir_basanak -= 2;
            }
         //   Console.WriteLine("ucuncu kısım" + onbir_basanak);

            long sayi1 = Sonraki_Dort_Rakam % 1000;
            long onevalue = Sonraki_Dort_Rakam / 1000;
            long sayi2 = sayi1 % 100;
            long twovaalue = sayi1 / 100;
            long sayi3 = sayi2 % 10;//son basamak

            long threevalue = sayi2 / 10;


            long toplam = count1 + count2 + count3 + deger4 + count4 + onevalue + twovaalue + threevalue + sayi3;
            // Console.WriteLine("tolam==" + toplam);
            long Son_Rakam = toplam % 10;
            //  Console.WriteLine(Son_Rakam);
            onuncu_basamak = onbir_basanak - Son_Rakam;
           // Console.WriteLine(onuncu_basamak);

            //Console.WriteLine("dortuncu kısım" + onuncu_basamak);
            long Yeni_tc = count1 * 10000000000 + count2 * 1000000000 + count3 * 100000000 + count4 * 10000000 + deger4 * 1000000 + onevalue * 100000 + twovaalue * 10000 + threevalue * 1000 + sayi3 * 100 + onuncu_basamak * 10 + onbir_basanak;
            textBox2.Text = Yeni_tc.ToString();
            int dogumtarihi = int.Parse(textBox5.Text);
            bool? durum;
         
            using (ServiceReference1.KPSPublicSoapClient servis = new ServiceReference1.KPSPublicSoapClient())
            {
                durum = servis.TCKimlikNoDogrula(tc, textBox3.Text, textBox4.Text,dogumtarihi);
                while (durum == true)
                {
                    var tc1 = Convert.ToInt64(textBox2.Text);
                    // ilk beş Rakam
                    long İlk_basamak1 = tc1 / 10000000000;
                    //  Console.WriteLine("tc kimlik numarasını girin " + İlk_basamak);
                    long tc_iki1 = tc1 % 10000000000;
                    long iki_basamak1 = tc_iki1 / 1000000000;
                    //  Console.WriteLine("  2= " + iki_basamak);
                    long tc_uc1 = tc_iki1 % 1000000000;
                    long uc_basamak1 = tc_uc1 / 100000000;
                    //  Console.WriteLine("3= " + uc_basamak);
                    long tc_dort1 = tc_uc1 % 100000000;
                    long dort_Basamak1 = tc_dort1 / 10000000;
                    //  Console.WriteLine("4= " + dort_Basamak);
                    long tc_bes1 = tc_dort1 % 10000000;
                    long bes_basamak1 = tc_bes1 / 1000000;
                    // Console.WriteLine("5= " + bes_basamak);
                    //sonraki dört Rakamı
                    long tc_alti1 = tc_bes1 % 1000000;
                    long alti_basamak1 = tc_alti1 / 100000;
                    //  Console.WriteLine("6= " + alti_basamak);
                    long tc_yedi1 = tc_alti1 % 100000;
                    long yedi_basamak1 = tc_yedi1 / 10000;
                    //    Console.WriteLine("7= " + yedi_basamak);
                    long tc_sekiz1 = tc_yedi1 % 10000;
                    long sekiz_basamak1 = tc_sekiz1 / 1000;
                    //  Console.WriteLine("8= " + sekiz_basamak);
                    long tc_dokuz1 = tc_sekiz1 % 1000;
                    long dokuz_basamak1 = tc_dokuz1 / 100;
                    //Console.WriteLine("9= " + dokuz_basamak);
                    long tc_on1 = tc_dokuz1 % 100;
                    long onuncu_basamak1 = tc_on1 / 10;
                    // Console.WriteLine("10= " + onuncu_basamak);
                    long onbir_basanak1 = tc_on1 % 10;
                    long İlk_Bes_Basamak1 = ((İlk_basamak1 * 10000) + (iki_basamak1 * 1000) + (uc_basamak1 * 100) + (dort_Basamak1 * 10) + (bes_basamak1 * 1) + 3);

                    long yeni_deger1 = İlk_Bes_Basamak1 % 10000;
                    long new_count1 = İlk_Bes_Basamak1 / 10000;
                    // Console.WriteLine("count1" + count1);
                    long yeni_deger2 = yeni_deger1 % 1000;
                    long new_count2 = yeni_deger1 / 1000;
                    // Console.WriteLine("count2" + count2);
                    long yeni_deger3 = yeni_deger2 % 100;

                    long new_count3 = yeni_deger2 / 100;
                    //   Console.WriteLine("count3" + count3);
                    long yeni_deger4 = yeni_deger3 % 10;//son basamak

                    //  Console.WriteLine("deger4" + deger4);
                    long new_count4 = yeni_deger3 / 10;
                    // Console.WriteLine("count4" + count4);
                    //   Console.WriteLine("degerr " + deger3);

                    if (uc_basamak1 != new_count3)
                    {
                        if (onbir_basanak1 < 4)
                        {

                            onbir_basanak1 += 10;
                            onbir_basanak1 -= 6;
                        }
                        else
                        {
                            onbir_basanak1 -= 6;
                        }

                    }
                    else
                    {
                        if (onbir_basanak1 < 4)
                        {

                            onbir_basanak1 += 10;
                            onbir_basanak1 -= 4;
                        }
                        else
                        {
                            onbir_basanak1 -= 4;
                        }

                    }
                    long Sonraki_Dort_Rakam1 = (alti_basamak1 * 1000 + yedi_basamak1 * 100 + sekiz_basamak1 * 10 + dokuz_basamak1 - 1);

                    long yeni_sayi = Sonraki_Dort_Rakam1 % 1000;

                    long new_twovaalue1 = yeni_sayi / 100;



                    if (yedi_basamak1 != new_twovaalue1)
                    {
                        onbir_basanak1 -= 2;
                    }
                    //   Console.WriteLine("ucuncu kısım" + onbir_basanak);

                    long yeni_sayi1 = Sonraki_Dort_Rakam1 % 1000;
                    long new_onevalue = Sonraki_Dort_Rakam1 / 1000;
                    long yeni_sayi2 = yeni_sayi1 % 100;
                    long new_twovaalue = yeni_sayi1 / 100;
                    long yeni_sayi3 = yeni_sayi2 % 10;//son basamak
                    long new_threevalue = yeni_sayi2 / 10;


                    long yeni_toplam = new_count1 + new_count2 + new_count3 + yeni_deger4 + new_count4 + new_onevalue + new_twovaalue + new_threevalue + yeni_sayi3;
                    // Console.WriteLine("tolam==" + toplam);
                    long yeni_Son_Rakam = yeni_toplam % 10;
                    //  Console.WriteLine(Son_Rakam);
                    onuncu_basamak1 = onbir_basanak1 - yeni_Son_Rakam;
                    // Console.WriteLine(onuncu_basamak);

                    //Console.WriteLine("dortuncu kısım" + onuncu_basamak);
                    long Yeni_tc1 = new_count1 * 10000000000 + new_count2 * 1000000000 + new_count3 * 100000000 + new_count4 * 10000000 + yeni_deger4 * 1000000 + new_onevalue * 100000 + new_twovaalue * 10000 + new_threevalue * 1000 + yeni_sayi3 * 100 + onuncu_basamak1 * 10 + onbir_basanak1;
                    textBox2.Text = Yeni_tc1.ToString();
                    int yeni_dogumtarihi = int.Parse(textBox5.Text);
                
                    durum = servis.TCKimlikNoDogrula(tc, textBox3.Text, textBox4.Text, dogumtarihi);


                }



            }
            

            
           // Console.WriteLine(Yeni_tc);
           // Console.ReadLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
          
        }
    }
}
