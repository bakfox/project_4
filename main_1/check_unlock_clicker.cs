using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_unlock_clicker : MonoBehaviour
{
    public GameObject[] clicker_obj;
    save_sc save_temp;
    void Start()
    {
        check_clicker_obj();
    }
    public void check_clicker_obj()//계속 언락 갱신 초반 갱신용 
    {
        save_temp = this.GetComponent<save_sc>();
        int i_temp = 0;
        foreach (GameObject obj_temp in clicker_obj)
        { 
            if (i_temp != 0)
            {
                if (save_temp.save_data_temp.user_upgrade_int[i_temp] > 0)
                {
                    
                    obj_temp.SetActive(true);
                }
                else
                    obj_temp.SetActive(false);
            }
            i_temp++;
        }
    }

}
