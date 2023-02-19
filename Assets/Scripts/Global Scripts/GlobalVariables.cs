using UnityEngine;

namespace GlobalVariables
{
    public class GlobalConstants
    {
        #region String Constants

        public const string HorizontalAxis = "Horizontal";
        public const string VerticalAxis = "Vertical";
        public const string JumpButton = "Jump";

        public const string LeftMouseButton = "Fire1";
        public const string MiddleMouseButton = "Fire3";
        public const string RightMouseButton = "Fire2";

        public const string MouseX = "Mouse X";
        public const string MouseY = "Mouse Y";

        public const string MouseScrollWheel = "Mouse ScrollWheel";

        #endregion

        #region Int Constants

        public const int MinHitPoints = 0;
        public const int HorizontalOffsetInfo = 15;
        public const int VerticalOffsetInfo = 15;

        #endregion

        #region Float Constants

        public const float CoefMovementSpeed = 10f;
        public const float CoefMouseSensitivityX = 2f;
        public const float CoefMouseSensitivityY = 0.3f;
        public const float CoefShotRollback = 0.04f;
        public const float BulletForce = 10f;
        public const float MinRangeDamage = 0.65f;
        public const float MaxRangeDamage = 2.01f;

        #endregion

        #region Position

        public static Vector2 WeaponPosition = new Vector2(0.65f, 0.25f);
        public static Vector2 ZeroRotation = new Vector2(0, 0);

        #endregion
    }
}