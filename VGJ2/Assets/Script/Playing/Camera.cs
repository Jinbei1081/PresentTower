using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public float hold = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var length = transform.position.y - GameObject.Find("PresentManager").GetComponent<PresentManager>().GetHighest();
        if ( length < hold)
        {
            var pos = transform.position;
            pos.y += hold - length;
            transform.position = pos;
        }
	}
}
