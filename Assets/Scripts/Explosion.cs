using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float dureeAvantDisparition;
	
	// Update is called once per frame
	void Update () {		
		if(dureeAvantDisparition <= 0)
		{
			Destroy (gameObject);
		}
		else
		{
			dureeAvantDisparition = dureeAvantDisparition - Time.deltaTime;
		}
	}


	void OnParticleCollision(GameObject obj){
		ControleDuJoueur joueur = obj.GetComponent<ControleDuJoueur>();
		if(joueur){
			Rigidbody body = joueur.rigidbody;
			if (body){
				//Vector3 push = obj.transform.localPosition - this.transform.localPosition;
				//body.AddForce((new Vector3(push.x, push.y, 0) * 100f));
				//Destroy(obj);
				obj.SetActive(false);
			}
		}
	}
}
