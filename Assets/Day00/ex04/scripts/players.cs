using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class players : MonoBehaviour
{
	[SerializeField] GameObject P1, P2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && P1.transform.position.y <= 4.76f)
		{
			P1.transform.Translate(Vector3.up * 0.2f);
		}
		if (Input.GetKey(KeyCode.S) && P1.transform.position.y >= -2.64f)
		{
			P1.transform.Translate(Vector3.down * 0.2f);
		}
		if (Input.GetKey(KeyCode.UpArrow) && P2.transform.position.y <= 4.76f)
		{
			P2.transform.Translate(Vector3.up * 0.2f);
		}
		if (Input.GetKey(KeyCode.DownArrow) && P2.transform.position.y >= -2.64f)
		{
			P2.transform.Translate(Vector3.down * 0.2f);
		}
	}
}
