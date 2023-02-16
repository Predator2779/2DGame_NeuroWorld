using UnityEngine;
using GlobalVariables;

namespace InputData
{
    public class InputHandler
    {
        static public float GetVerticalAxis()
        {
            return Input.GetAxis(GlobalConstants.VerticalAxis);
        }

        static public float GetHorizontallAxis()
        {
            return Input.GetAxis(GlobalConstants.HorizontalAxis);
        }

        static public Vector2 GetMousePosition()
        {
            return Input.mousePosition;
        }

        static public float GetMousePositionX()
        {
            return Input.GetAxis(GlobalConstants.MouseX) * GlobalConstants.FactorMouseSensitivityX;
        }

        static public float GetMousePositionY()
        {
            return Input.GetAxis(GlobalConstants.MouseY) * GlobalConstants.FactorMouseSensitivityY;
        }

        static public bool GetKeyE()
        {
            return Input.GetKey(KeyCode.E);
        }
        
        static public bool GetLMB()
        {
            return Input.GetMouseButtonDown(0);
        } 
        
        static public bool GetRMB()
        {
            return Input.GetMouseButtonDown(1);
        }  
        
        static public bool GetMMB()
        {
            return Input.GetMouseButtonDown(2);
        }
    }
}