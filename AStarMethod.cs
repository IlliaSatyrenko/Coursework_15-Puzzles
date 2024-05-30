namespace Coursework
{
    public class AStarMethod : Common
    {
        // Черга з пріоритетом, що містить усі обраховані стани
        private PriorityQueue<(byte[], ushort, EZeroDirection?), ushort> stateList = new PriorityQueue<(byte[], ushort, EZeroDirection?), ushort>();
        // Словник, що містить усі обійдені стані
        private Dictionary<ulong, (EZeroDirection? direction, ushort pathCost)> closedStates = new Dictionary<ulong, (EZeroDirection?, ushort)>();
        private List<(EZeroDirection direction, byte[] stateNumbers)> correctPath = new List<(EZeroDirection, byte[])>();

        // Метод знаходження шляху до розв'язаного стану
        public List<(EZeroDirection, byte[])> GetCorrectPath(State state)
        {
            //Перевірка, чи стан розв'язаний
            if (State.IsSolved(state.numbers))
            {
                return correctPath;
            }

            stateList.Enqueue((state.numbers, 0, null), 0);

            while (stateList.Count != 0)
            {
                //Перевірка чи час на оптимальний розв'язок сплив
                if (GameForm.isTimerExpired)
                {
                    return correctPath;
                }

                (byte[] stateNumbers, ushort pathCost, EZeroDirection? direction) currentState = stateList.Dequeue();

                ulong currentHash = State.GetHashCode(currentState.stateNumbers);

                if (closedStates.ContainsKey(currentHash) && closedStates[currentHash].pathCost <= currentState.pathCost)
                {
                    continue;
                }

                closedStates[currentHash] = (currentState.direction, currentState.pathCost);

                //Знаходження фінального масиву, що міститиме шлях до розв'яаного стану
                if (currentState.pathCost == 0 && stateList.Count != 0)
                {
                    (byte[] stateNumbers, EZeroDirection? direction) current = (currentState.stateNumbers, currentState.direction);

                    while (current.direction != null)
                    {
                        correctPath.Add((current.direction.Value, current.stateNumbers));
                        current = GetPrevState(current.stateNumbers, current.direction.Value);
                    }
                    break;
                }

                //Знаходження сусідів стану
                foreach ((byte[] stateNumbers, EZeroDirection direction) nextState in GetMovedStates(currentState.stateNumbers))
                {
                    ushort nextStatePathCost = (ushort) (currentState.pathCost + 1);
                    ushort nextStateCost = (ushort) (new State(nextState.stateNumbers).GetHeuristic() * 3 + nextStatePathCost);
                    if (State.IsSolved(nextState.stateNumbers))
                    {
                        nextStateCost = 0;
                        nextStatePathCost = 0;
                    }
                    stateList.Enqueue((nextState.stateNumbers, nextStatePathCost, nextState.direction), nextStateCost);
                }
            }

            correctPath.Reverse();
            return correctPath;
        }

        //Метод знаходження сусідських станів поточного стану
        private List<(byte[], EZeroDirection)> GetMovedStates(byte[] currentStateNumbers)
        {
            List<(byte[], EZeroDirection)> movedStates = new List<(byte[], EZeroDirection)>();

            foreach (EZeroDirection dir in Enum.GetValues(typeof(EZeroDirection)))
            {
                var tempPair = GameTile.Move(currentStateNumbers, dir);
                if (tempPair.isMoved)
                {
                    movedStates.Add((tempPair.numbersState, dir));
                }
            }

            return movedStates;
        }

        //Знаходження минулого стану у шляху за напрямком перемішення
        private (byte[], EZeroDirection?) GetPrevState(byte[] stateNumbers, EZeroDirection direction)
        {
            switch (direction)
            {
                case EZeroDirection.LeftDirection:
                    direction = EZeroDirection.RightDirection;
                    break;
                case EZeroDirection.RightDirection:
                    direction = EZeroDirection.LeftDirection;
                    break;
                case EZeroDirection.UpDirection:
                    direction = EZeroDirection.DownDirection;
                    break;
                case EZeroDirection.DownDirection:
                    direction = EZeroDirection.UpDirection;
                    break;
            }

            byte[] prevStateNumbers = GameTile.Move(stateNumbers, direction).numbersState;
            ulong prevHash = State.GetHashCode(prevStateNumbers);
            EZeroDirection? prevStateDirection = closedStates.ContainsKey(prevHash) ? closedStates[prevHash].direction : null;
            return (prevStateNumbers, prevStateDirection);
        }
    }
}
