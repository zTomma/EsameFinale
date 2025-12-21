using UnityEngine;

public class ResetBalls : MonoBehaviour
{
    public Transform[] balls;

    Vector3[] startPos;
    Quaternion[] startRot;
    Rigidbody[] rbs;

    void Awake()
    {
        int count = balls.Length;

        startPos = new Vector3[count];
        startRot = new Quaternion[count];
        rbs = new Rigidbody[count];

        for (int i = 0; i < count; i++)
        {
            startPos[i] = balls[i].position;
            startRot[i] = balls[i].rotation;
            rbs[i] = balls[i].GetComponent<Rigidbody>();
        }
    }

    public void ResetAllBalls()
    {
        Debug.Log("RESET BALLS");

        for (int i = 0; i < balls.Length; i++)
        {
            if (rbs[i] != null)
            {
                // ferma la fisica
                rbs[i].linearVelocity = Vector3.zero;
                rbs[i].angularVelocity = Vector3.zero;
                rbs[i].Sleep();
            }

            balls[i].SetPositionAndRotation(startPos[i], startRot[i]);

            if (rbs[i] != null)
                rbs[i].WakeUp();
        }
    }
}