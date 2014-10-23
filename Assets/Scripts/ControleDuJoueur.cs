using UnityEngine;
using System.Collections;

public class ControleDuJoueur : MonoBehaviour {

	public float absoluteMultiplier;
	public int numeroJoueur;
	public GameObject bombeModele;
	public int reserveDeBombes;
	public int reserveDeBombesMax;
	public float tempsPose;
	public float tempsCreation;

	private Vector3 _inputMovement;
	private string nomControleHorizontal;
	private string nomControleVertical;
	private KeyCode toucheBombe;
	private float tempsDepuisPose;
	private float tempsDepuisCreation;

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

		tempsDepuisPose = Mathf.Infinity;
		tempsDepuisCreation = Mathf.Infinity;
	}
	
	// Update is called once per frame
	void Update () {
		_inputMovement = new Vector3(Input.GetAxis(nomControleHorizontal), Input.GetAxis(nomControleVertical), 0);		
		//Vector3 moveAmount = _inputMovement * currentMoveSpeed;		
		//this.rigidbody2D.AddForce(moveAmount);

		this.transform.localPosition += binariserVecteur(_inputMovement)*absoluteMultiplier;

		if(reserveDeBombes > 0 && Input.GetKey(toucheBombe) && (tempsDepuisPose > tempsPose))
		{
			GameObject bombe = Instantiate(bombeModele) as GameObject;
			bombe.transform.localPosition = gameObject.transform.localPosition;
			tempsDepuisPose = 0;
			reserveDeBombes--;
		}
		else
		{
			tempsDepuisPose = tempsDepuisPose + Time.deltaTime;
		}
		
		if(reserveDeBombesMax > reserveDeBombes && tempsDepuisCreation > tempsCreation)
		{
			//Creation
			tempsDepuisCreation = 0;
			reserveDeBombes++;
		}
		else
		{
			tempsDepuisCreation = tempsDepuisCreation + Time.deltaTime;
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
