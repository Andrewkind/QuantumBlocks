using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public Vector3 eulerAngleVelocity;

	public float speed;
	public Text countText;
	public Text winText;

	private float jumpEnergy;
	private Rigidbody rb;
	private int count;
	float moveHorizontal;
	float moveVertical;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetText();
		//winText.text = "";
		jumpEnergy = 0;
	}

	void FixedUpdate ()
	{
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
		float x = moveVertical * 0.01f;
		Vector3 movement = new Vector3 (0,jumpEnergy, moveVertical);
		rb.AddForce (movement * speed);
		float y = moveHorizontal * 0.1f;

		rb.AddTorque(transform.up * y);
		//rb.AddTorque(transform.right * x);
		if (Input.GetKey (KeyCode.Space)) {
			jumpEnergy += 0.09f;
		} 
		else {
			jumpEnergy -= 0.09f;
		}

		if (jumpEnergy < 0) {
			jumpEnergy = 0;
		}
		if (jumpEnergy > 3f) {
			jumpEnergy = 2f;
		}
		SetText();

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetText ();
		}
	}

	void SetText ()
	{
		countText.text = "jumpEnergy: " + jumpEnergy.ToString () + " moveHoriz: " + moveHorizontal.ToString () + " moveVert: " + moveVertical.ToString ();
		{
			//winText.text = "You Win!";
		}
	}
		
}