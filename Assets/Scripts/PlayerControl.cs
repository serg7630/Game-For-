using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float _rotateSpeed;

    private Vector2 directions;
    public Vector2 MousPos;

    [SerializeField] Camera cam;
    [SerializeField] private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        directions.x = Input.GetAxisRaw("Horizontal");
        directions.y = Input.GetAxisRaw("Vertical");
        MousPos=cam.ScreenToWorldPoint(Input.mousePosition);
        //print(RB.velocity.magnitude);

    }

   
    private void FixedUpdate()
    {
        RB.MovePosition(RB.position + directions * speed * Time.deltaTime);

        Vector2 loocPos = MousPos - RB.position;

        float angle = Mathf.Atan2(loocPos.y,loocPos.x)*Mathf.Rad2Deg-90f;
        RB.rotation = angle;
        
        //rotationDirection();
    }
    
    
    //private void rotationDirection()
    //{

        
    //        Quaternion targetRotation=Quaternion.LookRotation(transform.forward, directions);
    //        Quaternion LookRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
    //        RB.MoveRotation(LookRotation);
        
    //}
}
