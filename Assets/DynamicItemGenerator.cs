using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを生成する地点;
    private int itemGenPos = 0;
    //アイテムを出す×方向の範囲
    private float posRangeX = 3.4f;
    //アイテムを出すy方向の範囲
    private int posRangeZ = 50;

    // Use this for initialization
    void Start()
    {
        //アイテムを出すUnityちゃんの地点を設定
        itemGenPos = startPos - posRangeZ;
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの現在地点が一定の範囲内であればアイテムを生成
        if (itemGenPos <= this.transform.position.z && this.transform.position.z <= goalPos - posRangeZ)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, itemGenPos + posRangeZ);

                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRangeX * j, coin.transform.position.y, itemGenPos + posRangeZ + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRangeX * j, car.transform.position.y, itemGenPos + posRangeZ + offsetZ);
                    }
                }
            }
            //アイテムを生成する範囲を変更
            itemGenPos += 15;
        }
    }
}
