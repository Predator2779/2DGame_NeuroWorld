using UnityEngine;
using GlobalVars;

public class InputHandler : MonoBehaviour
{
    public float GetVerticalAxis()
    {
        return Input.GetAxis(GlobalVariables.VerticalAxis);
    } 
    
    public float GetHorizontallAxis()
    {
        return Input.GetAxis(GlobalVariables.HorizontalAxis);
    }

    public Vector2 GetMousePosition()
    {
        return Input.mousePosition;
    }

    public float GetMousePositionX()
    {
        return Input.GetAxis(GlobalVariables.MouseX) * GlobalVariables.FactorMouseSensitivityX;
    }

    public float GetMousePositionY()
    {
        return Input.GetAxis(GlobalVariables.MouseY) * GlobalVariables.FactorMouseSensitivityY;
    } 
    
    public bool GetE()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}