using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySoipt : MonoBehaviour
{
    protected Joystick joystick;
    protected Joybutton joybutton;
    protected bool jump;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 10f + Input.GetAxis("Horizontal") * 10f,
                                        rigidbody.velocity.y,
                                        joystick.Vertical * 10f + Input.GetAxis("Vertical") * 10f);
        if (!jump && (joybutton.Pressed || Input.GetButton("Fire3")))
        {
            jump = true;
            rigidbody.velocity += Vector3.up * 3f;
        }
        {
            if (jump && !joybutton.Pressed || Input.GetButton("Fire3"))
            {
                jump = false;
            }
        }
    }

}
