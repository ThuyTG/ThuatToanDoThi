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
                Console.WriteLine("8. Chuyển đổi: Danh sách cạnh() --> Danh sách kề()");
                Console.WriteLine("9. Chuyển đổi: Danh sách kề --> Danh sách cạnh");
                Console.WriteLine("10. Chuyển đổi: Ma trận kề --> Danh sách kề");
                Console.WriteLine("11. Chuyển đổi: Ma trận kề --> Danh sách cạnh");
                Console.WriteLine("12. Đồ thị chuyển vị");
                Console.WriteLine("13. Nhập và xuất danh sách cạnh (Có Trọng Số)");
                Console.WriteLine("14. Danh sách cạnh có trọng số: tính độ dài trung bình của cạnh và lấy ra các cạnh có trọng số lớn nhất");
                Console.WriteLine("15. Chuyển đổi: Danh sách cạnh --> Ma trận kề");
                Console.WriteLine("16. Chuyển đổi: Danh sách kề --> Ma trận kề");
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
                        edgeList2.PrintDegreeOfedges(fileOut);
                        break;

                    // ============ BUỔI 2 ============
                    case 8:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\Canh2Ke.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\Canh2Ke.OUT";
                        EdgeList edgeList3 = new EdgeList();
                        edgeList3.Convert_EdgeList_To_AdjecencyList(fileIn, fileOut);
                        break;
                    case 9:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\Ke2Canh.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\Ke2Canh.OUT";
                        AdjecencyList list3 = new AdjecencyList();
                        list3.Convert_AdjecencyList_To_EdgeList(fileIn, fileOut);
                        break;
                    case 10:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\MaTranKe2DSKe.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\MaTranKe2DSKe.OUT";
                        AdjecencyMatrix graph_4 = new AdjecencyMatrix();
                        graph_4.Convert_AdjecencyMatrix_To_AdjecencyList(fileIn, fileOut);
                        break;
                    case 11:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\MaTranKe2DSCanh.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\MaTranKe2DSCanh.OUT";
                        AdjecencyMatrix graph_5 = new AdjecencyMatrix();
                        graph_5.Convert_AdjecencyMatrix_To_EdgeList(fileIn, fileOut);
                        break;
                    case 12:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\DSKe2Canh.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\ChuyenVi.OUT";
                        AdjecencyList reverseGraph = new AdjecencyList();
                        reverseGraph.Reverse_Graph_AdjecencyList(fileIn, fileOut);
                        break;
                    case 13:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\TrungBinhCanh.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\TrungBinhCanh.OUT";
                        EdgeWeightedList weightedList = new EdgeWeightedList();
                        weightedList.Read_EdgeWeightedList(fileIn);
                        weightedList.Print_EdgeWeightedList(fileOut);
                        break;
                    case 14:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\TrungBinhCanh.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\TrungBinhCanh.OUT";
                        EdgeWeightedList weightedList1 = new EdgeWeightedList();
                        weightedList1.Read_EdgeWeightedList(fileIn);
                        weightedList1.Print_EdgeWeightedList_To_File(fileOut);
                        break;
                    case 15:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\DSCanh2MTKe.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\DSCanh2MTKe.OUT";
                        EdgeList edgeList4 = new EdgeList();
                        edgeList4.Convert_EdgeList_To_AdjecencyMatrix(fileIn, fileOut);
                        break;
                    case 16:
                        fileIn = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\DSK2MTKe.INP";
                        fileOut = @"D:\Study\HUFLIT\Nam 2\HK2\ThuatToanDoThi\ThucHanh\Buoi2\DSK2MTKe.OUT";
                        AdjecencyList list4 = new AdjecencyList();
                        list4.Convert_AdjecencyList_To_AdjecencyMatrix(fileIn, fileOut);
                        break;
                }
            } while (choice != 0);            
        }
    }
}
