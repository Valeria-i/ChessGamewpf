using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace ChessBoard
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private const int longCastleVerticalPosition = 2;
        private const int shortCastleVerticalPosition = 6;
        private const string pathOfFenFile = "fen.txt";
        private readonly List<string> colors = new List<string>() { "Белые", "Черные" };
        /// <summary>
        /// Создаем элемент класса Bord и  прописываем необходимые команды 
        /// </summary>
        private Board _board = new Board();
        private ICommand _newGameCommand;
        private ICommand _clearCommand;
        private ICommand _cellCommand;
        private ICommand _backstepCommand;
        private ICommand _savegameCommand;
        private ICommand _returngameCommand;

        /// <summary>
        /// Перечисляем необходимые данные
        /// </summary>
        
        public IEnumerable<char> Numbers => "87654321";
        public IEnumerable<char> Letters => "ABCDEFGH";

        public int Player;

        public Board Board 
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Создаем новую доску
        /// </summary>
       
        public ICommand NewGameCommand => _newGameCommand ??= new RelayCommand(parameter => 
        {
            SetupBoard();
        });

        /// <summary>
        /// Очищаем доску
        /// </summary>
       
        public ICommand ClearCommand => _clearCommand ??= new RelayCommand(parameter =>
        {
            Board = new Board();
        });
        
        /// <summary>
        /// Игровой процесс, ходы
        /// </summary>
        
        public ICommand CellCommand => _cellCommand ??= new RelayCommand(parameter =>
        {
            Step();
            //объект кнопки, хранящий её параметры
            Cell cell = (Cell)parameter;
            //считаем активной клетку, которую нажали
            Cell activeCell = Board.FirstOrDefault(x => x.Active);

            if (cell.State != State.Empty)//ЕСЛИ КНОПКА НЕ ПУСТАЯ
            {
                //Если фигура белая и сейчас ход игрока с белыми фигурами
               if ((cell.State==State.WhiteQueen|| cell.State == State.WhiteBishop || cell.State == State.WhiteKing || cell.State == State.WhiteKnight|| 
                 cell.State == State.WhiteRook || cell.State == State.WhitePawn)&& (Player%2!=0))
               {
                    //если кнопка не пустая и кнопка хода имеет статус false
                    if (!cell.Active && activeCell != null)
                        activeCell.Active = false; //статус исходной кнопки false
                    cell.Active = !cell.Active; //статус кнопки хода не false
                   
               }   
               //Если фигура черная и сейчас ход игрока с черными фигурами
                if ((cell.State == State.BlackQueen || cell.State == State.BlackBishop || cell.State == State.BlackKing || cell.State == State.BlackKnight ||
                cell.State == State.BlackRook || cell.State == State.BlackPawn) && (Player % 2 == 0))
                {
                    if (!cell.Active && activeCell != null)
                        activeCell.Active = false;
                    cell.Active = !cell.Active;
                }
                
            }
            else if (activeCell != null) //ЕСЛИ КНОПКА НЕ ПУСТАЯ(СОДЕРЖИТ ФИГУРУ)
            {
                activeCell.Active = false; //убираем подсветку кнопки начального положения фигуры
                cell.State = activeCell.State;//присваиваем клетке, куда собираемся ходить, статус исходной 
                activeCell.State = State.Empty;//присваиваем исходной клетки статус пустой
                SwichPlayer();//меняем игрока
            }

        }, parameter => parameter is Cell cell && (Board.Any(x => x.Active) || cell.State != State.Empty));
        public void Step()
        {
           
        }
        /// <summary>
        /// Ставим фигуры на исходные позиции, представляя доску в виде двумерного массива
        /// </summary>
        
        private void SetupBoard()
        {
            Player = 1;
            Board board = new Board();
            board[0, 0] = State.BlackRook;
            board[0, 1] = State.BlackKnight;
            board[0, 2] = State.BlackBishop;
            board[0, 3] = State.BlackQueen;
            board[0, 4] = State.BlackKing;
            board[0, 5] = State.BlackBishop;
            board[0, 6] = State.BlackKnight;
            board[0, 7] = State.BlackRook;
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = State.BlackPawn;
                board[6, i] = State.WhitePawn;
            }
            board[7, 0] = State.WhiteRook;
            board[7, 1] = State.WhiteKnight;
            board[7, 2] = State.WhiteBishop;
            board[7, 3] = State.WhiteQueen;
            board[7, 4] = State.WhiteKing;
            board[7, 5] = State.WhiteBishop;
            board[7, 6] = State.WhiteKnight;
            board[7, 7] = State.WhiteRook;
            Board = board;
        }

        public ICommand BackstepCommand => _backstepCommand ??= new RelayCommand(parameter =>
        {
            Backstep();
        });
        public ICommand SavegameCommand => _savegameCommand ??= new RelayCommand(parameter =>
        {
            Board.Save("board.json");
        });
        public ICommand ReturngameCommand => _returngameCommand ??= new RelayCommand(parameter =>
        {
           Board = new Board("board.json");
        });
        private void Backstep()
        {

        }
        private void SaveGame()
        {
            Board.Save("board.json");
        }
        private void ReturnGame()
        {
            Board = new Board("board.json");
        }
        public MainViewModel()
        {
        }
       //Функция позволяет организовать очередность ходов игроков
       public void SwichPlayer()
       {
            Player++;
       }
        /// <summary>
        /// Проверяем, что ход не выходит за границу поля
        /// </summary>
        /// <param name="ti"></param>
        /// <param name="tj"></param>
        /// <returns></returns>
        public bool InsideBorder(int ti, int tj)
        {
            if (ti>=8 ||tj>=8||ti<0|| tj<0)
                return false;
            return true;    
        }
        /// <summary>
        /// возвращать исходный цвет клетки
        /// </summary>
        public void CloseSteps()
        {
            for(int i = 0; i <= 8; i++)
            {
                for(int j=0;j<=8; j++)
                {
                    
                }
            }
        }
        /// <summary>
        /// функция для определения возможных ходов фигуры
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="figurestate"></param>
       
        //public void ShowSteps(int x,int y)
        //{
        //    Cell activeCell = Board.FirstOrDefault(x => x.Active);
        //    for (int i=0; i <= 8; i++)
        //    {
        //        for (int j=0; j <= 8; j++)
        //        {
        //            if (Board[i,j]==State.BlackPawn || Board[i, j] == State.WhitePawn)
        //            {

        //                int k = i+1;
        //                int l = j+1;
        //                Board[k, l] = ;
        //                activeCell.Active = false;
        //                cell.Active = !cell.Active;
        //            }
        //        }
        //    }

        //}
    }
}