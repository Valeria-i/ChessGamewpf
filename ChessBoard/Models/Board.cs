using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ChessBoard
{
    public class Board : IEnumerable<Cell>
    {
        private readonly Cell[,] _area;
        /// <summary>
        /// Доступ к каждой клетке игрового поля по индексу
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>

        public State this[int row, int column]
        {
            get => _area[row, column].State;
            set => _area[row, column].State = value;
        }

        public Board()
        {
          _area = new Cell[8, 8];
            for (int vertical = 0; vertical<_area.GetLength(0); vertical++)
                for (int horizontal = 0; horizontal<_area.GetLength(1); horizontal++)
                    _area[vertical, horizontal] = new Cell(horizontal, _area.GetLength(0) - vertical - 1);
        }
       

        public IEnumerator<Cell> GetEnumerator() 
            => _area.Cast<Cell>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => _area.GetEnumerator();

        /// <summary>
        /// Метод сохранения доски в файл
        /// </summary>
        /// <param name="filename"></param>
        
        public void Save(string filename)
            => File.WriteAllText(filename, JsonSerializer.Serialize(_area.Cast<Cell>()));
        /// <summary>
        /// Восстановление состояния доски из файла
        /// </summary>
        /// <param name="filename"></param>
        
        public Board(string filename)
        { _area = new Cell[8, 8]; Cell[] data = JsonSerializer.Deserialize<Cell[]>(File.ReadAllText(filename));
            for (int i = 0; i < _area.GetLength(0); i++)
                for (int j = 0; j < _area.GetLength(1); j++) 
                    _area[i, j] = data[i * 8 + j];
        }
    }
}