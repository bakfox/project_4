using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class time_reward_manager : MonoBehaviour
{
    main_1_manager main_temp;//메인 

    public unity_api api_temp;//api받아오기용 

    //방치형 시간 보상 

    
    public float check_time;
    public GameObject reward_obj;
    public Image time_img;
    public TextMeshProUGUI time_text;
    public void open_box()//리워드 상자 열기
    {
        main_temp = main_1_manager.GetInstance();
        reward_obj.SetActive(true);
        StartCoroutine("get_six_hour_gold");
    }
    public void close_box()//리워드 상자 닫기
    {
        StopCoroutine("get_six_hour_gold");
        reward_obj.SetActive(false);
    }
    public void get_time_reward()//시간에 따른 리워드 
    {
        int get_gold_i = 0;
        for (int i = 1; i < main_temp.save_data_temp.user_upgrade_int.Length; i++)
        {
            if (main_temp.save_data_temp.user_upgrade_int[i] != 0)
            {
                Debug.Log(i);
                int i_temp = main_temp.check_defalt_gold(i);
                get_gold_i += ((i_temp * 3) * main_temp.save_data_temp.user_upgrade_int[i]);
                get_gold_i = get_gold_i * (int)(check_time / 360);
            }
        }
        if (get_gold_i < 0)
        {
            Debug.Log("get_gold_i" + get_gold_i);
            close_box();
            return;
        }
        if (main_temp.save_data_temp.user_gold < 0)
        {
            main_temp.save_data_temp.user_gold = -main_temp.save_data_temp.user_gold;
        }
        Debug.Log("get_gold_i" + get_gold_i);
        main_temp.save_data_temp.user_gold += get_gold_i;
        main_temp.ui_text_setting();
        api_temp.coll_api(true);
        close_box();
    }
    IEnumerator get_six_hour_gold()//상자 열면 발동  
    {
        bool check_open_box = true;
        api_temp.coll_api(false);
        TimeSpan time_temp = main_temp.now_tiem_temp - Convert.ToDateTime(main_temp.save_data_temp.user_last_time);
        check_time = (float)time_temp.TotalSeconds;
        while (check_open_box)
        {
            check_time += Time.deltaTime;
            if (check_time < 0)
            {
                time_text.SetText("데이터 연결 실패 ");
            }
            else
                time_text.SetText(Math.Round(check_time / 60, 0) + "분 지남");
            time_img.fillAmount = check_time / 21600f;
            if (check_time >= 21600f)
            {
                check_time = 21600f;
                check_open_box = false;
                time_text.SetText("보상을 받으세요!");
                time_img.fillAmount = 1;
            }
            yield return new WaitForFixedUpdate();
        }

    }
}
