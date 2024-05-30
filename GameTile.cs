using static Coursework.Common;

namespace Coursework
{
    internal class GameTile : Button
    {
        public (bool isNeighbor, EZeroDirection? direction) ZeroNeighbor = (false, null);
        public int tileIndex;

        public GameTile(string value)
        {
            Text = value;
            Font = new Font("Microsoft Sans Serif", 24, FontStyle.Regular, GraphicsUnit.Point);
            Size = new Size(64, 64);
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.White;

            if (value != "")
            {
                tileIndex = int.Parse(value) - 1;
            }
            else
            {
                tileIndex = 15;
            }
        }

        //Метод знаходження координат плитки за індексом
        public static (int xCord, int yCord) GetCoordinatesByIndex(int tileIndex)
        {
            return (tileIndex % sideSize, tileIndex / sideSize);
        }

        //Метод знаходження індексу плитки за координатами
        public static int GetIndexByCords(int xCord, int yCord)
        {
            return yCord * sideSize + xCord;
        }

        //Метод переміщення плитки
        public static (bool isMoved, byte[] numbersState) Move(byte[] numbersState, EZeroDirection dir)
        {
            int zeroIndex = 0;

            for (int i = 0; i < numbersState.Length; i++)
            {
                if (numbersState[i] == 0)
                {
                    zeroIndex = i;
                    break;
                }
            }

            var zeroCords = GetCoordinatesByIndex(zeroIndex);

            if ((dir == EZeroDirection.LeftDirection && zeroCords.xCord == 0) ||
                (dir == EZeroDirection.RightDirection && zeroCords.xCord == sideSize - 1) ||
                (dir == EZeroDirection.UpDirection && zeroCords.yCord == 0) ||
                (dir == EZeroDirection.DownDirection && zeroCords.yCord == sideSize - 1)
            )
            {
                return (false, numbersState);
            }

            int tileIndex = 0;
            switch (dir)
            {
                case EZeroDirection.LeftDirection:
                    tileIndex = GetIndexByCords(zeroCords.xCord - 1, zeroCords.yCord);
                    break;
                case EZeroDirection.RightDirection:
                    tileIndex = GetIndexByCords(zeroCords.xCord + 1, zeroCords.yCord);
                    break;
                case EZeroDirection.UpDirection:
                    tileIndex = GetIndexByCords(zeroCords.xCord, zeroCords.yCord - 1);
                    break;
                case EZeroDirection.DownDirection:
                    tileIndex = GetIndexByCords(zeroCords.xCord, zeroCords.yCord + 1);
                    break;
            }

            byte[] newNumbers = new byte[stateSize];
            for (int i = 0; i < stateSize; i++)
            {
                newNumbers[i] = numbersState[i];
            }
            var temp = newNumbers[tileIndex];
            newNumbers[tileIndex] = newNumbers[zeroIndex];
            newNumbers[zeroIndex] = temp;

            return (true, newNumbers);
        }
    }
}
