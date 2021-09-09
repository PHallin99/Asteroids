using UnityEngine;

public class WrappingBox : MonoBehaviour
{
    private bool isWrappingX;
    private bool isWrappingY;

    private void Update()
    {
        ScreenWrap();
    }

    private void ScreenWrap()
    {
        var isVisible = CheckRenderers();

        if (isVisible)
        {
            isWrappingX = false;
            isWrappingY = false;
            return;
        }

        if (isWrappingX && isWrappingY) return;

        Vector2 newPosition = transform.position;

        if (newPosition.x > 6.66f || newPosition.x < -6.66f)
        {
            newPosition.x = -newPosition.x;
            isWrappingX = true;
        }

        if (newPosition.y > -5 || newPosition.y < 5)
        {
            newPosition.y = -newPosition.y;
            isWrappingX = true;
        }

        transform.position = newPosition;
    }

    private bool CheckRenderers()
    {
        var position = transform.position;
        if (!(position.x < 6.66f) || !(position.x > -6.66f)) return false;
        return position.y > -5 && position.y < 5;
    }
}