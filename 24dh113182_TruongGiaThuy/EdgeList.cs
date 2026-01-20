using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24dh113182_TruongGiaThuy
{
    // 24dh113182 - Trương Gia Thuỵ
    internal class EdgeList
    {
        private int n;
        private int edge;
        private LinkedList<Tuple<int, int>> edges;
        public int N { get; set; }
        public int Edge { get; set; }
        public LinkedList<Tuple<int, int>> Edges { get;} = new LinkedList<Tuple<int, int>>();

        // 24dh113182 - Trương Gia Thuỵ
        public void EdgeListInput(string fileIn)
        {
            StreamReader sr = new StreamReader(fileIn);
            // Số đỉnh và số cạnh
            string line = sr.ReadLine();
            string[] arr = line.Split(' ');
            n = int.Parse(arr[0]);
            edge = int.Parse(arr[1]);
            while(sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                arr = line.Split(' ');
                int dinh1 = int.Parse(arr[0]);
                int dinh2 = int.Parse(arr[1]);
                Edges?.AddLast(new Tuple<int, int>(dinh1,dinh2));
            }
            sr.Close();
        }

        // 24dh113182 - Trương Gia Thuỵ
        public void EdgeListOutput(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            sw.WriteLine("Số đỉnh: " + n);
            for(int i = 0; i < Edges.Count; i++)
            {
                Tuple<int, int> e = Edges.ElementAt(i);
                Console.WriteLine($"{e.Item1} {e.Item2}");
                sw.WriteLine($"{e.Item1} {e.Item2}");
            }
            sw.Close();
        }

        // 24dh113182 - Trương Gia Thuỵ
        public void PrintDegreeOfEdges(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int[] count = new int[n + 1];
            sw.WriteLine("Số đỉnh: " + n);
            for(int i = 0; i < Edges.Count; i++)
            {
                Tuple<int, int> e = Edges.ElementAt(i);
                count[e.Item1]++;
                count[e.Item2]++;
            }
            foreach(Tuple<int, int> e in Edges)
            {
                int dinh = e.Item1;
                count[dinh]++;
                dinh = e.Item2;
                count[dinh]++;
            }
            for(int i = 1; i < count.Length; i++)
            {
                Console.WriteLine("Đỉnh " + i + " có bậc là: " + count[i]);
                sw.WriteLine("Đỉnh " + i + " có bậc là: " + count[i]);
            }
            sw.Close();
        }
    }
}
