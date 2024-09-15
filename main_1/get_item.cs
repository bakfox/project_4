using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class get_item : MonoBehaviour
{
    public int i_temp;//È¹µæ °¹¼ö
    public TextMeshProUGUI text_temp;//ÀÚ½Å text
    public Image image_temp;
    public float time_max = 1f;

    public Vector3 now_postion;
    main_1_manager main_1_temp;
    // Start is called before the first frame update

    public void setting_on()
    {
        main_1_temp = main_1_manager.GetInstance();
        gameObject.SetActive(true);
        transform.position = now_postion;
        text_temp.SetText(main_1_temp.change_unit(i_temp.ToString()) + " + ");
        StartCoroutine("up_effect");
    }
    IEnumerator up_effect()
    {
        float time_temp = 0;
        while (time_max > time_temp)
        {
            time_temp += Time.deltaTime;
            text_temp.color = new Color(text_temp.color.r, text_temp.color.g, text_temp.color.b, (255f - (time_temp * 255f)) / 255f);
            image_temp.color = new Color(image_temp.color.r, image_temp.color.g, image_temp.color.b, (255f - (time_temp * 255f)) / 255f);
            gameObject.transform.position = new Vector3(now_postion.x, now_postion.y + (time_temp * 1f), now_postion.z);
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
        main_1_temp.effect_list.Add(gameObject);
        gameObject.SetActive(false);

    }
}
