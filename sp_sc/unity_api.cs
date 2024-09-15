using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class unity_api : MonoBehaviour , api_settng
{
    main_1_manager main_1_temp;

    [SerializeField]
    bool update_tiem = false;//라스트 시간 갱신할때 필요 
    // Start is called before the first frame update
    void Start()
    {
        main_1_temp = main_1_manager.GetInstance();
        coll_api(false);
    }
    public void coll_api(bool now_update)
    {
        update_tiem = now_update;
        StartCoroutine("unity_api_time");
    }
    IEnumerator unity_api_time()//api받아오기 
    {
        string now_time = "";
        string url = "https://worldtimeapi.org/api/timezone/Asia/Seoul";

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.error == null)
        {
            now_time = www.downloadHandler.text;
            process_data(now_time);
            StopCoroutine("unity_api_time");
        }
        else
        {
            Debug.Log("ERROR");
            StopCoroutine("unity_api_time");
        }
    }
    void process_data(string data)
    {
        now_time timeData = JsonUtility.FromJson<now_time>(data);
        DateTime date_time_temp = Convert.ToDateTime(timeData.datetime);
        main_1_temp.now_tiem_temp = date_time_temp;
        Debug.Log(date_time_temp);
        if (main_1_temp.save_data_temp.user_last_time == "")
        {
            update_tiem = false;
            main_1_temp.save_data_temp.user_last_time = date_time_temp.ToString();
            main_1_temp.Save();
        }
        if (update_tiem)
        {
            update_tiem = false;
            main_1_temp.save_data_temp.user_last_time = date_time_temp.ToString();
            main_1_temp.Save();
        }
    }
}
public class now_time
{
    public string datetime;
}
