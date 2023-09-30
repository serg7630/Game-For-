using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    public Transform targetPlayer;

    public float moveSpeed;
    void Start()
    {
        this.transform.position = new Vector3()
        {
            x = this.targetPlayer.position.x,
            y = this.targetPlayer.position.y,
            z = this.targetPlayer.position.z - 10
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FixedUpdate()
    {
        if (this.targetPlayer)
        {
            Vector3 target = new Vector3()
            {
                x = this.targetPlayer.position.x,
                y = this.targetPlayer.position.y,
                z = this.targetPlayer.position.z - 10
            };
            Vector3 pos = Vector3.Lerp(this.transform.position, target, this.moveSpeed * Time.deltaTime);
            this.transform.position = pos;
        }
    }
}
