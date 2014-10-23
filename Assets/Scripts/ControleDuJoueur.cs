using UnityEngine;
using System.Collections;

public class ControleDuJoueur : MonoBehaviour {

	private Vector3 _inputMovement;
	public float absoluteMultiplier;
	
	// Update is called once per frame
	void Update () {
		_inputMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);		
		//Vector3 moveAmount = _inputMovement * currentMoveSpeed;		
		//this.rigidbody2D.AddForce(moveAmount);

		this.transform.localPosition += binariserVecteur(_inputMovement)*absoluteMultiplier;
	}



	Vector3 binariserVecteur(Vector3 vector)
	{
      return new Vector3(binariser(vector.x), binariser(vector.y), 0);
	}

	float seuil = 0f;
	float binariser(float f)
	{
      if(Mathf.Abs(f) - seuil > 0)
		{
			return Mathf.Sign(f);
		}
		else
		{
			return 0;
		}
	}
}
