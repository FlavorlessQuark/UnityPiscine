using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
	private float speed, time = 0;
	Vector3 newpos = Vector3.zero;
	[SerializeField]int k;
	KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
		speed = Random.Range(0.05f, 0.5f);
		newpos.y = 1.5f;
		if (k == 1)
			key = KeyCode.A;
		else if (k == 2)
			key = KeyCode.S;
		else if (k == 3)
			key = KeyCode.D;
	}

	// Update is called once per frame
	void Update()
	{
		time += Time.deltaTime;
		if (time >= speed)
		{
			gameObject.transform.position -= newpos;
			time = 0;
		}
		if (gameObject.transform.position.y <= -15)
		{
			if (Input.GetKeyDown(key))
			{
				print("precision : " + (gameObject.transform.position.y + 32));
				Destroy(gameObject);
			}
			
			if (gameObject.transform.position.y <= -35)
			{
				Destroy(gameObject);
			}
		}
	}
}
