using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    private enum Mode
    {
        LookAt,
        LookAtInverted,
        DirectLine,
        DirectLineInverted
    }
    [SerializeField] private Mode mode;

    private void LateUpdate()
    {
        
        switch (mode)
        {
            case Mode.LookAt:
                {
                    transform.LookAt(Camera.main.transform.position);
                    break;
                }

            case Mode.LookAtInverted:
            {
                    Vector3 dirFromCamera = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + dirFromCamera);
                break;
            }

            case Mode.DirectLine:
                transform.forward = Camera.main.transform.forward;
            break;
            case Mode.DirectLineInverted:
                transform.forward = -Camera.main.transform.forward;

                break;

        }
    }
}
