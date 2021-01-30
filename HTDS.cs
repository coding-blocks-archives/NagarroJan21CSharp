using System ;
using System.Collections ;

namespace HTDS
{
    public class HT
    {
        public static void main(string[] args)
        {
            Hashtable table = new Hashtable() ;

            // add
            table.Add("Aman", 10) ;
            table.Add(1, 20)  ;
            table.Add("Rohit", 15)  ;
            table.Add("Mohit", 25)  ;

            // obtain/get
            Console.WriteLine(table["Aman"]) ;
            Console.WriteLine(table["Chirag"]) ;

            // update
            table["Aman"] = 100 ;

            // obtain/get
            Console.WriteLine(table["Aman"]) ;
            Console.WriteLine(table.ContainsKey("Aman")) ;

            // remove
            // table.Remove("Aman") ;

            // containsKey
            Console.WriteLine(table.ContainsKey("Aman")) ;

            // print hashtable
            foreach(object key in table.Keys)
            {
                Console.WriteLine(key + " -> " + table[key]) ;
            }



        }

    }

}