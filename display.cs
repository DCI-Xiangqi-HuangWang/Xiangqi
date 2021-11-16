using System;
 namespace Xiangqi
 {
     class display{
        public void showPiece(GameBoard board){
            //Console.BackgroundColor = ConsoleColor.Yellow;
            //chesspiece[,] board1 = board.getBoard();
            Console.WriteLine("------------------------------");
            int[] num = new int[10]{0,1,2,3,4,5,6,7,8,9};
            for(int i=0;i<9;i++){
                Console.Write($"{num[i]} ");
            }
            Console.WriteLine("\n");
            for(int i=0;i<10;i++){
                for (int j=0;j<9;j++){
                    //Console.BackgroundColor = ConsoleColor.Yellow;  //设置黑屏为绿屏，即背景颜色
                    //chesspiece.Piece_type piecetypes = board1[i,j].getType();
                    if(board.getBoard()[i,j].getPlayer() == chesspiece.Player_side.red){
                        //Console.ForegroundColor = ConsoleColor.Red;
                        switch(board.getBoard()[i,j].getType()){
                        case chesspiece.Piece_type.general:
                            Console.Write("帅");
                            break;
                        case chesspiece.Piece_type.advisor:
                            Console.Write("仕");
                            break;
                        case chesspiece.Piece_type.elephant:
                            Console.Write("相");
                            break;
                        case chesspiece.Piece_type.house:
                            Console.Write("马");
                            break;
                        case chesspiece.Piece_type.chariot:
                            Console.Write("车");
                            break;
                        case chesspiece.Piece_type.cannon:
                            Console.Write("炮");
                            break;
                        case chesspiece.Piece_type.soldier:
                            Console.Write("兵");
                            break;
                        case chesspiece.Piece_type.blank:
                            Console.Write("  ");
                            break;
                        default: 
                            //Console.WriteLine("  ");
                            break;
                        }
                        if(j==8){
                            Console.Write($"  {num[i]}\n");
                        }
                    }else {
                         //Console.ForegroundColor = ConsoleColor.Black;
                        switch(board.getBoard()[i,j].getType()){
                        case chesspiece.Piece_type.general:
                            Console.Write("将");
                            break;
                        case chesspiece.Piece_type.advisor:
                            Console.Write("士");
                            break;
                        case chesspiece.Piece_type.elephant:
                            Console.Write("象");
                            break;
                        case chesspiece.Piece_type.house:
                            Console.Write("马");
                            break;
                        case chesspiece.Piece_type.chariot:
                            Console.Write("车");
                            break;
                        case chesspiece.Piece_type.cannon:
                            Console.Write("砲");
                            break;
                        case chesspiece.Piece_type.soldier:
                            Console.Write("卒");
                            break;
                        case chesspiece.Piece_type.blank:
                            Console.Write("  ");
                            break;
                        default: 
                            //Console.WriteLine("  ");
                            break;
                        }
                        if(j==8){
                            Console.Write($"  {num[i]}\n");
                        }
                    }   
                }
            }         
        }



        //用来选择移动的棋子并得到目的地,并且得到当前回合
        public (int,int,int,int) Selectpiece(GameBoard board){
            int x, y,x1, y1;
            Console.WriteLine("Please enter the coordinates of the pieces you want to move：");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the coordinates of the piece to be moved:");
            x1 = Convert.ToInt32(Console.ReadLine());
            y1 = Convert.ToInt32(Console.ReadLine());
            return (x,y,x1,y1);
        }
        public bool currentRound(GameBoard board,int x,int y,int turn){
             //其次要得到当前回合
             bool temp = true;
            if(turn==0){
                if(board.board[x,y].getPlayer()!=chesspiece.Player_side.red){
                    Console.WriteLine("当前回合只能移动红棋子！");
                    temp=false;
                }
            }else{
                if (board.board[x,y].getPlayer()!=chesspiece.Player_side.black){
                    Console.WriteLine("当前回合只能移动黑棋子！");
                    temp=false;
                }
            }
            return temp;
        }

      //判断游戏是否结束
	    public bool isWine(GameBoard board) {
            bool temp = false;
            int a=0;
            int b=0;
            for(int i=0;i<10;i++){
                for(int j=3;j<6;j++){
                    if(board.board[i,j].getType()==chesspiece.Piece_type.general&&board.board[i,j].getPlayer()==chesspiece.Player_side.red){
                        a=1;
                    }
                    else if(board.board[i,j].getType()==chesspiece.Piece_type.general&&board.board[i,j].getPlayer()==chesspiece.Player_side.black){
                        b=1;
                    }
                }
            }
            if(a==0){
                Console.WriteLine("黑方获胜！");
                temp = true;
            }
            else if(b==0){
                Console.WriteLine("红方获胜！!!!");
                temp = true;
            }
            return temp;
	    }
    }
 }
