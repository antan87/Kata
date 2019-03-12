using System;

namespace kata {
    public class Program {
        static void Main (string[] args) {

            // Console.WriteLine (ExecutionStopWatch.StopWatch (() => { Kata4.DblLinear (10000); }, 10, 10));
            // Console.WriteLine (Kata4.DblLinear (1000000));
            // Console.WriteLine (Kata4.DblLinear (200));
            // Console.WriteLine (Kata4.DblLinear (500));
            Console.WriteLine (Kata7.Kata7.ValidateBattlefield (new int[10, 10] { { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 }, { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 }, { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 }, { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            }));
            Console.ReadLine ();
        }
    }
}