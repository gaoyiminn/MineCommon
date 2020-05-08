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
            Show<int>();
            Console.ReadKey();

            IMyOut<Bird> bird = new MyOutImp<Bird>();
            IMyOut<Bird> birds = new MyOutImp<Sparrow>();
        }

        public static void Show<T>()
        {
            T t = default(T);
            Console.WriteLine(t.GetType().Name);
        }
    }

    public interface IMyIn<in T>
    {

    }

    public interface IMyOut<out T>
    {
        T show();
    }

    public class MyOutImp<T> : IMyOut<T>
    {
        public T show()
        {
            throw new NotImplementedException();
        }
    }

    public class Bird
    {
        public int Id { get; set; }
    }
    public class Sparrow : Bird
    {
        public string Name { get; set; }
    }
}
