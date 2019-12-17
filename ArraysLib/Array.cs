using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasat
{
    public class Array
    {
        public static void ArrayPractice()
        {
            //1- We can have multiple variables in memory.
            //2- All variables are stored Contigously in memory.
            //3- Because they are contigous thats why we can run loop on their index.
            //4- Compiler gave us 0 based index to run on each memory location, means arr[1] represents 2nd variable.
            //5- Because we have contigous memory locations thats why we cant add or delete items from the array
            //6- Thats why addition and deletion to array is very costly, bcz you suppose to create copy of whole array on a single addition or deletion.
            //7- When requirement is to have reading frequently but not addition and deletion then array should be used. Because you can have any location
            //   on a single clock cycle.

            int[] arr = new int[] { 1, 2, 3, 4 };
            int[] arr2 = new int[arr.Length + 1];// add one item to array

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            int fifthLoc = arr[2];

            //single dimensional
            int[] intArray1 = new int[5];// array declaration
            int[] intArray2 = new int[5] { 1, 2, 3, 4, 5 }; // array initialization

            //2 dimensional
            int[,] d2 = new int[5, 2]; //array declaration
            int[,] arr_2D = new int[,] { { 1, 2 }, //array initialization - we have 5x2=10 int variables
                                         { 3, 4 },
                                         { 5, 6 },
                                         { 7, 8 },
                                         { 9, 10 }};

            Console.WriteLine("2D Array Reading:-");
            for (int i = 0; i < arr_2D.GetLength(0); i++)
            {
                for (int j = 0; j < arr_2D.GetLength(1); j++)
                {
                    Console.Write(arr_2D[i, j] + (j == arr_2D.GetLength(1) - 1 ? "" : ","));
                }
                Console.WriteLine();
            }

            int loc4_1 = arr_2D[4, 1];

            Console.WriteLine();

            int[,,] arr_3D = new int[4, 3, 3] // we have 4x3x3=36 int variables
            {
           /*0*/{        /*0  1  2*/
                    /*0*/{ 1, 2, 3 },
                    /*1*/{ 4, 5, 6 },
                    /*2*/{ 4, 5, 6 }
                },       /*0  1  2*/
           /*1*/{        /*0  1  2*/
                    /*0*/{ 7, 8, 9 },
                    /*1*/{ 10, 11, 12 },
                    /*2*/{ 4, 5, 6 }
                },       /*0  1  2*/
           /*2*/{   /*0  1  2*/
                    /*0*/{ 7, 8, 9 },
                    /*1*/{ 10, 11, 12 },
                    /*2*/{ 4, 5, 6 }
                },       /*0  1  2*/
           /*3*/{        /*0  1  2*/
                    /*0*/{ 7, 8, 9 },
                    /*1*/{ 10, 11, 12 },
                    /*2*/{ 4, 5, 6 }
                }        /*0  1  2*/
            };

            Console.WriteLine("3D Array Reading:-");
            for (int i = 0; i < arr_3D.GetLength(0); i++)
            {
                for (int j = 0; j < arr_3D.GetLength(1); j++)
                {
                    for (int k = 0; k < arr_3D.GetLength(2); k++)
                    {
                        Console.Write(arr_3D[i, j, k] + (k == arr_3D.GetLength(2) - 1 ? "" : ","));
                    }
                    Console.WriteLine();
                }
            }

            arr_3D = new int[2, 2, 2];

            Console.WriteLine($"Writing to Array from User in {arr_3D.Rank} Dimensional Array[{arr_3D.GetLength(0)},{arr_3D.GetLength(1)},{arr_3D.GetLength(2)}]:-");
            for (int i = 0; i < arr_3D.GetLength(0); i++)
            {
                for (int j = 0; j < arr_3D.GetLength(1); j++)
                {
                    for (int k = 0; k < arr_3D.GetLength(2); k++)
                    {
                        Console.Write($"[{i},{j},{k}]=");
                        arr_3D[i, j, k] = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("3D Array Reading:-");
            for (int i = 0; i < arr_3D.GetLength(0); i++)
            {
                for (int j = 0; j < arr_3D.GetLength(1); j++)
                {
                    for (int k = 0; k < arr_3D.GetLength(2); k++)
                    {
                        Console.Write($"[{i},{j},{k}]=" + arr_3D[i, j, k] + (k == arr_3D.GetLength(2) - 1 ? "" : ","));
                    }
                    Console.WriteLine();
                }
            }

            //1-And where ever addition and deletion are frequent but nor reading then list should be used.

            Node node = new Node();
            int counter = 0;
            while (node.next != null)
            {
                counter++;

                if (counter == 5)
                    break;

                Console.WriteLine(node.value.ToString());
                node = node.next;
            }

            Console.ReadLine();
        }

        public class Node
        {
            public object value { get; set; }
            public Node next { get; set; }
        }
    }
}