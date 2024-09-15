using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class save_sc : MonoBehaviour
{
    public save_data save_data_temp = new save_data();// 이것만 불러서 사용하면 끝남.

    string data_path;//저장 장소 awake에서 초기화

    save_data save_temp = new save_data();

    // Start is called before the first frame update
    void Awake()
    {
        data_path = Application.persistentDataPath + "/" + "save_user_data" + ".json";
        Load();
        Save();
    }
    // 불러오기
    public void Load()
    {
        save_data save_temp = new save_data();
        if (!File.Exists(data_path))
        {
            Save();
        }
        if (File.Exists(data_path))
        {
            string json = File.ReadAllText(data_path);

            byte[] data =  System.Convert.FromBase64String(json);
            string j_data = System.Text.Encoding.UTF8.GetString(data);

            save_temp = JsonUtility.FromJson<save_data>(j_data);
            
        }
        save_data_temp = save_temp;

        return;
    }
    //저장
    public void Save()
    {         
        save_temp = save_data_temp;

        string json = JsonUtility.ToJson(save_temp);
        Byte[] data = System.Text.Encoding.UTF8.GetBytes(json);
        string j_data = System.Convert.ToBase64String(data);

        File.WriteAllText(data_path, j_data);
    }
    public string change_unit(string i_string)//숫자 변환용 
    {
        char[] unit_a = new char[4] { 'K', 'M', 'B', 'T' };
        int unit = 0;

        while (i_string.Length > 6)
        {
            unit++;
            i_string = i_string.Substring(0, i_string.Length - 3);
        }
        if (i_string.Length > 3)
        {
            int I_temp = int.Parse(i_string);
            if (i_string.Length > 4)
            {
                return (I_temp / 1000).ToString() + unit_a[unit];
            }
            else
            {
                return (I_temp / 1000f).ToString("0.0") + unit_a[unit];
            }
        }
        else
        {
            int I_temp = int.Parse(i_string);
            return (I_temp).ToString();
        }
    }
}

