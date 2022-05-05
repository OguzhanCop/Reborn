using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yürüme : MonoBehaviour
{
	float speed = 0.0099f;
	private float move = 2;
	private bool stop = false;
	private float blend;
	private float delay = 0;
	public float AddRunSpeed = 1;
	public float AddWalkSpeed = 1;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	
	
		void MMove()
		{
			float speed = 0.0f;
			float add = 0.0f;





			if (Input.GetKey(KeyCode.W))
			{
				move *= 1.015F;

				if (false)
				{
				
				}
				else
				{
					GetComponent<Animation>().Play("move_forward");
					add = 5 * AddWalkSpeed;
				}

				speed = Time.deltaTime * add;
				//transform.position = Vector3.MoveTowards(transform.position, mouse.transform.position, 0.0002f);
				transform.Translate(0, 0, speed);
			}


			if (Input.GetKeyUp(KeyCode.W))
			{
				if (GetComponent<Animation>().IsPlaying("move_forward"))
				{ GetComponent<Animation>().CrossFade("idle_normal", 0.3f); }
				if (GetComponent<Animation>().IsPlaying("move_forward_fast"))
				{
					GetComponent<Animation>().CrossFade("idle_normal", 0.5f);
					stop = true;
				}
				move = 20;
			}

			if (stop == true)
			{
				float max = Time.deltaTime * 20 * AddRunSpeed;
				blend = Mathf.Lerp(max, 0, delay);

				if (blend > 0)
				{
					transform.Translate(0, 0, blend);
					delay += 0.025f;
				}
				else
				{
					stop = false;
					delay = 0.0f;
				}
			}
		}

		bool CheckAniClip(string clipname)
		{
			if (this.GetComponent<Animation>().GetClip(clipname) == null)
				return false;
			else if (this.GetComponent<Animation>().GetClip(clipname) != null)
				return true;

			return false;
		}


		void Update()
		{

			MMove();

		if (Input.GetKey(KeyCode.A))

			transform.Rotate(0, -0.5f*Time.deltaTime*125, 0);

		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0, 0.5f*Time.deltaTime*125, 0);
		}
	}
		



	
}
