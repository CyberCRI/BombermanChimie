using UnityEngine;
using System.Collections;

public class PositionneurDeCubes : MonoBehaviour {

	public GameObject cubeHautGauche;
	public GameObject cubeHautDroite;
	public GameObject cubeBasGauche;

	// Use this for initialization
	void Start () {

		Vector3 horizontal = cubeHautDroite.transform.localPosition - cubeHautGauche.transform.localPosition;
		Vector3 vertical = cubeBasGauche.transform.localPosition - cubeHautGauche.transform.localPosition;
		
		for (int i = 1; i <= 5; i++)
		{
			for (int j = 1; j <= 6; j++)
			{
				GameObject nouveauCube = Instantiate(cubeHautGauche) as GameObject;
				nouveauCube.transform.localPosition = nouveauCube.transform.localPosition + (i-1)*vertical + (j-1)*horizontal;
				nouveauCube.transform.parent = gameObject.transform;
			}
		}

		cubeHautGauche.SetActive(false);
		cubeHautDroite.SetActive(false);
		cubeBasGauche.SetActive(false);
	}
}
