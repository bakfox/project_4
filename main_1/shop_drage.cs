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
    public GameObject upgrade_obj;  //���׷��̵� ������Ʈ ������ 
    main_1_manager main_temp;
    

    public Sprite[] not_unlcok_ui;
    public Sprite[] unlock_ui;

    [SerializeField] float x_vector = 300f;//����
    [SerializeField] float end_first = 700f;//�������� ó�� ��ġ - +

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
        //�̺�Ʈ �߰�
        ScrollRect scrollRect = GetComponent<ScrollRect>();
        scrollRect.onValueChanged.AddListener(OnScroll);

        // ó�� ������ ��ġ
        set_upgarde_obj();
    }
    // ��ũ���� �� ȣ��Ǵ� �Լ�
    private void OnScroll(Vector2 pos)
      {
        if (content.anchoredPosition.x <x_vector && content.anchoredPosition.x > -x_vector)
        {
            check_x = x_vector;
        }
          // ��ũ���� ���� ������ �Ѿ�� ������ ���ġ
          if (content.anchoredPosition.x >= check_x)
          {

                Debug.Log("������_2");
                ShiftItemsleft();
          }
      }
      //���� ��ũ��
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
    public void change_item_spawn(RectTransform rect_temp,GameObject obj_temp )//��ġ �̵��� 
    {
        rect_temp.anchoredPosition = new Vector2(end_first - x_vector * (check_id - 1), obj_temp.transform.localPosition.y);
    }
    public void check_setting(GameObject obj_temp ,int i)//�̹��� �ٽ� üũ��  
    {

        clicker_get clicker_temp = obj_temp.GetComponent<clicker_get>();

        if (main_temp.save_data_temp.user_upgrade_int[i] == 0)
        {
            clicker_temp.gold_temp = main_temp.check_defalt_gold(check_id);//�⺻ �ݾ�
            clicker_temp.sp_temp = not_unlcok_ui[i];//��� �̹���
        }
        else
        {
            clicker_temp.gold_temp = main_temp.check_defalt_gold(i) * ((int)math.pow(main_temp.save_data_temp.user_upgrade_int[i],3f) *50);//���׷��̵� ��� ����
            clicker_temp.sp_temp = unlock_ui[i];//�÷� �̹���
            clicker_temp.upgrade_temp = main_temp.save_data_temp.user_upgrade_int[i];//���� ���׷��̵�
        }

        clicker_temp.setting_img();
    }
    //ó���� ������ ��ġ
    private void set_upgarde_obj()
    {

        foreach (GameObject obj_temp in obj_list)//ó�� ���� 
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
