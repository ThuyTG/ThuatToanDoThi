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
                
                for (int i = 1; i <= n; i++)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue;
                    string[] arr = line.Trim().Split(' ');
                    for (int j = 1; j <= n; j++)
                    {
                        if(j - 1 < arr.Length) e[i, j] = int.Parse(arr[j - 1]);
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


        // ============ BUỔI 3 ============

        public int BacRaCuaDinh(int dinh)
        {
            int bacRa = 0;
            for (int column = 1; column < e.GetLength(1); column++)
            {
                if (e[dinh, column] == 1) bacRa++;
            }
            return bacRa;
        }
        public  int BacVaoCuaDinh(int dinh)
        {
            int bacVao = 0;
            for(int row = 1; row < e.GetLength(0); row++)
            {
                if (e[row, dinh] == 1) bacVao++;
            }
            return bacVao;
        }
        public void BonChua(string fileIn, string fileOut)
        {
            AdjecencyMatrixInput(fileIn);
            StreamWriter sw = new StreamWriter(fileOut);
            List<int> dsBonChua = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (BacRaCuaDinh(i) == 0 && BacVaoCuaDinh(i) > 0)
                {
                    dsBonChua.Add(i);
                }
            }
            sw.WriteLine($"Số lượng bồn chứa: {dsBonChua.Count}");
            Console.WriteLine($"Số lượng bồn chứa: {dsBonChua.Count}");
            if(dsBonChua.Count > 0)
            {
                foreach (int dinh in dsBonChua)
                {
                    Console.WriteLine(dinh);
                    sw.WriteLine(dinh);
                }
            }
            
            sw.Close();
        }


        // ============ BUỔI 6 ============
        // ------------- Bài 3 -------------
        public void FloydWarshall(int[,] dist, int[,] pre)
        {
            for(int i = 0; i < n + 1; i++)
            {
                for(int j = 0; j < n + 1; j++)
                {
                    if (e[i,j] != 0)
                    {
                        dist[i, j] = e[i, j];
                    }
                    else
                    {
                        dist[i, j] = int.MaxValue;
                    }
                }
                dist[i, i] = 0;
            }
            for(int k = 1; k < n + 1; k++)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    for (int j = 1; j < n + 1; j++)
                    {
                        if (dist[i, j] > dist[i, k] + dist[k, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            pre[i, j] = pre[k, j];
                        }
                }
                }
            }
            
        }

        public void Output_FloydWarshall(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            AdjecencyMatrixInput(fileIn);
            int[,] dist = new int[n + 1, n + 1];
            int[,] pre = new int[n + 1, n + 1];
            FloydWarshall(dist, pre);
            Console.WriteLine(n);
            sw.WriteLine(n);
            for(int i = 1; i < dist.GetLength(0); i++)
            {
                for(int j = 1; j < dist.GetLength(1); j++)
                {
                    Console.Write(dist[i, j] + " ");
                    sw.Write(dist[i, j] + " ");
                }
                Console.WriteLine();
                sw.WriteLine();
            }
            
            sw.Close();
        }

        // ------------- Bài 5 -------------
        public void FloyWarshallForBestCity(out int bestCity, out int bestValue, int[,] dist, int[,] pre)
        {
            bestCity = -1;
            bestValue = int.MaxValue;
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (e[i, j] != 0)
                    {
                        dist[i, j] = e[i, j];
                    }
                    else
                    {
                        dist[i, j] = int.MaxValue;
                    }
                }
                dist[i, i] = 0;
            }
            for (int k = 1; k < n + 1; k++)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    for (int j = 1; j < n + 1; j++)
                    {
                        if (dist[i, j] > dist[i, k] + dist[k, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            pre[i, j] = pre[k, j];
                        }
                    }
                }
            }
            for(int i = 1; i < n + 1; i++)
            {
                int maxDist = 0;
                for(int j = 1; j < n + 1; j++)
                {
                    maxDist = Math.Max(dist[i, j], maxDist);
                }
                if(maxDist < bestValue)
                {
                    bestCity = i;
                    bestValue = maxDist;
                }
            }
        }
        public void Output_BestCity(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int bestCity, bestValue;
            AdjecencyMatrixInput(fileIn);
            int[,] dist = new int[n + 1, n + 1];
            int[,] pre = new int[n + 1, n + 1];
            FloyWarshallForBestCity(out bestCity, out bestValue, dist, pre);
            Console.WriteLine(n);
            sw.WriteLine(n);
            for (int i = 1; i < dist.GetLength(0); i++)
            {
                for (int j = 1; j < dist.GetLength(1); j++)
                {
                    Console.Write(dist[i, j] + " ");
                    sw.Write(dist[i, j] + " ");
                }
                Console.WriteLine();
                sw.WriteLine();
            }
            Console.WriteLine($"Best city: {bestCity} have distance {bestValue}");
            sw.WriteLine($"Best city: {bestCity} have distance {bestValue}");
            sw.Close();
        }

        public int FindParent(int d, int[] parent)
        {
            if (parent[d] == d) return parent[d];
            return parent[d] = FindParent(parent[d], parent);
        }
        
        public int KruskalRoad(int[] parent, List<Tuple<int, int, int>> dsTree)
        {
            int total = 0;
            List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();
            for(int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }
            for(int i = 1; i <= n; i++)
            {
                for(int j = i + 1; j <= n; j++)
                {
                    if (e[i, j] != 0)
                    {
                        edges.Add(new Tuple<int, int, int>(i, j, e[i, j]));
                    }
                }
            }
            edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));
            
            foreach(Tuple<int, int, int> edge in edges)
            {
                int dinh1 = edge.Item1;
                int dinh2 = edge.Item2;
                int trongSo = edge.Item3;

                int parent_dinh1 = FindParent(dinh1, parent);
                int parent_dinh2 = FindParent(dinh2, parent);
                if(parent_dinh1 != parent_dinh2)
                {
                    total += trongSo;
                    dsTree.Add(edge);
                    parent[parent_dinh1] = parent_dinh2;
                }
            }
            return total;
        }
        public void Output_Kruskal_Road(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            AdjecencyMatrixInput(fileIn);
            int[] parent = new int[n + 1];
            List<Tuple<int, int, int>> dsTree = new List<Tuple<int, int, int>>();
            int totalCost = KruskalRoad(parent, dsTree);
            Console.WriteLine(totalCost);
            sw.WriteLine(totalCost);
            sw.Close();
        }

        //  ============ BUỔI 8 ============
    }
}
