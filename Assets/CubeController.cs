using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブに設定されたAudio
    AudioSource audioSource;

    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面の外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    // 各オブジェクトに衝突した際の効果音の設定
    void OnCollisionEnter2D(Collision2D collision)
    {
        string yourTag = collision.gameObject.tag;

        if (yourTag == "ground")
        {
            audioSource.Play();
        }
        if (yourTag == "CubePrefab")
        {
            audioSource.Play();
        }
        if (yourTag == "UnityChan2d")
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }
}
