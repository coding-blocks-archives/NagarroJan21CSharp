using System ;
using System.Collections.Generic ;

namespace BTDS
{
    public class BinaryTree
    {
       public class Node
       {
           public int data ;
           public Node left ;
           public Node right ;

           public Node(int data)
           {
                this.data = data ;
                this.left = null ;
                this.right = null;
           }
       }

        Node root ;
        
        public void createBT()
        {
            Queue<Node> q = new Queue<Node>() ;

            int val = Convert.ToInt32(Console.ReadLine()) ;
            root = new Node(val) ;
            q.Enqueue(root) ;

            while(q.Count != 0)
            {
                Node pn = q.Dequeue() ;

                int ld = Convert.ToInt32(Console.ReadLine()) ;

                if(ld != -1)
                {
                    Node ln = new Node(ld) ;
                    pn.left = ln ;
                    q.Enqueue(ln) ;
                }

                int rd = Convert.ToInt32(Console.ReadLine()) ;

                if(rd != -1)
                {
                    Node rn = new Node(rd) ;
                    pn.right = rn ;
                    q.Enqueue(rn) ;
                }

            }

        }

        public void display()
        {
            display(root) ;
        }

        private void display(Node node) // 1k
        {
            if(node == null)
                return ;

            String str = "" ;

            if(node.left == null)
                str += "." ;
            else
                str += node.left.data ; // 1k.left.data -> 2k->data -> 20

            str += " -> " + node.data + " <- " ; // 1k.data -> 10

            if(node.right == null)
                str += "." ;
            else
                str += node.right.data ;

            Console.WriteLine(str) ;

            display(node.left) ; // 2k
            display(node.right) ; // 3k
        }


    }

    public class Client
    {
        public static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree ();
            bt.createBT() ;
            bt.display() ;
        }
    }
}