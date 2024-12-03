using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    private VisualElement m_Healthbar;
    public static UIHandler instance { get; private set; }

    // Breytur fyrir samræðu-glugga í UI
    public float displayTime = 4.0f;
    private VisualElement m_NonPlayerDialogue;
    private float m_TimerDisplay;

    // Keyrt þegar leikjasenan hleðst inn
    private void Awake()
    {
        instance = this; // Stillir þessa stýringarklasa sem aðgengilega öðrum
    }

    // Keyrt í byrjun leiksins
    private void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f); // Stillir byrjunarheilsu sem 100%

        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        m_NonPlayerDialogue.style.display = DisplayStyle.None; // Felur samræðu-gluggann í upphafi
        m_TimerDisplay = -1.0f; // Stillir tímara
    }

    // Keyrt á hverjum ramma
    private void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime; // Lækkar tímara
            if (m_TimerDisplay < 0)
            {
                m_NonPlayerDialogue.style.display = DisplayStyle.None; // Felur samræðu-gluggann þegar tíminn rennur út
            }
        }
    }

    // Breytir stærð á heilsustikunni í UI
    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    // Sýnir samræðu-glugga og stillir tímara
    public void DisplayDialogue()
    {
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex; // Sýnir samræðu-gluggann
        m_TimerDisplay = displayTime; // Endurstillir tímara
    }
}
