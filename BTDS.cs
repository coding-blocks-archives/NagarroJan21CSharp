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
        
        public void CreateBT()
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

        public void Display()
        {
            Display(root) ;
        }

        private void Display(Node node) // 1k
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

            Display(node.left) ; // 2k
            Display(node.right) ; // 3k
        }

        public int Ht()
        {
            return Ht(root) ;
        }

        private int Ht(Node node)
        {
            if(node == null)
                return -1 ;
          
            int lh = Ht(node.left) ;
            int rh = Ht(node.right) ;

            int sp = Math.Max(lh, rh) ;

            return sp + 1 ;

        }

        public bool IsBalanced()
        {
            return IsBalanced(root) ;
        }

        private bool IsBalanced(Node node)
        {
            if(node == null)
                return true;

            bool lb = IsBalanced(node.left) ;
            bool rb = IsBalanced(node.right) ;

            int bf = Ht(node.left) - Ht(node.right) ;

            if(lb && rb && (bf == -1 || bf == 0 || bf == 1))
                return true ;
            else
                return false ;

        }

        public bool FlipEquivalent(BinaryTree other)
        {
            return FlipEquivalent(this.root, other.root) ;
        }

        private bool FlipEquivalent(Node t , Node o)
        {
            if(t == null && o == null)
                return true ;
            
            if(t == null || o == null)
                return false ;
                
            if(t.data != o.data)
                return false ;

            bool flip = FlipEquivalent(t.left , o.right) && FlipEquivalent(t.right, o.left) ;

            // if(flip)
            //     return true ;

            bool flipno = FlipEquivalent(t.left,o.left) && FlipEquivalent(t.right, o.right) ;

            return flip || flipno ;
        }

        public int Max()
        {
           return Max(root) ;
        }

        private int Max(Node node)
        {
            if(node == null)
                return Int32.MinValue ;

            int lm = Max(node.left) ;
            int rm = Max(node.right) ;

            return Math.Max(node.data , Math.Max(lm,rm)) ;
        }

        public int Min()
        {
           return Min(root) ;
        }

        private int Min(Node node)
        {
            if(node == null)
                return Int32.MaxValue ;

            int lm = Min(node.left) ;
            int rm = Min(node.right) ;

            return Math.Min(node.data , Math.Min(lm,rm)) ;
        }

        public bool IsBST()
        {
            return IsBST(root) ;
        }

        private bool IsBST(Node node)
        {
            if(node == null)
                return true ;

            bool lb = IsBST(node.left) ;
            bool rb = IsBST(node.right) ;

            if(lb && rb && node.data > Max(node.left) && node.data < Min(node.right))
                return true ;
            else
                return false ;
        }


    }

    public class Client
    {
        public static void main(string[] args)
        {
            BinaryTree bt = new BinaryTree ();
            // BinaryTree bt1 = new BinaryTree ();
         
            bt.CreateBT() ;
            // bt1.CreateBT() ;
          
            //bt.Display() ;
            
            // Console.WriteLine(bt.FlipEquivalent(bt1)) ;

            Console.WriteLine(bt.IsBST()) ; 
        }
    }
}