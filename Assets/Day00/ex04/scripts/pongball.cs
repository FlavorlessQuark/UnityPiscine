using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pongball : MonoBehaviour
{
	Vector3 start, direction;
	[SerializeField] GameObject p1, p2;
	[SerializeField] Text msg;
	float timer = 0;
	int s1 = 0, s2 = 0;
	bool stop;
    // Start is called before the first frame update
    void Start()
    {
		start.Set(0,1,-1.6f);
		transform.position = start;
		direction.Set(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f),0);
		msg.enabled = false;
	}

	void Reset()
	{
		transform.position = start;
		msg.enabled = false;
	}
	// Update is called once per frame
	void Update()
	{
		if (stop == false)
		{
			transform.Translate(direction * 0.2f);
			if (transform.position.y <= -2.64f || transform.position.y >= 4.76f)
				direction.y *= -1;
			if (transform.position.x <= p1.transform.position.x + 0.1f)
			{
				if (transform.position.y <= p1.transform.position.y + 0.7f && transform.position.y >= p1.transform.position.y - 0.7f)
				{
					direction.x *= -1;
					direction.y = Random.Range(-0.1f, 01f);
				}
				else
				{
					Reset();
					stop = true;
					s2++;
					print("Player 1 : " + s1 + " | Player 2 : " + s2);
					msg.text = ("Player 1 : " + s1 + " | Player 2 : " + s2);
					msg.enabled = true;
				}
			}
			if (transform.position.x >= p2.transform.position.x - 0.1f)
			{
				if (transform.position.y <= p2.transform.position.y + 0.7f && transform.position.y >= p2.transform.position.y - 0.7f)
				{
					direction.x *= -1;
					direction.y = Random.Range(-0.1f, 01f);
				}
				else 
				{
					Reset();
					stop = true;
					s1++;
					print("Player 1 : " + s1 + " | Player 2 : " + s2);
					msg.text = ("Player 1 : " + s1 + " | Player 2 : " + s2);
					msg.enabled = true;
				}
			}
		}
		else
		{
			timer += Time.deltaTime;
			if (timer >= 3)
			{
				stop = false;
				timer = 0;
			}
		}
	}
}
