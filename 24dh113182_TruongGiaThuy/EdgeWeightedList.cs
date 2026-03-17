using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24dh113182_TruongGiaThuy
{
    internal class EdgeWeightedList
    {
        public int soDinh { get; set; }
        public int soCanh { get; set; }
        public LinkedList<Tuple<int, int, int>> edges { get; set; }


        public EdgeWeightedList()
        {
            this.edges = new LinkedList<Tuple<int, int, int>>();
        }
        public void Read_EdgeWeightedList(string fileIn)
        {
            StreamReader sr = new StreamReader(fileIn);
            string[] line = sr.ReadLine().Split(' ');
            soDinh = int.Parse(line[0]);
            soCanh = int.Parse(line[1]);
            while(sr.EndOfStream == false)
            {
                line = sr.ReadLine().Split(' ');
                int dinh1 = int.Parse(line[0]);
                int dinh2 = int.Parse(line[1]);
                int trongSo = int.Parse(line[2]);
                edges.AddLast(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
            }
            sr.Close();
        }
        public void Print_EdgeWeightedList(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            sw.WriteLine($"{soDinh} {soCanh}");
            Console.WriteLine($"{soDinh} {soCanh}");
            foreach (Tuple<int, int, int> e in edges)
            {
                Console.WriteLine($"{e.Item1} {e.Item2} {e.Item3}");
                sw.WriteLine($"{e.Item1} {e.Item2} {e.Item3}");
            }
            sw.Close();
        }
        public float Average_EdgeWeight()
        {
            int sum = 0;
            foreach(Tuple<int, int, int> e in edges)
            {
                sum += e.Item3;
            }
            return (float)sum / soCanh;
        }
        public int GetMaxWeight()
        {
            int max = int.MinValue;
            foreach (Tuple<int, int, int> e in edges)
            {
                if(e.Item3 > max)
                {
                    max = e.Item3;
                }
            }
            return max;
        }
        public List<Tuple<int, int, int>> GetListEdgeMaxWeigth()
        {
            List<Tuple <int, int, int>> ds = new List<Tuple<int, int, int>>();
            int max = GetMaxWeight();
            int i = 0;
            foreach(Tuple<int, int, int> e in edges)
            {
                if(e.Item3 == max)
                {
                    Tuple<int,int, int> newMax =  new Tuple<int, int, int>(e.Item1, e.Item2, e.Item3);
                    ds.Add(newMax);
                    i++;
                }
            }
            return ds;
        }

        public void Print_EdgeWeightedList_To_File(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            float avg = Average_EdgeWeight();
            Console.WriteLine($"{avg}");
            sw.WriteLine($"{avg}");
            List<Tuple<int, int, int>> list = GetListEdgeMaxWeigth();
            for(int i = 0; i < list.Count; i++)
            {
                Tuple<int, int, int> e = list.ElementAt(i);
                Console.WriteLine($"{e.Item1} {e.Item2} {e.Item3}");
                sw.WriteLine($"{e.Item1} {e.Item2} {e.Item3}");
            }
            Console.WriteLine($"Số lượng cạnh max: {list.Count}");
            sw.Close();
        }


        // ============ BUỔI 6 ============

        // ------------- Bài 1 -------------
        public void Input_TimDuongDiNganNhat(string fileIn, out int start, out int end)
        {
            StreamReader sr = new StreamReader(fileIn);
            string line = sr.ReadLine();
            string[] arr = line.Trim().Split(' ');
            soDinh = int.Parse(arr[0]);
            soCanh = int.Parse(arr[1]);
            start = int.Parse(arr[2]);
            end = int.Parse(arr[3]);
            while(sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                arr = line.Trim().Split(' ');
                int dinh1 = int.Parse(arr[0]);
                int dinh2 = int.Parse(arr[1]);
                int trongSo = int.Parse(arr[2]);
                edges.AddLast(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
            }
            sr.Close();
        }

        public void Output_TimDuongDiNganNhat(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int start, end;
            Input_TimDuongDiNganNhat(fileIn, out start, out end);
            int[] dist = new int[soDinh + 1];
            bool[] processed = new bool[soDinh + 1];
            int[] pre = new int[soDinh + 1];
            
            Dijkstra(start, dist, processed, pre);

            Console.WriteLine("Min path using Dijkstra: " + dist[end]);
            sw.WriteLine("Min path using Dijkstra: " + dist[end]);
            LinkedList<int> path = new LinkedList<int>();
            for(int i = end; i != -1; i = pre[i])
            {
                path.AddFirst(i);
            }
            for(int i = 0; i < path.Count; i++)
            {
                Console.Write(path.ElementAt(i) + " ");
                sw.Write(path.ElementAt(i) + " ");
            }
            Console.WriteLine();
            sw.Close();
        }

        public int TimDinhCoMinDist(int[] dist, bool[] processed)
        {
            int min_value = int.MaxValue;
            int min_index = -1;
            for (int i = 1; i < dist.Length; i++)
            {
                if (processed[i] == false && dist[i] <= min_value)
                {
                    min_value = dist[i];
                    min_index = i;
                }
            }
            return min_index;
        }
        public void Dijkstra(int start, int[] dist, bool[] processed, int[] pre)
        {
            for (int i = 0; i < soDinh + 1; i++)
            {
                dist[i] = int.MaxValue;
                processed[i] = false;
                pre[i] = -1;
            }
            dist[start] = 0;
            for(int dinh = 1; dinh < soDinh + 1; dinh++)
            {
                int a = TimDinhCoMinDist(dist, processed);
                processed[a] = true;
                foreach(Tuple<int, int, int> t in edges)
                {
                    int dinh1 = t.Item1;
                    int dinh2 = t.Item2;
                    int trongSo = t.Item3;
                    if(dinh1 == a) 
                    {
                        int b = dinh2;
                        int weightAtoB = trongSo;
                        if (dist[a] != int.MaxValue && processed[b] == false && dist[b] > dist[a] + weightAtoB)
                        {
                            dist[b] = dist[a] + weightAtoB;
                            pre[b] = a;
                        }
                    }
                    if(dinh2 == a)
                    {
                        int b = dinh1;
                        int weightAtoB = trongSo;
                        if (dist[a] != int.MaxValue && processed[b] == false && dist[b] > dist[a] + weightAtoB)
                        {
                            dist[b] = dist[a] + weightAtoB;
                            pre[b] = a;
                        }
                    }
                }
            }
        } 

        // ------------- Bài 2 -------------
        public void Input_TimDuongNganNhatQuaTrungGian(string fileIn, out int start, out int end, out int intermediate)
        {
            StreamReader sr = new StreamReader(fileIn);
            string line = sr.ReadLine();
            string[] arr = line.Trim().Split(' ');
            soDinh = int.Parse(arr[0]);
            soCanh = int.Parse(arr[1]);
            start = int.Parse(arr[2]);
            end = int.Parse(arr[3]);
            intermediate = int.Parse(arr[4]);
            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                arr = line.Trim().Split(' ');
                int dinh1 = int.Parse(arr[0]);
                int dinh2 = int.Parse(arr[1]);
                int trongSo = int.Parse(arr[2]);
                edges.AddLast(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
            }
            sr.Close();
        }
        public void Output_TimDuongNganNhatQuaTrungGian(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int start, end, intermediate;
            Input_TimDuongNganNhatQuaTrungGian(fileIn, out start, out end, out intermediate);
            int[] dist = new int[soDinh + 1];
            int[] pre = new int[soDinh + 1];
            bool[] processed = new bool[soDinh + 1];
            int sum = 0;
            LinkedList<int> pathStartToIntermediate = new LinkedList<int>(); 
            LinkedList<int> pathIntermediateToEnd = new LinkedList<int>();

            // Tìm đường đi từ điểm bắt đầu đến điểm trung gian
            Dijkstra(start, dist, processed, pre);
            for(int i = intermediate; i != -1; i = pre[i])
            {
                pathStartToIntermediate.AddFirst(i);
            }
            sum += dist[intermediate];
            // Tìm đường đi từ đỉnh trung gian đến điểm kết thúc
            Dijkstra(intermediate, dist, processed, pre);
            for(int i = end; i != intermediate; i = pre[i])
            {
                pathIntermediateToEnd.AddFirst(i);
            }
            sum += dist[end];


            Console.WriteLine("Find path using Dijkstra with intermediate node: " + sum);
            sw.WriteLine("Find path using Dijkstra with intermediate node: " + sum);
            for (int i = 0; i < pathStartToIntermediate.Count; i++)
            {
                Console.Write(pathStartToIntermediate.ElementAt(i) + " ");
                sw.Write(pathStartToIntermediate.ElementAt(i));
            }
            for (int j = 0; j < pathIntermediateToEnd.Count; j++)
            {
                Console.Write(pathIntermediateToEnd.ElementAt(j) + " ");
                sw.Write(pathIntermediateToEnd.ElementAt(j));
            }
            Console.WriteLine();
            sw.Close();
        }

        // ============ BUỔI 7 ============

        // ------------- Bài 1 -------------
        public void DFS_TimCayKhung(int s, bool[] visited, List<Tuple<int, int, int>> dsTree)
        {
            if (visited[s] == true) return;
            else
            {
                visited[s] = true;

                foreach(Tuple<int, int, int> ke in edges)
                {
                    int dinh1 = ke.Item1;
                    int dinh2 = ke.Item2;
                    int trongSo = ke.Item3;
                    if (dinh1 == s && visited[dinh2] == false)
                    {
                        dsTree.Add(ke);
                        DFS_TimCayKhung(dinh2, visited, dsTree);
                    }
                }
            }
        }
        public void Print_TimCayKhung(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Read_EdgeWeightedList(fileIn);
            bool[] visited = new bool[soDinh + 1];
            List<Tuple<int, int, int>> dsTree = new List<Tuple<int, int, int>>();

            DFS_TimCayKhung(1, visited, dsTree);
            Console.WriteLine("Số cạnh trong cây khung: " + dsTree.Count);
            sw.WriteLine("Số cạnh trong cây khung: " + dsTree.Count);

            foreach(Tuple<int, int, int> canh in dsTree)
            {
                Console.WriteLine($"{canh.Item1}, {canh.Item2}, {canh.Item3}");
                sw.WriteLine($"{canh.Item1}, {canh.Item2}, {canh.Item3}");
            }
            sw.Close();
        }

        // ------------- Bài 2 -------------
        public int FindParent(int d, int[] parent)
        {
            if (parent[d] != d)
            {
                return FindParent(parent[d], parent);
            }
            else
            {
                return parent[d];
            }
        }

        public void Kruskal(int[] parent, List<Tuple<int, int, int>> dsTree)
        {
            List<Tuple<int, int, int>> dsCanh = new List<Tuple<int, int, int>>();
            foreach(Tuple<int, int, int> e in edges)
            {
                dsCanh.Add(e);
            }
            dsCanh.Sort((a, b) => a.Item3.CompareTo(b.Item3));
            for(int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }
            foreach(Tuple<int, int, int> canh in dsCanh)
            {
                int dinh1 = canh.Item1;
                int dinh2 = canh.Item2;
                int trongSo = canh.Item3;

                int parent_dinh1 = FindParent(dinh1, parent);
                int parent_dinh2 = FindParent(dinh2, parent);
                if(parent_dinh1 != parent_dinh2)
                {
                    dsTree.Add(canh);
                    parent[parent_dinh1] = parent_dinh2;
                }
            }
        }
        public void Print_Kruskal(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Read_EdgeWeightedList(fileIn);

            int[] parent = new int[soDinh + 1];
            List<Tuple<int, int, int>> dsTree = new List<Tuple<int, int, int>>();

            Kruskal(parent, dsTree);

            Console.WriteLine("Số cạnh trong cây khung: " + dsTree.Count);
            sw.WriteLine("Số cạnh trong cây khung: " + dsTree.Count);
            foreach (Tuple<int, int, int> canh in dsTree)
            {
                Console.WriteLine($"{canh.Item1}, {canh.Item2}, {canh.Item3}");
                sw.WriteLine($"{canh.Item1}, {canh.Item2}, {canh.Item3}");
            }
            int TongTrongSo = 0;
            foreach(Tuple<int, int, int> canh in dsTree)
            {
                TongTrongSo += canh.Item3;
            }
            Console.WriteLine("Tổng trọng số của cây khung: " + TongTrongSo);
            sw.WriteLine("Tổng trọng số của cây khung: " + TongTrongSo);
            sw.Close();
        }

        // ------------- Bài 3 -------------
        public void PRIM(int s, bool[] includedTree, List<Tuple<int, int, int>> dsTree, List<Tuple<int, int, int>> PriorityQueue)
        {
            includedTree[s] = true;
            foreach(Tuple<int, int, int> canh in edges)
            {
                int dinh1 = canh.Item1;
                int dinh2 = canh.Item2;
                int trongSo = canh.Item3;
                if(dinh1 == s)
                {
                    PriorityQueue.Add(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
                }
                else if(dinh2 == s)
                {
                    PriorityQueue.Add(new Tuple<int, int, int>(dinh2, dinh1, trongSo));
                }
                PriorityQueue.Sort((a, b) => a.Item3.CompareTo(b.Item3));
            }
            while(PriorityQueue.Count > 0 && dsTree.Count < soDinh)
            {
                // Lấy cạnh nhỏ nhất
                Tuple<int, int, int> canh = PriorityQueue[0];
                PriorityQueue.RemoveAt(0);
                int a = canh.Item1;
                int b = canh.Item2;
                int weightAtoB = canh.Item3;
                if (includedTree[b] == true && includedTree[a] == true) continue;
                else
                {
                    dsTree.Add(canh);
                    includedTree[b] = true;
                    foreach(Tuple<int, int, int> ke_b in edges)
                    {
                        int dinh1 = ke_b.Item1;
                        int dinh2 = ke_b.Item2;
                        int trongSo = ke_b.Item3;
                        if(dinh1 == b)
                        {
                            PriorityQueue.Add(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
                        }
                        else if(dinh2 == b)
                        {
                            PriorityQueue.Add(new Tuple<int, int, int>(dinh2, dinh1, trongSo));
                        }
                        PriorityQueue.Sort((x, y) => x.Item3.CompareTo(y.Item3));
                    }
                }
            }
        }
        public void Print_PRIM(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Read_EdgeWeightedList(fileIn);
            bool[] includedTree = new bool[soDinh + 1];
            List<Tuple<int, int, int>> dsTree = new List<Tuple<int, int, int>>();
            List<Tuple<int, int, int>> PQ = new List<Tuple<int, int, int>>();
            PRIM(1, includedTree, dsTree, PQ);

            Console.WriteLine("Tổng số cạnh: " + dsTree.Count);
            sw.WriteLine("Tổng số cạnh: " + dsTree.Count);

            foreach(Tuple<int, int, int> canh in dsTree)
            {
                Console.WriteLine($"{canh.Item1}, {canh.Item2}, {canh.Item3}");
                sw.WriteLine($"{canh.Item1}, {canh.Item2}, {canh.Item3}");
            }
            int TongTrongSo = 0;
            foreach (Tuple<int, int, int> canh in dsTree)
            {
                TongTrongSo += canh.Item3;
            }
            Console.WriteLine("Tổng trọng số của cây khung: " + TongTrongSo);
            sw.WriteLine("Tổng trọng số của cây khung: " + TongTrongSo);
            sw.Close();
        }

        // ------------- Bài 4 -------------
        public void Read_PRIM_X_FILE(string fileIn, out int x)
        {
            StreamReader sr = new StreamReader(fileIn);
            string[] line = sr.ReadLine().Split(' ');
            soDinh = int.Parse(line[0]);
            soCanh = int.Parse(line[1]);
            x = int.Parse(line[2]);
            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine().Split(' ');
                int dinh1 = int.Parse(line[0]);
                int dinh2 = int.Parse(line[1]);
                int trongSo = int.Parse(line[2]);
                edges.AddLast(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
            }
            sr.Close();
        }
        public void PRIM_X(int s, bool[] includedTree, List<Tuple<int, int, int>> dsTree, List<Tuple<int, int, int>> PriorityQueue, int x)
        {
            includedTree[s] = true;
            foreach (Tuple<int, int, int> canh in edges)
            {
                int dinh1 = canh.Item1;
                int dinh2 = canh.Item2;
                int trongSo = canh.Item3;
                if(trongSo >= x)
                {
                    if (dinh1 == s)
                    {
                        PriorityQueue.Add(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
                    }
                    else if (dinh2 == s)
                    {
                        PriorityQueue.Add(new Tuple<int, int, int>(dinh2, dinh1, trongSo));
                    }
                    PriorityQueue.Sort((a, b) => a.Item3.CompareTo(b.Item3));
                }
            }
            while (PriorityQueue.Count > 0 && dsTree.Count < soDinh)
            {
                // Lấy cạnh nhỏ nhất
                Tuple<int, int, int> canh = PriorityQueue[0];
                PriorityQueue.RemoveAt(0);
                int a = canh.Item1;
                int b = canh.Item2;
                int weightAtoB = canh.Item3;
                if (includedTree[b] == true && includedTree[a] == true) continue;
                else
                {
                    dsTree.Add(canh);
                    includedTree[b] = true;
                    foreach (Tuple<int, int, int> ke_b in edges)
                    {
                        int dinh1 = ke_b.Item1;
                        int dinh2 = ke_b.Item2;
                        int trongSo = ke_b.Item3;
                        if(trongSo >= x)
                        {
                            if (dinh1 == b)
                            {
                                PriorityQueue.Add(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
                            }
                            else if (dinh2 == b)
                            {
                                PriorityQueue.Add(new Tuple<int, int, int>(dinh2, dinh1, trongSo));
                            }
                            PriorityQueue.Sort((i, j) => i.Item3.CompareTo(j.Item3));
                        }
                    }
                }
            }
        }
        public void Print_PRIM_X(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int x;
            Read_PRIM_X_FILE(fileIn, out x);
            bool[] includedTree = new bool[soDinh + 1];
            List<Tuple<int, int, int>> dsTree = new List<Tuple<int, int, int>>();
            List<Tuple<int, int, int>> PQ = new List<Tuple<int, int, int>>();
            PRIM_X(1, includedTree, dsTree, PQ, x);

            Console.WriteLine("Tổng số cạnh: " + dsTree.Count);
            sw.WriteLine("Tổng số cạnh: " + dsTree.Count);

            foreach (Tuple<int, int, int> canh in dsTree)
            {
                Console.WriteLine($"{canh.Item1}, {canh.Item2}, {canh.Item3}");
                sw.WriteLine($"{canh.Item1}, {canh.Item2}, {canh.Item3}");
            }
            int TongTrongSo = 0;
            foreach (Tuple<int, int, int> canh in dsTree)
            {
                TongTrongSo += canh.Item3;
            }
            Console.WriteLine("Tổng trọng số của cây khung: " + TongTrongSo);
            sw.WriteLine("Tổng trọng số của cây khung: " + TongTrongSo);
            sw.Close();
        }
    }
}