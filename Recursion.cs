using System ;

namespace Recursion
{
    class RecursionQs
    {
        static void main(string[] args)
        {
            //PDI(3);
            // CoinToss(2, "") ;
            // ValidParenthesis(4, 0, 0, "") ;
            PalindromePartitioning("nitin", "") ;
        }

        static void PDI(int n)
        {
            if(n == 0)
                return ;

            Console.WriteLine("Hii " + n) ;
            PDI(--n) ;
            Console.WriteLine("Bye " + n) ;
        }

        static void CoinToss(int n, String ans)
        {
            if(n == 0)
            {
                Console.WriteLine(ans) ;
                return ;
            }

            CoinToss(n-1, ans + "H") ;
            CoinToss(n-1, ans + "T") ;
        }

        static void ValidParenthesis(int n , int open , int close, String ans)
        {
            if(open == n && close == n)
            {
                Console.WriteLine(ans) ;
                return ;
            }

            if(open > n || close > open)
                return ;

            ValidParenthesis(n , open+1, close, ans + "(") ;
            ValidParenthesis(n , open, close+1, ans + ")") ;

        }

        static void PalindromePartitioning(String ques, String ans)
        {

            if(ques.Length == 0)
            {
                Console.WriteLine(ans) ;
                return ;
            }

            for(int i = 1 ; i <= ques.Length ; i++)
            {
                String roq = ques.Substring(i) ;
                String component = ques.Substring(0,i) ;

                if(IsPalindrome(component))
                    PalindromePartitioning(roq, ans + component + "  ") ;
            }
        }

        static bool IsPalindrome(String str)
        {

            int i = 0 ;
            int j = str.Length-1 ;

            while(i <= j)
            {
                if(str[i] != str[j])
                {
                    return false ;
                }

                i++ ;
                j-- ;
            }

            return true ;
        }

    }

}