using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	[SerializeField] GameObject A, S, D;
	[SerializeField] Transform tA, tS, tD;
	Vector3 newpos;
	public float time, distance, wait;
	public int row;
	GameObject SpawnedObj;
	GameObject[] PosArr = new GameObject[3];
	Transform[] TrArr = new Transform[3];
	// Start is called before the first frame update
	void Start()
    {
		PosArr[0] = A;
		PosArr[1] = S;
		PosArr[2] = D;
		TrArr[0] = tA;
		TrArr[1] = tS;
		TrArr[2] = tD;
		wait = 0;
		row = Random.Range(0, 3);
		newpos.Set(0, 0, 0);
		wait = Random.Range(1f, 2f);
	}

	GameObject Spawn(int pos)
	{

		return Instantiate(PosArr[pos], TrArr[pos]);
	}
    // Update is called once per frame
    void Update()
    {
		time += Time.deltaTime;
        if (time >= wait)
		{
			time = 0;
			wait = Random.Range(1, 2.5f);
			SpawnedObj = Spawn(row);
			if (SpawnedObj)
			{
				SpawnedObj.AddComponent<Cube>();
			}
			row = Random.Range(0, 3);
		}
    }
}
