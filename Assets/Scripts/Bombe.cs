using UnityEngine;
using System.Collections;

public class Bombe : MonoBehaviour {

	public float dureeAvantDetonation;
	public GameObject explosionModele;
	
	// Update is called once per frame
	void Update () {		
		if(dureeAvantDetonation <= 0)
		{
			GameObject explosion = Instantiate(explosionModele) as GameObject;
			explosion.transform.parent = transform.parent;
			explosion.transform.localPosition = transform.localPosition;
			Destroy (gameObject);
		}
		else
		{
			dureeAvantDetonation = dureeAvantDetonation - Time.deltaTime;
		}
	}
}
