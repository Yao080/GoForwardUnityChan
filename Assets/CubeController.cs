using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //�L���[�u�ɐݒ肳�ꂽAudio
    AudioSource audioSource;

    //�L���[�u�̈ړ����x
    private float speed = -12;

    //���ňʒu
    private float deadLine = -10;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //��ʂ̊O�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    // �e�I�u�W�F�N�g�ɏՓ˂����ۂ̌��ʉ��̐ݒ�
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
