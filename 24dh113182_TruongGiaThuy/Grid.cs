using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24dh113182_TruongGiaThuy
{
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
            matrix = new int[row + 1, col + 1];

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
    }
}
