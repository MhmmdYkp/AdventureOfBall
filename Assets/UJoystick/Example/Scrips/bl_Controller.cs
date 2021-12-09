using UnityEngine;

public class bl_Controller : MonoBehaviour {


	[SerializeField]private bl_Joystick Joystick;//Joystick reference for assign in inspector

    [SerializeField]public float Speed = 3;

    public Rigidbody fizik;

    private void Start()
    {
        fizik = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {


        float yatay = Joystick.Horizontal;
        float dikey = Joystick.Vertical;

        Vector3 vec = new Vector3(yatay, 0, dikey) *Speed;

        fizik.AddForce(vec * Speed);
    }
}