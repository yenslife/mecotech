using UnityEngine;
using UnityEngine.UI;
public class CharacterSwitcher : MonoBehaviour
{

    public GameObject maleCharacter;
    public GameObject femaleCharacter;
    public Button switchButton;
    private bool isMale = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switchButton.onClick.AddListener(SwitchCharacter);
    }

    void SwitchCharacter()
    {
        if (maleCharacter.activeSelf)
        {
            maleCharacter.SetActive(false);
            femaleCharacter.SetActive(true);
        }
        else
        {
            maleCharacter.SetActive(true);
            femaleCharacter.SetActive(false);
        }
    }
}
