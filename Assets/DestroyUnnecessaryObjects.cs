using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUnnecessaryObjects : MonoBehaviour {

    //UnityChanのゲームオブジェクト
    private GameObject unityChan;

    // Use this for initialization
    void Start () {

        //シーン中unityChanオブジェクトを取得
        this.unityChan = GameObject.Find("unitychan");
    }
	
	// Update is called once per frame
	void Update () {

        //unityChanから一定の距離に移動
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.unityChan.transform.position.z - 7.5f);

    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    private void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトを削除
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag")
        {
            Destroy(other.gameObject);
        }
    }
}
