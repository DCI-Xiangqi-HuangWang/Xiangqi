using System;
namespace Xiangqi{
    class GameBoard 
    {
        string Name;
        int columns;
        int rows;
        public chesspiece[,] board;
        public GameBoard(string name,int columns,int rows){
            this.Name = name;
            this.columns = columns;
            this.rows = rows;
            this.board = new chesspiece[columns,rows];
        }
        //得到当前棋盘
        public chesspiece[,] getBoard(){
            return this.board;
        }
        public void setBoard(chesspiece[,] board){
            this.board = board;
        }
        public string getName(){
            return this.Name;
        }
        public int getRow(){
            return this.rows;
        }
        public int getColumn(){
            return this.columns;
        }

        public void GiveThePiece()//给棋盘所有棋子赋值,初始化游戏棋盘
        {
            for ( int i = 0; i < board.GetLength(0); i++)//10
            {
                for ( int j = 0; j < board.GetLength(1); j++)//9
                {
                    this.board[i,j] = new blank(chesspiece.Player_side.blank,i,j);//棋盘的(x，y)
                }
            }
            board[9, 0] = new chariot(chesspiece.Player_side.red,9,0);             //每个棋子的起始位置
            board[9, 1] = new house(chesspiece.Player_side.red,9,1);
            board[9, 2] = new elephant(chesspiece.Player_side.red,9,2);
            board[9, 3] = new advisor(chesspiece.Player_side.red,9,3);
            board[9, 4] = new general(chesspiece.Player_side.red,9,4);
            board[9, 5] = new advisor(chesspiece.Player_side.red,9,5);
            board[9, 6] = new elephant(chesspiece.Player_side.red,9,6);
            board[9, 7] = new house(chesspiece.Player_side.red,9,7);
            board[9, 8] = new chariot(chesspiece.Player_side.red,9,8);
            board[7, 1] = new cannon(chesspiece.Player_side.red,7,1);
            board[7, 7] = new cannon(chesspiece.Player_side.red,7,7);
            board[6, 0] = new soldier(chesspiece.Player_side.red,6,0);
            board[6, 2] = new soldier(chesspiece.Player_side.red,6,2);
            board[6, 4] = new soldier(chesspiece.Player_side.red,6,4);
            board[6, 6] = new soldier(chesspiece.Player_side.red,6,6);
            board[6, 8] = new soldier(chesspiece.Player_side.red,6,8);

            board[0, 0] = new chariot(chesspiece.Player_side.black,0,0);
            board[0, 1] = new house(chesspiece.Player_side.black,0,1);
            board[0, 2] = new elephant(chesspiece.Player_side.black,0,2);
            board[0, 3] = new advisor(chesspiece.Player_side.black,0,3);
            board[0, 4] = new general(chesspiece.Player_side.black,0,4);
            board[0, 5] = new advisor(chesspiece.Player_side.black,0,5);
            board[0, 6] = new elephant(chesspiece.Player_side.black,0,6);
            board[0, 7] = new house(chesspiece.Player_side.black,0,7);
            board[0, 8] = new chariot(chesspiece.Player_side.black,0,8);
            board[2, 1] = new cannon(chesspiece.Player_side.black,2,1) ;
            board[2, 7] = new cannon(chesspiece.Player_side.black,2,7);
            board[3, 0] = new soldier(chesspiece.Player_side.black,3,0);
            board[3, 2] = new soldier(chesspiece.Player_side.black,3,2);
            board[3, 4] = new soldier(chesspiece.Player_side.black,3,4);
            board[3, 6] = new soldier(chesspiece.Player_side.black,3,6);
            board[3, 8] = new soldier(chesspiece.Player_side.black,3,8);
        }
    
        public void movePiece(int x ,int y,int x1, int y1){
                chesspiece load  = new blank(chesspiece.Player_side.blank,x,y); 
                //Console.WriteLine(load.getType());
                
                this.board[x,y].setX(x1);
                this.board[x,y].setY(y1);
                this.board[x1,y1] = this.board[x,y];
                this.board[x,y] = load;

                //Console.WriteLine(this.board[x,y].getType());
        }
    }
}
