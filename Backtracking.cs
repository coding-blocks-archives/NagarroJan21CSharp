using System ;

namespace Backtracking
{
    class BacktrackingQs
    {
        static void main(string[] args)
        {

            int[,] maze = {{0,1,0,0},{0,0,0,0},{0,1,0,0},{0,0,1,0}} ;

            bool[,] visited = new bool[maze.GetLength(0), maze.GetLength(1)] ;

            BlockedMaze(maze, 0, 0, maze.GetLength(0)-1, maze.GetLength(1)-1 , visited, "") ; 

        }

        static void BlockedMaze(int[,] maze , int cr , int cc , int er , int ec , bool[,] visited, String ans)
        {

            if(cr == er && cc == ec)
            {
                Console.WriteLine(ans) ;
                return ;
            }

            if(cr < 0 || cc < 0 || cr >= maze.GetLength(0) || cc >= maze.GetLength(1) || maze[cr,cc] == 1 || visited[cr,cc])
            {
                return ;
            }

            visited[cr,cc] = true ;

            BlockedMaze(maze , cr-1, cc , er , ec, visited, ans + "T") ;
            BlockedMaze(maze , cr+1, cc , er , ec, visited, ans + "D") ;
            BlockedMaze(maze , cr, cc-1 , er , ec, visited, ans + "L") ;
            BlockedMaze(maze , cr, cc+1 , er , ec, visited, ans + "R") ;

            visited[cr,cc] = false ;
        }


        static void Sudoku(int[,] grid, int cr , int cc, int er , int ec)
        {

            if(cr > er)
            {
                display(grid) ;
                return ;
            }

            if(cc > ec)
            {
                Sudoku(grid, cr+1, 0, er, ec) ;
                return ;
            }

            if(grid[cr,cc] != 0)
            {
                Sudoku(grid, cr, cc+1, er, ec) ;
                return ;
            }

            for(int i = 1 ; i <= 9 ; i++)
            {
                if(IsItSafe(grid, cr, cc, i))
                {
                    grid[cr,cc] = i ;
                    Sudoku(grid, cr , cc+1, er, ec) ;
                    grid[cr, cc] = 0 ;
                }
            }


        }

        static bool IsItSafe(int[,] grid, int row, int col, int val)
        {
            // row
            for(int c = 0 ; c < grid.GetLength(1) ; c++)
            {
                if(grid[row,c] == val)
                    return false ;
            }

            // col
            for(int r = 0 ; r < grid.GetLength(0) ; r++)
            {
                if(grid[r,col] == val)
                    return false ;
            }

            // 3*3 grid
            
        }

        static void display(int[,] grid)
        {
            Console.WriteLine("--------------------------------") ;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1) ; j++)
                {
                    Console.Write(grid[i,j] + " ") ;
                }   

                Console.WriteLine() ;
            }

            Console.WriteLine("--------------------------------") ;
        }

    }
}