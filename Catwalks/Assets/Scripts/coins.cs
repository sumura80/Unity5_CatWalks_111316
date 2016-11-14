using UnityEngine;
using System.Collections;

public class coins : MonoBehaviour {
    GameObject cat;
    //キャラの変数を作成
    
    
	// Use this for initialization
	void Start () {
        this.cat = GameObject.Find("cat");
        //キャラをオブジェクトでFind関数でCATのものを探し、This.catに代入
       
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 c1 = transform.position;//coinの位置を認識
        Vector2 c2 = this.cat.transform.position;//キャラの位置を認識
        Vector2 dir = c1 - c2;//coinとキャラの距離を引き
        float d = dir.magnitude;//その差をmagnitudeで距離に変更

        float r1 = 0.3f;
        float r2 = 0.6f;
         
        if(d <r1 + r2)//コインと猫の半径がコインとキャラの距離の差より大きければ
        {//Destoryでコインを消している。
            Destroy(gameObject);
        }
	
	}
    
    

}
