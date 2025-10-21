using System;

namespace TH2_Bai1
{
    class XuatThang
    {
        private int Thang;
        private int Nam;

        private bool KiemTraNamNhuan()
        {
            if ((Nam % 4 == 0 && Nam % 100 != 0) || Nam % 400 == 0)
                return true;
            return false;
        }
        public void NhapThangNam()
        {
            do
            {
                Console.WriteLine("Nhap Ngay Thang Nam :");
                string input = Console.ReadLine();
                string[] ThangNam = input.Split('/');
                Thang = Convert.ToInt32(ThangNam[0]);
                Nam = Convert.ToInt32(ThangNam[1]);
                if (!(Thang > 0 && Thang < 13))
                    Console.WriteLine("Thang khong hop le moi nhap lai ");
            }
            while (!(Thang > 0 && Thang < 13));
        }
        public int TimThuTrongTuan()
        {
            int T = Thang;
            int N = Nam;    
            if (Thang == 1 || Thang == 2)
            {
                T += 12;
                N = Nam - 1;
            }
            int J = N/ 100;
            int K = N % 100;
            int h = (1 + ((13 * (T + 1)) / 5) + K + (K / 4) + (J / 4) + 5 * J) % 7;
            switch (h)
            {
                case 0: return 6;
                case 1: return 0;
                case 2: return 1;
                case 3: return 2;
                case 4: return 3;
                case 5: return 4;
                case 6: return 5;

            }
            return 0;


        }
        public int SoNgayTrongThang()
        {
            if (Thang == 1 || Thang == 3 || Thang == 5 || Thang == 7 || Thang == 8 || Thang == 10 || Thang == 12)
                return 31;
            else if (Thang == 4 || Thang == 6 || Thang == 9 || Thang == 11)
                return 30;
            else if (Thang == 2 && KiemTraNamNhuan() == false)
                return 28;
            return 29;
        }
        public void XuatLichThang()
        {   
            Console.Write("ChuNhat\t");
            Console.Write("ThuHai\t");
            Console.Write("ThuBa\t");
            Console.Write("ThuTu\t");
            Console.Write("ThuNam\t");
            Console.Write("ThuSau\t");
            Console.Write("ThuBay\t");
            
            Console.WriteLine();
            int Ngay = 1;
            bool DuocXuat = false;
            for(int i = 0; i < 40; i++)
            {
                int Thu = i % 7;
                if (Thu == TimThuTrongTuan())
                    DuocXuat = true;
                if (Ngay-1 == SoNgayTrongThang())
                    DuocXuat = false;
                if (DuocXuat) {
                    Console.Write("  "+ Ngay + "\t");
                    Ngay++;
                        if (Thu == 6)
                        Console.WriteLine();
                }
                else
                {
                    Console.Write("\t");
                }

            }
        }
    }

        internal class Program
        {

            static void Main(string[] args)
            {
                XuatThang Xuat= new XuatThang(); ;
            Xuat.NhapThangNam();
            Xuat.XuatLichThang();
            }
        }
}
