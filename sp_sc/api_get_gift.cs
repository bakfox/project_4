using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class api_get_gift : MonoBehaviour , api_settng
{
    public GameObject mailbox_main_obj;
    public GameObject mailbox_obj;
    save_sc save_temp;
    // Start is called before the first frame update
    private void Start()
    {
        save_temp = this.GetComponent<save_sc>();
    }
    public void open_mailbox()
    {
        if (save_temp.save_data_temp.gift_get)
        {
            mailbox_main_obj.SetActive(true);
        }else
        StartCoroutine("unity_api_time");
    }

    IEnumerator unity_api_time()//api받아오기 
    {
        string url = "http://localhost:3000/api/gift";
        
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.error == null)
        {
            mailbox_main_obj.SetActive(true);
            string data = request.downloadHandler.text;
            Debug.Log(data);
            process_data(data);
            StopCoroutine("unity_api_time");
        }
        else
        {
            Debug.Log("ERROR");
            StopCoroutine("unity_api_time");
        }
    }
    void process_data(string data)
    {
        gift_dat gift_data = JsonUtility.FromJson<gift_dat>(data);
        if (!save_temp.save_data_temp.gift_get)
        {
            save_temp.save_data_temp.gift_get = true;

            if (save_temp.save_data_temp.gift_id != gift_data.gift_id)
            {
                save_temp.save_data_temp.gift_id = gift_data.gift_id;
                save_temp.save_data_temp.gift_value = gift_data.gift_value;
                save_temp.save_data_temp.gift_name = gift_data.gift_text;

                GameObject box_temp = Instantiate(mailbox_obj, GameObject.FindGameObjectWithTag("mailbox").transform);
                get_gift_box gif_box_temp = box_temp.GetComponent<get_gift_box>();
                gif_box_temp.check_value = gift_data.gift_value;
                gif_box_temp.check_name = gift_data.gift_text;
                gif_box_temp.check_box();
            }
        }
        
    }
    class gift_dat
    {
       public int gift_id = 0;
       public int gift_value = 0;
       public string gift_text = "";
    }
}
