using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNode
{
    public static class Alg
    {
        /// <summary>
        /// http://www.oignatov.ru/2013/06/23/poisk-kratchajshego-puti-na-yazyke-c/
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="roads"></param>
        /// <returns></returns>
        public static IList<string> GetShortPath(string from, string to,
    IList<Tuple<string, string, int>> roads)
        {
            var routes = new List<Tuple<string, string, int>>();
            var cities = new HashSet<string>();
            foreach (var road in roads)
            {
                cities.Add(road.Item1);
                cities.Add(road.Item2);
                routes.Add(new Tuple<string, string, int>(road.Item1,
                    road.Item2, road.Item3));
                routes.Add(new Tuple<string, string, int>(road.Item2,
                    road.Item1, road.Item3));
            }

            var shortestPaths = cities.ToDictionary(city => city, city =>
                new Tuple<int, List<Tuple<string, string, int>>>(int.MaxValue,
                    new List<Tuple<string, string, int>>()));
            shortestPaths[from] = new Tuple<int, List<Tuple<string, string, int>>>(0,
                new List<Tuple<string, string, int>>());

            bool finish = false;
            var processed = new List<string>();
            while (processed.Count != cities.Count)
            {
                var shortestCities = (from s in shortestPaths
                                      orderby s.Value.Item1
                                      select s.Key).ToList();

                string currentCity = null;
                foreach (string city in shortestCities)
                {
                    if (!processed.Contains(city))
                    {
                        if (shortestPaths[city].Item1 == int.MaxValue)
                        {
                            finish = true;
                        }
                        currentCity = city;
                        break;
                    }
                }
                if (finish)
                {
                    break;
                }

                var citiesToGo = routes.Where(route => route.Item1 == currentCity);
                foreach (Tuple<string, string, int> cityToGo in citiesToGo)
                {
                    if (shortestPaths[cityToGo.Item2].Item1 > cityToGo.Item3 +
                        shortestPaths[cityToGo.Item1].Item1)
                    {
                        List<Tuple<string, string, int>> sss =
                            shortestPaths[cityToGo.Item1].Item2.ToList();
                        sss.Add(cityToGo);
                        int cost = cityToGo.Item3 + shortestPaths[cityToGo.Item1].Item1;
                        shortestPaths[cityToGo.Item2] =
                            new Tuple<int, List<Tuple<string, string, int>>>(cost, sss);
                    }
                }
                processed.Add(currentCity);
            }

            if (shortestPaths[to].Item1 == int.MaxValue)
            {
                return new List<string>();
            }
            var shortPath = shortestPaths[to].Item2.Select(t => t.Item1).ToList();
            shortPath.Add(to);
            return shortPath;
        }
    }
}