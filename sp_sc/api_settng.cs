using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public interface api_settng 
{
    IEnumerator unity_api_time()//api �޾ƿ��� 
    {
        string url = "";
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
    }
    void process_data(string data)//api �޾ƿ°� �ڷ� ������ 
    {

    }
}
