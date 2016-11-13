using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //LoadSceneを使うために追加

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("GameScene");
            //マウスがクリックされたら＝あたり判定に該当したら
            //SceneManagerのLoadSCeneにより引数のsceneに遷移する。
        }

	
	}
}
