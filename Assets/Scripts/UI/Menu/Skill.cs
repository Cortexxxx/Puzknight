using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill : MonoBehaviour
{
    [SerializeField] private string skillNameInSaves = "Skill";
    [SerializeField] private Button skillUpgradeButton;
    [SerializeField] private TextMeshProUGUI skillText;
    [SerializeField] private int maxLevels = 10;
    private void OnEnable() {
        if(PlayerPrefs.GetInt(skillNameInSaves) == 0) {
            PlayerPrefs.SetInt(skillNameInSaves, 1);
        }
        Refresh();
        skillUpgradeButton.onClick.RemoveAllListeners();
        skillUpgradeButton.onClick.AddListener(GetComponentInParent<AudioSource>().Play);
        skillUpgradeButton.onClick.AddListener(Upgrade);
    }
    public void Upgrade() {
        if (PlayerPrefs.GetInt("skillPoints") > 0 && PlayerPrefs.GetInt(skillNameInSaves) < maxLevels) {
            PlayerPrefs.SetInt(skillNameInSaves, PlayerPrefs.GetInt(skillNameInSaves) + 1);
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
            Refresh();
        } else {
            Debug.Log("Не хватает очков!");
        }

    }
    private void Refresh() {
        skillText.text = "Уровень: " + PlayerPrefs.GetInt(skillNameInSaves);
    }
    
}
