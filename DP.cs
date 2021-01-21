using System ;

namespace Dp
{
    class DPQuestions
    {
        static void Main(string[] args)
        {
            int n = 1000 ;
            // Console.WriteLine(Fib(n)) ;
            // Console.WriteLine(FibTD(n, new int[n+1])) ;
            // Console.WriteLine(FibBU(n)) ;

            int[] arr = {2,3,5,1,4} ;
            Console.WriteLine(WineProblem(arr , 0, arr.Length-1, 1)) ;
        }

        static int Fib(int n)
        {

            if(n == 0 || n == 1)
                return n ;

            int fnm1 = Fib(n-1) ;
            int fnm2 = Fib(n-2) ; 

            int fn = fnm1 + fnm2 ;

            return fn ;
        }

        static int FibTD(int n, int[] strg)
        {

            if(n == 0 || n == 1)
                return n ;

            if(strg[n] != 0) // result is already computed
            {
                return strg[n] ;
            }

            int fnm1 = FibTD(n-1, strg) ;
            int fnm2 = FibTD(n-2, strg) ; 

            int fn = fnm1 + fnm2 ;

            strg[n] = fn; // store

            return fn ;
        }

        static int FibBU(int n)
        {
            int[] strg = new int[n+1] ;

            strg[0] = 0 ;
            strg[1] = 1 ;

            for(int i = 2 ; i <= n ; i++)
            {
                strg[i] = strg[i-1] + strg[i-2] ;
            }

            return strg[n] ;

        }

        static int WineProblem(int[] arr, int si , int ei, int yr)
        {
            if(si == ei)
            {
                return arr[si] * yr ;
            }

            int left = WineProblem(arr , si + 1 , ei, yr + 1)+ arr[si] * yr;
            int right = WineProblem(arr , si , ei - 1, yr + 1) + arr[ei] * yr ;

            int ans = Math.Max(left , right) ;

            return ans ;

        }
    }
}