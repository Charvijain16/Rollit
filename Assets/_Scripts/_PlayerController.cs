using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class _PlayerController : MonoBehaviour {

	public float speed;
    public Text winText;
    public Text countText;
	private Rigidbody rb;
    private int count;

	
    // Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCountText();
        winText.text = "";
    }

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "SCORE: " + count.ToString();
        if(count>=12)
        {
            winText.text = "YOU WIN!";
        }
    }
}
