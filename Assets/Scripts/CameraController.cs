using UnityEngine;
using UnityEngine.UI;

public class CameraOrbitController : MonoBehaviour
{
    public Transform character;  // 角色的 Transform
    public Transform cameraPivot; // Camera 的旋轉中心
    public Camera mainCamera;
    public Slider rotationSlider; // UI Slider 控制旋轉
    public float distance; // Camera 與角色的距離
    public float height; // Camera 高度

    void Start()
    {
        // 設定初始位置
        rotationSlider.onValueChanged.AddListener(UpdateCameraPosition);
        UpdateCameraPosition(rotationSlider.value);
        height = 1.5f; // 如果想要在 Unity 中設定，請註解掉之後再到 Inspector 中設定
        distance = 4.5f; // 如果想要在 Unity 中設定，請註解掉之後再到 Inspector 中設定
    }

    void UpdateCameraPosition(float angle)
    {
        Vector3 characterPosition;

        characterPosition = character.position; // 預設使用 Transform.position

        float radians = angle * Mathf.Deg2Rad;
        float x = characterPosition.x + distance * Mathf.Cos(radians);
        float z = characterPosition.z + distance * Mathf.Sin(radians);

        cameraPivot.position = new Vector3(x, characterPosition.y + height, z);
        print(cameraPivot.position);
        Vector3 adjustedCharacterPosition = new Vector3(characterPosition.x, characterPosition.y - 0.5f, characterPosition.z);
        cameraPivot.LookAt(adjustedCharacterPosition);
    }
}
