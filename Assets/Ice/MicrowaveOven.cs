using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// このコンポーネントを加えたオブジェクトに、コンポーネントに取り込んだオブジェクトが入っているときにフラグを立てることでカウントダウンをはじめ、カウントが終わると取り込んだオブジェクトを消失させる
public class MicrowaveOven : MonoBehaviour
{
    // 対象のオブジェクトを取り込む
    [SerializeField] private GameObject ice = null;
    [SerializeField] private GameObject key = null;
    [SerializeField] private Image progress = null; // プログレスバー内の"Fill"を入れる
    [SerializeField] private AudioClip clip;

    private AudioSource audioSource;

    private Rigidbody rigidbody_ice;
    private Rigidbody rigidbody_key;
    private Vector3 start_Scale;
    private float start_time;

    // 対象のオブジェクトがレンジ内にあるかどうかを判別するフラグ
    private bool flag_in = false;

    // 対象のオブジェクトのあたためが始まったかどうかを判別するフラグ
    private bool flag_warm = false;

    // レンジのカウント時間
    private float totalTime;
    [SerializeField] private int seconds = 60;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody_ice = ice.GetComponent<Rigidbody>();
        rigidbody_key = key.GetComponent<Rigidbody>();
        totalTime = seconds;
        start_time = totalTime;
        start_Scale = ice.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag_warm == true){
            // カウントダウン
            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;

            // プログレスバーを動かす
            progress.fillAmount = 1 - (totalTime / start_time);

            // 氷を小さくしていく
            Vector3 ice_scale;
            ice_scale = ice.transform.localScale;
            ice_scale.x -= start_Scale.x*(Time.deltaTime/start_time);
            ice_scale.y -= start_Scale.y*(Time.deltaTime/start_time);
            ice_scale.z -= start_Scale.z*(Time.deltaTime/start_time);
            ice.transform.localScale = ice_scale;

            if(totalTime <= 0){
                rigidbody_key.constraints = RigidbodyConstraints.None;
                flag_warm = false;

                progress.fillAmount = 1f;


                AudioSource.PlayClipAtPoint(clip, transform.position);

                // 対象のオブジェクトを消失させる(溶かす)
                Destroy(this.gameObject);
            }
        } else{
            Vector3 posi = ice.transform.position;
            key.transform.position = posi;
        }
    }

    // レンジと対象オブジェクトが触れた時に呼ばれる関数
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == ice) {
            flag_in = true;
        }
    }

    // レンジと対象オブジェクトが離れた時に呼ばれる関数
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == ice) {
            flag_in = false;
        }
    }

    // あたためのフラグを管理する関数
    public void warm()
    {
        if(flag_in == true){
            flag_warm = true;

            // 対象オブジェクトの操作を不能にする
            rigidbody_ice.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    
}
