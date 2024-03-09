using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEndUI : MonoBehaviour
{
    [Header("Source")]
    public GameObject titlePrefeb;
    public GameObject InventoryUI;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
