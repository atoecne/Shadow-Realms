using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform mainCam;
    public Transform midBg;
    public Transform sideBg;
    public float lenght;

    void Update()
    {
        if (mainCam.position.x > midBg.position.x)
        {
            UpdateBackgroundPosition(Vector3.right);
        }
        else if (mainCam.position.x < midBg.position.x)
        {
            UpdateBackgroundPosition(Vector3.left);
        }

        Debug.Log("Cinemachine Camera Position: " + Camera.main.transform.position);
    }

    void UpdateBackgroundPosition(Vector3 direction)
    {
        sideBg.position = midBg.position + direction * lenght;
        Transform temp = midBg;
        midBg = sideBg;
        sideBg = temp;
    }
}
