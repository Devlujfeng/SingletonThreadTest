using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericClass<string> gc = new GenericClass<string>();
            gc.Push("A");
            gc.Push("B");
            gc.Push("C");
            gc.Push("D");
            Console.WriteLine(gc.Pop());
            Console.WriteLine(gc.Pop());
            Console.WriteLine(gc.Pop());
            Console.WriteLine(gc.Pop());
            Console.WriteLine("this is to test the generic indexing: " + gc[1]);
            //int a = 100, b = 200;
            string a = "100", b = "200";
            Console.WriteLine("Before swap a:" + a + "---- b:" + b);
            swap(ref a, ref b);
            Console.WriteLine("After swap a:" + a + "---- b:" + b);

            //To Test Generic Functions
            Beverage bg = new Beverage("Pepsi",100);
            Meat mt = new Meat("Pork", 200, 30);
            UpdatePrice(ref mt);
            UpdatePrice(ref bg);
            Console.WriteLine(mt.ProductPrice + "---" + bg.ProductPrice);
            Console.ReadLine();
        }
        //1. use template in function
        static void swap <T> (ref T a, ref T b)
        {
            T temp = a; a = b; b = temp;
        }
        static void UpdatePrice<T> (ref T branch)
        {
            Parent p = branch as Parent;
            p.ProductPrice = p.ProductPrice + 100;
        }
    }
    //2. use generic in Class
    public class GenericClass<T>
    {
        int position;
        T[] data = new T[100];
        public void Push(T obj) => data[position++] = obj;//add after using
        public T Pop() => data[--position];//minus before using
        //we could write an indexer that returns a generic item
        public T this[int index] { get { return data[index]; } }
    }

    class Dictionary<TKey, TValue> {


    }
    //var myDic = new Dictionary<int,string>();



    //Define 2 different model(dataset) class, create a function to change the amount value.
    public class Parent
    {
        public int ProductPrice { get; set; }
    }

    public class Beverage : Parent
    {
        public string ProductName  { get; set; }
        
        public Beverage(string productName, int productPrice)
        {
            base.ProductPrice = productPrice;
            ProductName = ProductName;
        }
    }
    public class Meat : Parent
    {
        public string ProductName { get; set; }
        public int Size { get; set; }
        public Meat(string productName, int productPrice, int size)
        {
            base.ProductPrice = productPrice;
            ProductName = ProductName;
            Size = size;
        }
    }




}
