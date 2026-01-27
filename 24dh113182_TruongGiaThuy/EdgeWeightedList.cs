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
    }
}
