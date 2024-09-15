using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class atck_ui_setting : MonoBehaviour
{
    public GameObject atck_btn_obj;//��ư ui
    public GameObject atck_ui_obj;//atck uiȭ�� 
    public GameObject atck_end_ui;//end uiȭ��
    public RectTransform atck_monster_spawn_tr;//���� ��ġ 

    public Image atck_img;
    public TextMeshProUGUI atck_time_text;
    public TextMeshProUGUI atck_hp_ui;

    int check_monster_value = 0;
    int monster_hp = 0;
    float time_max = 120;

    public bool now_atck = false;//�ο� �����ϸ� true��

    main_1_manager main_temp;
    public void on_atck_ui()
    {
        main_temp = main_1_manager.GetInstance();
        main_temp.ui_text_setting();
        if (random_sc.random_gacha(70, 30) ==1)
        {
            check_monster_value = 1;
            monster_hp = main_temp.atck_dmg* 120;
        }
        else
        {
            check_monster_value = 2;
            monster_hp = main_temp.atck_dmg * 240;
        }
        atck_hp_ui.SetText(monster_hp+": ü��");
        atck_time_text.SetText(time_max+": �ð�");

    }
}
