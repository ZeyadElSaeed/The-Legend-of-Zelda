using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StasisObjectSpawner : MonoBehaviour
{

    [SerializeField] GameObject StasisBall;
    private GameObject CurrentStasisObject;
    // Start is called before the first frame update
    void Start()
    {
        CurrentStasisObject = Instantiate(StasisBall, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentStasisObject == null)
        {
            CurrentStasisObject = Instantiate(StasisBall, transform.position, Quaternion.identity);
        }

        if (CurrentStasisObject.transform.position.y <= -6)
        {
            Destroy(CurrentStasisObject);
        }
    }
}
