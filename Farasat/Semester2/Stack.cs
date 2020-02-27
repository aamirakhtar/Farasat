using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Farasat.Semester2
{
    /// <summary>
    /// Represents the stack class.
    /// </summary>
    public class IntStack : IIntStack
    {
        /// <summary>
        /// Contains the items.
        /// </summary>
        private List<int> items;
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectStack"/> class.
        /// </summary>
        public IntStack()
        {
            this.items = new List<int>();
        }
        /// <summary>
        /// Gets the number of items in the stack.
        /// </summary>
        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        // C# Generics
        /// <summary>Peeks the next item on the stack.</summary>
        /// <returns>The next item on the stack.</returns>
        /// <exception cref="InvalidOperationException">Is thrown, if there are no items on the stack.</exception>
        public int Peek()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek an empty stack");
            }
            return this.items[this.items.Count - 1];
        }
        /// <summary>Pops an item from the stack.</summary>
        /// <returns>The next item on the stack.</returns>
        /// <exception cref="InvalidOperationException">Is thrown, if there are no items on the stack.</exception>
        public int Pop()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop an empty stack");
            }
            int item = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);
            return item;
        }

        // C# Generics
        /// <summary>
        /// Pushes an item onto the stack.
        /// </summary>
        /// <param name="item">The item to be pushed.</param>
        public void Push(int item)
        {
            this.items.Add(item);
        }
    }

    /// <summary>
    /// Represents the StringStack class which extends the Stack class.
    /// </summary>
    public class StringStack : IStringStack
    {
        /// <summary>
        /// Contains the items.
        /// </summary>
        private List<string> items;
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectStack"/> class.
        /// </summary>
        public StringStack()
        {
            this.items = new List<string>();
        }
        /// <summary>
        /// Gets the number of items in the stack.
        /// </summary>
        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        // C# Generics
        /// <summary>Peeks the next item on the stack.</summary>
        /// <returns>The next item on the stack.</returns>
        /// <exception cref="InvalidOperationException">Is thrown, if there are no items on the stack.</exception>
        public string Peek()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek an empty stack");
            }
            return this.items[this.items.Count - 1];
        }
        /// <summary>Pops an item from the stack.</summary>
        /// <returns>The next item on the stack.</returns>
        /// <exception cref="InvalidOperationException">Is thrown, if there are no items on the stack.</exception>
        public string Pop()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop an empty stack");
            }
            string item = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);
            return item;
        }

        // C# Generics
        /// <summary>
        /// Pushes an item onto the stack.
        /// </summary>
        /// <param name="item">The item to be pushed.</param>
        public void Push(string item)
        {
            this.items.Add(item);
        }
    }

    /// <summary>
    /// Represents the stack class.
    /// </summary>
    public class ObjectStack : IObjectStack
    {
        /// <summary>
        /// Contains the items.
        /// </summary>
        private List<object> items;
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectStack"/> class.
        /// </summary>
        public ObjectStack()
        {
            this.items = new List<object>();
        }
        /// <summary>
        /// Gets the number of items in the stack.
        /// </summary>
        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        // C# Generics
        /// <summary>Peeks the next item on the stack.</summary>
        /// <returns>The next item on the stack.</returns>
        /// <exception cref="InvalidOperationException">Is thrown, if there are no items on the stack.</exception>
        public object Peek()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek an empty stack");
            }
            return this.items[this.items.Count - 1]; // Last element
        }
        /// <summary>Pops an item from the stack.</summary>
        /// <returns>The next item on the stack.</returns>
        /// <exception cref="InvalidOperationException">Is thrown, if there are no items on the stack.</exception>
        public object Pop()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop an empty stack");
            }
            object item = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);
            return item;
        }

        // C# Generics
        /// <summary>
        /// Pushes an item onto the stack.
        /// </summary>
        /// <param name="item">The item to be pushed.</param>
        public void Push(object item)
        {
            this.items.Add(item);
        }
    }

    //+++++++++++++++

    public interface IIntStack
    {
        int Count { get; }
        void Push(int item);
        int Pop();
        int Peek();
    }

    public interface IStringStack
    {
        int Count { get; }
        void Push(string item);
        string Pop();
        string Peek();
    }

    public interface IObjectStack
    {
        int Count { get; }
        void Push(object item);
        object Pop();
        object Peek();
    }

    public interface IStack<T>
    {
        int Count { get; }
        void Push(T item);
        T Pop();
        T Peek();
    }

    /// <summary>
    /// Represents the stack class.
    /// </summary>
    /// <typeparam name="T">Specifies the type of element in the stack.</typeparam>
    public class Stack<T> : IStack<T>
    {
        /// <summary>
        /// Contains the items.
        /// </summary>
        private List<T> items;
        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class.
        /// </summary>
        public Stack()
        {
            this.items = new List<T>();
        }
        /// <summary>
        /// Gets the number of items in the stack.
        /// </summary>
        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        // C# Generics
        /// <summary>Peeks the next item on the stack.</summary>
        /// <returns>The next item on the stack.</returns>
        /// <exception cref="InvalidOperationException">Is thrown, if there are no items on the stack.</exception>
        public T Peek()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek an empty stack");
            }
            return this.items[this.items.Count - 1];
        }
        /// <summary>Pops an item from the stack.</summary>
        /// <returns>The next item on the stack.</returns>
        /// <exception cref="InvalidOperationException">Is thrown, if there are no items on the stack.</exception>
        public T Pop()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop an empty stack");
            }
            T item = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);
            return item;
        }

        // C# Generics
        /// <summary>
        /// Pushes an item onto the stack.
        /// </summary>
        /// <param name="item">The item to be pushed.</param>
        public void Push(T item)
        {
            this.items.Add(item);
        }
    }

    class Program
    {
        public void Stack()
        {
            //ObjectStack myStack = new ObjectStack();
            //myStack.Push(1);
            //myStack.Push(2);
            //myStack.Push(3);
            //while (myStack.Count > 0)
            //{
            //    Console.WriteLine("Peeking the next element: {0}", myStack.Peek());
            //    Console.WriteLine("Taking the next element: {0}", myStack.Pop());
            //}

            //Int Stack
            IntStack intStack = new IntStack();
            intStack.Push(1);
            intStack.Push(3123);
            intStack.Push(45);

            int intItem = intStack.Pop();

            //String Stack
            StringStack stringStack = new StringStack();
            stringStack.Push("farasat");
            stringStack.Push("aamir");
            stringStack.Push("noman");

            string strItem = stringStack.Pop();

            //Object Stack
            ObjectStack objectStack = new ObjectStack();
            objectStack.Push((object)1);
            objectStack.Push((object)13);
            objectStack.Push((object)45);

            object objectItem = (object)objectStack.Pop();

            //Templated Stack
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(13);
            stack.Push(45);

            int iItem = stack.Pop();

            Stack<string> strStack = new Stack<string>();
            strStack.Push("aamir");
            strStack.Push("farasat");
            strStack.Push("noman");

            string stItem = strStack.Pop();
        }

        public void StackAsObject()
        {
            ObjectStack myStack = new ObjectStack();
            myStack.Push((object)1);
            myStack.Push((object)"2");
            myStack.Push((object)3);
            while (myStack.Count > 0)
            {
                Console.WriteLine("Peeking the next element: {0}",
                (int)myStack.Peek());
                Console.WriteLine("Taking the next element: {0}",
                (int)myStack.Pop());
            }
        }

        public void StackAsString()
        {
            StringStack myStack = new StringStack();
            myStack.Push("1");
            myStack.Push("2");
            myStack.Push("3");
            while (myStack.Count > 0)
            {
                Console.WriteLine("Peeking the next element: {0}", myStack.Peek());
                Console.WriteLine("Taking the next element: {0}", myStack.Pop());
            }
        }

        public void GenericStack()
        {
            Stack<int> myStack = new Stack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            while (myStack.Count > 0)
            {
                Console.WriteLine("Peeking the next element: {0}", myStack.Peek());
                Console.WriteLine("Taking the next element: {0}", myStack.Pop());
            }
        }

        static void StackMain(string[] args)
        {



        }
    }
}