using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet; 
    public Transform spawnPoint; 
    public float bulletSpeed; 

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>(); 
        grabbable.activated.AddListener(FireBullet); 
    }

    void Update()
    {
        // No need to update every frame unless additional functionality is added here
    }

    public void FireBullet(ActivateEventArgs arg) 
    {
        GameObject spawnedBullet = Instantiate(bullet); 
        spawnedBullet.transform.position = spawnPoint.position; 
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed; 
        Destroy(spawnedBullet, 5); 
    }
}
