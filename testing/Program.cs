// See https://aka.ms/new-console-template for more information

// Assignment: Tic Tac Toe Game (CSE210)
// Author: Michelle Huang
// Date: 1/18/2021


using System;
using System.Collections.Generic;

namespace tictactoe
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Tic Tac Toe");
            // create a string for board
            List<string> board = new List<string>(9) {"1","2","3","4","5","6","7","8","9"};
            string currentPlayer = "x";
            while (!GameOver(board))
            {
                if (currentPlayer == "x")
                {
                    DisplayBoard(board);
                    board = PlayersMove(board, currentPlayer); 
                    currentPlayer = "o";
                }
                else
                {
                    DisplayBoard(board);
                    board = PlayersMove(board, currentPlayer); 
                    currentPlayer = "x";
                }
                
            }
            DisplayBoard(board);
            Console.WriteLine("Good game. Thanks for playing!");
           
        }

        static void DisplayBoard(List<string> board) // board function that creates and diplays the board

        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]} ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]} ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]} ");
            Console.WriteLine("     |     |     ");
        }


        static List<string> PlayersMove(List<string> board, string player)
        {
            Console.Write($"{player}'s turn to choose a square (1-9): ");
            string userInput = Console.ReadLine();
            int index = int.Parse(userInput);
            if (index >= 1 || index <= 9)
            {
                board[index - 1] = player;
            }
            else
            {
                Console.WriteLine("Not a valid number/spot unavailable!");
            }

            return board;
        }

            
        static bool GameOver(List<string> board)
        {
            bool GameOver = false;

            if (CheckWin(board, "x") || CheckWin(board, "o") || CheckDraw(board))
            {
                GameOver = true;
            }
            
            return GameOver;
        }

        
        static bool CheckWin(List<string> board, string player)
        {
            bool checkWin = false;
                // check win top                                    check win for far left                            diagonal from left to right
            if ((board[0] == board [1] && board[1] == board[2]) || (board[0] == board[3] && board[3] == board[6]) || (board[0] == board[4] && board[4] == board[8])
                    // check middle middle (L to R)                   check win from top to bottom (middle)
                || (board[3] == board[4] && board[4] == board[5]) || (board[1] == board[4] && board[4] == board[7]) 
                    // check win bottom                               check win for far right                           check win for diagonal from right to left
                || (board[6] == board[7] && board[7] == board[8]) || (board[2] == board[5] && board[5] == board[8]) || (board[2] == board[4] && board[4] == board[6]))
            {
                checkWin = true;
            }
            
            return checkWin;
       }

        static bool CheckDraw(List<string> board)
        {
            bool checkDraw = false;
            foreach (string value in board)
            {
                if (value != "x" || value != "o") // trying to see if there is a number in the board
                {
                    checkDraw = false;
                    break;
                }
                checkDraw = true;
            }
            return checkDraw;
        }
    }
}    