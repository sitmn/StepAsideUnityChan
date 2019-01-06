using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;

    public GameObject UnityChan;

    private int startPos = -160;
    private int goalPos = 120;
    private float posRange = 3.4f;

    private int distance = 45;

    private bool Itemmake = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Itemmakeをリセット
        if(Itemmake == false && Mathf.Abs(UnityChan.transform.position.z % 15) < 15 && Mathf.Abs(UnityChan.transform.position.z % 15) >= 13)
        {
            Itemmake = true;
        }

        //1.ユニティちゃんが15ｍ移動する毎にアイテム生成
        //2.ユニティちゃんから45ｍ離れた場所（オフセット込みで40～50ｍ）のアイテムを生成
		if(startPos - distance <= UnityChan.transform.position.z && UnityChan.transform.position.z <= goalPos - distance && Itemmake && Mathf.Abs(UnityChan.transform.position.z % 15) <= 10 && Mathf.Abs(UnityChan.transform.position.z % 15) >=8)
        {
            //1回のみ生成
            Itemmake = false;

            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, UnityChan.transform.position.z + distance);
                }
            }
            else
            {
                for (float j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);

                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, UnityChan.transform.position.z + distance + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, UnityChan.transform.position.z + distance + offsetZ);
                    }
                }
            }
        }
	}
}
