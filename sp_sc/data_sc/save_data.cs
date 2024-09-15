using System;

public class save_data
{
    //인게임 내용 
    public Int64 user_gold = 200;
    public int[] user_upgrade_int = new int[7] { 0, 0, 0, 0, 0, 0, 0, };//0 은 제외 

    //셋팅
    public int user_last_check_cam = 0;

    //접속 시간 비교 
    public string user_last_time = "";

    //우편함 시스템용도
    public bool gift_get = false;
    public int gift_id = 0;
    public int gift_value = 0;
    public string gift_name = "";
}
