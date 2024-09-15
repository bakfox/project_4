using Cinemachine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class camera_working : save_sc
{
    public CinemachineVirtualCamera[] camer_temp;
    public Vector3[] light_position;
    public GameObject light_obj;
    public int chect_came_stect = 0;

    public GameObject[] touch_ui_obj;

    private void Start()
    {
        chect_came_stect = save_data_temp.user_last_check_cam;
        check_came_now();
    }

    public void down_came()//카메라 아래로 
    {
        chect_came_stect--;
        save_data_temp.user_last_check_cam = chect_came_stect;
        check_came_now();
    }
    public void up_came()//위로 
    {
        chect_came_stect++;
        save_data_temp.user_last_check_cam = chect_came_stect;
        check_came_now();
    }
    public void check_came_now()// 카메라 위치 체크 
    {
        if (chect_came_stect == 0)
        {
            touch_ui_obj[0].SetActive(false);
        }
        else if(camer_temp.Length -1 == chect_came_stect)
        {
            touch_ui_obj[1].SetActive(false);
        }
        else
        {
            touch_ui_obj[0].SetActive(true);
            touch_ui_obj[1].SetActive(true);
        }
        camer_temp[chect_came_stect].MoveToTopOfPrioritySubqueue();
        StartCoroutine("change_light");
    }
    IEnumerator change_light()//빛 위치 변경 
    {
        bool b_temp = true;
        float f_temp = 0.5f;
        Light2D light_temp = light_obj.GetComponent<Light2D>();

        while (b_temp)
        {
            f_temp -= Time.deltaTime;
            light_temp.intensity = f_temp;

            if (f_temp <= 0)
            {
                
                b_temp = false;
                f_temp = 0f;
            }
            yield return new WaitForFixedUpdate();
        }
        light_obj.transform.position = light_position[chect_came_stect];
        light_temp.intensity = 0.5f;
    }
}
