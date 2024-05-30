using static Coursework.Common;

namespace Coursework
{
    public class State
    {
        public byte[] numbers = new byte[stateSize];

        public State(byte[] nums)
        {
            numbers = nums;
        }

        //Оператор порівняння станів
        public static bool operator == (State leftState, State rightState)
        {            
            for (int i = 0; i < leftState.numbers.Length; i++)
            {
                if (leftState.numbers[i] != rightState.numbers[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator != (State leftState, State rightState)
        {
            return !(leftState == rightState);
        }

        // Метод знаходження евристики стану
        public ushort GetHeuristic()
        {
            ushort result = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                var targetCords = GameTile.GetCoordinatesByIndex(i - 1);
                var tileCords = GameTile.GetCoordinatesByIndex(Array.IndexOf(numbers, (byte) i));
                result += (ushort) (Math.Abs(tileCords.xCord - targetCords.xCord) + Math.Abs(tileCords.yCord - targetCords.yCord));
            }

            HashSet<byte> conflictedTiles = new HashSet<byte>();

            // Обчислення евристики лінійних конфліктів
            for (int row = 0; row < sideSize; row++)
            {
                result += CountLinearConflicts(row, true, conflictedTiles);
            }
            for (int col = 0; col < sideSize; col++)
            {
                result += CountLinearConflicts(col, false, conflictedTiles);
            }

            // Обчислення евристики кутових конфліктів
            result += CountCornerConflicts(conflictedTiles);

            var UpLastCords = GameTile.GetCoordinatesByIndex(Array.IndexOf(numbers, (byte)(stateSize - sideSize)));
            var LeftLastCords = GameTile.GetCoordinatesByIndex(Array.IndexOf(numbers, (byte)(stateSize - 1)));

            if (UpLastCords.yCord != sideSize - 1 && LeftLastCords.xCord != sideSize - 1 && !IsSolved(numbers))
            {
                result += 2;
            }

            return result;
        }

        // Метод знаходження лінійних конфліктів
        private ushort CountLinearConflicts(int line, bool isRow, HashSet<byte> conflictedTiles)
        {
            ushort result = 0;

            for (int i = 0; i < sideSize - 1; i++)
            {
                byte tempTile = isRow ? numbers[GameTile.GetIndexByCords(i, line)] : numbers[GameTile.GetIndexByCords(line, i)];
                // Перевірка на порожню пластинку
                if (tempTile == 0)
                {
                    continue;
                }

                int correctLine = isRow ? GameTile.GetCoordinatesByIndex(tempTile - 1).yCord : GameTile.GetCoordinatesByIndex(tempTile - 1).xCord;
                // Перевірка на відповідність пластинки до своєї лінії
                if (line != correctLine)
                {
                    continue;
                }

                for (int j = i + 1; j < sideSize; j++)
                {
                    byte nextTile = isRow ? numbers[GameTile.GetIndexByCords(j, line)] : numbers[GameTile.GetIndexByCords(line, j)];
                    if (nextTile == 0)
                    {
                        continue;
                    }

                    int correctNextLine = isRow ? GameTile.GetCoordinatesByIndex(nextTile - 1).yCord : GameTile.GetCoordinatesByIndex(nextTile - 1).xCord;
                    if (line != correctNextLine)
                    {
                        continue;
                    }

                    if (tempTile > nextTile)
                    {
                        result += 2;
                        conflictedTiles.Add(tempTile);
                        break;
                    }
                }
            }

            return result;
        }

        // Метод знаходження кутових конфліктів
        private ushort CountCornerConflicts(HashSet<byte> conflictedTiles)
        {
            ushort result = 0;

            for (int i = 0; i < stateSize; i++)
            {
                if (numbers[i] != i + 1 && numbers[i] != 0)
                {
                    if (i == 0)
                    {
                        if ((numbers[i + sideSize] == i + sideSize + 1 && !conflictedTiles.Contains(numbers[i + sideSize])) &&
                            (numbers[i + 1] == i + 2 && !conflictedTiles.Contains(numbers[i + 1])))
                        {
                            result += 4;
                        }
                        else if ((numbers[i + sideSize] == i + sideSize + 1 && !conflictedTiles.Contains(numbers[i + sideSize])) ||
                            (numbers[i + 1] == i + 2 && !conflictedTiles.Contains(numbers[i + 1])))
                        {
                            result += 2;
                        }
                    }
                    else if (i == sideSize - 1)
                    {
                        if ((numbers[i + sideSize] == i + sideSize + 1 && !conflictedTiles.Contains(numbers[i + sideSize])) &&
                            (numbers[i - 1] == i && !conflictedTiles.Contains(numbers[i - 1])))
                        {
                            result += 4;
                        }
                        else if ((numbers[i + sideSize] == i + sideSize + 1 && !conflictedTiles.Contains(numbers[i + sideSize])) ||
                            (numbers[i - 1] == i && !conflictedTiles.Contains(numbers[i - 1])))
                        {
                            result += 2;
                        }
                    }
                    else if (i == stateSize - sideSize)
                    {
                        if ((numbers[i - sideSize] == i - sideSize + 1 && !conflictedTiles.Contains(numbers[i - sideSize])) &&
                            (numbers[i + 1] == i + 2 && !conflictedTiles.Contains(numbers[i + 1])))
                        {
                            result += 4;
                        }
                        else if ((numbers[i - sideSize] == i - sideSize + 1 && !conflictedTiles.Contains(numbers[i - sideSize])) ||
                            (numbers[i + 1] == i + 2 && !conflictedTiles.Contains(numbers[i + 1])))
                        {
                            result += 2;
                        }
                    }
                }
            }

            return result;
        }

        // Метод обчислення кількості інверсій у стані
        public int CountInversions()
        {
            int result = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] == 0 || numbers[j] == 0)
                    {
                        continue;
                    }
                    if (numbers[i] > numbers[j])
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        // Метод, що визначає, чи має стан розвз'язок
        public bool IsSolvable()
        {
            int tileIndex = Array.IndexOf(numbers, (byte) 0);
            int row = GameTile.GetCoordinatesByIndex(tileIndex).yCord;
            int inv = CountInversions();

            if (inv % 2 == 0 && row % 2 == 1)
            {
                return true;
            }
            else if (inv % 2 == 1 && row % 2 == 0)
            {
                return true;
            }
            return false;
        }

        // Метод, що перевіряє, чи розв'язаний стан
        public static bool IsSolved(byte[] stateNumbers)
        {
            bool isSolved = true;

            for (int i = 1; i < stateSize - 1; i++)
            {
                if (stateNumbers[i] != i + 1)
                {
                    isSolved = false;
                }
            }

            return isSolved;
        }

        // Метод обрахування хешу стану
        public static ulong GetHashCode(byte[] numbers)
        {
            ulong hash = 17;
            foreach (var item in numbers)
            {
                hash = hash * 31 + item;
            }
            return hash;
        }
    }
}
