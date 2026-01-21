using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _24dh113182_TruongGiaThuy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            string fileIn, fileOut;
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            do
            {
                Console.WriteLine("/---------- DAY 1 ----------\"");
                Console.WriteLine("1. Nhập xuất danh sách ma trận kề (Bài 1)");
                Console.WriteLine("2. In bậc của các đỉnh ma trận kề đồ thị (Bài 1)");
                Console.WriteLine("3. In bậc vào và bậc ra của các đỉnh của đồ thị có hướng (Bài 2)");
                Console.WriteLine("4. Nhập xuất danh sách kề (Bài 3)");
                Console.WriteLine("5. In bậc của các đỉnh trong danh sách kề (Bài 3)");
                Console.WriteLine("6. Nhập xuất danh sách cạnh");
                Console.WriteLine("7. In bậc của các đỉnh trong danh sách cạnh");
                Console.WriteLine("0. Exit");

                Console.WriteLine("-------------------------------------------------");
                Console.Write("Nhập vào lựa chọn của bạn: ");
                choice = int.Parse(Console.ReadLine());
                
                switch (choice)
                {
                    // 24dh113182 - Trương Gia Thuỵ
                    case 1:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\AdjecencyMaTrix.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\AdjecencyMaTrix.OUT";
                        AdjecencyMatrix graph_1 = new AdjecencyMatrix();
                        graph_1.AdjecencyMatrixInput(fileIn);
                        graph_1.AdjecencyMatrixOutput(fileOut);
                        break;

                    // 24dh113182 - Trương Gia Thuỵ
                    case 2:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\AdjecencyMaTrix.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\AdjecencyMaTrix.OUT";
                        AdjecencyMatrix graph_2 = new AdjecencyMatrix();
                        graph_2.AdjecencyMatrixInput(fileIn);
                        graph_2.PrintDegreeOfVertices(fileOut);
                        break;

                    // 24dh113182 - Trương Gia Thuỵ
                    case 3:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\BacVaoRa.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\BacVaoRa.OUT";
                        AdjecencyMatrix graph_3 = new AdjecencyMatrix();
                        graph_3.AdjecencyMatrixInput(fileIn);
                        graph_3.PrintDegreeDirectedGraphOfVertices(fileOut);
                        break;

                    // 24dh113182 - Trương Gia Thuỵ
                    case 4:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\AdjecencyList.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\AdjecencyList.OUT";
                        AdjecencyList list = new AdjecencyList();
                        list.AdjecencyListInput(fileIn);
                        list.PrintAdjecencyList(fileOut);
                        break;

                    // 24dh113182 - Trương Gia Thuỵ
                    case 5:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\AdjecencyList.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\AdjecencyList.OUT";
                        AdjecencyList list2 = new AdjecencyList();
                        list2.AdjecencyListInput(fileIn);
                        list2.PrintDegreeOfVertices(fileOut);
                        break;

                    // 24dh113182 - Trương Gia Thuỵ
                    case 6:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\EdgeList.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\EdgeList.OUT";
                        EdgeList edgeList = new EdgeList();
                        edgeList.EdgeListInput(fileIn);
                        edgeList.EdgeListOutput(fileOut);
                        break;

                    // 24dh113182 - Trương Gia Thuỵ
                    case 7:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\EdgeList.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\EdgeList.OUT";
                        EdgeList edgeList2 = new EdgeList();
                        edgeList2.EdgeListInput(fileIn);
                        edgeList2.PrintDegreeOfEdges(fileOut);
                        break;

                    // ============ BUỔI 2 ============
                    case 8:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\Canh2Ke.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\Canh2Ke.OUT";
                        
                        break;
                    case 9:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\Ke2Canh.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\Ke2Canh.OUT";
                        
                        break;
                    case 10:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\MaTranKe2DSKe.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\MaTranKe2DSKe.OUT";
                        
                        break;
                    case 11:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\MaTranKe2DSCanh.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\MaTranKe2DSCanh.OUT";
                        
                        break;
                    case 12:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\MaTranKe2DSCanh.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\MaTranKe2DSCanh.OUT";
                        
                        break;
                    case 13:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\ChuyenVi.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\ChuyenVi.OUT";
                        
                        break;
                    case 14:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\TrungBinhCanh.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi1\TrungBinhCanh.OUT";
                        
                        break;
                }
            } while (choice != 0);            
        }
    }
}
