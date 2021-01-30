using System ;
using System.Collections.Generic ;

namespace GraphDS
{
    public class Graph
    {
        public class Pair
        {
            public int nbr ;
            public int cost ;

            public Pair(int nbr , int cost)
            {
                this.nbr = nbr ;
                this.cost = cost ;
            }

        }

        LinkedList<Pair>[] al ;

        public Graph(int V)
        {
            al = new LinkedList<Pair>[V] ;

            for(int i = 0 ; i < al.Length ; i++)
            {
                al[i] = new LinkedList<Pair>() ;
            }

        }

        public void AddEdge(int u , int v , int wt)
        {
            Pair up = new Pair(v , wt) ;
            Pair vp = new Pair(u , wt) ;

            al[u].AddLast(up) ;
            al[v].AddLast(vp) ;
        }

        public void Display()
        {
            int V = al.Length ;

            for(int i = 0 ; i < V ; i++)
            {
                Console.Write(i + " -> ") ;

                foreach(Pair p in al[i])
                {
                    Console.Write(p.nbr + "[" + p.cost + "]  ") ;
                }
                Console.WriteLine() ;
            }
        }

        public void BFT()
        {
            int V = al.Length ;

            bool[] visited = new bool[V] ;
            Queue<int> q = new Queue<int>() ;

            for(int i = 0 ; i < V ; i++)
            {
                if(visited[i])
                    continue ;

                q.Enqueue(i) ;
                visited[i] = true ;

                while(q.Count != 0)
                {
                    // remove the element
                    int re = q.Dequeue() ;

                    // print
                    Console.Write(re + "\t") ;

                    // unvisited nbrs
                    foreach(Pair p in al[re])
                    {
                        if(!visited[p.nbr])
                        {
                            q.Enqueue(p.nbr) ;
                            visited[p.nbr] = true ;
                        }
                    }
                }
            }

            Console.WriteLine() ;
        }

        public void DFT()
        {
            int V = al.Length ;

            bool[] visited = new bool[V] ;
            Stack<int> q = new Stack<int>() ;

            for(int i = 0 ; i < V ; i++)
            {
                if(visited[i])
                    continue ;
                    
                q.Push(i) ;
                visited[i] = true ;

                while(q.Count != 0)
                {
                    // remove the element
                    int re = q.Pop() ;

                    // print
                    Console.Write(re + "\t") ;

                    // unvisited nbrs
                    foreach(Pair p in al[re])
                    {
                        if(!visited[p.nbr])
                        {
                            q.Push(p.nbr) ;
                            visited[p.nbr] = true ;
                        }
                    }
                }
            }

            Console.WriteLine() ;
        }

    }

    public class Client
    {
        public static void Main(string[] args)
        {
            Graph g = new Graph(7) ;

            g.AddEdge(0, 1, 2);
            g.AddEdge(0, 3, 6);
            g.AddEdge(1, 2, 3);
            g.AddEdge(2, 3, 1);
            g.AddEdge(3, 4, 4);
            g.AddEdge(4, 5, 5);
            g.AddEdge(4, 6, 6);
            g.AddEdge(5, 6, 7);

            g.Display() ;
            g.DFT() ;

        }
    }

}