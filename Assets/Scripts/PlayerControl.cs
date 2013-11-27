using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;

	public float moveForce = 365f;
	public float maxSpeed = 3f;

	private float rndWait = 1f;
	private Animator anim;

	void Awake () 
	{
		anim = GetComponent<Animator> ();
	}

	void Start() 
	{
		StartCoroutine (GiveRandomWait());
	}
	
	void Update () 
	{

		if (Input.GetButton("Sprint")) {
			maxSpeed = 10f;
			anim.SetInteger("Run", 1);
		} else {
			maxSpeed = 3f;
			anim.SetInteger("Run", 0);
		}
		float h = Input.GetAxis ("Horizontal");
		if (Mathf.Abs(h) == 0) {
			anim.SetInteger("Wait", (int) rndWait);
		}

		anim.SetFloat ("Speed", Mathf.Abs (h));
		if ( h * rigidbody2D.velocity.x < maxSpeed ) {
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		}

		if ( Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed ) {
			rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		}
		if (h > 0 && !facingRight) {
				Flip ();
		} else if (h < 0 && facingRight) {
				Flip ();
		}

	}

	void Flip() 
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	IEnumerator GiveRandomWait()
	{
		while(true)
		{
			rndWait = Random.Range (1, 3);
			yield return new WaitForSeconds(10);
		}
	}
}
