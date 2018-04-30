using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Player_Tests : MonoBehaviour {

    public float speed;
    public float rotationSpeed = 0.05f;

    private CharacterController player;
    private int zDir = 1;
    private bool isRotating = false;
    private Quaternion newRotation;
    private float rotationTime = 0f;
    private int directionsetter = 1;
    private bool isSet = false;

    void Start()
    {
        player = GetComponent<CharacterController>();
        newRotation = new Quaternion();
    }

    void FixedUpdate()
    {
        if (isRotating)
        {
            rotationTime += rotationSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationTime);
            if (rotationTime >= 0.3 && !isSet)
            {
                zDir = zDir * directionsetter;
                isSet = true;
            }
            if (rotationTime > 1)
            {
                isRotating = false;
                isSet = false;
                rotationTime = 0;
            }
        }
        float lateral = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); //Récuperation des inputs
        Vector3 mvtForce = new Vector3(lateral * zDir, vertical, zDir); //Force à appliquer au joueur
        mvtForce = transform.InverseTransformDirection(mvtForce); //Permet de mettre le mouvement sur les coordonées locales
        player.Move(mvtForce * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rTrigger"))
        {
            Quaternion rotation = new Quaternion();
            rotation.SetLookRotation(transform.right, transform.up); //Crée une rotation qui tourne vers la droite
            Turn(rotation, -1); // Appelle de la fonction pour tourner
            other.gameObject.SetActive(false); // Désactivation du trigger
        }
    }

    public void Turn(Quaternion rotation, int directionSetter) // Déclenche une rotation du quaternion avec inversion des coordonées si nécessaire
    {
        this.directionsetter = directionSetter;
        newRotation = rotation;
        isRotating = true;
    }
}
