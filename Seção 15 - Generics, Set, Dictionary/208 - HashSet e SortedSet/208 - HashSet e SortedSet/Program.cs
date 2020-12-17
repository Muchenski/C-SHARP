using System;
using System.Collections.Generic;

namespace _208___HashSet_e_SortedSet {
    class Program {
        static void Main(string[] args) {

            HashSet<String> hSet = new HashSet<string>();
            hSet.Add("TV");
            hSet.Add("Notebook");
            hSet.Add("Tablet");
            Console.WriteLine(hSet.Contains("Notebook"));

            //PrintCollection(hSet);

            SortedSet<int> sSetPar = new SortedSet<int>() { 0, 2, 4, 5, 6, 8, 10 };
            SortedSet<int> sSet = new SortedSet<int>() { 5, 6, 7, 8, 9, 10 };

            //PrintCollection(sSetPar);
            //PrintCollection(sSet);

            //Union:
            SortedSet<int> u = new SortedSet<int>(sSetPar);
            u.UnionWith(sSet);
            PrintCollection(u);

            //Intersection
            SortedSet<int> i = new SortedSet<int>(sSetPar);
            i.IntersectWith(sSet);
            PrintCollection(i);

            //Difference
            SortedSet<int> d = new SortedSet<int>(sSetPar);
            d.ExceptWith(sSet);
            PrintCollection(d);
        }
        static void PrintCollection<T>(IEnumerable<T> collection) {
            foreach(T item in collection) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
