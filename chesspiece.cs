using System;
namespace Xiangqi
{
    abstract class chesspiece
    {
       public Player_side player;
       public Piece_type piecetype;
       public int Column;
       public int Row;
       public int getX(){
           return this.Column;
       }
       public int setX(int x){
           return this.Column = x;
       }
       public int getY(){
           return this.Row;
       }
       public int setY(int y){
           return this.Row;
       }
        public abstract bool ValidMove(GameBoard board,int x,int y,int destX, int destY);

        public chesspiece(Player_side player,int column, int row){
            this.player = player;
            this.Column = column;
            this.Row = row;
            //this.Board = board.getBoard();//得到当前棋盘
        }
        public chesspiece(int column,int row){
            this.Row =row;
            this.Column =column;
            this.player = Player_side.blank;
            this.piecetype = Piece_type.blank;
        }
        public enum Piece_type{
            blank,
            general,
            advisor,
            elephant,
            chariot,
            cannon,
            house,
            soldier
        }
        public Piece_type getType(){
            return this.piecetype;
        }
        public Piece_type setType(Piece_type type){
            return this.piecetype = type;
        }

        public void SetCol(int col){
            this.Column = col;
        }

        public void SetRow(int row){
            this.Row = row;
        }
        public enum Player_side{
            blank,
            black,
            red
        }
        public Player_side getPlayer(){
            return this.player;
        }
        public Player_side setPlayer(Player_side player){
            return this.player = player;
        }
    }
    
     //“将”类
    class general : chesspiece{
        public general(Player_side player,int column, int row) : base(player,column, row){
            setType(Piece_type.general);
        }

        //它只能在“九宫”之内活动，可上可下，可左可右,
        //每次走动只能按竖线或横线走动一格。帅与将不能在同一直线上直接对面，否则走方判负
         public override bool ValidMove( GameBoard board,int x,int y,int destX, int destY){
            
            bool temp= false;
            chesspiece[,] theboard = board.board;
            //int i=0;
            //int j=0;
            display show = new display();
            //判断是否落在原处
            //如果不落在原处的话
            if (!(x == destX && y == destY)) {
                //目的地只能在米字格范围里
                //横移一格或竖移一格
                //目的地满足九宫的范围，为true
                //红帅
                if (theboard[x,y].getPlayer() == chesspiece.Player_side.red){ 
                    temp = (destX >= 7 && destY >= 3 && destY <= 5 );//&& (Math.Abs(x - destX) + Math.Abs(y - destY) == 1));
                }
                //黑将
                else if (theboard[x,y].getPlayer() == chesspiece.Player_side.black){
                    temp = (destX <= 2 && destY >= 3 && destY <= 5 );//&& (Math.Abs(x - destX) + Math.Abs(y - destY) == 1));
                }
                //两个棋子碰面就能吃 找到另一个帅的xy
                /*else if (theboard[x,y].getPlayer()==Player_side.black||theboard[x,y].getPlayer()==Player_side.red)
                {
                    for(int column=0;column<10;column++){
                        for(int row=0;row<9;row++){
                            //找到另一个与要移动的的将不一样的将
                            if((theboard[column,row].getType()==chesspiece.Piece_type.general) && (theboard[column,row]!=theboard[x,y])){
                                i=column;
                                j=row;
                                break;
                            }
                        }   
                    }
                    if (destY == j)  //说明将会移动到跟另一个将在同一y轴的位置
                    {
                        //比较起点行和落点行的大小
                        int max = destX > i ? destX : i;
                        int min = destX > i ? i : destX;

                        //统计移动路径上棋子的数量
                        int chessNum = 0;
                        for (int a = min + 1; a <= max - 1; a++)
                        {
                            if (theboard[a,destY].getPlayer()!= chesspiece.Player_side.blank) {
                                chessNum++;
                            }
                        }        
                        //当两个将之间没有棋子,则对面的将可以吃了这个移动的将
                        //对面的将赢
                        if (chessNum == 0){
                            board.movePiece(destX,destY,i,j);
                           // show.isWine(board);
                            temp = true;
                            //return true;
                        }
                        else if(chessNum != 0){
                            temp = true;
                        }
                           
                    }
                }*/
                //横移一格或竖移一格
                //目的地满足九宫的范围,同时满足这两个条件为true
                temp = temp && (Math.Abs(this.Column - destX) + Math.Abs(this.Row - destY) == 1)&&(theboard[destX,destY].getType()!=chesspiece.Piece_type.soldier);
            }
            
            return temp;
        }
    
    }
    //“士”类
    class advisor : chesspiece{
        public advisor(Player_side player,int column, int row) : base(player,column, row){
            setType(Piece_type.advisor);
            //chesspiece.CreatePiece(Piece_type.advisor,player,column,row);
        }

        public override bool ValidMove( GameBoard board,int x,int y,int destX, int destY){
            bool temp= false;
            chesspiece[,] theboard = board.board;
            //判断是否落在原处
            //如果不落在原处的话
            if (!(x == destX && y == destY)) {
                //只能在米字格里走
                //红方
                if (theboard[x,y].getPlayer() == chesspiece.Player_side.red){ 
                    temp = (destX >= 7 && destY >= 3 && destY <= 5 );
                }
                //黑方
                else if (theboard[x,y].getPlayer() == chesspiece.Player_side.black){
                    temp = (destX <= 2 && destY >= 3 && destY <= 5 );
                }
                //只能斜着走
                temp = temp && (Math.Abs(destY-y) ==1 && Math.Abs(destX-x) == 1 && theboard[destX,destY].getType() != chesspiece.Piece_type.general);
            }
            return temp;
        }
    }
    //“象”类
    class elephant : chesspiece{
        public elephant(Player_side player,int column, int row) : base(player, column, row){
            setType(Piece_type.elephant);
            //chesspiece.CreatePiece(Piece_type.elephant,player,column,row);
        }
         public override bool ValidMove( GameBoard board,int x,int y,int destX, int destY){
            bool temp= false;
            chesspiece[,] theboard = board.board;
            
            //判断是否落在原处
            //如果不落在原处的话
            if (!(x == destX && y == destY)) {
                //只能在本方移动
                //黑方 
                if(theboard[x,y].getPlayer() == chesspiece.Player_side.black){
                    temp = (destX < 5 );
                }
                //红方
                else if(theboard[x,y].getPlayer() == chesspiece.Player_side.red){
                    temp = (destX > 4 );
                }
                
                //满足走田字
                temp = temp &&( (Math.Abs(destY-y)==2 && Math.Abs(destX-x)==2 )&& (theboard[(destX+x)/2,(destY+y)/2].getType() == chesspiece.Piece_type.blank) && (theboard[destX,destY].getType() != chesspiece.Piece_type.general) && (theboard[destX,destY].getType() != chesspiece.Piece_type.advisor));
                
            }
            return temp;

         }
    }
    //“马”类
    class house : chesspiece{
        public house(Player_side player,int column, int row) : base(player,column, row){
            setType(Piece_type.house);
            //hesspiece.CreatePiece(Piece_type.house,player,column,row);
        }
         public override bool ValidMove( GameBoard board,int x,int y,int destX, int destY){
            bool temp= false;
            chesspiece[,] theboard = board.board;
            //判断是否落在原处
            //如果不落在原处的话
            if (!(x == destX && y == destY)) {
                //双方都可以过河
                //如果横着走日子，且不拌马脚
                if (theboard[x, (y + destY) / 2].getType() == chesspiece.Piece_type.blank)
                        temp = true;

                //如果竖着走日字，且不绊马脚
                else if (theboard[(x + destX) / 2, y].getType() == chesspiece.Piece_type.blank)
                        temp = true;
                
                temp = temp && ((Math.Abs(y - destY) ==1 &&  Math.Abs(x - destX) ==2)||(Math.Abs(y - destY) ==2 &&  Math.Abs(x - destX) ==1) && (theboard[destX,destY].getType() != chesspiece.Piece_type.general) && (theboard[destX,destY].getType() != chesspiece.Piece_type.advisor) && (theboard[destX,destY].getType() != chesspiece.Piece_type.elephant)) ;
                
            }
            
            return temp;
        }
    }
    //“车”类
    class chariot : chesspiece{
        public chariot(Player_side player,int column, int row) : base(player,column, row){
            setType(Piece_type.chariot);
            //chesspiece.CreatePiece(Piece_type.chariot,player,column,row);
        }

        //横线、竖线均可行走，只要无子阻拦，步数不受限制,不能拐弯
        public override bool ValidMove( GameBoard board,int x,int y,int destX, int destY){
            bool temp= false;
            chesspiece[,] theboard = board.board;

            //如果不落在原处的话
            if (!(x == destX && y == destY)) {
                //红车、黑车
                //if (this.player == chesspiece.Player_side.red || this.player == chesspiece.Player_side.black){
                    //如果车竖着走,y不变，只改变x
                    if (destY == y){
                        //  x?y:z 表示如果表达式x为true，则返回y；如果x为false，则返回z，是省略if{}else{}的简单形式
                        //如果this.Column>destX则max=this.Column,如果不满足，max=destX
                        int max = x > destX ? x : destX;
                        int min = x > destX ? destX :x;

                        //走过的路径有没有棋子挡着
                        int chessNum = 0;
                        for (int i = min + 1; i <= max - 1; i++){
                            if (theboard[i,y].getType() != chesspiece.Piece_type.blank)
                                chessNum++;
                        }
                        //没有棋子阻拦
                        if (chessNum == 0){ 
                            //目的地为空或者敌方棋子
                            if (theboard[destX,destY].getType() == chesspiece.Piece_type.blank || theboard[destX,destY].getPlayer() != theboard[x,y].getPlayer()){
                                //目的地棋子不为象、士、马
                                if(theboard[destX,destY].getType()!=chesspiece.Piece_type.elephant && theboard[destX,destY].getType()!=chesspiece.Piece_type.advisor && theboard[destX,destY].getType()!=chesspiece.Piece_type.general){
                                    temp = true;
                                }
                            }
                        }  
                    }
                    //如果车横着走
                    else if (destX == x){
                        //如果y>destY则max=y,如果不满足，max=destY
                        int max = y > destY ? y : destY;
                        int min = y > destY ? destY :y;

                        //走过的路径有没有棋子挡着
                        int chessNum = 0;
                        for (int i = min + 1; i <= max - 1; i++){
                            if (theboard[x,i].getType() != chesspiece.Piece_type.blank)
                                chessNum++;
                        }
                        //没有棋子阻拦
                        if (chessNum == 0){ 
                            //目的地为空或者敌方棋子
                            if (theboard[destX,destY].getType() == chesspiece.Piece_type.blank || theboard[destX,destY].getPlayer() != theboard[x,y].getPlayer()){
                                //目的地棋子不为象、士、马
                                if(theboard[destX,destY].getType()!=chesspiece.Piece_type.elephant && theboard[destX,destY].getType()!=chesspiece.Piece_type.advisor && theboard[destX,destY].getType()!=chesspiece.Piece_type.general){
                                    temp = true;
                                }
                            }
                        }  
                    }
                //}
            }
            return temp;
        }
    }
    //“炮”类
    class cannon : chesspiece{
        public cannon(Player_side player,int column, int row) : base(player,column, row){
            setType(Piece_type.cannon);
           // chesspiece.CreatePiece(Piece_type.cannon,player,column,row);
        }
         public override bool ValidMove(GameBoard board,int x, int y,int destX,int destY)
         {
             bool temp=false;
             chesspiece[,] theboard = board.board;
             if (!(x == destX && y == destY))
             {
              //如果是竖着走
                if (destY == y)
                {
                    //比较起点行和落点行的大小
                    int max=0;
                    int min=0;
                    if(destX>x){
                         max = destX;
                         min = x;
                    }
                    else{
                        max = x;
                        min = destX; 
                    }

                    //统计移动路径上棋子的数量
                    int chessNum = 0;
                    for (int i = min+1 ; i <= max-1 ; i++)
                    {
                        if (theboard[i, y].getPlayer()==chesspiece.Player_side.red || theboard[i, y].getPlayer()==chesspiece.Player_side.black) 
                        //if (theboard[i, y].getPlayer()!=chesspiece.Player_side.blank) 
                            chessNum++;
                    }
                     //Console.WriteLine("chessnum"+chessNum);
                     //Console.WriteLine("min"+min);
                     //Console.WriteLine("max"+max);  
      
                    //当移动路径上棋子数量为0时，落子点为无子
                    if (chessNum == 0 && theboard[destX,destY].getPlayer()==chesspiece.Player_side.blank)
                    {
                         temp = true;
                    }
                     //当移动路径上棋子数量为1时，落子点为对方棋子
                    else if(chessNum == 1 && theboard[destX,destY].getPlayer()!=chesspiece.Player_side.blank && theboard[destX,destY].getPlayer()!=theboard[x,y].getPlayer())
                         temp = true;
                }
                //如果是横着走
                else if (destX == x)
                {
                    //比较起点列和落点列的大小
                    int max=0;
                    int min=0;
                    if(destY>y){
                         max = destY;
                         min = y;
                    }
                    else{
                        max = y;
                        min = destY; 
                    }

                    //统计移动路径上棋子的数量
                    int chessNum = 0;
                    for (int i = min+1 ; i <= max-1 ; i++)
                    {
                        if (theboard[x,i].getPlayer()==chesspiece.Player_side.red || theboard[x,i].getPlayer()==chesspiece.Player_side.black) 
                            chessNum++;
                    }
                     //Console.WriteLine("chessnum"+chessNum);
                     //Console.WriteLine("min"+min);
                     //Console.WriteLine("max"+max);  
                     
                        //当移动路径上棋子数量为0时，落子点为无子
                    if (chessNum == 0 && theboard[destX,destY].getPlayer()==chesspiece.Player_side.blank)
                    {
                        temp = true;
                    }
                    //当移动路径上棋子数量为1时，落子点为对方棋子
                    else if(chessNum == 1 && theboard[destX,destY].getPlayer()!=chesspiece.Player_side.blank && theboard[destX,destY].getPlayer()!=theboard[x,y].getPlayer()&&theboard[destX,destY].getType()!=chesspiece.Piece_type.house)
                        temp = true;

                }       
        
            }
                   return temp;
        }
    }
    //“卒”类
    class soldier : chesspiece{
        public soldier(Player_side player,int column, int row) : base(player,column, row){
            setType(Piece_type.soldier);
            //chesspiece.CreatePiece(Piece_type.soldier,player,column,row);
        }
        public override bool ValidMove(GameBoard board,int x,int y,int destX, int destY)
        {
            bool temp = false;
            chesspiece[,] theboard = board.board;
             if (!(x == destX && y == destY))
             {
                  //红方
                  if (theboard[x,y].getPlayer()== chesspiece.Player_side.red)
                  {
                      //没有过河界
                      if (destX>= 5 && ((x - destX) == 1 && Math.Abs(y - destY) == 0 ))
                      temp = true;
                      
                      //过了河界
                     else if (destX< 5 && (((x - destX) == 1 && Math.Abs(y - destY) == 0 )|| (Math.Abs(y - destY) == 1 && (destX - x) == 0)))
                      temp = true;
                  }
                  //黑方
                  if (theboard[x,y].getPlayer()== chesspiece.Player_side.black)
                  {
                      //没有过河界
                      if (destX<=4 && ((destX - x) == 1 && Math.Abs(y - destY) == 0))
                      temp = true;
                    
                      //过了河界
                      if (destX>4 && (((destX- x) == 1 && Math.Abs(y -destY) == 0 )|| (Math.Abs(y - destY) == 1 && (x - destX) == 0)))
                      temp = true;
                  }
             }
            return temp;
         }
    }
    //“空”类
    class blank : chesspiece {
        public blank(Player_side player,int column, int row) : base(player,column, row){
            setType(Piece_type.blank);
            //chesspiece.CreatePiece(Piece_type.soldier,player,column,row);
        }
        public override bool ValidMove(GameBoard board,int x,int y,int destX, int destY){
            return true;
        }
    }
}
