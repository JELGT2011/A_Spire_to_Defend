using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pair<A, B>
{
    public A Item1 { get; set; }

    public B Item2 { get; set; }

    public Pair(A item1, B item2)
    {
        Item1 = item1;
        Item2 = item2;
    }
}
