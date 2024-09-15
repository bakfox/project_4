using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.Collections.AllocatorManager;

public class shop_ui : MonoBehaviour, IPointerClickHandler
{
    Animator anim_temp;

    bool shop_bool =false;
    [SerializeField]
    bool check_end_anim = true;
    public GameObject shop_ui_obj;
    

    public void OnPointerClick(PointerEventData eventData)//화면 오른쪽 중간에 조타수 모양 클릭시 발동 
    {
        if (check_end_anim)
        {
            check_end_anim = false;
            anim_temp = this.GetComponent<Animator>();
            anim_temp.SetTrigger("click");
            StartCoroutine("shop_move");
        }
    }
    IEnumerator shop_move()//움직이는 애니메이션 
    {
        RectTransform rect_temp = shop_ui_obj.GetComponent<RectTransform>();
        float check_t = 0f;

        if (shop_bool)
        {
            shop_bool = false;
            while (check_t > -1f)
            {
                
                check_t -= Time.deltaTime;
                rect_temp.anchoredPosition = new Vector2((0 + -check_t*1920), 0);
                yield return new WaitForFixedUpdate();
            }
            rect_temp.anchoredPosition = new Vector2(1920, 0);
            shop_ui_obj.SetActive(false);
        }
        else
        {
            shop_bool = true;
            shop_ui_obj.SetActive(true);
            while (check_t < 1f)
            {
                check_t += Time.deltaTime;
                rect_temp.anchoredPosition = new Vector2((1920 - check_t * 1920), 0);
                yield return new WaitForFixedUpdate();
            }
            rect_temp.anchoredPosition = new Vector2(0, 0);

        }
        Debug.Log("check_t" + check_t);
        check_end_anim = true;
        StopCoroutine("shop_move");
        
    }
}
