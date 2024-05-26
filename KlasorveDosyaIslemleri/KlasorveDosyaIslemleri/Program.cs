using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
class Program
{
    static void Main()
    {
        OperationFolderFiles operationFolderFiles = new OperationFolderFiles();
        while (true)
        {
            Console.Clear();
            int operation = -1;
            Console.Write("0 --> Uygulamayı Kapatma   1 --> Klasör Oluşturma   2 --> Klasör Silme   3 --> Klasör Bul\n4 --> Dosya Oluşturma   5 --> Dosya Silme   6 --> Dosya Bul\n7 --> Dosyaya Veri Yazma   8 --> Dosyadan Veri Okuma   9 --> Dosyayı Temizleme\nLütfen yapmak istediğiniz işlemi giriniz: ");
            try
            {
                operation = int.Parse(Console.ReadLine());
                Console.Clear();
                if (operation == 0)
                {
                    Console.Write("Uygulama kapatıldı!");
                    Console.ReadKey();
                    break;
                }
                else if (operation == 1)
                {
                    Console.WriteLine(">>>>>>>>  Klasör Oluşturma  <<<<<<<<\n---------------------------------------");
                    Console.Write("Lütfen, en sonda ismi olmak üzere oluşturmak istediğiniz klasörün yolunu giriniz: ");
                    operationFolderFiles.CreateFolder(Console.ReadLine());
                }
                else if (operation == 2)
                {
                    Console.WriteLine(">>>>>>>>    Klasör Silme   <<<<<<<<\n----------------------------------------");
                    Console.Write("Lütfen, en sonda ismi olmak üzere silmek istediğiniz klasörün yolunu giriniz: ");
                    operationFolderFiles.DeleteFolder(Console.ReadLine());
                }
                else if (operation == 3)
                {
                    Console.WriteLine(">>>>>>>>     Klasör Bul    <<<<<<<<\n----------------------------------------");
                    Console.Write("Lütfen, en sonda ismi olmak üzere bulmak istediğiniz klasörün yolunu giriniz: ");
                    operationFolderFiles.FindFolder(Console.ReadLine());
                }
                else if (operation == 4)
                {
                    Console.WriteLine(">>>>>>>>  Dosya Oluşturma  <<<<<<<<\n---------------------------------------");
                    Console.Write("Lütfen, en sonda ismi ve özelliği olmak üzere oluşturmak istediğiniz dosyanın yolunu giriniz: ");
                    operationFolderFiles.CreateFile(Console.ReadLine());
                }
                else if (operation == 5)
                {
                    Console.WriteLine(">>>>>>>>    Dosya Silme    <<<<<<<<\n----------------------------------------");
                    Console.Write("Lütfen, en sonda ismi ve özelliği olmak üzere silmek istediğiniz dosyanın yolunu giriniz: ");
                    operationFolderFiles.DeleteFile(Console.ReadLine());
                }
                else if (operation == 6)
                {
                    Console.WriteLine(">>>>>>>>     Dosya Bul     <<<<<<<<\n----------------------------------------");
                    Console.Write("Lütfen, en sonda ismi ve özelliği olmak üzere bulmak istediğiniz dosyanın yolunu giriniz: ");
                    operationFolderFiles.FindFile(Console.ReadLine());
                }
                else if (operation == 7)
                {
                    Console.WriteLine(">>>>>>>>   Dosyaya Veri Yazma   <<<<<<<<\n----------------------------------------");
                    Console.Write("Lütfen, en sonda ismi ve özelliği olmak üzere veri eklemek istediğiniz dosyanın yolunu giriniz: ");
                    operationFolderFiles.TextWriterToFile(Console.ReadLine());
                }
                else if (operation == 8)
                {
                    Console.WriteLine(">>>>>>>>   Dosyadan Veri Okuma   <<<<<<<<\n----------------------------------------");
                    Console.Write("Lütfen, en sonda ismi ve özelliği olmak üzere verisini okumak istediğiniz dosyanın yolunu giriniz: ");
                    operationFolderFiles.TextReaderToFile(Console.ReadLine());
                }
                else if (operation == 9)
                {
                    Console.WriteLine(">>>>>>>>   Dosyayı Temizleme   <<<<<<<<\n----------------------------------------");
                    Console.Write("Lütfen, en sonda ismi ve özelliği olmak üzere verisini temizlemek istediğiniz dosyanın yolunu giriniz: ");
                    operationFolderFiles.TextClearToFile(Console.ReadLine());
                }
                else
                {
                    Console.Write("Yanlış seçim! Devam etmek için klavyeden bir tuşa basınız!");
                    Console.ReadKey();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Console.Write("Devam etmek için klavyeden bir tuşa basınız!"); Console.ReadKey(); }
        }
    }
}

class OperationFolderFiles
{
    public OperationFolderFiles() { }
    public void CreateFolder(string klasorYolu)
    {
        if (klasorYolu == string.Empty)
            return;
        string mesaj = string.Empty;
        if (!Directory.Exists(klasorYolu))
            Directory.CreateDirectory(klasorYolu);
        else
            mesaj = "Uygulama işleme hazır durumdadır.";
        Console.Write(mesaj + "Devam etmek için klavyeden bir tuşa basınız!");
        Console.ReadKey();
    }
    public void DeleteFolder(string klasorYolu)
    {
        if (klasorYolu == string.Empty)
            return;
        string mesaj = string.Empty;
        if (Directory.Exists(klasorYolu))
        {
            try
            {
                Directory.Delete(klasorYolu);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        else
            mesaj = "Klasör bulunamadı!";
        Console.Write(mesaj + "Devam etmek için klavyeden bir tuşa basınız!");
        Console.ReadKey();
    }
    public void FindFolder(string klasorYolu)
    {
        if (klasorYolu == string.Empty)
            return;
        string mesaj = string.Empty;
        if (Directory.Exists(klasorYolu))
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(klasorYolu);
            Console.WriteLine("Tam adı: " + directoryInfo.FullName + "\nDosya ismi: " + directoryInfo.Name + "\nDosya içeriği: " + directoryInfo.Attributes + "\nBulunduğu disk: " + directoryInfo.Root);
        }
        else
        {
            mesaj = "Klasör bulunamadı!";
        }
        Console.Write(mesaj + "Devam etmek için klavyeden bir tuşa basınız!");
        Console.ReadKey();
    }

    public void CreateFile(string dosyaYolu)
    {
        if (dosyaYolu == string.Empty)
            return;
        string mesaj = string.Empty;
        if (!File.Exists(dosyaYolu))
            File.Create(dosyaYolu);
        else
            mesaj = "Uygulama işleme hazır durumdadır.";
        Console.Write(mesaj + "Devam etmek için klavyeden bir tuşa basınız!");
        Console.ReadKey();
    }
    public void DeleteFile(string dosyaYolu)
    {
        if (dosyaYolu == string.Empty)
            return;
        string mesaj = string.Empty;
        if (File.Exists(dosyaYolu))
        {
            try
            {
                File.Delete(dosyaYolu);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        else
            mesaj = "Dosya bulunamadı!";
        Console.Write(mesaj + "Devam etmek için klavyeden bir tuşa basınız!");
        Console.ReadKey();
    }
    public void FindFile(string dosyaYolu)
    {
        if (dosyaYolu == string.Empty)
            return;
        string mesaj = string.Empty;
        if (File.Exists(dosyaYolu))
        {
            FileInfo fileInfo = new FileInfo(dosyaYolu);
            Console.WriteLine("Tam adı: " + fileInfo.FullName + "\nDosya ismi: " + fileInfo.Name + "\nOluşturulma tarihi: " + fileInfo.CreationTime + "\nBulunduğu klasör ismi: " + fileInfo.DirectoryName);
        }
        else
        {
            mesaj = "Dosya bulunamadı!";
        }
        Console.Write(mesaj + "Devam etmek için klavyeden bir tuşa basınız!");
        Console.ReadKey();
    }
    public void TextWriterToFile(string dosyaYolu)
    {
        if (dosyaYolu == string.Empty)
            return;
        if (File.Exists(dosyaYolu))
        {
            using(FileStream fs =  new FileStream(dosyaYolu, FileMode.Append, FileAccess.Write))
            {
                Console.Write("Lütfen kaydetmek istediğiniz veriyi giriniz: ");
                string _veri = Console.ReadLine();
                if (_veri == string.Empty)
                {
                    Console.Write("Boş veri eklenemez! Devam etmek için klavyeden bir tuşa basınız.");
                }
                else
                {
                    byte[] veri = Encoding.UTF8.GetBytes(_veri);
                    fs.Write(veri, 0, veri.Length);
                    fs.Close();
                    Console.Write("Devam etmek için klavyeden bir tuşa basınız!");
                }
            }
        }
        else
        {
            Console.WriteLine("Dosya bulunamadı! Devam etmek için klavyeden bir tuşa basınız.");
        }
        Console.ReadKey();
    }
    public void TextReaderToFile(string dosyaYolu)
    {
        if (dosyaYolu == string.Empty)
            return;
        if (File.Exists(dosyaYolu))
        {
            using (FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024];

                while (fs.Read(buffer, 0, buffer.Length) > 0)
                {
                    Console.Write(Encoding.UTF8.GetString(buffer));
                }
            }
        }
        else
        {
            Console.WriteLine("Dosya bulunamadı! Devam etmek için klavyeden bir tuşa basınız.");
        }
        Console.ReadKey();
    }
    public void TextClearToFile(string dosyaYolu)
    {
        if (dosyaYolu == string.Empty)
            return;
        if (File.Exists(dosyaYolu))
        {
            using (FileStream fs = new FileStream(dosyaYolu, FileMode.Truncate))
            {
                
            }
            Console.WriteLine("Devam etmek için klavyeden bir tuşa basınız!");
        }
        else
        {
            Console.WriteLine("Dosya bulunamadı! Devam etmek için klavyeden bir tuşa basınız.");
        }
        Console.ReadKey();
    }
}