using UnityEngine;
using UnityEngine.UI;

public class UIManager_Farm : MonoBehaviour
{
    [SerializeField] GameObject outSideUI;
    [SerializeField] GameObject fieldUI;
    [SerializeField] GameObject houseUI;
    [SerializeField] GameObject animUi;
    [SerializeField] GameObject invenUI;

    [SerializeField] GameObject seedUi;

    [SerializeField] Button seedButton;
    [SerializeField] Button harvestButton;
    [SerializeField] Button[] plantButtons;

    private void Awake()
    {
        seedButton.onClick.AddListener(SeedButton);
        harvestButton.onClick.AddListener(HarvestButton);

        for(int i = 0; i< plantButtons.Length; i++)
        {
            //필드 매니저에서 식물 선택하도록
            int j = i;
            plantButtons[i].onClick.AddListener(() => GameManager.Instance.field.SetPlant(j));
        }

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            invenUI.SetActive(!invenUI.activeSelf);
        }
    }

    void SeedButton()
    {
        GameManager.Instance.field.SetState(FieldManager.FieldState.Seed);
        seedUi.SetActive(true);
    }

    void HarvestButton()
    {
        GameManager.Instance.field.SetState(FieldManager.FieldState.Harvest);
        seedUi.SetActive(false);

    }
    public void ActivateFieldUI(bool isActive)
    {
        fieldUI.SetActive(isActive);
    }
}
