using System;
using System.Collections;
using System.Collections.Generic;
using GenericLibrary;

namespace Generic
{
    class Program
    {
        //метод обмена элементов
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        //сортировка вставками
        static int[] InsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 1) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }

            return array;
        }

        static void Main(string[] args)
        {
            MyList<string> stringList = new MyList<string>();
            MyList<int> intList = new MyList<int>();
            int[] sortArr = { 1, 5, 2, 6, 9, 7 };

            Console.WriteLine("MY INT LIST:");

            intList.Add(1);
            intList.Add(2);
            intList.Add(3);

            Console.WriteLine("Add 1, 2, 3 to intList:");
            foreach (var item in intList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            intList.Remove(2);
            Console.WriteLine("Delete 2 from intList:");
            foreach (var item in intList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            bool f = intList.Contains(3);
            Console.WriteLine(f == true ? "List contain 3" : "List doesn't contain 3");

            Console.WriteLine("Add 4 first in intList:");
            intList.AppendFirst(4);
            foreach (var item in intList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Reverse:");
            foreach (var item in intList.Reverse())
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            intList.Clear();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("MY STRING LIST:");

            stringList.Add("AA");
            stringList.Add("BB");
            stringList.Add("CC");
            stringList.Add("DD");

            Console.WriteLine("Add AA, BB, CC, DD to stringList:");
            foreach (var item in stringList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Delete AA from stringList:");
            stringList.Remove("AA");
            foreach (var item in stringList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            bool isPresent = stringList.Contains("CC");
            Console.WriteLine(f == true ? "List contain CC" : "List doesn't contain CC");

            Console.WriteLine("Add WW first in intList:");
            stringList.AppendFirst("WW");
            foreach (var item in stringList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Reverse:");
            foreach (var item in stringList.Reverse())
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            stringList.Clear();
            Console.ReadKey();
            Console.Clear();



            Console.WriteLine("BINARY TREE:");

            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(5);
            binaryTree.Add(6);
            binaryTree.Add(8);
            binaryTree.Add(11);
            binaryTree.Add(2);
            binaryTree.Add(6);
            binaryTree.Add(8);
            binaryTree.Add(4);
            binaryTree.Add(12);

            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(5);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(8);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Try to find node 10");
            if (binaryTree.FindNode(11) == null)
            {
                Console.WriteLine("Node isn't exist");
            }
            else
            {
                Console.WriteLine("Node is found");
            }
           

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("SORT:");
            Console.WriteLine("Before: \n1 5 2 6 9 7");
            Console.WriteLine("After: ");
            foreach (var item in InsertionSort(sortArr))
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
