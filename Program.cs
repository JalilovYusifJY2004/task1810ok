using System.Text;

namespace task1810
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListInt myList = new ListInt();
            myList.Add(1);
            myList.AddRange(2, 5, 4);
            myList.Remove(5);
            myList.RemoveRange(1, 2);
            Console.WriteLine("Contains 2: " + myList.Contains(2));
            Console.WriteLine("Sum: " + myList.Sum());
            Console.WriteLine("List: " + myList);

        }
    }
    class ListInt
    {
        private int[] array;

        public ListInt()
        {
            array = new int[0];
        }

        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public void Add(int num)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = num;
        }

        public void AddRange(params int[] nums)
        {
            int arrLength = array.Length;
            Array.Resize(ref array, arrLength + nums.Length);
            Array.Copy(nums, 0, array, arrLength, nums.Length);
        }

        public bool Contains(int num)
        {
            return Array.IndexOf(array, num) != -1;
        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        public void Remove(int num)
        {
            int index = Array.IndexOf(array, num);
            if (index != -1)
            {
                int newSize = array.Length - 1;
                int[] newArray = new int[newSize];
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index + 1, newArray, index, newSize - index);
                array = newArray;
            }
        }

        public void RemoveRange(params int[] nums)
        {
            foreach (int num in nums)
            {
                Remove(num);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                builder.Append(array[i]);
                if (i < array.Length - 1)
                {
                    builder.Append(", ");
                }
            }
            return builder.ToString();
        }
    }
}