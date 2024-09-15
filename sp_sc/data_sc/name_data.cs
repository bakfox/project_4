using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class name_data : MonoBehaviour
{
    private string[] clicker_name = new string[7] { "?", "관람지", "빵집", "목욕탕", "기계실", "대장간", "여관" };
    public string  get_name_gold(int i_temp)
    {
        return clicker_name[i_temp];
    }
}
