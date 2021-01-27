using System ;
using System.Collections.Generic ;

namespace QueueDS
{
    class QueueQs
    {
        static void main(string[] args)
        {
            int[] arr = {10,-1,-8,6,30,40,50, 60} ;

            FirstNegativeIntegerWindow(arr , 3) ;
        }

        static void FirstNegativeIntegerWindow(int[] arr , int k)
        {

            Queue<int> q = new Queue<int>() ;

            // first window : -ve values index insert in queue
            for(int i = 0 ; i < k ; i++)
            {
                if(arr[i] < 0)
                    q.Enqueue(i) ;
            }

            for(int i = k ; i < arr.Length ; i++)
            {
                // window : first -ve print
                if(q.Count == 0)
                    Console.WriteLine("no -ve in this window") ;
                else
                    Console.WriteLine(arr[q.Peek()]) ;

                // window update , out of window remove
                if(q.Count != 0 && q.Peek() == i-k)
                    q.Dequeue() ;

                // window update , new value add if it is -ve
                if(arr[i] < 0)
                    q.Enqueue(i) ;

                
            }

            if(q.Count == 0)
                Console.WriteLine("no -ve in this window") ;
            else
                Console.WriteLine(arr[q.Peek()]) ;


        }
    }
}