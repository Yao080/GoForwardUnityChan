using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;

    //Unityちゃんに移動させるコンポーネントを入れる（追加1）
    Rigidbody2D rigid2D;

    //地面の位置
    private float groundLevel = -3.0f;

    //ジャンプの速度の減衰（追加1）
    private float dump = 0.8f;

    //ジャンプの速度（追加1）
    float jumpVelocity = 20;

    //ゲームオーバーになる位置（追加2）
    private float deadline = -9;

    // Start is called before the first frame update
    void Start()
    {
        //アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dのコンポーネントを取得する（追加1）
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態のときはボリュームを0にする（追加3）
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされた場合（追加1）
        if(Input.GetMouseButtonDown (0) && isGround)
        {
            //上方向の力をかける（追加1）
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックをやめたら上方向へ速度を減速する（追加1）
        if(Input.GetMouseButton (0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //デッドラインを超えた場合ゲームオーバーにする(追加2)
        if(transform.position.x < this.deadline)
        {
            //UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する(追加2)
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //ユニティちゃんを破棄する(追加2)
            Destroy(gameObject);
        }
    }
}
