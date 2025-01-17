using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text targetText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image portrait;

    private DialogueContainer currentDialogue;
    private int currentTextLine;
    private InputAction _interact;

    [Range(0f, 1f)]
    [SerializeField] private float visibleTextPercent;
    [SerializeField] private float timePerLetter = 0.05f;
    private float totalTimeToType, currentTime;
    private string lineToShow;
    

    private void Awake()
    {
        _interact = InputSystem.actions.FindAction("Interact");
    }
    
    private void Start()
    {
        _interact.Enable();
    }

    private void OnEnable()
    {
        _interact.Enable();
    }

    private void OnDisable()
    {
        _interact.Disable();
    }

    private void Update()
    {
        if (_interact.triggered)
        {
            PushText();
            
        }

        TypeOutText();
    }

    private void TypeOutText()
    {
        if (visibleTextPercent >= 1f) { return; }
        currentTime += Time.deltaTime;
        visibleTextPercent = currentTime / totalTimeToType;
        visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0, 1f);
        UpdateText();
    }

    private void UpdateText()
    {
        int letterCount = (int)(lineToShow.Length * visibleTextPercent);
        targetText.text = lineToShow.Substring(0, letterCount);
    }

    public void PushText()
    {
        if (visibleTextPercent < 1f)
        {
            visibleTextPercent = 1f;
            UpdateText();
            return;
        }
        
        
        if (currentTextLine >= currentDialogue.line.Count)
        {
            Conclude();
        }
        else
        {
            Cycleline();
        }
    }

    private void Cycleline()
    {
        lineToShow = currentDialogue.line[currentTextLine];
        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibleTextPercent = 0f;
        targetText.text = "";
        
        currentTextLine += 1;
    }

    public void Initialize(DialogueContainer dialogueContainer)
    {
        Show(true);
        currentDialogue = dialogueContainer;
        currentTextLine = 0;
        Cycleline();
        UpdatePortrait();
    }

    private void UpdatePortrait()
    {
        portrait.sprite = currentDialogue.actor.portrait;
        nameText.text = currentDialogue.actor.name;
    }

    private void Show(bool v)
    {
        gameObject.SetActive(v);
    }

    private void Conclude()
    {
        Debug.Log("Ending the text");
        Show(false);
    }
}
