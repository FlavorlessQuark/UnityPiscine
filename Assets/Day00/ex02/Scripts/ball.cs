using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
	[SerializeField] GameObject manager;
	public float speed = 0, time = 0;
	Vector3 pos;
	int mult = 1;
	Transform tr;
	bool move = true;
    // Start is called before the first frame update
    void Start()
    {
		tr = gameObject.transform;
		pos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
		if (move == true)
		{
			pos.z = speed * mult;
			time += Time.deltaTime;
			if (speed > 0)
			{
				tr.position += pos;
				if (time >= 1)
				{
					speed -= 0.03f;
					time = 0;
				}
			}
			else
			{
				manager.GetComponent<club>().stopped = true;
				speed = 0;
				mult = 1;
			}
			if (tr.position.z >= 1)
				mult = -1;
			if (tr.position.z <= -11)
				mult = 1;
			if (tr.position.z >= -0.8f && tr.position.z <= -0.3f && speed <= 0.05f)
			{
				manager.GetComponent<club>().win();
				move = false;
			}
		}

    }
}
