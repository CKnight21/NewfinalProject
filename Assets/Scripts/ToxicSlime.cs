using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicSlime : MonoBehaviour
{
    public GameObject explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 particleSpawnPoint = other.transform.position;
        Instantiate(explosionEffect, particleSpawnPoint, Quaternion.identity);
        //Quaternion.identity = no rotation

        Destroy(other.gameObject);
        //Destroy()is the base function for destorying components and objects in a secne.
        //You need to specify that you are reffering to a game object.
        //Destory(this), for instance, will destory the component, not the object.
        //Destiry(the.gameObeject) will destory the object where this compent is.
        Destroy(other.gameObject);
    }
}
