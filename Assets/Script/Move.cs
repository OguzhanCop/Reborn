using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Move : MonoBehaviour
{
	private float move = 20;
	private bool stop = false;
	private float blend;
	private float delay = 0;
	public float AddRunSpeed = 1;
	public float AddWalkSpeed = 1;


	public GameObject[] skills;
	public GameObject[] skills2;
	public Image iceicon;
	public Image iceultyicon;
	public Image fireicon;
	public Image fireareaicon;
	public Image lightingicon;
	public Image lightingultyicon;
	public float iceefeckttime;
	public Image seç0;
	public Image seç1;
	public Image seç2;
	bool[] skillready = new bool[3];
	bool[] skillready2 = new bool[3];
	public Image[] can;
	public GameObject mouse;
	int skillselect = 0;
	public Slider hpbar;
	public int a;
	public TextMeshProUGUI gameover;
	int level;
	int ok;
	public TextMeshProUGUI levelt;
	public AudioSource[] ses1;
	public AudioSource[] ses2;
	public Image again;


	void Start()
	{
		level = PlayerPrefs.GetInt("Level");
        if (level == 1)
        {
			skillready[0] = true;
			skillready[1] = false;
			skillready[2] = false;
			skillready2[0] = false;
			skillready2[1] = false;
			skillready2[2] = false;
			fireicon.gameObject.SetActive(true);
			fireareaicon.gameObject.SetActive(false);
			iceicon.gameObject.SetActive(false);
			iceultyicon.gameObject.SetActive(false);
			lightingicon.gameObject.SetActive(false);
			lightingultyicon.gameObject.SetActive(false);
			ok = 0;
		}
		if (level == 2)
		{
			skillready[0] = true;
			skillready[1] = true;
			skillready[2] = false;
			skillready2[0] = false;
			skillready2[1] = false;
			skillready2[2] = false;
			fireicon.gameObject.SetActive(true);
			fireareaicon.gameObject.SetActive(false);
			iceicon.gameObject.SetActive(true);
			iceultyicon.gameObject.SetActive(false);
			lightingicon.gameObject.SetActive(false);
			lightingultyicon.gameObject.SetActive(false);
			ok = 1;
		}
		if (level == 3)
		{
			skillready[0] = true;
			skillready[1] = true;
			skillready[2] = true;
			skillready2[0] = false;
			skillready2[1] = false;
			skillready2[2] = false;
			fireicon.gameObject.SetActive(true);
			fireareaicon.gameObject.SetActive(false);
			iceicon.gameObject.SetActive(true);
			iceultyicon.gameObject.SetActive(false);
			lightingicon.gameObject.SetActive(true);
			lightingultyicon.gameObject.SetActive(false);
			ok = 2;
		}
		if (level == 4)
		{
			skillready[0] = true;
			skillready[1] = true;
			skillready[2] = true;
			skillready2[0] = true;
			skillready2[1] = false;
			skillready2[2] = false;
			fireicon.gameObject.SetActive(true);
			fireareaicon.gameObject.SetActive(true);
			iceicon.gameObject.SetActive(true);
			iceultyicon.gameObject.SetActive(false);
			lightingicon.gameObject.SetActive(true);
			lightingultyicon.gameObject.SetActive(false);
			ok = 2;
		}
		if (level == 5)
		{
			skillready[0] = true;
			skillready[1] = true;
			skillready[2] = true;
			skillready2[0] = true;
			skillready2[1] = true;
			skillready2[2] = false;
			fireicon.gameObject.SetActive(true);
			fireareaicon.gameObject.SetActive(true);
			iceicon.gameObject.SetActive(true);
			iceultyicon.gameObject.SetActive(true);
			lightingicon.gameObject.SetActive(true);
			lightingultyicon.gameObject.SetActive(false);
			ok = 2;
		}
		if (level == 6)
		{
			skillready[0] = true;
			skillready[1] = true;
			skillready[2] = true;
			skillready2[0] =true;
			skillready2[1] =true;
			skillready2[2] = true;
			fireicon.gameObject.SetActive(true);
			fireareaicon.gameObject.SetActive(true);
			iceicon.gameObject.SetActive(true);
			iceultyicon.gameObject.SetActive(true);
			lightingicon.gameObject.SetActive(true);
			lightingultyicon.gameObject.SetActive(true);
			ok = 2;
		}
		
		skills[0].SetActive(false);
		skills[1].SetActive(false);
		skills[2].SetActive(false);
		skills2[2].SetActive(false);
		skills2[1].SetActive(false);
		skills2[0].transform.GetChild(0).gameObject.SetActive(false);
		skills2[0].transform.GetChild(1).gameObject.SetActive(false);
		
		a = PlayerPrefs.GetInt("can");

	}

	void MMove()
	{
		float speed = 0.0f;
		float add = 0.0f;





		if (Input.GetKey(KeyCode.W))
		{
			//move *= 1.015F;

			//if (move > 250 && CheckAniClip("move_forward_fast") == true)
			//{
			//	{
			//		GetComponent<Animation>().CrossFade("move_forward_fast");
			//		add =50 * AddRunSpeed;
			//	}
			//}
			//else
			//{
				GetComponent<Animation>().Play("move_forward");
				add = 13 * AddWalkSpeed;
			

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
		levelt.text = "Level :" + PlayerPrefs.GetInt("Level");
		
		MMove();
		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			skillselect--;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			skillselect++;
		}
		if (Input.GetKeyDown(KeyCode.Q))
			skillselect--;
		if (Input.GetKeyDown(KeyCode.E))
			skillselect++;
		skillselect = Mathf.Clamp(skillselect, 0, ok);
		if (skillselect == 0)
		{
			seç0.gameObject.SetActive(true);
			seç1.gameObject.SetActive(false);
			seç2.gameObject.SetActive(false);
		}
		if (skillselect == 1)
		{
			seç0.gameObject.SetActive(false);
			seç1.gameObject.SetActive(true);
			seç2.gameObject.SetActive(false);
		}
		if (skillselect == 2)
		{
			seç0.gameObject.SetActive(false);
			seç1.gameObject.SetActive(false);
			seç2.gameObject.SetActive(true);
		}
        if (a == 3)
        {
			can[0].gameObject.SetActive(true);
			can[1].gameObject.SetActive(true);
			can[2].gameObject.SetActive(true);
		
		}
		if (a == 2)
		{
			can[0].gameObject.SetActive(true);
			can[1].gameObject.SetActive(true);
			can[2].gameObject.SetActive(false);
			
		}
		if (a == 1)
		{
			can[0].gameObject.SetActive(true);
			can[1].gameObject.SetActive(false);
			can[2].gameObject.SetActive(false);
			
		}
        



		if (hpbar.value<=0)
		{			
			GetComponent<Animation>().CrossFade("dead", 0.2f);
			a = PlayerPrefs.GetInt("can");
			a--;
			PlayerPrefs.SetInt("can", a);
			a = Mathf.Clamp(a, 0, 3);
			if (a == 0)
			{
				can[0].gameObject.SetActive(false);
				can[1].gameObject.SetActive(false);
				can[2].gameObject.SetActive(false);
				gameover.gameObject.SetActive(true);
				again.gameObject.SetActive(true);
				Time.timeScale = 0;


            }
            else
            {
				SceneManager.LoadScene(3);
			}
			

		}


		if (Input.GetKey(KeyCode.P))
		{
			if (CheckAniClip("attack_short_001") == false) return;

			GetComponent<Animation>().CrossFade("attack_short_001", 0.0f);
			GetComponent<Animation>().CrossFadeQueued("idle_combat");
		}

		if (Input.GetKey(KeyCode.Z))
		{
			if (CheckAniClip("damage_001") == false) return;

			GetComponent<Animation>().CrossFade("damage_001", 0.0f);
			GetComponent<Animation>().CrossFadeQueued("idle_combat");
		}


		if (Input.GetKey(KeyCode.D))
		{
			if (CheckAniClip("idle_normal") == false) return;

			GetComponent<Animation>().CrossFade("idle_normal", 0.0f);
			GetComponent<Animation>().CrossFadeQueued("idle_normal");
		}

		if (Input.GetKey(KeyCode.Mouse0))
		{
			if (CheckAniClip("idle_combat") == false) return;

			GetComponent<Animation>().CrossFade("idle_combat", 0.0f);
			GetComponent<Animation>().CrossFadeQueued("idle_normal");
			if (skillready[skillselect])
			{
				
				skills[skillselect].transform.position = transform.position + new Vector3(0, 3f, 0);
				skills[skillselect].transform.LookAt(new Vector3(mouse.transform.position.x, transform.position.y+3F, mouse.transform.position.z));
				skills[skillselect].SetActive(true);
				ses1[skillselect].Play();
				if (skillselect == 0)
				{
					Invoke("firefecktbitir", iceefeckttime);
					fireicon.fillAmount = 0;
					InvokeRepeating("firefecktdolma", iceefeckttime / 12, iceefeckttime / 12);
				}
				if (skillselect == 1)
				{
					Invoke("iceefecktbitir", iceefeckttime);
					iceicon.fillAmount = 0;
					InvokeRepeating("iceefecktdolma", iceefeckttime / 12, iceefeckttime / 12);
				}
				if (skillselect == 2)
				{
					Invoke("lightingefecktbitir", iceefeckttime);
					lightingicon.fillAmount = 0;
					InvokeRepeating("lightingefecktdolma", iceefeckttime / 12, iceefeckttime / 12);
				}

				skillready[skillselect] = false;
			}
		}
		
		if (Input.GetKey(KeyCode.Mouse1))
		{
			if (CheckAniClip("idle_combat") == false) return;

			GetComponent<Animation>().CrossFade("idle_combat", 0.0f);
			GetComponent<Animation>().CrossFadeQueued("idle_normal");
			if (skillready2[skillselect])
			{
				ses2[skillselect].Play();
				if (skillselect == 2)
				{
					skills2[skillselect].transform.position = new Vector3(mouse.transform.position.x, transform.position.y, mouse.transform.position.z)  ; 
					skills2[skillselect].transform.rotation = transform.rotation;
					skills2[skillselect].SetActive(true);
					Invoke("lightingultyefecktbitir", iceefeckttime);
					lightingultyicon.fillAmount = 0;
					InvokeRepeating("lightingultydolma", iceefeckttime / 12, iceefeckttime / 12);
					
				}
				if (skillselect == 1)
				{
					skills2[skillselect].transform.position = new Vector3(mouse.transform.position.x, transform.position.y, mouse.transform.position.z);
					skills2[skillselect].transform.rotation = transform.rotation;
					skills2[skillselect].SetActive(true);
					Invoke("iceultybitir", iceefeckttime);
					iceultyicon.fillAmount = 0;
					InvokeRepeating("iceultydolma", iceefeckttime / 12, iceefeckttime / 12);

				}
				if (skillselect == 0)
				{
					
					skills2[0].transform.GetChild(0).gameObject.SetActive(true);
					skills2[0].transform.GetChild(0).transform.rotation = Quaternion.Euler(90, 90, 90);
					skills2[0].transform.GetChild(1).gameObject.SetActive(false);
					
					skills2[0].transform.GetChild(0).transform.position = new Vector3(mouse.transform.position.x, mouse.transform.position.y + 50, mouse.transform.position.z);
				
					

					Invoke("fireareabitir", iceefeckttime);
					fireareaicon.fillAmount = 0;
					InvokeRepeating("fireareaultydolma", iceefeckttime / 8, iceefeckttime / 8);
				}
				skillready2[skillselect] = false;
			}

		}


		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(0, Time.deltaTime * -100, 0);
		}
		if (Input.GetKey(KeyCode.D))
			transform.Rotate(0, Time.deltaTime * 100, 0);
		if (Input.GetKey(KeyCode.S))
		{
			GetComponent<Animation>().CrossFade("idle_normal", 0.3f);
			transform.Translate(Vector3.back * 0.2f* Time.deltaTime * 45);
		}
	}
	void firefecktbitir()
	{
		skills[0].SetActive(false);
	}
	void firefecktdolma()
	{
		fireicon.fillAmount += 1 / 12f;

		if (fireicon.fillAmount == 1)
		{
			CancelInvoke("firefecktdolma");
			skillready[0] = true;
		}
	}
	void iceefecktbitir()
	{
		skills[1].SetActive(false);
	}
	void iceefecktdolma()
	{
		iceicon.fillAmount += 1 / 12f;

		if (iceicon.fillAmount == 1)
		{
			CancelInvoke("iceefecktdolma");
			skillready[1] = true;
		}
	}
	void lightingefecktbitir()
	{
		skills[2].SetActive(false);
	}
	

	
	void lightingefecktdolma()
	{
		lightingicon.fillAmount += 1 / 12f;

		if (lightingicon.fillAmount == 1)
		{
			CancelInvoke("lightingefecktdolma");
			skillready[2] = true;
		}
	}
	void lightingultyefecktbitir()
	{
		skills2[2].SetActive(false);
	}
	void lightingultydolma()
	{
		lightingultyicon.fillAmount += 1 / 12f;

		if (lightingultyicon.fillAmount == 1)
		{
			CancelInvoke("lightingultydolma");
			skillready2[2] = true;
		}
	}
	void fireareabitir()
	{
		skills2[0].transform.GetChild(1).gameObject.SetActive(false);
		
	}
	void fireareaultydolma()
	{
		fireareaicon.fillAmount += 1 / 15f;

		if (fireareaicon.fillAmount == 1)
		{
			CancelInvoke("fireareaultydolma");
			skillready2[0] = true;
			skills2[0].transform.GetChild(0).gameObject.SetActive(false);
		}
	}
	void iceultybitir()
	{
		skills2[1].SetActive(false);

	}
	void iceultydolma()
	{
		iceultyicon.fillAmount += 1 / 15f;

		if (iceultyicon.fillAmount == 1)
		{
			CancelInvoke("iceultydolma");
			skillready2[1] = true;
			
		}
	}

}
