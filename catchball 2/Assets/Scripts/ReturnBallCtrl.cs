using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBallCtrl : MonoBehaviour
{
    [SerializeField] float returnSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = transform.position;
        Vector3 target = new Vector3(0, 0.39f, 0);
        transform.position = Vector3.MoveTowards(current, target, returnSpeed);
    }
}
