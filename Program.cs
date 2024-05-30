namespace Coursework
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm());
        }
        //static void Main()
        //{
        //    State state = new State(new byte[] {
        //        //11, 14, 3, 6,
        //        //4, 2, 5, 7,
        //        //10, 12, 13, 15,
        //        //1, 9, 8, 0

        //        //13, 14, 15, 0,
        //        //9, 10, 11, 12,
        //        //5, 6, 7, 8,
        //        //1, 2, 3, 4,

        //        4, 8 ,11, 12,
        //        2, 1, 10 , 3,
        //        6, 9, 0, 7, 
        //        14, 5 , 13, 15

        //        //1, 2, 3, 4,
        //        //5, 6, 7, 8,
        //        //9, 10, 11, 12,
        //        //13, 14, 0, 15
        //    });

        //    bool x = state.IsSolvable();
        //    int y = state.GetHeuristic();

        //    AStarMethod method = new AStarMethod();
        //    var path = method.GetCorrectPath(state);
        //}
    }
}