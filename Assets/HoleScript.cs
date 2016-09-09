using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HoleScript : MonoBehaviour {

	public Text scoreText;
	int score;

	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();
		score = 0;
		SetScoreText ();
	}
	
	// Update is called once per frame
	void Update () {
		//text.text = "Score: " + score.ToString();
		SetScoreText();
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "RollerBall")
		{
			//Destroy(col.gameObject);
			//col.gameObject.SetActive(false);
			col.transform.position = new Vector3 (299.2f, 21.2f, 137f);
			score = score + 1;
		}
	}

	void SetScoreText() {
		scoreText.text = "Score: " + score.ToString();

	}

}
