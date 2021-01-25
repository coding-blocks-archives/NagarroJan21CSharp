using System ;
using System.Collections.Generic ;

namespace StackDS
{
    class StackQs
    {
        static void main(string[] args)
        {
            // int[,] arr = { {0,1,1,1} , {1,0,1,0} , {0,0,0,1} , {1,1,1,0} } ;

            // CelebrityProblem(arr);

            MyStack ms = new MyStack() ;
            ms.Push(20) ;
            ms.Push(30) ;
            ms.Push(5) ;
            Console.WriteLine(ms.Min());
            ms.Push(2) ;
            Console.WriteLine(ms.Peek());

        }

        static void CelebrityProblem(int[,] arr)
        {

            Stack<int> s = new Stack<int>() ;

            for(int i = 0 ; i < arr.GetLength(0) ; i++)
            {
                s.Push(i) ;
            }

            while(s.Count != 1)
            {
                int fp = s.Pop() ;
                int sp = s.Pop() ;

                // fp knows sp ? Yes, fp can't be a celeb
                if(arr[fp,sp] == 1)
                {
                    s.Push(sp) ;
                }
                // fp doesn't know sp , sp can't be a celeb
                else
                {
                    s.Push(fp) ;
                }
            }

            int candidate = s.Pop() ;

            for(int i = 0 ; i < arr.GetLength(0) ; i++)
            {
                if(i != candidate)
                {
                    if(arr[candidate,i] == 1 || arr[i, candidate] == 0)
                    {
                        Console.WriteLine("No celeb") ;
                        return ;
                    }
                }
            }

            Console.WriteLine("Celeb is " + candidate) ;


        }

        class MyStack
        {
            Stack<int> s = new Stack<int>() ;
            int min ;

            public void Push(int val)
            {
                if(s.Count == 0)
                {
                    s.Push(val) ;
                    min = val ;
                }
                else if(val >= min)
                {
                    s.Push(val) ;
                }
                else 
                {
                    // encrypted
                    s.Push(2*val-min) ;
                    min = val ;
                }
            }

            public int Peek()
            {
                if(s.Count == 0)
                {
                    Console.WriteLine("Stack is Empty") ;
                    return 0 ;
                }
                else if(s.Peek() >= min)
                {
                    // no encryption
                    return s.Peek() ;
                }
                else
                {
                    // encryption
                    return min ;
                }
            }

            public int Pop()
            {
                if(s.Count == 0)
                {
                    Console.WriteLine("Stack is Empty") ;
                    return 0 ;
                }
                else if(s.Peek() >= min)
                {
                    // no encryption
                    return s.Pop() ;
                }
                else
                {
                    // encryption
                    int ov = min ;

                    int topMostValue = s.Pop() ;
                    min = 2*min - topMostValue ;

                    return ov ;
                    
                }
            }

            public int Min()
            {
                return min ;
            }
        }

    }
}