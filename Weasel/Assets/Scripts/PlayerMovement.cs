using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public enum Direction { RIGHT, LEFT };
    public float accelerationX;
    public float maxSpd;
    private Direction movingDir = Direction.RIGHT;

    // Use this for initialization
    void Start ()
    {
        //movingDir = Direction.RIGHT;
        //accelerationX = 5.0f;
        //maxSpd = 5.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Reverse"))
        {
            Reverse();
        }
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        Vector3 vv = body.velocity;
        vv.x += accelerationX;
        vv.x = NormaliseSpd(vv.x);
        body.velocity = vv;
    }

    void Reverse()
    {
        accelerationX *= -1;
        switch(movingDir)
        {
            case Direction.RIGHT: movingDir = Direction.LEFT; break;
            case Direction.LEFT: movingDir = Direction.RIGHT; break;
        }
    }

    float NormaliseSpd(float spd)
    {
        return Mathf.Max(-maxSpd, Mathf.Min(maxSpd, spd));
    }

}
