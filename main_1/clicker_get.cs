using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clicker_get : MonoBehaviour , IPointerClickHandler
{
    public TextMeshProUGUI name_text;//이름
    public TextMeshProUGUI gold_text;//골드
    public TextMeshProUGUI upgrade_text;//업그레이드
    public int id_temp = 0;//아이디 관리
    public shop_drage shop_drage_temp;
    main_1_manager main_temp;//메인
    public int upgrade_temp = 0;
    public string name_temp = "";
    public int gold_temp = 0;
    public Sprite sp_temp;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (main_temp.save_data_temp.user_gold> gold_temp)
        {
            main_temp.save_data_temp.user_gold -= gold_temp;
            if (main_temp.save_data_temp.user_upgrade_int[id_temp] <= 0)
            {
                main_temp.save_data_temp.user_upgrade_int[id_temp]++;
                main_temp.check_clicker_obj_temp.check_clicker_obj();
            }else
                main_temp.save_data_temp.user_upgrade_int[id_temp]++;
            main_temp.Save();
            main_temp.ui_text_setting();
            shop_drage_temp.check_setting(gameObject,id_temp);
        }
    }
    public void setting_img()
    {
        main_temp = main_1_manager.GetInstance();
        this.GetComponent<Image>().sprite = sp_temp;
        name_text.SetText(name_temp);
        gold_text.SetText(main_temp.change_unit(gold_temp.ToString())+"필요");
        upgrade_text.SetText(upgrade_temp +"레밸");
    }
}
