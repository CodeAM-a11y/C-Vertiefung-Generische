using System.Collections;

namespace C__Vertiefung_Generische
{
    public class Mensch : IComparable<Mensch>
    {
        public string Name { get; set; }
        public int Alter { get; set; }
        public string Adresse { get; set; }

        public int CompareTo(Mensch anderer)
        {
            return Name.CompareTo(anderer.Name);
        }
    }
    public class GenericStack<T>
    {
        private T[] array;
        public int count { get; set; } = 0;
        public GenericStack(int capacity)
        {
            array = new T[capacity];
        }
        public void Push(T element)
        {
            count++;
            array[count] = element;
        }
        public object Pop()
        {
            count--;
            T element = array[count];
            array[count] = default(T);
            return element;
        }
    }
    public class ObjectStack
    {
        private object[] array;
        public int count { get; set; } = 0;
        public ObjectStack(int capacity)
        {
            array = new object[capacity];
        }
        public void Push(object element)
        {
            count++;
            array[count] = element;
        }
        public object Pop()
        {
            count--;
            object element = array[count];
            array[count] = default(object);
            return element;
        }
    }
    public class IntStack
    {
        private object[] array;
        public int count { get; set; } = 0;
        public IntStack(int capacity)
        {
            array = new object[capacity];
        }
        public void Push(object element)
        {
            count++;
            array[count] = element;
        }
        public object Pop()
        {
            count--;
            object element = array[count];
            array[count] = default(object);
            return element;
        }
    }
    public class StringStack
    {
        private string[] array;
        public int count { get; set; } = 0;
        public StringStack(int capacity)
        {
            array = new string[capacity];
        }
        public void Push(string element)
        {
            count++;
            array[count] = element;
        }
        public string Pop()
        {
            count--;
            string element = array[count];
            array[count] = default(string);
            return element;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StringStack sts = new StringStack(5);
            sts.Push("Hallo");
            sts.Push("1.push");
            Console.WriteLine(sts.Pop());
            Console.WriteLine(sts.Pop());
            Hashtable table = new Hashtable();
            table.Add(1,"Hallo");
            Console.WriteLine(table[1]);
            SortedList<Mensch,int> listeM = new SortedList<Mensch,int>();
            Mensch eins = new Mensch();
            eins.Name = "Klaus";
            Mensch zwei = new Mensch();
            zwei.Name = "Paul";
            listeM.Add(eins,3);
            listeM.Add(zwei, 7);
            Console.WriteLine(eins.CompareTo(zwei));
            foreach(var Men in listeM)
            {
                Console.WriteLine(Men.Key.Name);
            }
        }
    }
}
