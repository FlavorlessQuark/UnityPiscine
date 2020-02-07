using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class bird : MonoBehaviour
{
	[SerializeField] Animator  anim;
	Vector3 rotateU, rotateD;
	bool r = true, up = false;
	float wait = 0.5f, time = 0;
    // Start is called before the first frame update
    void Start()
    {
		anim = gameObject.GetComponent<Animator>();
		rotateD.Set(-3f, 0, 0);
		rotateU.Set(3, 0, 0);;
	}

    // Update is called once per frame
    void Update()
    {
		if (up == true && wait >= time)
		{
			gameObject.transform.Translate(Vector3.up * 3);
			time = 0;
			up = false;
		}
		else if (wait >= time && transform.position.y >= -3)
		{
			gameObject.transform.Translate(Vector3.down * 0.1f);
		}
        if (Input.GetKeyDown(KeyCode.Space))
		{
			anim.Play("Flap");
			gameObject.transform.Rotate(rotateD);
			r = true;
			up = true;
		}
		if (r == true)
		{
			gameObject.transform.Rotate(rotateU);
			r = false;
		}
    }
}
