namespace TaskExample
{
    public class DoStuff
    {
        public static int Counter = 0;

        public static object syncObjA = new object();
        public static object syncObjB = new object();

        public void CountToUnfinity(string botName)
        {
            while (true)
            {
                // Thread 2 wait
                lock (syncObjA) // Thread 1
                {
                    Console.WriteLine($"{botName} {++Counter}");
                    if (Counter % 2 == 0)
                    {
                        Console.WriteLine($"{Counter} is Odd");
                    }
                    else
                    {
                        Console.WriteLine($"{Counter} is Even");
                    }

                    // Thread 1
                    SayHi();
                }
            }
        }

        public void SayHi()
        {
            //Thread 1 wait
            lock (syncObjB) //Thread 2 
            {
                Console.WriteLine("Hi");
                //Thread 2 
                CountToUnfinity("Jonny 5");
            }
            
        }
    }
}
