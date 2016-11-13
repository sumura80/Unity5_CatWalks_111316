using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    GameObject player;

	// Use this for initialization
	void Start () {
        //カメラがキャラクターの猫を追いかけるように猫をFind関数で認識できるようにする。
        this.player = GameObject.Find("cat");
	
	}
	
	// Update is called once per frame
	void Update () {

        //キャラクタの座標をとりplayerposに代入する
        Vector3 playerPos = this.player.transform.position;

        //カメラにその座標を追従させる
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);

           

	
	}
}
