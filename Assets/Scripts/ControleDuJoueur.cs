using UnityEngine;
using System.Collections;

public class ControleDuJoueur : MonoBehaviour {

	public float absoluteMultiplier;
	public int numeroJoueur;
	public GameObject bombeModele;
	public int reserveDeBombes;

	private Vector3 _inputMovement;
	private string nomControleHorizontal;
	private string nomControleVertical;
	private KeyCode toucheBombe;

	void Start()
	{
		nomControleHorizontal = "Horizontal"+numeroJoueur;
		nomControleVertical = "Vertical"+numeroJoueur;

		if(numeroJoueur == 1)
		{
			toucheBombe = KeyCode.RightShift;
		}
		else
		{
			toucheBombe = KeyCode.LeftShift;
		}
	}
	
	// Update is called once per frame
	void Update () {
		_inputMovement = new Vector3(Input.GetAxis(nomControleHorizontal), Input.GetAxis(nomControleVertical), 0);		
		//Vector3 moveAmount = _inputMovement * currentMoveSpeed;		
		//this.rigidbody2D.AddForce(moveAmount);

		this.transform.localPosition += binariserVecteur(_inputMovement)*absoluteMultiplier;

		if(reserveDeBombes > 0 && Input.GetKey(toucheBombe))
		{
			GameObject bombe = Instantiate(bombeModele) as GameObject;
			bombe.transform.localPosition = gameObject.transform.localPosition;
			reserveDeBombes--;
		}
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
