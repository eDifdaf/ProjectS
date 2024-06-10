using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private DialogManager dialogManager;
    [SerializeField] private DayNightManager dayNightManager;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private Playermanager playermanager;
    public GameObject player;

    public DayNightManager DayNightManager => dayNightManager;
    public QuestManager QuestManager => questManager;
    public DialogManager DialogManager => dialogManager;
    public SaveManager SaveManager => saveManager;
    public Playermanager Playermanager => playermanager;

    void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    private void Start(){
        dialogManager.HideUI();
        saveManager.LoadGame();
    }

    public void SetActiveNPC(NPC npc){
        if (npc == null){
            DayNightManager.ResumeTime();
            return;
        }

        DayNightManager.PauseTime();
        dialogManager.ShowUI();
        dialogManager.StartDialog(npc);
    }
}