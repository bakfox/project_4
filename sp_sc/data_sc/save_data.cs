using System;

public class save_data
{
    //�ΰ��� ���� 
    public Int64 user_gold = 200;
    public int[] user_upgrade_int = new int[7] { 0, 0, 0, 0, 0, 0, 0, };//0 �� ���� 

    //����
    public int user_last_check_cam = 0;

    //���� �ð� �� 
    public string user_last_time = "";

    //������ �ý��ۿ뵵
    public bool gift_get = false;
    public int gift_id = 0;
    public int gift_value = 0;
    public string gift_name = "";
}
