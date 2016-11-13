using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 700.0f;
    float walkForce = 50.0f; //歩く速さの設定
    float maxWalkSpeed = 2.0f; //歩くのが早すぎないようにするための限度設定
    Animator animator; //animationを使えるように変数にしておく
    // Use this for initialization
    void Start()
    {
        //rigid2D変数をrigidbodyコンポーナントが使えるように代入
        this.rigid2D = GetComponent<Rigidbody2D>();

        //animatorを操作できるようにコンポーナントを取得する
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //ジャンプできるようにする.
        //空中で更にジャンプできないようにY方向の速度が０の時だけ飛べるよう制限をかけている。
        if (Input.GetKeyDown(KeyCode.Space) && (this.rigid2D.velocity.y == 0))
        {
            //AnimatorコンポーナントのSetTriggerでアニメーションを遷移している。
            this.animator.SetTrigger("JumpTrigger");

            //AddForceでキャラクターにジャンプできる力を加えている。
            this.rigid2D.AddForce(transform.up * this.jumpForce);

            
        }

        //左右の移動
        int key = 0; //何も押さないときは停止するための0
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }

        //歩きに速度をつける
        //1.catのスピードvelocityの横方向のスピードを絶対値で計算
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        //2.スピードに制限をつけてAddforceで力をかけて左右に移動させている
        if (speedx < this.maxWalkSpeed)
        {
            //右矢印なら1、左矢印なら-1がかえって来るのでそのKEYにスピードをかける。
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //左右を向けるように設定する1は右方向、－1だと逆に左を向く（反転）
        if (key != 0)
        {
            //クリックした矢印によってscaleで向きを変えている
            transform.localScale = new Vector3(key * 2, 2, 2);
        }

        //移動速度の変更。そのままだと走り続けるので、2で割り適当な速さにしている。
        //キャラの速度に応じてアニメーションを変える
       
            this.animator.speed = speedx / 2.0f;
        



        //現在の座標をとり穴から落ちてY座標が-10より小さくなったら（－11以上）
        //SceneManagerのLoadSceneの引数に現在のシーンを入れると戻る
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }



    }
    //Treasure box とのあたり判定をつけるために、OnTriggerEnter2Dを追加
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ゴール");
        SceneManager.LoadScene("ClearScene");
    }

}
