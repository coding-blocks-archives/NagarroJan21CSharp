using System ;

namespace DP
{
    class DPQuestions
    {
        static void main(string[] args)
        {
            int n = 10 ;
            // Console.WriteLine(Fib(n)) ;
            // Console.WriteLine(FibTD(n, new int[n+1])) ;
            // Console.WriteLine(FibBU(n)) ;

           // int[] arr = {2,3,5,1,4} ;
            int[] arr = new int[n] ;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            // Console.WriteLine(WineProblemTD(arr , 0, arr.Length-1, new int[arr.Length, arr.Length])) ;
            // Console.WriteLine(WineProblemBU(arr)) ;

            // Console.WriteLine(NoOfBSTsTD(n, new int[n+1])) ;
            Console.WriteLine(NoOfBSTsBU(n)) ;
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

        static int WineProblemTD(int[] arr, int si , int ei, int[,] strg)
        {
            int yr = arr.Length - (ei - si + 1) + 1 ;

            if(si == ei)
            {
                return arr[si] * yr ;
            }

            if(strg[si,ei] != 0) // re-use
            {
                return strg[si,ei] ;
            }

            int left = WineProblemTD(arr , si + 1 , ei, strg)+ arr[si] * yr;
            int right = WineProblemTD(arr , si , ei - 1, strg) + arr[ei] * yr ;

            int ans = Math.Max(left , right) ;

            strg[si,ei] = ans ; // store

            return ans ;

        }

        static int WineProblemBU(int[] arr)
        {

            int n = arr.Length ;

            int[,] strg = new int[n,n] ;

            for(int slide = 0 ; slide <= n-1 ; slide++)
            {
                for(int si = 0 ; si <= n - slide - 1 ; si++)
                {
                    int ei = si + slide ;

                    // copy
                    int yr = arr.Length - (ei - si + 1) + 1 ;

                    if(si == ei) // slide == 0
                    {
                        strg[si,ei] = arr[si] * yr ;
                    }
                    else
                    {
                        int left = strg[si + 1 , ei] + arr[si] * yr;
                        int right = strg[si, ei - 1] + arr[ei] * yr ;

                        int ans = Math.Max(left , right) ;

                        strg[si,ei] = ans ; 
                    }
                }
            }

            return strg[0,n-1] ;

        }

        static int NoOfBSTs(int n)
        {

            if(n <= 1)
                return 1 ;

            int sum = 0 ;

            for(int i = 1 ; i <= n ; i++)
            {
                int l = NoOfBSTs(i - 1) ;
                int r = NoOfBSTs(n - i) ; 

                int ans = l * r ;

                sum = sum + ans ;
            }

            return sum ;
        }

        static int NoOfBSTsTD(int n, int[] strg)
        {

            if(n <= 1)
                return 1 ;

            if(strg[n] != 0)
                return strg[n] ;

            int sum = 0 ;

            for(int i = 1 ; i <= n ; i++)
            {
                int l = NoOfBSTsTD(i - 1 , strg) ;
                int r = NoOfBSTsTD(n - i, strg) ; 

                int ans = l * r ;

                sum = sum + ans ;
            }

            strg[n] = sum ;

            return sum ;
        }

        static int NoOfBSTsBU(int tn)
        {
            int[] strg = new int[tn+1] ;

            strg[0] = 1 ;
            strg[1] = 1 ;

            for(int n = 2 ; n <= tn ; n++)
            {
                int sum = 0 ;

                for(int i = 1 ; i <= n ; i++)
                {
                    int l = strg[i-1] ;
                    int r = strg[n-i] ;

                    int ans = l * r ;

                    sum = sum + ans ;
                }

                strg[n] = sum ;
            }

            foreach(int val in strg)
            {
                Console.Write(val + " ") ;
            }
            Console.WriteLine() ;

            return strg[tn] ;
        }
    }
}