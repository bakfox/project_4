using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class get_gift_box : MonoBehaviour
{
    main_1_manager main_temp;
    public TextMeshProUGUI[] text_temp;
    public int check_value = 0;
    public string check_name = "";

    public void check_box()
    {
        main_temp = new main_1_manager();
        text_temp[0].SetText("보상 수량 : "+ main_temp.change_unit(check_value.ToString()));
        text_temp[1].SetText("보상 내용 : " + check_name);
    }

}
