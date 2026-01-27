using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24dh113182_TruongGiaThuy
{
    // 24dh113182 - Trương Gia Thuỵ
    internal class AdjecencyMatrix
    {
        public int n { get; set; }
        public int[,] e { get; set; }

        
        
        public AdjecencyMatrix() {
            e = new int[0, 0];
        }
        public AdjecencyMatrix(int soDinh)
        {
            n = soDinh;
            e = new int[n+ 1,n+1];
        }
        
        // 1. Nhập xuất ma trận kề
        // 24dh113182 - Trương Gia Thuỵ
        public void AdjecencyMatrixInput(string file_input)
        {
            StreamReader sr = new StreamReader(file_input);

            // Số đỉnh
            n = int.Parse(sr.ReadLine());

            // Khởi tạo ma trận kề
            e = new int[n + 1, n + 1];
            while(sr.EndOfStream == false)
            {
                
                for (int i = 1; i < e.GetLength(0); i++)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(' ');
                    for (int j = 1; j < e.GetLength(1); j++)
                    {
                        e[i, j] = int.Parse(arr[j-1]);
                    }
                }
            }
            sr.Close();
        }
        public void AdjecencyMatrixOutput(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            for(int i = 1; i < e.GetLength(0); i++)
            {
                for(int j = 1; j < e.GetLength(1); j++)
                {
                    Console.Write(e[i, j] + " ");
                    sw.WriteLine(e[i, j] + " ");
                }
                Console.WriteLine();
                sw.WriteLine();
            }
            sw.Close();
        }

        // 2. In ra bậc của đỉnh trong ma trận kề
        // 24dh113182 - Trương Gia Thuỵ
        public void PrintDegreeOfVertices(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            sw.WriteLine("Số đỉnh: " + n);
            int soBac;
            for(int i = 1; i < e.GetLength(0); i++)
            {
                soBac = 0;
                for(int j = 1; j < e.GetLength(1); j++)
                {
                    if (e[i, j] == 1) soBac++;
                }
                Console.WriteLine("Bậc của đỉnh " + i + " là: " + soBac);
                sw.WriteLine("Bậc của đỉnh " + i + " là: " + soBac);
            }
            sw.Close();
        }

        // 3. In ra bậc vào và bậc ra của đỉnh trong ma trận kề có hướng
        // 24dh113182 - Trương Gia Thuỵ
        public void PrintDegreeDirectedGraphOfVertices(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            sw.WriteLine("Số đỉnh: " + n);
            int BacRa, BacVao;
            for(int i = 1; i <= n ; i++)
            {
                BacRa = BacVao = 0;
                
                // Bậc vào
                for(int row = 1; row < e.GetLength(0); row++)
                {
                    if (e[row, i] == 1) BacVao++;
                }
                // Bậc ra
                for(int column = 1; column < e.GetLength(1); column++)
                {
                    if (e[i, column] == 1) BacRa++;
                }
                Console.WriteLine($"Đỉnh {i}: Bậc vào: {BacVao} | Bậc ra: {BacRa}");
                sw.WriteLine($"Đỉnh {i}: Bậc vào: {BacVao} | Bậc ra: {BacRa}");
            }
            sw.Close();
        }

        // ============ BUỔI 2 ============
        public void Convert_AdjecencyMatrix_To_AdjecencyList(string fileIn, string fileOut)
        {
            AdjecencyMatrixInput(fileIn);
            int soDinh = this.n;
            AdjecencyList adj = new AdjecencyList(soDinh);
            for(int i = 1; i < adj.v.Count(); i++)
            {
                adj.v[i] = new LinkedList<int>();
            }
            for(int i = 1; i < e.GetLength(0); i++)
            {
                for(int j = 1; j < e.GetLength(1); j++)
                {
                    if (e[i, j] == 1) adj.v[i].AddLast(j);
                }
            }

            // Ma trận trước khi chuyển đổi
            Console.WriteLine("Ma trận trước khi chuyển đổi");
            AdjecencyMatrixInput(fileIn);

            // Ma trận sau khi chuyển đổi
            adj.Print_AdjecencyList_To_File(fileOut);
        }
        public void Convert_AdjecencyMatrix_To_EdgeList(string fileIn, string fileOut)
        {
            AdjecencyMatrixInput(fileIn);
            int soDinh = this.n;
            EdgeList list = new EdgeList(soDinh);

            for(int i = 1; i < e.GetLength(0); i++)
            {
                for(int j = 1; j < e.GetLength(1); j++)
                {
                    if (e[i, j] == 1)
                    {
                        int dinh1 = i;
                        int dinh2 = j;
                        Tuple<int, int> canh = new Tuple<int, int>(dinh1, dinh2);
                        bool checkDuplicate = list.CheckEdgeDuplicate(canh);
                        if (checkDuplicate == false) list.edges.AddLast(canh);
                    }
                }
            }
            list.edge = list.edges.Count();

            Console.WriteLine("Danh sách ma trận kề trước khi chuyển đổi");
            AdjecencyMatrixOutput(fileIn);
            Console.WriteLine("Sau khi chuyển đổi sang danh sách cạnh");
            list.Print_EdgeList_To_File(fileOut);   
        }
    }
}
