using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class main_1_manager : save_sc
{
    private static main_1_manager main_1_instance;//�̱���
    [SerializeField] Int64 gold_temp;

    public check_unlock_clicker check_clicker_obj_temp;//Ŭ��Ŀ obj on off Ȯ�� 

    //��� ȹ�� ����Ʈ ���� 
    public List<GameObject> effect_list  = new List<GameObject>();
    public GameObject effect_obj;

    //����� ����
    public event Action Defolt_ui_changer;
    public TextMeshProUGUI gold_text;
    public Transform gold_tr;
    float check_cooltime = 60;

    //���ݷ� ����
    public TextMeshProUGUI atck_text;
    //�ð� ���� 
    public DateTime now_tiem_temp;

    public int atck_dmg { get; set; }
    public int atck_steck = 0;
    // Start is called before the first frame update
    public static main_1_manager GetInstance()
    {
        if (main_1_instance ==null)
        {
            main_1_instance = GameObject.FindGameObjectWithTag("mainmanager").GetComponent<main_1_manager>();
            Debug.Log(main_1_instance.name);
        }
        return main_1_instance;
    }

    void Start()
    {
        gold_temp = save_data_temp.user_gold;
        first_setting();  
    }
    public GameObject get_item_effect()//����Ʈ ������Ʈ ������ 
    {
        GameObject effect_obj = effect_list[0];
        effect_list.RemoveAt(0);
        return effect_obj;
    }
    void first_setting()//ó�� ���ÿ�
    {
        main_1_instance = this;
        Debug.Log(main_1_instance.name);
        ui_text_setting();
        for (int i = 0; i < 50; i++)
        {
            GameObject obj_temp = Instantiate(effect_obj);
            effect_list.Add(obj_temp);
        }
        StartCoroutine("retrun_gold");
    }
    public void ui_text_setting()//ui���� ����
    {
        Defolt_ui_changer?.Invoke();
    }

    public void get_gold(int gold_temp)//��� ���
    {
        save_data_temp.user_gold += gold_temp;
        Save();
        ui_text_setting();
    }
    IEnumerator retrun_gold()//1�и��� ȹ�� ���� 
    {
        float now_coltiem = 0;
        int get_gold_i = 0;
        while (now_coltiem <= check_cooltime)
        {
            now_coltiem += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        for (int i =1; i < save_data_temp.user_upgrade_int.Length;i++)
        {
            Debug.Log(i);
            if (save_data_temp.user_upgrade_int[i] != 0)
            {
                int i_temp = check_defalt_gold(i);
                get_gold_i += ((i_temp * 3) * save_data_temp.user_upgrade_int[i]) ;
            }
        }
        atck_steck++;
        get_gold(get_gold_i);
        StartCoroutine("retrun_gold");
    }
    public int check_defalt_gold(int i_index)//�⺻ ���
    {
        defolt_gold_data defolt = new defolt_gold_data();
        int i_temp = 0;
        if (save_data_temp.user_upgrade_int.Length > i_index)
        { 
            i_temp = defolt.get_defolt_gold(i_index);
        }
        return i_temp;
    }
    public string check_defalt_name(int i_index)
    {
        name_data name = new name_data();
        string s_temp = "";
        if (save_data_temp.user_upgrade_int.Length > i_index)
        {
            s_temp = name.get_name_gold(i_index);
        }
        return s_temp;
    }

}
