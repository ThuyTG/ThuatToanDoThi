using System;
using System.Collections;
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
                        if (arr[j] == "") break;
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

        // ======= Buổi 3 ========
        public void Print_BFS(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            bool[] visited = new bool[n + 1];
            int[] pre = new int[n + 1];
            Console.Write("Nhập số đỉnh bắt đầu duyệt: ");
            int start = int.Parse(Console.ReadLine());
            sw.WriteLine($"Đỉnh bắt đầu: {start}");
            List<int> dsBFS = BFS(start,ref visited, ref pre);
            Console.WriteLine("BFS: ");
            sw.WriteLine("BFS: ");
            Console.Write(start + " ");
            sw.Write(start + " ");
            for(int i = 1; i < dsBFS.Count; i++)
            {
                Console.Write(dsBFS[i] + " ");
                sw.Write(dsBFS[i] + " ");
            }
            Console.WriteLine();
            sw.Close();
        }
        public List<int> BFS(int start, ref bool[] visitedList, ref int[] pre)
        {
            List<int> dsBFS = new List<int>();
            Queue<int> q = new Queue<int>();
            visitedList[start] = true;
            q.Enqueue(start);
            dsBFS.Add(start);
            pre[start] = -1;
            while(q.Count > 0)
            {
                int u = q.Dequeue();
                foreach(int ke in v[u])
                {
                    if (visitedList[ke] == true) continue;
                    else
                    {
                        visitedList[ke] = true;
                        q.Enqueue(ke);
                        dsBFS.Add(ke);
                        pre[ke] = u;
                    }
                }
            }
            return dsBFS;
        }

        public void Input_DSLienThong(string fileIn, out int start)
        {
            StreamReader sr = new StreamReader(fileIn);
            string line = sr.ReadLine();
            string[] arr = line.Split(' ');
            this.n = int.Parse(arr[0]);

            start = int.Parse(arr[1]);
            v = new LinkedList<int>[n + 1];
            while(sr.EndOfStream == false)
            {
                for(int i = 1; i < this.v.Length; i++)
                {
                    line = sr.ReadLine();
                    arr = line.Split(' ');
                    v[i] = new LinkedList<int>();
                    for(int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == "") break;
                        v[i].AddLast(int.Parse(arr[j]));
                    }
                }
            }
            sr.Close();
        }
        

        public void Print_DSLienThong(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int start;
            Input_DSLienThong(fileIn, out start);
            bool[] visited = new bool[n + 1];
            int[] pre = new int[n + 1];
            List<int> dsLienThong = BFS(start, ref visited, ref pre);
            Console.WriteLine($"Số lượng đỉnh liên thông: {dsLienThong.Count - 1}");
            sw.WriteLine($"Số lượng đỉnh liên thông: {dsLienThong.Count - 1}");
            for (int i = 1; i < dsLienThong.Count; i++)
            {
                if (dsLienThong[i] != start)
                {
                    Console.WriteLine(dsLienThong[i] + " ");
                    sw.WriteLine(dsLienThong[i] + " ");
                }
            }
            sw.Close();
        }

        public void Print_TimDuongDi(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int start, end;
            Input_TimDuongDi(fileIn, out start, out end);
            LinkedList<int> DuongDi = TimDuongDi(start, end);
            foreach (int t in DuongDi)
            {
                Console.Write(t + " ");
                sw.Write(t + " ");
            }
            Console.WriteLine();
            sw.Close();
        }
        public LinkedList<int> TimDuongDi(int start, int end)
        {
            LinkedList<int> path = new LinkedList<int>();
            bool[] visited = new bool[n + 1];
            int[] pre = new int[n + 1];
            List<int> ds = BFS(start, ref visited, ref pre);
            for(int i = end; i != -1; i = pre[i])
            {
                path.AddFirst(i);
            }
            return path;
        }
        public void Input_TimDuongDi(string fileIn, out int start, out int end)
        {
            StreamReader sr = new StreamReader(fileIn);
            string line = sr.ReadLine();
            string[] arr = line.Split(' ');
            this.n = int.Parse(arr[0]);

            start = int.Parse(arr[1]);
            end = int.Parse(arr[2]);
            v = new LinkedList<int>[n + 1];
            while (sr.EndOfStream == false)
            {
                for (int i = 1; i < this.v.Length; i++)
                {
                    line = sr.ReadLine();
                    arr = line.Split(' ');
                    v[i] = new LinkedList<int>();
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == "") break;
                        v[i].AddLast(int.Parse(arr[j]));
                    }
                }
            }
            sr.Close();
        }

        public void Print_KiemTraDoThiLienThong(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            AdjecencyListInput(fileIn);
            bool KetQua = KiemTraDoThiLienThong();
            if (KetQua)
            {
                Console.WriteLine("Đồ thị liên thông");
                sw.WriteLine("Đồ thị liên thông");
            }
            else
            {
                Console.WriteLine("Đồ thị không liên thông");
                sw.WriteLine("Đồ thị không liên thông");
            }
            sw.Close();
        }
        public bool KiemTraDoThiLienThong(bool isConnected = true)
        {
            bool[] visited = new bool[n + 1];
            int[] pre = new int[n + 1];

            List<int> DoThi = BFS(1, ref visited, ref pre);
            foreach(bool visit in visited)
            {
                if(visit == false)
                {
                    return isConnected = false;
                }
            }
            return isConnected;
        }

        public void DemSoMienLienThong(string fileIn, string fileOut)
        {
            AdjecencyListInput(fileIn);
            StreamWriter sw = new StreamWriter(fileOut);

            bool[] visited = new bool[n + 1];
            int[] pre = new int[n + 1];
            int cnt = 0;
            for(int i = 1; i < v.Length; i++)
            {
                if (visited[i] == false)
                {
                    cnt++;
                    BFS(i, ref visited, ref pre);
                }
            }
            Console.WriteLine(cnt);
            sw.WriteLine(cnt);
            sw.Close();
        }

        // ==== Buổi 4 ====
        public List<List<int>> MienLienThong(string fileIn)
        {
            AdjecencyListInput(fileIn);
            List<List<int>> dsMienLienThong = new List<List<int>>();
            bool[] visited = new bool[n + 1];
            int[] pre = new int[n + 1];
            int cnt = 0;
            for (int i = 1; i < v.Length; i++)
            {
                if (visited[i] == false)
                {
                    cnt++;
                    List<int> mienlienThong = BFS(i, ref visited, ref pre);
                    dsMienLienThong.Add(mienlienThong);
                }
            }
            return dsMienLienThong;
        }
        public void LietKeMienLienThong(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            List<List<int>> dsMienLienThong = MienLienThong(fileIn);
            Console.WriteLine("Số lượng miền liên thông: " + dsMienLienThong.Count);
            sw.WriteLine("Số lượng miền liên thông: " + dsMienLienThong.Count);
            foreach (List<int> ds in dsMienLienThong)
            {
                for(int i = 0; i < ds.Count; i++)
                {
                    Console.Write(ds[i] + " ");
                    sw.Write(ds[i] + " ");
                }
                Console.WriteLine();
                sw.WriteLine();
            }
            sw.Close();
        }

        public int SoMienLienThong()
        {
            bool[] visited = new bool[n + 1];
            int[] pre = new int[n + 1];
            int cnt = 0;
            for (int i = 1; i < v.Length; i++)
            {
                if (visited[i] == false)
                {
                    cnt++;
                    BFS(i, ref visited, ref pre);
                }
            }
            return cnt;

        }
        public bool KiemTraCanhCau(string fileIn)
        {
            int dinhBatDau, dinhKetThuc;
            Input_TimDuongDi(fileIn, out dinhBatDau, out dinhKetThuc);
            int countTruocXoa = SoMienLienThong();
            v[dinhBatDau].Remove(dinhKetThuc);
            v[dinhKetThuc].Remove(dinhBatDau);
            int countSauXoa = SoMienLienThong();
            if (countSauXoa > countTruocXoa) return true;
            return false;
        }
        public void InKiemTraCanhCau(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            bool KTCC = KiemTraCanhCau(fileIn);
            if (KTCC)
            {
                Console.WriteLine("YES");
                sw.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
                sw.WriteLine("NO");
            }
            sw.Close();
        }

        public bool KiemTraDinhKhop(string fileIn)
        {
            int dinhKiemTra;
            Input_DSLienThong(fileIn, out dinhKiemTra);
            int countTruocXoa = SoMienLienThong();
            v[dinhKiemTra].Clear();
            for(int i = 1; i < v.Length; i++)
            {
                if (v[i].Contains(dinhKiemTra))
                {
                    v[i].Remove(dinhKiemTra);
                }
            }
            int countSauXoa = SoMienLienThong();
            if(countSauXoa - countTruocXoa >= 2)
            {
                return true;
            }
            return false;
        }
        public void InKiemTraDinhKhop(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            bool KTDK = KiemTraDinhKhop(fileIn);
            if (KTDK)
            {
                Console.WriteLine("YES");
                sw.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
                sw.WriteLine("NO");
            }
            sw.Close();
        }
    }
}


