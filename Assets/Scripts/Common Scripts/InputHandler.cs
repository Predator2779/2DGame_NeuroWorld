using UnityEngine;
using GlobalVars;

namespace InputData
{
    public class InputHandler
    {
        static public float GetVerticalAxis()
        {
            return Input.GetAxis(GlobalVariables.VerticalAxis);
        }

        static public float GetHorizontallAxis()
        {
            return Input.GetAxis(GlobalVariables.HorizontalAxis);
        }

        static public Vector2 GetMousePosition()
        {
            return Input.mousePosition;
        }

        static public float GetMousePositionX()
        {
            return Input.GetAxis(GlobalVariables.MouseX) * GlobalVariables.FactorMouseSensitivityX;
        }

        static public float GetMousePositionY()
        {
            return Input.GetAxis(GlobalVariables.MouseY) * GlobalVariables.FactorMouseSensitivityY;
        }

        static public bool GetE()
        {
            return Input.GetKeyDown(KeyCode.E);
        }
    }
}