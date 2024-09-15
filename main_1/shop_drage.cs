using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class shop_drage : MonoBehaviour
{
    public RectTransform content; //Content
    [SerializeField] float check_x;
    public GameObject upgrade_obj;  //업그레이드 오브젝트 데이터 
    main_1_manager main_temp;
    

    public Sprite[] not_unlcok_ui;
    public Sprite[] unlock_ui;

    [SerializeField] float x_vector = 300f;//간격
    [SerializeField] float end_first = 700f;//마지막과 처음 위치 - +

    [SerializeField] private Queue<GameObject> obj_list = new Queue<GameObject>();
    [SerializeField] int check_id = 0;
    [SerializeField] int check_id_right = 0;

    private void Start()
    {
        start_setting();    
    }
    void start_setting()
    {
        main_temp = main_1_manager.GetInstance();
        check_x = x_vector;

        for (int i = 1; i< main_temp.save_data_temp.user_upgrade_int.Length; i++)
        {
            GameObject obj_temp = Instantiate(upgrade_obj, content);

            clicker_get clicker_temp = obj_temp.GetComponent<clicker_get>();
            clicker_temp.gold_temp = main_temp.check_defalt_gold(i);
            clicker_temp.setting_img();
            obj_list.Enqueue(obj_temp);
        }
        //이벤트 추가
        ScrollRect scrollRect = GetComponent<ScrollRect>();
        scrollRect.onValueChanged.AddListener(OnScroll);

        // 처음 아이템 배치
        set_upgarde_obj();
    }
    // 스크롤할 때 호출되는 함수
    private void OnScroll(Vector2 pos)
      {
        if (content.anchoredPosition.x <x_vector && content.anchoredPosition.x > -x_vector)
        {
            check_x = x_vector;
        }
          // 스크롤이 일정 범위를 넘어서면 아이템 재배치
          if (content.anchoredPosition.x >= check_x)
          {

                Debug.Log("실행중_2");
                ShiftItemsleft();
          }
      }
      //왼쪽 스크롤
    private void ShiftItemsleft()
    {
        check_x = x_vector + check_x;

        check_id--;
        if (check_id < 0)
        {
            check_id = main_temp.save_data_temp.user_upgrade_int.Length -1;
        }
        GameObject obj_temp = obj_list.Dequeue();
        obj_list.Enqueue(obj_temp);
        change_item_spawn(obj_temp.GetComponent<RectTransform>(),obj_temp);
    }
    public void change_item_spawn(RectTransform rect_temp,GameObject obj_temp )//위치 이동용 
    {
        rect_temp.anchoredPosition = new Vector2(end_first - x_vector * (check_id - 1), obj_temp.transform.localPosition.y);
    }
    public void check_setting(GameObject obj_temp ,int i)//이미지 다시 체크용  
    {

        clicker_get clicker_temp = obj_temp.GetComponent<clicker_get>();

        if (main_temp.save_data_temp.user_upgrade_int[i] == 0)
        {
            clicker_temp.gold_temp = main_temp.check_defalt_gold(check_id);//기본 금액
            clicker_temp.sp_temp = not_unlcok_ui[i];//흑백 이미지
        }
        else
        {
            clicker_temp.gold_temp = main_temp.check_defalt_gold(i) * ((int)math.pow(main_temp.save_data_temp.user_upgrade_int[i],3f) *50);//업그레이드 비용 증가
            clicker_temp.sp_temp = unlock_ui[i];//컬러 이미지
            clicker_temp.upgrade_temp = main_temp.save_data_temp.user_upgrade_int[i];//현재 업그레이드
        }

        clicker_temp.setting_img();
    }
    //처음에 아이템 배치
    private void set_upgarde_obj()
    {

        foreach (GameObject obj_temp in obj_list)//처음 셋팅 
        {
            obj_temp.transform.localPosition = new Vector3(( x_vector * check_id - (end_first+100)), obj_temp.transform.localPosition.y, obj_temp.transform.localPosition.z);
            check_id++;
            clicker_get clicker_temp = obj_temp.GetComponent<clicker_get>();
            clicker_temp.id_temp = check_id;
            clicker_temp.shop_drage_temp = this;
            clicker_temp.name_temp = main_temp.check_defalt_name(check_id);
            check_setting(obj_temp,check_id);
            clicker_temp.setting_img();
        }
        check_id = 1;
      }
}
