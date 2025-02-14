using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 向右移動
        // transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        // 使用 上下左右按鍵 來移動
        // transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime;

        // 使用 W A S D 來移動
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime;

    }
}
