using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24dh113182_TruongGiaThuy
{
    // ============ BUỔI 4 ============
    internal class Grid
    {
        private int n; // Row
        private int m; // Column
        private int[,] matrix;
        
        public int N { get { return n; } set { n = value; } }
        public int M { get { return m; } set { m = value; } }
        public int[,] Matrix { get { return matrix; } set { matrix = value; } }

        public Grid() { }
        public Grid(int row, int col)
        {
            matrix = new int[row + 1, col + 1];
        }
        public List<Tuple<int, int>> Grid_BFS(ref bool[,] visited, ref Tuple<int, int>[,] pre,int startX,int startY)
        {
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();

            List<Tuple<int, int>> dsDinhDaDuyet = new List<Tuple<int, int>>();
            visited[startX, startY] = true;
            dsDinhDaDuyet.Add(new Tuple<int, int>(startX, startY));
            pre[startX, startY] = new Tuple<int, int>(-1, -1);
            q.Enqueue(new Tuple<int, int>(startX, startY));
            while(q.Count != 0)
            {
                Tuple<int, int> u = q.Dequeue();
                List<Tuple<int, int>> dsKeCuaU = new List<Tuple<int, int>>();

                // Kề trên
                int keTrenX = u.Item1 - 1;
                int keTrenY = u.Item2;
                dsKeCuaU.Add(new Tuple<int, int>(keTrenX, keTrenY));
                
                // Kề dưới
                int keDuoiX = u.Item1 + 1;
                int keDuoiY = u.Item2;
                dsKeCuaU.Add(new Tuple<int, int>(keDuoiX, keDuoiY));

                // Kề phải
                int kePhaiX = u.Item1;
                int kePhaiY = u.Item2 + 1;
                dsKeCuaU.Add(new Tuple<int, int>(kePhaiX, kePhaiY));

                // Kề trái
                int keTraiX = u.Item1;
                int keTraiY = u.Item2 - 1;
                dsKeCuaU.Add(new Tuple<int, int>(keTraiX, keTraiY));

                int keX, keY;
                foreach(Tuple<int, int> ke in dsKeCuaU)
                {
                    keX = ke.Item1;
                    keY = ke.Item2;
                    if((keX >= 1 && keX < n) && (keY >= 1 && keY < m))
                    {
                        if (visited[keX, keY] == true || matrix[keX, keY] == 0) continue;
                        else
                        {
                            visited[keX, keY] = true;
                            q.Enqueue(new Tuple<int, int>(keX, keY));
                            dsDinhDaDuyet.Add(new Tuple<int, int>(keX, keY));
                            pre[keX, keY] = new Tuple<int, int>(u.Item1, u.Item2);
                        }
                    }
                }
            }
            return dsDinhDaDuyet;
        }
        public void InputGrid(string fileIn, out int startX, out int startY, out int endX, out int endY)
        {
            StreamReader sr = new StreamReader(fileIn);
            
            string line1 = sr.ReadLine();
            string[] arr = line1.Trim().Split(' ');
            int row = int.Parse(arr[0]);
            int col = int.Parse(arr[1]);
            n = row;
            m = col;
            matrix = new int[n + 1, m + 1];

            string line2 = sr.ReadLine();
            arr = line2.Trim().Split(' ');
            startX = int.Parse(arr[0]);
            startY = int.Parse(arr[1]);
            endX = int.Parse(arr[2]);
            endY = int.Parse(arr[3]);

            string line;
            while (sr.EndOfStream == false)
            {
                for(int i = 1; i < matrix.GetLength(0); i++)
                {
                    line = sr.ReadLine();
                    arr = line.Trim().Split(' ');
                    for(int j = 1; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = int.Parse(arr[j - 1]);
                    }
                }
            }

            sr.Close();
        }
        public void PrintGrid_BFS(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int startX, startY, endX, endY;
            InputGrid(fileIn, out startX, out startY, out endX, out endY);
            bool[,] visited = new bool[n + 1, m + 1];
            Tuple<int, int>[,] pre = new Tuple<int, int>[n + 1, m + 1];
            Grid_BFS(ref visited, ref pre, startX, startY);

            for(int i = 1; i < matrix.GetLength(0); i++)
            {
                for(int j = 1; j < matrix.GetLength(1); j++)
                {
                    pre[i, j] = new Tuple<int, int>(-1, -1);
                }
            }
            LinkedList<Tuple<int, int>> path = new LinkedList<Tuple<int, int>>();
            Tuple<int, int> diemTruyVet = new Tuple<int, int>(endX, endY);

            while(!diemTruyVet.Equals(new Tuple<int, int>(-1, -1)))
            {
                path.AddFirst(diemTruyVet);
                int diemTruyVet_X = diemTruyVet.Item1;
                int diemTruyVet_Y = diemTruyVet.Item2;
                diemTruyVet = pre[diemTruyVet_X, diemTruyVet_Y];
            }

            Console.WriteLine(path.Count);
            sw.WriteLine(path.Count);
            foreach(Tuple<int, int> t in path)
            {
                Console.WriteLine(t.Item1 + " " + t.Item2);
                sw.WriteLine(t.Item1 + " " + t.Item2);
            }
            sw.Close();
        }
        public void PrintGrid()
        {
            for(int i = 1; i < matrix.GetLength(0); i++)
            {
                for(int j = 1; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void InputIsland(string fileIn)
        {
            StreamReader sr = new StreamReader(fileIn);

            string line = sr.ReadLine();
            string[] arr = line.Trim().Split(' ');
            int row = int.Parse(arr[0]);
            int col = int.Parse(arr[1]);
            matrix = new int[row + 1, col + 1];

            
            while (sr.EndOfStream == false)
            {
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    line = sr.ReadLine();
                    arr = line.Trim().Split(' ');
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = int.Parse(arr[j - 1]);
                    }
                }
            }

            sr.Close();
        }
        public int CountIsland(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int count = 0;
            InputIsland(fileIn);
            bool[,] visited = new bool[n + 1, m + 1];
            Tuple<int, int>[,] pre = new Tuple<int, int>[n + 1, m + 1];
            for(int i = 1; i < matrix.GetLength(0); i++)
            {
                for(int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (visited[i, j] == false)
                    {
                        Grid_BFS(ref visited, ref pre, i, j);
                        count++;
                    }
                }
            }
            Console.WriteLine($"Số đảo: {count}");
            sw.WriteLine($"Số đảo: {count}");
            sw.Close();
            return count;   
        }

        // ============ BUỔI 6 ============
        // ------------- Bài 4 -------------

        public Tuple<int, int> TimDinhCoMinDist(int[,] dist, bool[,] processed)
        {
            int min_value = int.MaxValue;
            int min_index_X = -1;
            int min_index_Y = -1;
            for (int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= m; j++)
                {
                    if (processed[i, j] == false && dist[i, j] <= min_value)
                    {
                        min_value = dist[i, j];
                        min_index_X = i;
                        min_index_Y = j;
                    }
                }
                
            }
            return new Tuple<int, int>(min_index_X, min_index_Y);
        }
        public void Dijkstra(int startX, int startY, out int endX, out int endY, int[,] dist, bool[,] processed, Tuple<int, int>[,] pre)
        {
            endX = -1;
            endY = -1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    dist[i, j] = int.MaxValue;
                    processed[i, j] = false;
                    pre[i, j] = new Tuple<int, int>(-1, -1);
                }
            }
            dist[startX, startY] = matrix[startX, startY];
            for (int i = 0; i < dist.GetLength(0) * dist.GetLength(1); i++)
            {
                Tuple<int, int> a = TimDinhCoMinDist(dist, processed);
                processed[a.Item1, a.Item2] = true;
                int Ax = a.Item1;
                int Ay = a.Item2;
                int distA = dist[Ax, Ay];

                List<Tuple<int, int>> dsKeCuaDinhA = new List<Tuple<int, int>>();
                // Đi lên
                int keX = a.Item1 - 1;
                int keY = a.Item2;
                dsKeCuaDinhA.Add(new Tuple<int, int>(keX, keY));
                // Đi xuống
                keX = a.Item1 + 1;
                keY = a.Item2;
                dsKeCuaDinhA.Add(new Tuple<int, int>(keX, keY));

                // Đi sang trái
                keX = a.Item1;
                keY = a.Item2 - 1;
                dsKeCuaDinhA.Add(new Tuple<int, int>(keX, keY));

                // Đi sang phải
                keX = a.Item1;
                keY = a.Item2 + 1;
                dsKeCuaDinhA.Add(new Tuple<int, int>(keX, keY));

                foreach (Tuple<int, int> ke in dsKeCuaDinhA)
                {
                    int Bx = ke.Item1;
                    int By = ke.Item2;
                    if (Bx >= 0 && By >= 0 && Bx < n && By < m)
                    {
                        int weightAtoB = matrix[Bx, By];
                        if (dist[Bx, By] > dist[Ax, Ay] + weightAtoB && processed[Bx, By] == false)
                        {
                            dist[Bx, By] = dist[Ax, Ay] + weightAtoB;
                            pre[Bx, By] = new Tuple<int, int>(Ax, Ay);
                            //processed[Bx, By] = true;
                        }
                    }
                }
                if (Ax == 0 || Ax == n || Ay == 0 || Ay == m) 
                {
                    endX = Ax;
                    endY = Ay;
                    Console.WriteLine("Print distances: ");
                    for(int e = 1; e <= n; e++)
                    {
                        for(int f = 1; f <= m; f++)
                        {
                            if (dist[e, f] == int.MaxValue) dist[e, f] = 0;
                            Console.Write(dist[e, f] + " ");
                        }
                        Console.WriteLine();
                    }
                    break;
                }
            }
        }

        public void Input_RaBien(string fileIn, out int startX, out int startY)
        {
            StreamReader sr = new StreamReader(fileIn);
            string line = sr.ReadLine();
            string[] arr = line.Trim().Split(' ');
            n = int.Parse(arr[0]);
            m = int.Parse(arr[1]);
            startX = int.Parse(arr[2]);
            startY = int.Parse(arr[3]);

            matrix = new int[n + 1, m + 1];
            while(sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                arr = line.Trim().Split(' ');
                for(int i = 1; i <= n; i++)
                {
                    for(int j = 1; j <= m; j++)
                    {
                        matrix[i, j] = int.Parse(arr[j - 1]);
                    }
                }
            }
            sr.Close();
        }
        public void Output_RaBien(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int startX, startY, endX = - 1, endY = -1;
            Input_RaBien(fileIn, out startX, out startY);
            int[,] dist = new int[n + 1, m + 1];
            bool[,] processed = new bool[n + 1, m + 1];
            Tuple<int, int>[,] pre = new Tuple<int, int>[n + 1, m + 1];
            Dijkstra(startX, startY, out endX, out endY, dist, processed, pre);
            LinkedList<Tuple<int, int>> path = new LinkedList<Tuple<int, int>>();
            //for(Tuple<int, int> k = new Tuple<int, int>(endX, endY); !k.Equals(new Tuple<int, int>(-1, -1)); k = pre[k.Item1, k.Item2])
            //{
            //    path.AddFirst(k);
            //}
            Tuple<int, int> k = new Tuple<int, int>(endX, endY);
            while(k != null && !k.Equals(new Tuple<int, int>(-1, -1)))
            {
                path.AddFirst(k);
                k = pre[k.Item1, k.Item2];
            }
            Console.WriteLine("Length path: " + dist[endX, endY]);
            sw.WriteLine("Length path: " + dist[endX, endY]);
            for (int i = 0; i < path.Count; i++)
            {
                Console.WriteLine($"({path.ElementAt(i).Item1}, {path.ElementAt(i).Item2})");
                sw.WriteLine($"({path.ElementAt(i).Item1}, {path.ElementAt(i).Item2})");
            }
            sw.Close();
        }
    }
}
