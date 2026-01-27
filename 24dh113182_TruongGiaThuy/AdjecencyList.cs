using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24dh113182_TruongGiaThuy
{
    // 24dh113182 - Trương Gia Thuỵ
    internal class AdjecencyList
    {
        public int n; // Số đỉnh
        public LinkedList<int>[] v { get; set; } // Danh sách kề

        //public int N { get; set; }
        //public LinkedList<int>[] V { get { return v; }  set { v = value; } }


        public AdjecencyList() {
            this.v = new LinkedList<int>[0];
        }
        public AdjecencyList(int soDinh)
        {
            this.n = soDinh;
            this.v = new LinkedList<int>[n + 1];
        }
        // 1. Nhập xuất danh sách kề
        // 24dh113182 - Trương Gia Thuỵ
        public void AdjecencyListInput(string file_input)
        {
            StreamReader sr = new StreamReader(file_input);
            // Số đỉnh
            n = int.Parse(sr.ReadLine());
            v = new LinkedList<int>[n+1];            

            while (sr.EndOfStream == false)
            {
                for (int i = 1; i < v.Length; i++)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(' ');
                    v[i] = new LinkedList<int>();

                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == "" || arr.Length == 1) break;
                        v[i].AddLast(int.Parse(arr[j]));
                    }
                }
            }
            sr.Close();
        }

        // 24dh113182 - Trương Gia Thuỵ
        public void PrintAdjecencyList(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            sw.WriteLine("Số đỉnh: " + n);
            for(int i = 1; i < v.Length; i++)
            {
                sw.Write("Đỉnh " + i + ": ");
                Console.Write("Đỉnh " + i + ": ");
                for (int j = 0; j < v[i].Count; j++)
                {
                    Console.Write(v[i].ElementAt(j) + "--> ");
                    sw.Write(v[i].ElementAt(j) + "-->    ");
                }
                Console.WriteLine("null");
                sw.WriteLine("null");
                Console.WriteLine();
                sw.WriteLine();
            }
            sw.Close();
        }

        // 2. In bậc của các đỉnh trong danh sách kề
        // 24dh113182 - Trương Gia Thuỵ
        public void PrintDegreeOfVertices(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            for(int i = 1; i < v.Length; i++)
            {
                Console.WriteLine($"Bậc của đỉnh {i}: {v[i].Count()}");
                sw.WriteLine($"Bậc của đỉnh {i}: {v[i].Count()}");
            }
            sw.Close();
        }


        // ============ BUỔI 2 ============
        public void Print_AdjecencyList_To_File(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            sw.WriteLine("Số đỉnh: " + n);

            for(int i = 1; i < v.Length; i++)
            {
                LinkedList<int> ds = this.v[i];
                for(int j = 0; j < ds.Count; j++)
                {
                    Console.Write(ds.ElementAt(j)+ " ");
                    sw.Write(ds.ElementAt(j) + " ");
                }
                Console.WriteLine();
                sw.WriteLine();
            }
            sw.Close();
        }

        public void Convert_AdjecencyList_To_EdgeList(string fileIn, string fileOut)
        {
            AdjecencyListInput(fileIn);
            int soDinh = this.n;
            EdgeList edgeList = new EdgeList(soDinh);

            for(int i = 1; i < this.v.Length; i++)
            {
                // lay ra v[i]
                LinkedList<int> t = v[i];
                    // lay ra n dinh + check duplicate
                for(int j = 0; j < t.Count; j++)
                {
                    int dinhGoc = i;
                    int dinhCon = t.ElementAt(j);
                    Tuple<int, int> canh = new Tuple<int, int>(dinhGoc, dinhCon);
                    bool checkDuplicate = edgeList.CheckEdgeDuplicate(canh);
                    if (checkDuplicate == false) edgeList.edges.AddLast(canh);
                }
            }

            // soCanh = count cua list v
            edgeList.edge = edgeList.edges.Count();

            // In ra trc khi chuyen
            PrintAdjecencyList(fileIn);
            Console.WriteLine("-------------------------------------------");
            // Sau khi chuyen
            edgeList.Print_EdgeList_To_File(fileOut);
        }

        public void Convert_AdjecencyList_To_AdjecencyMatrix(string fileIn, string fileOut)
        {
            AdjecencyListInput(fileIn);
            int soDinh = this.n;
            AdjecencyMatrix adjMatrix = new AdjecencyMatrix(n);
            int[,] matrix = new int[n + 1, n + 1];
            for(int i = 1; i <= adjMatrix.n; i++)
            {
                LinkedList<int> list = v[i];
                for(int j = 0; j < list.Count; j++)
                {
                    int dinh = list.ElementAt(j);
                    if (matrix[i, dinh] == 0)
                    {
                        matrix[i, dinh] = 1;
                    }
                }
            }
            adjMatrix.e = matrix;
            adjMatrix.AdjecencyMatrixOutput(fileOut);
        }

        public void Reverse_Graph_AdjecencyList(string fileIn, string fileOut)
        {
            AdjecencyListInput(fileIn);
            AdjecencyList reverse_v = new AdjecencyList(this.n);
            reverse_v.n = this.n;

            for(int i = 0; i < reverse_v.v.Length; i++)
            {
                reverse_v.v[i] = new LinkedList<int>();
            }
            for(int i = 1; i < v.Length; i++)
            {
                LinkedList<int> item = this.v[i];
                if(item != null)
                {
                    for (int j = 0; j < item.Count; j++)
                    {
                        int dinh = item.ElementAt(j);
                        reverse_v.v[dinh].AddLast(i);
                    }
                }
                
            }

            Console.WriteLine("Danh sách kề trước khi chuyển vị");
            PrintAdjecencyList(fileOut);

            Console.WriteLine("Danh sách sau chuyển vị");
            reverse_v.Print_AdjecencyList_To_File(fileOut);
        }
    }
}


