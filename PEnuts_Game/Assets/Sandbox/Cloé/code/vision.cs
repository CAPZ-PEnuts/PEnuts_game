using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vision : MonoBehaviour {

	public GameObject player;       // Variable publique pour stocker la référence vers l'objet du joueur


	private Vector3 offset;         // Variable privée pour stocker le décalage entre le joueur et la caméra

	// Initialisation
	void Start () 
	{
		// Calcul et stocke le décalage entre le joueur et la caméra
		offset = transform.position - player.transform.position;
	}
    
	// La fonction LateUpdate() est appelée après la fonction Update() à chaque image
	void LateUpdate () 
	{
		// Définit la position de la caméra avec celle du joueur tout en ajoutant un décalage.
		transform.position = player.transform.position + offset;
	}
}
