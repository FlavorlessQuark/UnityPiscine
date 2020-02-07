using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class club : MonoBehaviour
{
	[SerializeField] GameObject balls;
	[SerializeField] Transform bar;
	[SerializeField] Text wintext;
	Camera cam;
	ball bScript;
	public Vector3 scale;
	public float force = 0;
	private float inv = 0;
	public bool stopped = true;
	int score = -15;
    // Start is called before the first frame update
    void Start()
    {
		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		scale = Vector3.one;
		bScript = balls.GetComponent<ball>();
    }

	public void win()
	{
		bar.gameObject.SetActive(false);
		if (score <= 0)
			wintext.text = ("    You win! \n You score is : " + score);
		else
			wintext.text = ("    You lost :( \n You score is : " + score);
	}
	// Update is called once per frame
	void Update()
	{
		if (force >= 0.2f)
			inv = 1;
		else if (force <= 0)
			inv = 0;
		scale.x = (force * 10) / 2;
		bar.transform.localScale = scale;
		if (stopped)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				if (inv == 0)
					force += 0.002f;
				else
					force -= 0.002f;
			}
			if (Input.GetKeyUp(KeyCode.Space))
			{
				bScript.speed = force;
				force = 0;
				stopped = false;
				score += 5;
			}
		}
    }
}
