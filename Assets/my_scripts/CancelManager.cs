using UnityEngine;

public class CancelManager : MonoBehaviour
{
    public GameObject menuPanel;

    public void CloseMenu()
    {
        menuPanel.SetActive(false); // يخفي القائمة
    }
}
