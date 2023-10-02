using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int Health = 1;
    public Transform Target;
    public bool Gametrue=true;

    public int Score = 100;

    public float RoatationSpeed = 0.010f;
    public float speed = 3;

    private Rigidbody2D RB;

    [Header("Изминение цвета")]
    public float currentTime = 0;
    public Renderer R;
    public Material Mat;

    public bool inDetector = false;
    public bool ChangeColor = false;


    public float duration = 3;


    void Start()
    {
        RB= GetComponent<Rigidbody2D>();
        //R=GetComponent<Renderer>();
        Mat = R.material;
        Gametrue = true;
        GetTarget();
    }


    void Update()
    {
        if (!Gametrue) return;

        if (!Target)
        {
            return;
            //GetTarget();
        }
        else
        {
            RotatedTarget();
        };


        if (inDetector) 
        {
            Color c = Mat.color;
            c.a = 1;
            Mat.color = c;
            currentTime = 0;
        }
        else
        {
            
                currentTime += Time.deltaTime;
                float alpha = 1.0f - currentTime / duration;
                //print(alpha);
                Color color = Mat.color;
                color.a = alpha;
                Mat.color = color;
            
        }

    }
    private void FixedUpdate()
    {
        RB.velocity = transform.up * speed;
    }
    private void GetTarget()
    {

        Target = GameObject.FindGameObjectWithTag("Player").transform;


    }

    private void RotatedTarget()
    {
        Vector2 targetDirection = Target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, RoatationSpeed);
    }
    public void takeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0) {
            Health = 0;
            GameManager.S.AddScore(Score);
            Destroy(gameObject);
            creating_a_tower.S.addTowerForEnemy();
            GameManager.S.DeliteEnemy();
            //SpawnEnemy.S.SpawnGameEnemy();
        }
    }

    public void ShowMaterial()
    {
        if (ChangeColor ==true) ChangeColor = false;
        //Debug.LogError("showmat");
        Color c = Mat.color;
        c.a = 1f;
        Mat.color = c;
    }
    public void StelsMaterial()
    {
        //if (inDetector) return;
        //ChangeColor = true;
    }
}
