const express = require('express');
const app_temp = express();
const port = 3000;

app_temp.get('/api/gift', (req, res) => {
    // 데이터 보내기
    
    const data = {
        gift_id: 1,
        gift_value: 1000,
        gift_text: "플레이 해주셔서 감사합니다.!"
    };

    res.json(data);
});

app_temp.listen(port,()=>{
    console.log(port +'포트 사용')
    
})