using System;
using System.Net;

namespace BTH2_bai3
{
    class MaTran
    {
        private int m, n;
        private int[,] a = new int[100, 100];
        public bool KiemTraSoNguyenTo(int n)
        {
            if(n<=1)
                return false; ;
            for(int  i=2;i<=Math.Sqrt(n);i++)
                if(n%i==0)
                    return false;
            return true;
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap So Cot (>=1 va <100):");
            m = Convert.ToInt32(Console.ReadLine());
            while (m < 1 || m >= 100)
            {
                Console.WriteLine("So Cot Sai Moi Nhap Lai");
                m = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Nhap So dong (>=1 va <100):");
            n = Convert.ToInt32(Console.ReadLine());
            while (n < 1 || n >= 100)
            {
                Console.WriteLine("So dong Sai Moi Nhap Lai");
                n = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Nhap Ma Tran");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }

            }

        }
        public void Xuat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();

            }
        }
        public void TimKiem1PhanTu()
        {
            Console.WriteLine("Nhap 1 so Can Tim Trong Ma Tran");
            int k=Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (a[i, j] == k)
                    {
                        Console.WriteLine("So " + k + " o vi tri cot = "+(j+1)+" dong = "+(i+1));
                        return;
                    }
                }
            }
                Console.WriteLine("So " + k + " khong co trong ma tran");
        }
        public void XuatPhanTuLaSoNguyenTo()
        {
            Console.Write("Cac Phan Tu Trong Ma Tran La So Nguyen To : ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (KiemTraSoNguyenTo(a[i, j]))
                        Console.Write(a[i,j]+ " ");
            Console.WriteLine();
        }
        public void DongChuaNhieuSoNguyenToNhat()
        {
            int DongNhieuSoNguyenToNhat = 0;
            int max = 0;
            for(int i = 0;i < n; i++)
            {
                int Count = 0;
                for( int j = 0; j < m; j++)
                    if (KiemTraSoNguyenTo(a[i,j]))
                        Count++;
                if (Count > max) { 
                    max = Count;
                    DongNhieuSoNguyenToNhat = i;
                }
            }
            Console.WriteLine("Dong Chua Nhieu So Nguyen To Nhat La :"+(DongNhieuSoNguyenToNhat+1));
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //a
            MaTran Matran = new MaTran();
            Matran.Nhap();
            Matran.Xuat();
            //b
            Matran.TimKiem1PhanTu();
            //c
            Matran.XuatPhanTuLaSoNguyenTo();
            //d
            Matran.DongChuaNhieuSoNguyenToNhat();
        }
    }
}
