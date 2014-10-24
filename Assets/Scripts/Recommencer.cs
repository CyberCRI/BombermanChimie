using UnityEngine;
using System.Collections;

public class Recommencer : MonoBehaviour {

	public GameObject joueur1;
	public GameObject joueur2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
		{
			joueur1.SetActive(true);
			joueur2.SetActive(true);
		}
	}
}
