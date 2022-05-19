using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    abstract class BankaHesap
    {
        public long HesapNo { get; set; }
        public int SubeKodu { get; set; }
        public string IBAN { get; set; }
        public decimal Bakiye { get; set; }
        public virtual string ParaCek(decimal tutar)
        {
            Bakiye-=tutar ;
            return "Hesabınızdan " + tutar+" TL para çektiniz. Güncel Bakiyeniz : "+Bakiye;
        }
        public virtual string ParaYatirma(decimal tutar)
        {
            Bakiye += tutar;
            return "Hesabınızdan " + tutar + " TL para yatırdınız. Güncel Bakiyeniz : " + Bakiye;
        }
    }

    class VadesizHesap:BankaHesap
    {
        public override  string ParaCek(decimal tutar)
        {
            if (Bakiye<tutar)
            {
                return "Yetersiz Bakiye";
            }
            if (tutar%5==0)
            {
                return base.ParaCek(tutar);
            }
            else
            {
                return "5 ve 5'in katlarını çekebilirsiniz !!!";
            }
        }
        public virtual string ParaYatirma(decimal tutar)
        {
            Bakiye += tutar;
            return "Hesabınızdan " + tutar + " TL para yatırdınız. Güncel Bakiyeniz : " + Bakiye;
        }
    }

    class VadeliHesap:BankaHesap
    {
        public DateTime VadeBaslangicTarihi { get; set; }
        public int  VadeGunSayisi { get; set; }
        public DateTime VadeSonuTarihi
        {
            get
            {
                return VadeBaslangicTarihi.AddDays(VadeGunSayisi);
            }
        
        }
        public override string ParaCek(decimal tutar)
        {
            if (DateTime.Today.Date!=VadeSonuTarihi.Date)
            {
                return "Vade Sonu Tarihini Bekleyiniz ";
            }
            else if (Bakiye<tutar)
            {
                return "Yetersiz Bakiye ";
            }
            else if (tutar %5 != 0 )
            {
                return "5 ve 5in katlarını çekebilirsin";
            }
            else
            {
                return base.ParaCek(tutar);
            }
        }
        public override string ParaYatirma(decimal tutar)
        {
            if (DateTime.Today.Date == VadeSonuTarihi.Date)
            {
                return base.ParaYatirma(tutar);
            }
            else
            {
                return "Vade Sonu Tarihini Bekleyiniz ";
            }
        }
    }

}
