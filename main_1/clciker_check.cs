using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clciker_check : MonoBehaviour, IPointerClickHandler 
{
    public int now_id = 0;
    [SerializeField]
    int defalt_gold = 0;//�⺻ ȹ�� ���
    int upgrade_gold = 0;//��� ������

    main_1_manager main_temp;

    private void Start()
    {
        main_temp = main_1_manager.GetInstance();
        defalt_gold = main_temp.check_defalt_gold(now_id);
        upgrade_gold = defalt_gold * 2;
    }
    public void OnPointerClick(PointerEventData eventData)//������Ʈ Ŭ���� ��� ȹ��
    {
        get_item get_temp =  main_temp.get_item_effect().GetComponent<get_item>();
        Debug.Log(""+ main_temp.save_data_temp.user_upgrade_int[now_id]);
        int i_temp = (defalt_gold + (upgrade_gold * (int)Math.Pow(main_temp.save_data_temp.user_upgrade_int[now_id],3))) / 10;//��� ȹ�淮 ����
        get_temp.i_temp = i_temp;
        get_temp.now_postion = gameObject.transform.position;
        get_temp.setting_on();
        main_temp.get_gold(i_temp);
        Debug.Log("Ŭ��");
    }
   
}
