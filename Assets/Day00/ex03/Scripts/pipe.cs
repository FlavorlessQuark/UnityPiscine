using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
	[SerializeField] GameObject SpawnUp, SpawnDown, PipeU, PipeD, One, Two, bird, over;
	float time = 0, wait = 0, speed = 4, inc = 2, spawn = 0, owo = 0;
	public int UD;
	int score = 0;
    // Start is called before the first frame update
    void Start()
    {
		UD = Random.Range(0, 2);
		wait = Random.Range(0.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
		
		time += Time.deltaTime;
		owo += Time.deltaTime;
		spawn += Time.deltaTime;
		if (spawn >= wait)
		{
			UD = Random.Range(0, 2);
			spawn = 0;
			wait = Random.Range(0.5f, 1f);
			if (!One)
			{
				if (UD == 0)
					One = Instantiate(PipeU, SpawnUp.transform);
				else
					One = Instantiate(PipeD, SpawnDown.transform);
			}
			else if (!Two)
			{
				if (UD == 0)
					Two = Instantiate(PipeU, SpawnUp.transform);
				else
					Two = Instantiate(PipeD, SpawnDown.transform);
			}
		}
		if (time >= inc)
		{
			speed++;
			time = 0;
			inc += inc /2;
		}
		if (One)
		{
			if (One.name == "PipeU(Clone)")
			{
				if (One.transform.position.x >= -1.5f && One.transform.position.x <= -0.8f && bird.transform.position.y <= -1.1f)
				{
					print("Score : " + score + "\nTime : " + owo);
					Destroy(bird);
					over.SetActive(true);
					Destroy(this);
				}
				One.transform.Translate(Vector3.left * Time.deltaTime * speed);
			}
			else
			{
				One.transform.Translate(Vector3.right * Time.deltaTime * speed);
				if (One.transform.position.x >= -1.5f && One.transform.position.x <= -0.8f && bird.transform.position.y >= 0.8f)
				{
					print("Score : " + score + "\nTime : " + owo);
					Destroy(bird);
					over.SetActive(true);
					Destroy(this);
				}
			}
			if (One.transform.position.x <= -10.5f)
			{
				Destroy(One);
				score += 5;
			}
		}
		if (Two)
		{
			if (Two.name == "PipeU(Clone)")
			{
				if (Two.transform.position.x >= -1.5f && Two.transform.position.x <= -0.8f && bird.transform.position.y <= -1.1f)
				{
					print("Score : " + score + "\nTime : " + owo);
					Destroy(bird);
					over.SetActive(true);
					Destroy(this);
				}
				Two.transform.Translate(Vector3.left * Time.deltaTime * speed);
			}
			else
			{
				Two.transform.Translate(Vector3.right * Time.deltaTime * speed);
				if (Two.transform.position.x >= -1.5f && Two.transform.position.x <= -0.8f && bird.transform.position.y >= 0.8f)
				{
					print("Score : " + score + "\nTime : " + owo);
					Destroy(bird);
					over.SetActive(true);
					Destroy(this);
				}
			}
			if (Two.transform.position.x <= -10.5f)
			{
				Destroy(Two);
				score += 5;
			}
		}
	}
}
