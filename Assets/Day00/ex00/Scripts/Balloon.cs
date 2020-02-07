using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    GameObject ballon;
	[SerializeField] Transform bone;
    [SerializeField] int max;
	[SerializeField] Text oob;
    public float breath = 0, wait = 0, scale = 0;
    private float lifetime = 0;
	public bool bout = false, game = true;
	[SerializeField] Vector3 ScaleUp;
    // Start is called before the first frame update
    void Start()
    {
        ballon = gameObject;
		ScaleUp.x = 0.3f;
		ScaleUp.y = 0.2f;
		ScaleUp.z = 0.1f;
		oob.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (game == true)
		{
			lifetime += Time.deltaTime;
			wait += Time.deltaTime;
			scale += Time.deltaTime;
			if (bout == false)
			{
				if (Input.GetKeyDown(KeyCode.Space) && breath <= 6)
				{
					bone.localScale += ScaleUp;
					breath += 1;
				}
				else if (breath >= 6)
				{
					wait = 0;
					bout = true;
					oob.enabled = true;
				}
			}
			else
			{
				if (wait >= 5)
				{
					bout = false;
					oob.enabled = false;
				}
			}
			if (scale >= 0.7f)
			{
				bone.localScale -= ScaleUp;
				if (breath > 0)
					breath -= 1;
				scale = 0;
			}
			if (bone.localScale.x <= 0.5f || bone.localScale.x >= 2.5f)
			{
				Debug.Log("Balloon lifetime : " + Mathf.RoundToInt(lifetime) + "s");
				Destroy(gameObject);
			}
		}
	}
}
