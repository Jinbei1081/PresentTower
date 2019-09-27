using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledMove : MonoBehaviour {
    
    public float speed;

    // Update is called once per frame
    void Update () {
        var pos = GetComponent<Transform>().position;
        var scale = GetComponent<Transform>().localScale;

        pos.x += speed;
        transform.position = pos;

        //折り返し
        if (Mathf.Abs(pos.x) > 30)
        {
            //移動方向反転
            speed *= -1;

            //スプライト反転
            scale.x *= -1;
            transform.localScale = scale;
        }


	}
}
