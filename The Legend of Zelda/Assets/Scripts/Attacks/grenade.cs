using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public float delay = 0.5f;
    public float radius = 5f;
    public float explosionForce = 700f;
    float countdown;
    bool hasExploded = false; 

    public GameObject explosionEffect;
    public KeyCode detonateKey = KeyCode.G;


    public AudioSource ExplosionAudio;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<GameManagerBridge>().paused() && Time.timeScale!=0){
            countdown -=Time.deltaTime;
            if(!hasExploded && Input.GetKeyDown(detonateKey) && countdown<=0){
                Explode();
                hasExploded = true;
                
            }
        }
    }
    void Explode() {
        GameObject currentExplosion = Instantiate(explosionEffect,transform.position,transform.rotation);
        Destroy(gameObject);
        Collider [] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider bombed in colliders){
            if(bombed.CompareTag("Fragile")){
                Destroy(bombed);
            }
            else{
                if(bombed.CompareTag("Bokoblin") || bombed.CompareTag("Moblin") || bombed.CompareTag("MawJLaygo")){
                    if (bombed.CompareTag("MawJLaygo"))
                    {
                        Fire fire = bombed.GetComponent<Fire>();
                        fire.TakeDamage(10);
                    }
                    else
                    {
                        Enemy enemy = bombed.GetComponent<Enemy>();
                        enemy.TakeDamage(10);
                    }
                }
                else{
                    Rigidbody rb = bombed.GetComponent<Rigidbody>();
                    if(rb!=null){
                        rb.AddExplosionForce(explosionForce,transform.position, radius);
                    }
                }
            }
        }
        Destroy(currentExplosion, 1.5f);
    }
}
