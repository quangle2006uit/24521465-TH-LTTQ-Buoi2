using System.Runtime.Serialization;

namespace TH2_Bai5
{
    class KhuDat
    {
        protected string DiaDiem;
        protected int GiaBan;
        protected double DienTich;
        public KhuDat()
        {
            DiaDiem = "369 Nguyen Thi Dinh , Buon Ma Thuoc , Dak Lak";
            GiaBan = 1000000000;
            DienTich = 200.5;
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap Dia Diem :");
            DiaDiem = Console.ReadLine();
            do
            {
                Console.Write("Nhap Gia Ban :");
                GiaBan = Convert.ToInt32(Console.ReadLine());
                if (GiaBan <= 0)
                    Console.WriteLine("Gia Ban Khong Hop Le !");
            } while (GiaBan <= 0);
            do
            {
                Console.Write("Nhap Diem Tich :");
                DienTich = Convert.ToDouble(Console.ReadLine());
                if (DienTich <= 0)
                    Console.WriteLine("Dien Tich Khong Hop Le !");
            } while (DienTich <= 0);
        }
        public virtual void Xuat()
        {
            Console.WriteLine("Dia Diem : " +DiaDiem);
            Console.WriteLine("Gia Ban : "+ GiaBan);
            Console.WriteLine("Dien Tich : "+ DienTich);
        }
        public int GetGiaBan() {  return GiaBan; }
        public double GetDienTich() { return DienTich ; }
        public string GetDiaDiemToLower() { return DiaDiem.ToLower(); }
    }
    class NhaPho : KhuDat
    {
        private int NamXayDung;
        private int SoTang;
        public NhaPho() : base() 
        {
            NamXayDung = 2018;
            SoTang = 2;
        }
        public override void Nhap()
        {
            base.Nhap();
                Console.Write("Nhap Nam Xay Dung :");
                NamXayDung = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.Write("Nhap So Tang :");
                SoTang = Convert.ToInt32(Console.ReadLine());
                if (SoTang <= 0)
                    Console.WriteLine("So Tang Khong Hop Le !");
            } while (SoTang <= 0);
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Nam Xay Dung : " + NamXayDung);
            Console.WriteLine("So Tang : " + SoTang);
        }
        public int GetNamXayDung() {  return NamXayDung; }
    }
    class ChungCu : KhuDat 
    {
        private int Tang;
        public ChungCu() : base() 
        {
            Tang = 1;
        }
        public override void Nhap()
        {
            base.Nhap();
            do
            {
                Console.Write("Nhap So Tang :");
                Tang = Convert.ToInt32(Console.ReadLine());
                if (Tang <= 0)
                    Console.WriteLine("So Tang Khong Hop Le !");
            } while (Tang <= 0);
        }
        public override void Xuat() 
        {
            base.Xuat();
            Console.WriteLine("So Tang : " + Tang);
        }
    }
    internal class Program
    {
        static void  NhapList(ref List<KhuDat> KhuDats , ref List<NhaPho> NhaPhos, ref List<ChungCu> ChungCus)
        {
            int nKhuDat, nNhaPho,nChungCu;
            // Nhap Danh Sach Khu Dat
            Console.WriteLine("Nhap So Khu Dat :");
            nKhuDat= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap Danh sach khu dat :");
            for (int i = 0; i < nKhuDat; i++) 
            { 
               KhuDat kd = new KhuDat();
                kd.Nhap();
                KhuDats.Add(kd);
            }
            // Nhap Danh Sach Nha Pho
            Console.WriteLine("Nhap So Nha Pho :");
            nNhaPho = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap Danh sach Nha Pho :");
            for (int i = 0; i < nNhaPho; i++)
            {
                NhaPho np = new NhaPho();
                np.Nhap();
                NhaPhos.Add(np);
            }
            // Nhap Danh Sach Chung Cu
            Console.WriteLine("Nhap So Chung Cu :");
            nChungCu = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap Danh sach Chung Cu :");
            for (int i = 0; i < nChungCu; i++)
            {
                ChungCu cc = new ChungCu();
                cc.Nhap();
                ChungCus.Add(cc);
            }
        }
        static void XuatGiaBanTong(List<KhuDat> KhuDats , List<NhaPho> NhaPhos , List<ChungCu> ChungCus)
        {
            long SumKhuDat = 0 , SumNhaPho = 0 , SumChungCu = 0;
            foreach (KhuDat khuDat in KhuDats) { SumKhuDat += khuDat.GetGiaBan(); }
            foreach(NhaPho nhaPho in NhaPhos) { SumNhaPho += nhaPho.GetGiaBan(); }
            foreach (ChungCu chungCu in ChungCus) { SumChungCu += chungCu.GetGiaBan(); }
            Console.WriteLine("Tong Gia Ban Cua Danh Sach Khu Dat : "+SumKhuDat);
            Console.WriteLine("Tong Gia Ban Cua Danh Sach Nha Pho : " + SumNhaPho);
            Console.WriteLine("Tong Gia Ban Cua Danh Sach Chung Cu : " + SumChungCu);
        }
        static void XuatTheoDK(List<KhuDat> KhuDats, List<NhaPho> NhaPhos, List<ChungCu> ChungCus) 
        {
            Console.WriteLine("Khu Dat Co Dien Tich Tren 100 m vuong :");
            foreach (KhuDat khuDat in KhuDats) { if (khuDat.GetDienTich() > 100) khuDat.Xuat(); }
            bool KiemTra = true;
            foreach (NhaPho nhaPho in NhaPhos) 
                if (nhaPho.GetNamXayDung() >= 2019 && nhaPho.GetDienTich() >= 60)
                {
                    if(KiemTra)
                    {
                        Console.WriteLine("Nha Pho co dien tich >60m2 va nam xay dung >= 2019 :");
                        KiemTra=false;
                    }
                    nhaPho.Xuat();
                }
            }
        static void TimKiem(List<KhuDat> KhuDats, List<NhaPho> NhaPhos, List<ChungCu> ChungCus)
        {
            if (KhuDats.Count == 0 && NhaPhos.Count == 0 && ChungCus.Count == 0)
                return;
            Console.Write("Nhap Dia Diem Can Tim :");
            string? DiaDiem= Console.ReadLine();
            Console.Write("Nhap Gia Can Tim :");
            int Gia =Convert.ToInt32( Console.ReadLine());
            Console.Write("Nhap Dien Tich Can Tim :");
            double DienTich = Convert.ToDouble(Console.ReadLine());
            DiaDiem =DiaDiem.ToLower();
            bool KiemTra = true;
            foreach (KhuDat khuDat in KhuDats) 
            {
                if (khuDat.GetDiaDiemToLower().IndexOf(DiaDiem) != -1&&khuDat.GetGiaBan()<=Gia&&khuDat.GetDienTich()>=DienTich) {
                    Console.WriteLine("             Khu Dat ");
                    khuDat.Xuat();
                    KiemTra=false;
                }
            }
            foreach (NhaPho nhaPho in NhaPhos)
            {
                if (nhaPho.GetDiaDiemToLower().IndexOf(DiaDiem) != -1 && nhaPho.GetGiaBan() <= Gia && nhaPho.GetDienTich() >= DienTich)
                {
                    Console.WriteLine("             Nha Pho ");
                    nhaPho.Xuat();
                    KiemTra=false;
                }
            }
            foreach (ChungCu chungCu in ChungCus)
            {
                if (chungCu.GetDiaDiemToLower().IndexOf(DiaDiem) != -1 && chungCu.GetGiaBan() <= Gia && chungCu.GetDienTich() >= DienTich)
                {
                    Console.WriteLine("             Chung Cu ");
                    chungCu.Xuat();
                    KiemTra=false;
                }
            }
            if (KiemTra)
            {
                Console.WriteLine("Dia Diem Can Tim Khong Co !");
            }
        }

        static void Main(string[] args)
        {
            List<KhuDat> KhuDats = new List<KhuDat>();
            List<NhaPho> NhaPhos = new List<NhaPho>();
            List<ChungCu> ChungCus = new List<ChungCu>();
            //Nhập xuất danh sách các thông tin (Khu đất, Nhà phố, Chung Cư) cần quản lý.
               NhapList(ref KhuDats, ref NhaPhos, ref ChungCus);
            //Xuất tổng giá bán cho 3 loại (Khu đất, Nhà phố, Chung Cư) của công ty Đại Phú.
               XuatGiaBanTong(KhuDats, NhaPhos, ChungCus);
            // Xuất danh sách các khu đất có diện tích > 100m2 hoặc là nhà phố mà có diện tích > 60m2 và năm xây dựng >= 2019(nếu có).
               XuatTheoDK(KhuDats, NhaPhos, ChungCus);
            // Nhập vào các thông tin cần tìm kiếm (địa điểm, giá, diện tích). Xuất thông
            // tin danh sách tất cả các nhà phố hoặc chung cư phù hợp yêu cầu. (có địa
            // điểm chứa chuỗi tìm kiếm không phân biệt hoa thường, có giá <= giá tìm
            // kiếm, và diện tích >= diện tích cần tìm kiếm)
               TimKiem(KhuDats,NhaPhos, ChungCus);
        }
    }
}
