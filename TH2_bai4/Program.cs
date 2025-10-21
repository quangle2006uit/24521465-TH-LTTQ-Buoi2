using System.Runtime.CompilerServices;

namespace TH2_bai4
{
    class PhanSo
    {
        private int Tu;
        private int Mau;
        public PhanSo()
        {
            this.Tu = new int();
            this.Mau = new int();
        }
        public PhanSo(int Tu, int Mau)
        {
            this.Tu = Tu;
            this.Mau = Mau;
        }
        public PhanSo(int Tu) { 
           this.Tu = Tu;
            this.Mau = 1;
        }
        public void SetTu(int x){this.Tu = x;}
        public void SetMau(int x){this.Mau = x;}
        public int GetTu() { return this.Tu; }
        public int GetMau() { return this.Mau ; }
        public static int UocChungLonNhat(int x,int y)
        {
            //x<y
            if (x == 0 || y == 0) return 1;
            while (x != 0) 
            {
                int Tam = x;
                x = y % x;
                y=Tam;
            }
            return y;
        }
        public static void RutGon(ref int Tu, ref int Mau)
        {
            int ucln = UocChungLonNhat(Math.Min(Tu, Mau), Math.Max(Tu, Mau));
            Tu /= ucln;
            Mau /= ucln;
            if(Mau < 0)
            {
                Tu = -Tu;
                Mau = -Mau;
            }
        }

        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            PhanSo This = new PhanSo();
            int Tu = a.GetTu() * b.GetMau() + b.GetTu() * a.GetMau();
            int Mau = a.GetMau() * b.GetMau();
            RutGon(ref Tu,ref Mau);
            This.SetMau(Mau);
            This.SetTu(Tu);
            return This;
        }
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            PhanSo This = new PhanSo();
            int Tu = a.GetTu() * b.GetMau() - b.GetTu() * a.GetMau();
            int Mau = a.GetMau() * b.GetMau();
            RutGon(ref Tu, ref Mau);
            This.SetMau(Mau);
            This.SetTu(Tu);
            return This;
        }
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            PhanSo This = new PhanSo();
            int Tu = a.GetTu()*b.GetTu();
            int Mau = a.GetMau() * b.GetMau();
            RutGon(ref Tu, ref Mau);
            This.SetMau(Mau);
            This.SetTu(Tu);
            return This;
        }
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            PhanSo This = new PhanSo();
            int Tu = a.GetTu() * b.GetMau();
            int Mau = a.GetMau() * b.GetTu();
            RutGon(ref Tu, ref Mau);
            This.SetMau(Mau);
            This.SetTu(Tu);
            return This;
        }
        public double GiaTri() { return ((double)Tu)/(double)Mau; }
        public  void NhapSo()
        {
            int Tu,Mau;
            Console.WriteLine("Nhap Tu So :");
            Tu= Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.WriteLine("Nhap Mau So :");
                Mau = Convert.ToInt32(Console.ReadLine());
                if(Mau==0)
                Console.WriteLine("Mau so = 0 moi nhap lai");
            } while (Mau == 0);
            this.Tu = Tu;
            this.Mau = Mau;
        }
        public void Xuat()
        {
            if (Mau == 1)
                Console.WriteLine(Tu);
            else if(Tu == 0)
                Console.WriteLine(0);
            else 

                Console.WriteLine(Tu + "/" + Mau);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        // chương trình nhập vào phân số và tính tổng hiệu tích thương
            PhanSo phanso1 = new PhanSo();
            phanso1.NhapSo();
            PhanSo phanso2 = new PhanSo();
            phanso2.NhapSo();
            //Tong
            PhanSo phanso = new PhanSo();
            phanso = phanso1+phanso2 ;
            Console.WriteLine("Tong 2 Phan So :");
            phanso.Xuat();
            //Hieu
            phanso = phanso1 - phanso2;
            Console.WriteLine("Hieu 2 Phan So :");
            phanso.Xuat();
            // Tich
            phanso = phanso1 * phanso2;
            Console.WriteLine("Tich 2 Phan So :");
            phanso.Xuat();
            // Thuong
            if (phanso2.GetTu() != 0)
            {
                phanso = phanso1 / phanso2;
                Console.WriteLine("Thuong 2 Phan So :");
                phanso.Xuat();
            }
            else Console.WriteLine("Thuong 2 Phan So khong hop le!");
        // chương trình nhập vào danh sach phan so
        List<PhanSo> PhanSoList = new List<PhanSo> ();
            Console.WriteLine("Nhap vao So Phan So :");
            int n= Convert.ToInt32 (Console.ReadLine());
            if (n <= 0)
                return;
            for (int i = 0; i < n; i++) { 
              PhanSo PS = new PhanSo();
                PS.NhapSo();
                PhanSoList.Add(PS);
            }
            // Tìm phần tử lớn nhất
            phanso = PhanSoList[0];
            foreach (PhanSo PS in PhanSoList)
            {
                if(phanso.GiaTri()<PS.GiaTri()) 
                    phanso=PS;
            }
            Console.WriteLine("Phan So Co Gia Tri Lon Nhat :");
            phanso.Xuat();
            // xap xep list phan so 
            Console.WriteLine("List sau khi sort :");
            for (int i = 1; i < n; i++) {
                int j = i - 1;
                PhanSo ps1 = PhanSoList[i];
                while (j >= 0 && PhanSoList[j].GiaTri() > ps1.GiaTri())
                {
                    PhanSoList[j + 1] = PhanSoList[j];
                    j--;
                }
                PhanSoList[j+1] = ps1;
            }
            foreach(PhanSo PS in PhanSoList)
            {
                PS.Xuat();
            }
        }
    }
}
