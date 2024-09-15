using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defolt_gold_data
{
    private int[] defolt_gold = new int[7] {0, 200, 500,1000,5000,20000,50000};
    public int get_defolt_gold(int i_temp)
    {
        return defolt_gold[i_temp];
    }
}
