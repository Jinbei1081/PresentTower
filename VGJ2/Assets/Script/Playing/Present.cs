using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Present : MonoBehaviour {

    GameObject presentMgr;

    bool isGenerate = false;

	// Use this for initialization
	void Start () {
        presentMgr = GameObject.Find("PresentManager");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().simulated = true;
            transform.SetParent(presentMgr.transform);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            SceneManager.LoadScene("Result");
            return;
        }

        if (!isGenerate){
            presentMgr.GetComponent<PresentManager>().Generate();
            presentMgr.GetComponent<PresentManager>().AddPresent(this.gameObject);

            var mgr = GameObject.Find("PresentManager").GetComponent<PresentManager>();
            if (tag == "Large")
            {
                presentMgr.GetComponent<PresentManager>().AddScore(Mathf.CeilToInt(50 * (mgr.GetHighest()/2 + 1)));
            }
            if (tag == "Medium")
            {
                presentMgr.GetComponent<PresentManager>().AddScore(Mathf.CeilToInt(100 * (mgr.GetHighest()/2 + 1)));
            }
            if (tag == "Small")
            {
                presentMgr.GetComponent<PresentManager>().AddScore(Mathf.CeilToInt(200 * (mgr.GetHighest()/2 + 1)));
            }

            isGenerate = true;
        }
    }
}
