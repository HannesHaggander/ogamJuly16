using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour {

    private Renderer rend = null;
    float x, y;
    public float speed = 1;

    void Start()
    {
        rend = GetComponent<Renderer>();
        speed = GetCameraTargetSpeed();
    }

    void FixedUpdate()
    {
        x = transform.parent.position.x * Time.deltaTime * -1 * speed;
        y = transform.parent.position.y * Time.deltaTime * -1 * speed;
        Vector2 cameraMoveVector = new Vector2(x, y);
        rend.material.mainTextureOffset = cameraMoveVector;
    }

    float GetCameraTargetSpeed()
    {
        float tmp = 1;
        CameraBehaviour CB = transform.parent.GetComponent<CameraBehaviour>();
        if (CB)
        {
            Transform targetTransform = CB.GetCameraTarget();
            if (targetTransform)
            {
                Movement movement = targetTransform.root.GetComponent<Movement>();
                if (movement)
                {
                    tmp = movement.GetShipSpeed();
                    tmp /= 10;
                    return tmp;
                }
            }
        }
        Debug.Log("Could not find ship speed in parallax scrolling");
        return 1;
    }
}
