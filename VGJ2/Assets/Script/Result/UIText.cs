using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour {

    public Text score;
    public Text LPresent;
    public Text MPresent;
    public Text SPresent;

	// Use this for initialization
	void Start () {

        score.text = PresentManager.GetScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
