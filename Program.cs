using System;

namespace Xiangqi
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            (int,int,int,int) position;
            Console.WriteLine("游戏开始！");
            Console.WriteLine("棋盘初始化中……");
            GameBoard Board = new GameBoard("中国象棋棋盘",10,9);
            Board.GiveThePiece();
            display show = new display();
            show.showPiece(Board);
            int i;
            chesspiece piece;
            do{
                do{
                    //bool wine;
                    int turn = count%2;
                    Console.WriteLine("------------------------------");//30
                    if(turn == 0){
                        Console.WriteLine("红方回合:");
                    }else{
                        Console.WriteLine("黑方回合:");
                    }
                    //选择棋子和目的地
                    position = show.Selectpiece(Board);
                    int x = position.Item1;
                    int y = position.Item2;
                    //判断当前回合是否完成
                    bool round = show.currentRound(Board,x,y,turn);
                    piece = Board.board[position.Item1,position.Item2];
                    if(round){
                        //如果成功移动，则跳出循环进入下一回合，如果移动不成功,则重新开始第一回合
                        if(piece.ValidMove(Board,position.Item1,position.Item2,position.Item3,position.Item4)){
                            count++;
                            Board.movePiece(position.Item1,position.Item2,position.Item3,position.Item4);
                            show.showPiece(Board);
                            bool wine = show.isWine(Board);
                            if(wine){
                                break;
                            }else{
                                continue;
                            }
                        }else{
                            Console.WriteLine("棋子移动不符合规则！");
                        }
                    }
                }while(!piece.ValidMove(Board,position.Item1,position.Item2,position.Item3,position.Item4));
                Console.WriteLine("输入1继续");
                i = Convert.ToInt32(Console.ReadLine());
            }while(i==1);
            Console.ReadKey();
        }
    }
}
