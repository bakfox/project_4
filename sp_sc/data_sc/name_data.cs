using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class name_data : MonoBehaviour
{
    private string[] clicker_name = new string[7] { "?", "������", "����", "�����", "����", "���尣", "����" };
    public string  get_name_gold(int i_temp)
    {
        return clicker_name[i_temp];
    }
}
