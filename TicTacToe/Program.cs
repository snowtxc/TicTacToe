using System;
using System.Globalization;

namespace HellowWorld
{

  

    
    internal class Program
    {
      
        static void Main(string[] args)
        { 
            char[,] tictactoe = new char[3, 3] {
                {'-','-','-' },
                {'-','-','-' },
                {'-','-','-' }
            };

            
            int rowChoice;
            int colChoice;


            char turn = 'X';
            string turnText;
            while (true)
            {

                PrintTictacToe(tictactoe);
                turnText = turn == 'X' ? "Turno del jugador 1" : "Turno del jugador 2";
                Console.WriteLine(turnText);
                
                do
                {
                    Console.Write("Escribe un posicion de la fila(1-3):");
                    rowChoice = LeerInt();

                } while (rowChoice < 1 || rowChoice > 3);
                do
                {
                    Console.Write("Escribe un posicion de la columna(1-3):");
                    colChoice = LeerInt();
                } while (colChoice < 1 || colChoice > 3);

                int indexRow = rowChoice - 1;
                int indexCol = colChoice - 1;

                if (tictactoe[indexRow , indexCol ] == '-')
                {
                    tictactoe[indexRow, indexCol] = turn;
                    if(turn == 'X')
                    {
                        turn = 'O';
                    }else{
                        turn = 'X';
                    }

                    if (Checker(tictactoe))
                    {
                        break;
                    }


                }
                else
                {
                    Console.WriteLine("Ya hay un valor aqui vuelve a intentarlo");
                }
            }

            Console.WriteLine("Jugador" + turn + " Has ganado!!");
            Console.Read();
            
            
         

           

      
        }


        public static void PrintTictacToe(char[,] board)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int z =0; z < 3; z++)
                {
                    Console.Write(board[i, z] + " ");
                }
                Console.Write("\n");

            }
        }
        public static bool Checker(char[,] board)
        { 
            for(int i = 0;  i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (board[i,j] != '-') {

                        /*Si el indice d ela fila y la columna son iguales quiere decir
                         que pertenece a la diagonal por lo tanto se puede calcular"*/
                        if (i == j)    
                        {
                            if (CheckDiagonal(board, i, j))
                            {
                                return true;
                            }
                        }

                        /*Solo en uno de estos tres casos se puede checkear la diagonal inversa*/
                        if ((i == 2 && j == 0) || (i == 1 && j == 1) || (i == 0 && j == 2))
                        {
                            if (CheckInverseDiagonal(board, i, j))
                            {
                                return true;
                            }
                        }


                        /*Cualquier posicion se puede checkear si esta completo en vertical o en diagonal*/
                        if (CheckHorizontal(board, i, j))
                        {
                            return true;
                        }

                        if(CheckVertical(board, i, j))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
           
        }

        //Checkea si el ticktactoe tiene una diagonal no inversa para el elemento con la posicion en row y col
        public static bool CheckDiagonal(char[,] board,int row,int col)  
        {
            char value = board[row, col];
            int points = 0;
            try{
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, i] == value)
                    {
                        points++;
                    }
                }
                if (points == 3)
                {
                    return true;
                }
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            
           
        }

        public static bool CheckInverseDiagonal(char[,] board, int row, int col){
            char value = board[row, col];
            int points = 0;


            int rowI = 0;
            int colI = col;
            try
            {
                while (rowI <= 2 && rowI >= 0){
                    if(value == board[rowI, colI]){
                        points++;
                    }
                    colI--;
                    rowI++;
                }

                if(points == 3)
                {
                    return true;
                }
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public static bool CheckHorizontal(char[,] board , int row,int col){
            char value = board[row, col];
            int points = 0;

            int rowAux = row;
            int colAux = 0;

            while (colAux >= 0 && colAux <= 2){
                if(value == board[rowAux,colAux])
                {
                    points++;
                }
                colAux++;
            }
            if(points == 3)
            {
                return true;
            }

            return false;
        }

        public static bool CheckVertical(char[,] board, int row, int col)
        {
            char value = board[row, col];
            int points = 0;

            int rowAux = 0;
            int colAux = col;

            while (rowAux >= 0 && rowAux <= 2)
            {
                if (value == board[rowAux, colAux])
                {
                    points++;
                }
                rowAux++;
            }
            if (points == 3)
            {
                return true;
            }

            return false;
        }



        private static void GetOdd(int[] numbers){
            foreach(int i in numbers)
            {
                if(i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }


        private static void GetEven(int[] numbers)
        {
            foreach (int i in numbers)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }

        }

        private static int LeerInt()
        {
            string inputNum;
            int res;
            while (true)
            {
                try
                {
                    inputNum = Console.ReadLine();
                    res = int.Parse(inputNum);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Numero invalido");
                }
            }
            return res;

        }


        private static void GreetFriend(string friendName)
        {
            Console.WriteLine("Hello {0} , my friend", friendName);

        }

        private static string LowUpper(string word)
        {
            word = word.Trim();
            return word.ToLower() + word.ToUpper();
        }

        private static int Count(string word)
        {
            return word.Length;
        }
        public static void Check(int number)
        {
            if(number % 2 == 0)
            {
                Console.WriteLine("Es par");
                return;
            }
            Console.WriteLine("Es impar");
            return;
        }

        public static void NestedCheck(int number)
        {
            if(number % 3 == 0)
            {
                Console.WriteLine("Divisible by 3");
            }
            else if(number % 3 != 0 && number % 7 == 0)
            {
                Console.WriteLine("Divisible by 7");
            }
            else
            {
                if(number % 2 != 0)
                {
                    Console.Write("Its not divisible by 3 and by 7 but is a odd number ");
                }
                else
                {
                    Console.Write("Its not divisible by 3 and by 7 but is a even number ");
                }

            }
        }


       

        public static void ForLoop()
        {
            for(int i = -3; i <= 3; i++)
            {
                Console.WriteLine(i);
            }

        }

        public static void WhileLoop()
        {
            int i = -3;
            while(i <= 3)
            {
                Console.WriteLine(i);
                i++;
            }
        }
    }
}
