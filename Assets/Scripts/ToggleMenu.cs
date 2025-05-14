using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject sounds;

    public void ToggleSoundMenu()
    {
        sounds.SetActive(!sounds.activeSelf);
    }
}
