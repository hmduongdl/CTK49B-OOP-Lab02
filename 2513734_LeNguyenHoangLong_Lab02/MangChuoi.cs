using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MangChuoi
{

    // Khai bao kieu enum, mang chuoi
    public enum MenuCT
    {
        Thoat,
        NhapDanhSachHT,
        NhapDSCoDinh,
        XuatDanhSachHT,
        InDSTheoHo,
        ChuanHoaDSHT,
        DemTheoTen,
        XuatDSInHoa,
        TimHTDaiNhat,
        TimHTNganNhat,
        SapXepDSTangTheoHo,
        SapXepDSGiamTheoTen,
    }

    static string[] dshoten = new string[100];
    static int length = 0;


    // ham xuat ke Ngang voi so lan n
    static void XuatKeNgang(char kt, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write(kt);

        }   
        Console.WriteLine();
    }


    // Ham xuat menu

    static void XuatMenu()
    {
        XuatKeNgang('-', 40);
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.Thoat, "Thoat Chuong Trinh");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.NhapDanhSachHT, "Nhap Danh Sach Tu Ban Phim");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.NhapDSCoDinh, "Nhap Danh Sach Co Dinh");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.XuatDanhSachHT, "Xuat Danh Sach");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.InDSTheoHo, "In Danh Sach Theo Ho");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.ChuanHoaDSHT, "Chuan Hoa Danh Sach Ho Ten");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.DemTheoTen, "Dem Nguoi Co Ten X (Khong phan biet hoa thuong)");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.XuatDSInHoa, "Xuat Danh Sach In Hoa");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.TimHTDaiNhat, "Tim Ho Ten Dai Nhat");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.TimHTNganNhat, "Tim Ho Ten Ngan Nhat");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.SapXepDSTangTheoHo, "Sap Xep Danh Sach Tang Theo Ho");
        Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.SapXepDSGiamTheoTen, "Sap Xep Danh Sach Giam Theo Ten");
        XuatKeNgang('-', 40);

    }

    // Ham chon menu

    static MenuCT ChonMenu()
    {
        int chon;
        do
        {
            Console.Write("Nhap chon {0} den {1}: ",(int)MenuCT.Thoat, (int)MenuCT.SapXepDSGiamTheoTen);
            chon = int.Parse( Console.ReadLine() );
            if ((int)MenuCT.Thoat <= chon && chon <= (int)MenuCT.SapXepDSGiamTheoTen)
                break;
        } while (true);
        return (MenuCT)chon;
    }

    // ham xu ly menu
    static void XuLyMenu(MenuCT m)
    {
        string[] kq;
        switch (m)
        {
            case MenuCT.Thoat:
                return;
            case MenuCT.NhapDanhSachHT:
                NhapDS();
                break;
            case MenuCT.NhapDSCoDinh:
                NhapCoDinh();
                Console.WriteLine("Da Nhap Danh Sach Co Dinh!");
                XuatDS();
                break;
            case MenuCT.XuatDanhSachHT:
                XuatDS();
                break;
            case MenuCT.InDSTheoHo:
                Console.Write("Nhap ho can tim: ");
                string ho = Console.ReadLine();
                InDSTheoHo(ho);
                break;
            case MenuCT.ChuanHoaDSHT:
                ChuanHoaDSHT();
                Console.WriteLine("Danh sach duoc chuan hoa");
                XuatDS();
                break;
            case MenuCT.DemTheoTen:
                Console.Write("Nhap ten can dem: ");
                string ten = Console.ReadLine();
                int dem = DemTheoTen(ten);
                Console.WriteLine("Co {0} nguoi co ten '{1}'", dem, ten);
                break;
            case MenuCT.XuatDSInHoa:
                XuatDSInHoa();
                break;
            case MenuCT.TimHTDaiNhat:
                kq = TimHTDaiNhat();
                Console.WriteLine("Ho ten dai nhat:");
                XuatKeNgang('-', 43);
                for (int i = 0; i < kq.Length; i++)
                {
                    Console.WriteLine("{0}|{1}|", (i + 1).ToString().PadRight(5), kq[i].PadRight(35));
                }
                XuatKeNgang('-', 43);
                break;
            case MenuCT.TimHTNganNhat:
                kq = TimHTNganNhat();
                Console.WriteLine("Ho ten ngan nhat:");
                XuatKeNgang('-', 43);
                for (int i = 0; i < kq.Length; i++)
                {
                    Console.WriteLine("{0}|{1}|", (i + 1).ToString().PadRight(5), kq[i].PadRight(35));
                }
                XuatKeNgang('-', 43);
                break;
            case MenuCT.SapXepDSTangTheoHo:
                SapXepDSTangTheoHo();
                Console.WriteLine("Da sap xep tang theo ho!");
                XuatDS();
                break;
            case MenuCT.SapXepDSGiamTheoTen:
                SapXepDSGiamTheoTen();
                Console.WriteLine("Da sap xep giam theo ten!");
                XuatDS();
                break;
        }
        Console.ReadKey();

    }
    public static void ChayChuongTrinh()
    {
        MenuCT chon;
        do
        {
            Console.Clear();
            XuatMenu();
            chon = ChonMenu();
            if (chon == MenuCT.Thoat)
                break;
            XuLyMenu(chon);
            Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
            Console.ReadKey();
        } while (true);
    }


    // Nhap danh sach chuoi ho ten tu ban phim
    static void NhapDS()
    {
        Console.Write("Nhap chieu dai danh sach:");
        length = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < length; i++)
        {
            Console.Write("Nhap ho ten thu {0}: ", i + 1);
            dshoten[i] = Console.ReadLine();
        }
    }

    // Nhap danh sach chuoi ho ten co dinh
    static void NhapCoDinh()
    {
        dshoten = new string[] {
            "Cao     Anh Tu  ",
            "Nguyen  quoc    Khanh   ",
            "Phan    bao   Linh",
            "Nguyen Lan Huong",
            "   Le     Hoang   Bao",
            "Pham Anh",
            " Le Tran   nguyen quoc  khanh",
            "Do Thi Huong",
            "Nguyen thi   thuy Anh",
            "le Viet     anh    "
        };
        length = 10;
    }

    // Xuat danh sach chuoi ho ten
    static void XuatDS()
    {
        XuatKeNgang('-', 43);
        Console.WriteLine("{0}|{1}|", "STT".ToUpper().PadRight(5), "Ho ten".PadRight(35));
        XuatKeNgang('-', 43);
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine("{0}|{1}|", (i + 1).ToString().PadRight(5), dshoten[i].PadRight(35));
        }
        XuatKeNgang('-', 43);
    }

    // Lay ho tu chuoi ho ten
    static string LayHo(string hoten)
    {
        string[] ss = hoten.Trim().Split(' ');
        return ss[0];
    }

    // Lay ten tu chuoi ho ten
    static string LayTen(string hoten)
    {
        string[] ss = hoten.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return ss[ss.Length - 1];
    }

    // In danh sach theo ho (khong phan biet hoa thuong)
    static void InDSTheoHo(string hotim)
    {
        int d = 0;
        XuatKeNgang('-', 43);
        for (int i = 0; i < length; i++)
        {
            if (LayHo(dshoten[i]).ToLower() == hotim.ToLower())
            {
                Console.WriteLine("{0}|{1}|", (d + 1).ToString().PadRight(5), dshoten[i].PadRight(35));
                d++;
            }
        }
        if (d == 0)
        {
            Console.WriteLine("Khong tim thay nguoi nao co ho '{0}'", hotim);
        }
        XuatKeNgang('-', 43);
    }

    // Chuan hoa mot ten (bo khoang trang thua, chu dau viet hoa)
    static string ChuanHoaTen(string hoten)
    {
        string[] ss = hoten.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string kq = "";
        for (int i = 0; i < ss.Length; i++)
        {
            string tu = ss[i].ToLower();
            tu = char.ToUpper(tu[0]) + tu.Substring(1);
            kq += tu;
            if (i < ss.Length - 1)
                kq += " ";
        }
        return kq;
    }

    // Chuan hoa danh sach ho ten
    static void ChuanHoaDSHT()
    {
        for (int i = 0; i < length; i++)
        {
            dshoten[i] = ChuanHoaTen(dshoten[i]);
        }
    }

    // Dem nguoi co ten X (khong phan biet hoa thuong)
    static int DemTheoTen(string tentim)
    {
        int dem = 0;
        for (int i = 0; i < length; i++)
        {
            if (LayTen(dshoten[i]).ToLower() == tentim.ToLower())
                dem++;
        }
        return dem;
    }

    // Xuat danh sach in hoa
    static void XuatDSInHoa()
    {
        XuatKeNgang('-', 43);
        Console.WriteLine("{0}|{1}|", "STT".ToUpper().PadRight(5), "Ho ten".PadLeft(35));
        XuatKeNgang('-', 43);
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine("{0}|{1}|", (i + 1).ToString().PadRight(5), dshoten[i].ToUpper().PadRight(35));
        }
        XuatKeNgang('-', 43);
    }

    // Tim ho ten dai nhat
    static string[] TimHTDaiNhat()
    {
        int max = dshoten[0].Trim().Length;
        for (int i = 1; i < length; i++)
        {
            if (dshoten[i].Trim().Length > max)
                max = dshoten[i].Trim().Length;
        }

        int dem = 0;
        for (int i = 0; i < length; i++)
        {
            if (dshoten[i].Trim().Length == max)
                dem++;
        }

        string[] kq = new string[dem];
        int j = 0;
        for (int i = 0; i < length; i++)
        {
            if (dshoten[i].Trim().Length == max)
            {
                kq[j] = dshoten[i];
                j++;
            }
        }
        return kq;
    }

    // Tim ho ten ngan nhat
    static string[] TimHTNganNhat()
    {
        int min = dshoten[0].Trim().Length;
        for (int i = 1; i < length; i++)
        {
            if (dshoten[i].Trim().Length < min)
                min = dshoten[i].Trim().Length;
        }

        int dem = 0;
        for (int i = 0; i < length; i++)
        {
            if (dshoten[i].Trim().Length == min)
                dem++;
        }

        string[] kq = new string[dem];
        int j = 0;
        for (int i = 0; i < length; i++)
        {
            if (dshoten[i].Trim().Length == min)
            {
                kq[j] = dshoten[i];
                j++;
            }
        }
        return kq;
    }

    // Sap xep danh sach tang theo ho
    static void SapXepDSTangTheoHo()
    {
        for (int i = 0; i < length - 1; i++)
        {
            for (int j = i + 1; j < length; j++)
            {
                if (string.Compare(LayHo(dshoten[i]), LayHo(dshoten[j]), true) > 0)
                {
                    string tam = dshoten[i];
                    dshoten[i] = dshoten[j];
                    dshoten[j] = tam;
                }
            }
        }
    }

    // Sap xep danh sach giam theo ten
    static void SapXepDSGiamTheoTen()
    {
        for (int i = 0; i < length - 1; i++)
        {
            for (int j = i + 1; j < length; j++)
            {
                if (string.Compare(LayTen(dshoten[i]), LayTen(dshoten[j]), true) < 0)
                {
                    string tam = dshoten[i];
                    dshoten[i] = dshoten[j];
                    dshoten[j] = tam;
                }
            }
        }
    }

}