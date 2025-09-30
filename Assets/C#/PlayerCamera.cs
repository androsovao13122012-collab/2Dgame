using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    Transform trP;
    Transform trC;
    private void Awake()
    {
        trC = transform;
        trP = FindObjectOfType<PlayerController>().transform;
    }
    private void LateUpdate()
    {
        MoveCamera();
    }
    private void MoveCamera()
    {

        trC.position = new Vector3 (trP.position.x, trP.position.y, -10);
    }
}
