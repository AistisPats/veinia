using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject OldMan;
    public GameObject Bat;
    public bool Spawn;
    public Transform SpawnLocation;
    public PlayerHealth ph;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("wazap");
        if(collision.CompareTag("Player"))
        {
            if(Spawn)
            {
                GameObject a = Instantiate(OldMan, SpawnLocation.position, OldMan.transform.rotation);
                a.GetComponent<OldManController>().Health = ph;
            }
            else
            {
                GameObject a = Instantiate(Bat, SpawnLocation.position, Bat.transform.rotation);
                a.GetComponent<BatController>().Health = ph;
            }
        }
    }
}
