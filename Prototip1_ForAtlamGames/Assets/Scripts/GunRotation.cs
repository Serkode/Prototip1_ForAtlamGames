using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Vector2 turn;


    public GameObject aimObject;


    void Update()
    {
        MouseMove();
    }


    public void MouseMove()
    {
        if (Input.GetMouseButton(0))
        {
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            transform.localRotation = Quaternion.Euler(Mathf.Clamp(-turn.y, -20f, 10f), Mathf.Clamp(turn.x, -30f, 30f), 0).normalized;

            if (turn.x <= -30)
            {
                turn.x = -30;
            }
            else if (turn.x >= 30)
            {
                turn.x = 30;
            }
            if (turn.y <= -10)
            {
                turn.y = -10;
            }
            else if (turn.y >= 20)
            {
                turn.y = 20;
            }
        }
    }
}
