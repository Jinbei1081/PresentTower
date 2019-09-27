using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentManager : MonoBehaviour {

    public GameObject genPos;

    [SerializeField]
    List<RateInfo> RateInfos = new List<RateInfo>();

    [System.Serializable]
    class RateInfo
    {
        [SerializeField]
        public int weight; //確率の重み
        [SerializeField]
        public GameObject prefab; //抽選されるプレハブ
    }

    public void AddPresent(GameObject _present) { stackedPresent.Add(_present); }

    public static List<GameObject> stackedPresent;

    public static int Score;
    float highest;

    public void AddScore(int _score) { Score += _score; }
    public float GetHighest() { return highest; }

    public static List<GameObject> GetstackedPresent() { return stackedPresent; }
    public static int GetScore() { return Score; }

    private void Start()
    {
        stackedPresent = new List<GameObject>();
        stackedPresent.Clear();
        Score = 0;
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in stackedPresent)
        {
            if (go.transform.position.y > highest)
            {
                highest = go.transform.position.y;
            }
        }
    }

    public void Generate()
    {
        var genPresent = WeightedPick(RateInfos);
        var genObj = Instantiate(genPresent, genPos.transform.position, Quaternion.identity) as GameObject;
        genObj.name = genPresent.name;
        genObj.transform.SetParent(GameObject.Find("プレゼント生成位置").transform);

    }

    GameObject WeightedPick(List<RateInfo> list)
    {
        int totalWeight = 0;
        GameObject pick = null;

        // トータルの重みを計算する
        foreach (var weight in list)
        {
            totalWeight += weight.weight;
        }

        // 抽選する
        int rnd = Random.Range(0, totalWeight);

        foreach (var i in list)
        {
            if (rnd < i.weight)
            {
                //抽選対象決定
                pick = i.prefab;
                break;
            }

            //次の対象を調べる
            rnd -= i.weight;
        }

        return pick;
    }
}
