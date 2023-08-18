using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatterbits : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotSpeed,spinTime;
    public bool shouldSpin;

    private Vector3 moveDirection;

    public float deceleration = 6f;

    public float lifetime = 5f;

    public SpriteRenderer theSR;
    public float fadeSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection.x = Random.Range(-moveSpeed, moveSpeed);
        moveDirection.y = Random.Range(-moveSpeed, moveSpeed);
        deceleration = Random.Range(.5f, deceleration);
        moveSpeed = Random.Range(moveSpeed * .5f, moveSpeed);
        spinTime = Random.Range(0f, spinTime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime;

        moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, deceleration * Time.deltaTime);

        if(shouldSpin)
        {
            transform.Rotate (0,0, Random.Range(0, rotSpeed));

            spinTime -= Time.deltaTime;

            if(spinTime <= 0)
            {
                shouldSpin = false;
            }

        }
        lifetime -= Time.deltaTime;

        if(lifetime < 0)
        {
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, Mathf.MoveTowards(theSR.color.a, 0f, fadeSpeed * Time.deltaTime));

            if(theSR.color.a == 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
