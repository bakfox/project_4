using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class defolt_ui_presenter : MonoBehaviour
{
    //공격력 관련
    public TextMeshProUGUI atck_text;
    //골드 관련
    public TextMeshProUGUI gold_text;
    main_1_manager main_1_tmep;
    // Start is called before the first frame update
    void Start()
    {
        check_first_setting();
    }
    public int check_atck()//공격력 계산
    {
        int i_temp = 0;
        for (int i = 0; i < main_1_tmep.save_data_temp.user_upgrade_int.Length; i++)
        {
            i_temp += main_1_tmep.save_data_temp.user_upgrade_int[i] * i;
        }
        main_1_tmep.atck_dmg = i_temp;
        return i_temp;
    }
    public void check_first_setting()
    {
        main_1_tmep = main_1_manager.GetInstance();
        main_1_tmep.Defolt_ui_changer += On_changer_ui_defolt;
    }
    public void On_changer_ui_defolt()
    {
        update_view();
    }
    public void update_view()
    {
        gold_text.SetText(main_1_tmep.change_unit(main_1_tmep.save_data_temp.user_gold.ToString()));
        atck_text.SetText(main_1_tmep.change_unit(check_atck().ToString()));
    }
}
