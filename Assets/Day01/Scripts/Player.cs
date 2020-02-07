using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] GameObject Claire, Thomas, John, model, cam, screen;
	GameObject[] plist = new GameObject[3];
	public int index;
	public bool grounded = true,  c = false, t = false, j = false;
	Vector3 campos;
	public Vector3 direction;
	[SerializeField] float speed, ydir;
	[SerializeField] Animator anim;
	[SerializeField] Scene nextlvl;
	
    // Start is called before the first frame update
    void Start()
    {
		plist[0] = Claire;
		plist[1] = Thomas;
		plist[2] = John;
		direction = Vector3.zero;
		direction.y = model.transform.rotation.y;
		ydir = 90;
		screen.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		campos = transform.position;
		campos.z = cam.transform.position.z;
		cam.transform.position = campos;
		if (c && j && t)
		{
			if (SceneManager.GetActiveScene().name == "level01")
			{
				print("over");
				screen.SetActive(true);
				cam.transform.Translate(Vector3.back * 70);
				gameObject.GetComponent<Player>().enabled = false;
			}
			else
				SceneManager.LoadScene("level01");
		}
		if (direction.y != ydir)
			direction.y = Mathf.Lerp(direction.y, ydir, 0.1f);
		model.transform.rotation = Quaternion.Euler(0, direction.y, 0);
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * speed);
			anim.SetBool("idle", false);
			ydir = 90;
		}
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.left * speed);
			anim.SetBool("idle", false);
			ydir = -90;
		}
		else if (Input.GetKey(KeyCode.Alpha1) && index != 0)
		{
			plist[0].gameObject.GetComponent<Player>().enabled = true;
			plist[0].gameObject.GetComponent<Player>().c = c;
			plist[0].gameObject.GetComponent<Player>().j = j;
			plist[0].gameObject.GetComponent<Player>().t = t;
			GetComponent<Player>().enabled = false;
		}
		else if (Input.GetKey(KeyCode.Alpha2) && index != 1)
		{
			plist[1].gameObject.GetComponent<Player>().enabled = true;
			plist[1].gameObject.GetComponent<Player>().c = c;
			plist[1].gameObject.GetComponent<Player>().j = j;
			plist[1].gameObject.GetComponent<Player>().t = t;
			GetComponent<Player>().enabled = false;
		}
		else if (Input.GetKey(KeyCode.Alpha3) && index != 2)
		{
			plist[2].gameObject.GetComponent<Player>().enabled = true;
			plist[2].gameObject.GetComponent<Player>().c = c;
			plist[2].gameObject.GetComponent<Player>().j = j;
			plist[2].gameObject.GetComponent<Player>().t = t;
			GetComponent<Player>().enabled = false;
		}
		else if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else
		{
			anim.SetBool("idle", true);
		}
		if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
		{
			grounded = false;
			anim.SetBool("grounded", false);
			gameObject.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(0, speed * 700, 0), ForceMode.Impulse);
		}
		
	}
	
	void OnTriggerEnter(Collider co)
	{
		print(co.gameObject.name + "trigger");
		if (index == 0 && co.gameObject.tag == "Claire")
			c = true;
		else if (index == 1 && co.gameObject.tag == "Thomas")
			t = true;
		else if (index == 2 && co.gameObject.tag == "John")
			j = true;
	}

	void OnTriggerExit(Collider co)
	{
		if (index == 0 && co.gameObject.tag == "Claire")
			c = false;
		else if (index == 1 && co.gameObject.tag == "Thomas")
			t = false;
		else if (index == 2 && co.gameObject.tag == "John")
			j = false;
	}

	void OnCollisionEnter(Collision col)
	{
		print(col.gameObject.name + "coll");
		if (grounded == false && col.gameObject.tag == ("Ground"))
		{
			grounded = true;
			anim.SetBool("grounded", true);
		}
		if (col.gameObject.tag == "Yellow")
		{
			if (index == 2)
			{
				grounded = true;
				anim.SetBool("grounded", true);
			}
			else 
				Physics.IgnoreCollision(col.collider, gameObject.GetComponent<Collider>());
		}
		if (col.gameObject.tag == "Red")
		{
			if (index == 1)
			{
				grounded = true;
				anim.SetBool("grounded", true);
			}
			else
				Physics.IgnoreCollision(col.collider, gameObject.GetComponent<Collider>());
		}
		if (col.gameObject.tag == "Blue")
		{
			if (index == 0)
			{
				grounded = true;
				anim.SetBool("grounded", true);
			}
			else
				Physics.IgnoreCollision(col.collider, gameObject.GetComponent<Collider>());
		}
	}
}
