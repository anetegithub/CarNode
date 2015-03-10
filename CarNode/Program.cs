using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNode
{
    class Program
    {
        static void Main(string[] args)
        {
            //parse file to List<Node> objects
            var file = Parser.Parse();

            //convert list to list of tuples
            List<Tuple<string, string, int>> nodes = file.Select(x => new Tuple<string, string, int>(x.id.ToString(), x.reference.ToString(), x.weight)).ToList();

            //find min and max node
            Node Start = file.Aggregate((curmin, x) => x.id < curmin.id ? x : curmin);
            Node End = file.OrderByDescending(x => x.id).FirstOrDefault();  //.Aggregate((curmax, x) => x.id >= curmax.id ? x : curmax);

            //main step
            var route = Alg.GetShortPath(Start.id.ToString(), End.id.ToString(), nodes);

            //show shortest way
            Console.WriteLine("Shortest way:");
            foreach(var r in route.ToList())
            {
                Console.WriteLine(r);
            }
            Console.Read();
        }
    }
}
