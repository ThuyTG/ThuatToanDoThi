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
        private int soDinh;
        private int soCanh;
        private LinkedList<Tuple<int, int, int>> edges;

        public int SoDinh { get; set; }
        public int SoCanh { get; set; }
        public Tuple<int, int, int> Edges { get; set; }

        public void Read_EdgeWeightedList(string fileIn)
        {
            StreamReader sr = new StreamReader(fileIn);
            string[] line = sr.ReadLine().Split(' ');
            SoDinh = int.Parse(line[0]);
            SoCanh = int.Parse(line[1]);
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

        public float Average_EdgeWeight()
        {
            int sum = 0;
            foreach(Tuple<int, int, int> e in edges)
            {
                sum += e.Item3;
            }
            return sum / soCanh;
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
        public Tuple<int, int, int>[] GetListEdgeMaxWeigth()
        {
            Tuple<int, int, int>[] ds = new Tuple<int, int, int>[0];
            int max = GetMaxWeight();
            int i = 0;
            foreach(Tuple<int, int, int> e in edges)
            {
                if(e.Item3 == max)
                {
                    Tuple<int,int, int> newMax =  new Tuple<int, int, int>(e.Item1, e.Item2, e.Item3);
                    ds.Append(newMax);
                    i++;
                }
            }
            return ds;
        }

        public void Print_EdgeWeightedList_To_File(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            sw.WriteLine($"{Average_EdgeWeight()}");
            Tuple<int, int, int>[] list = GetListEdgeMaxWeigth();
            for(int i = 0; i < list.Length; i++)
            {
                Tuple<int, int, int> e = list.ElementAt(i);
                Console.WriteLine($"{e.Item1} {e.Item2} {e.Item3}");
                sw.WriteLine($"{e.Item1} {e.Item2} {e.Item3}");
            }
            sw.Close();
        }
    }
}
