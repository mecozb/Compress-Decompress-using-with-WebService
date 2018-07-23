using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using DosyaZipleDonustur.webReferans;
using System.Web.Services;
using System.Web;
using System.Diagnostics;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Spire.Doc;

namespace DosyaZipleDonustur
{
    class Program
    {

        static void Main(string[] args)
        {
            // Ziple();  
             //MultiZiple();
           // Unzip();
        }

        static void Ziple()
        {
            string inputPath = "C:/Users/Administrator/Desktop/metinDeneme.docx";


            Spire.Doc.Document document = new Spire.Doc.Document();
            document.LoadFromFile(inputPath);

            //Convert Word to PDF  
            document.SaveToFile("metin.PDF", FileFormat.PDF);
            byte[] array = File.ReadAllBytes("metin.PDF");

            webReferans.WebService1 ws = new webReferans.WebService1();
            byte[] zipByteArray = ws.ZipThat("metin.pdf", array);
            File.WriteAllBytes("C:/Users/Administrator/Desktop/test.zip", zipByteArray);

            Console.WriteLine("İşlem Başarılı .");
            Console.ReadLine();
        }

        static void MultiZiple()
        {
            string inputPath1 = "C:/Users/Administrator/Desktop/metinDeneme.docx";
            string inputPath2 = "C:/Users/Administrator/Desktop/metinDeneme2.docx";

            Spire.Doc.Document doc1 = new Spire.Doc.Document();
            Spire.Doc.Document doc2 = new Spire.Doc.Document();

            doc1.LoadFromFile(inputPath1);
            doc2.LoadFromFile(inputPath2);

            doc1.SaveToFile("metin1.PDF", FileFormat.PDF);
            doc2.SaveToFile("metin2.PDF", FileFormat.PDF);

            byte[] metin1_Array = File.ReadAllBytes("metin1.PDF");
            byte[] metin2_Array = File.ReadAllBytes("metin2.PDF");

            webReferans.WebService1 ws = new webReferans.WebService1();

            byte[] multiZipArray = ws.ZipMulti("metin1.PDF", "metin2.PDF", metin1_Array, metin2_Array);

            File.WriteAllBytes("C:/Users/Administrator/Desktop/testMultiZip.zip", multiZipArray);

        }

        static void Unzip()
        {
            //string startPath = "C:/Users/Administrator/Desktop/start";
            //string zipPath = "C:/Users/Administrator/Desktop/testMultiZip.zip";
            //string extractPath = "C:/Users/Administrator/Desktop/extract";

            //System.IO.Compression.ZipFile.CreateFromDirectory(startPath, zipPath);
            //System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);

            String ZipPath = "C:/Users/Administrator/Desktop/testMultiZip.zip";
            String extractPath = "C:/Users/Administrator/Desktop/extract";
            ZipFile.ExtractToDirectory(ZipPath, extractPath);
        }

    }
}
