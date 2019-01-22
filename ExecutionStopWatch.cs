using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class ExecutionStopWatch {

    public static string StopWatch (Action action, int rounds, int iterations) {
        action ();

        List<decimal> time = new List<decimal> ();
        for (int r = 0; r < rounds; r++) {
            Stopwatch st = new Stopwatch ();
            st.Start ();
            for (int it = 0; it < iterations; it++)
                action ();
            st.Stop ();
            time.Add (st.ElapsedMilliseconds);

        }
        decimal avg = time.Average ();
        decimal min = time.Min ();
        decimal max = time.Max ();
        return $"Avreage: {avg}, Min: {min}, Max: {max}";
    }

    public Dictionary<string, List<decimal>> Times = new Dictionary<string, List<decimal>> ();

    public void StopWatch (string key, Action action) {
        Stopwatch st = new Stopwatch ();
        st.Start ();
        action ();
        st.Stop ();

        if (this.Times.ContainsKey (key))
            this.Times[key].Add (st.ElapsedMilliseconds);
        else
            this.Times[key] = new List<decimal> () { st.ElapsedMilliseconds };

    }

    public string GetTimeMessage () =>
        string.Join (Environment.NewLine, this.Times.Select (x => $"{x.Key}{Environment.NewLine}Max: {x.Value.Max()}{Environment.NewLine}Min: {x.Value.Min()}{Environment.NewLine}Average: {x.Value.Average()}{Environment.NewLine}"));
}