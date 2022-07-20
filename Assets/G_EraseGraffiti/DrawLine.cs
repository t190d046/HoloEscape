using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int positionCount;

    private bool isCacth;
    public void SetIsCacth(bool flag)
    {
        isCacth = flag;
    }
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        positionCount = 0;
    }


    private void OnTriggerStay(Collider collision)
    {
        string name = collision.gameObject.name;
        //Debug.Log(name);

        if (name == "Graffiti" && isCacth)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
            // 座標指定の設定をローカル座標系にしたため、与える座標にも手を加える
            Vector3 pos = transform.position;
            pos.y = collision.transform.position.y;
            // 得られたローカル座標をラインレンダラーに追加する
            positionCount++;
            lineRenderer.positionCount = positionCount;
            lineRenderer.SetPosition(positionCount - 1, pos);
        }

    }


    private void OnTriggerExit(Collider collision)
    {
        //positionCount = 0;
    }
}
