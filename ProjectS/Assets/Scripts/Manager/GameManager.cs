using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private DialogManager dialogManager;
    [SerializeField] private DayNightManager dayNightManager;
    
    public DayNightManager DayNightManager => dayNightManager;
    public QuestManager QuestManager => questManager;
    public DialogManager DialogManager => dialogManager;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        
    }

    private void Start() {
        dialogManager.HideUI();
    }

    public void SetActiveNPC(NPC npc)
    {
        if(npc == null)
        {
            dialogManager.HideUI();
            return;
        }
        dialogManager.ShowUI();
        dialogManager.StartDialog(npc);
    }
    
    
}
