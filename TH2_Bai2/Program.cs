using System.IO;

namespace TH2_Bai2
{
    internal class Program
    {
        static void XuatThuMuc(string duongdan, int n)
        {
            try
            {
                // file
                string[] tapTins = Directory.GetFiles(duongdan);
                foreach (string file in tapTins)
                {
                    FileAttributes attr = File.GetAttributes(file);
                    if ((attr & FileAttributes.Hidden) != 0 || (attr & FileAttributes.System) != 0)
                        continue;

                    for (int i = 0; i < n; i++) Console.Write("  ");
                    Console.WriteLine(Path.GetFileName(file)); 
                }
                // Tệp
                string[] thuMucs = Directory.GetDirectories(duongdan);
                foreach (string s in thuMucs)
                {
                    FileAttributes attr = File.GetAttributes(s);
                    if ((attr & FileAttributes.Hidden) != 0 || (attr & FileAttributes.System) != 0)
                        continue;

                    for (int i = 0; i < n; i++) Console.Write("  ");
                    Console.WriteLine("📁 " + Path.GetFileName(s));
                    XuatThuMuc(s, n + 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Nếu không có quyền truy cập, bỏ qua thư mục đó
                for (int i = 0; i < n; i++) Console.Write("  ");
                Console.WriteLine("[Không có quyền truy cập]");
            }
            catch (Exception ex)
            {
                // Bỏ qua lỗi khác (ví dụ đường dẫn quá dài, IO lỗi, ...)
                for (int i = 0; i < n; i++) Console.Write("  ");
                Console.WriteLine("[Lỗi: " + ex.Message + "]");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Nhap Duong Dan file :");
            string duongdan = Console.ReadLine();
            if (Directory.Exists(duongdan))
            {
                Console.WriteLine("Duong dan hop le ");
                XuatThuMuc(duongdan,0);
            }
            else
            {
                Console.WriteLine("Duong dan khong hop le ");
            }
        }
    }
}
