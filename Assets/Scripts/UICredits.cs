using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item
{
    public string name;
    public string description;
}

public class UICredits : MonoBehaviour
{
    
    private List<Item> items = new List<Item>();

    [SerializeField] private TextMeshProUGUI creditsText;
    [SerializeField] private RectTransform creditsPanel;
    [SerializeField] private GameObject panelElement;
    [SerializeField] private SoundManager _soundManager = null;
    

    private float totalHeight;

    [SerializeField] private float speed = 60f;

    private bool showCredit = false;

    void Start()
    {
        items.Add(new Item { name = "ART", description = "" });
        items.Add(new Item { name = "3D Modeling", description = "Ana Belén Rodríguez Candanoza \n Porfirio Juan Ignacio Partida Ibarra \n Jesus Eduardo Ramirez Guevara \n Martin Williams Lara" });
        items.Add(new Item { name = "Rigging", description = "Roberto de Jesús Barraza Mendoza \n Porfirio Juan Ignacio Partida Ibarra" });
        items.Add(new Item { name = "Animations", description = "Roberto de Jesús Barraza Mendoza \n Porfirio Juan Ignacio Partida Ibarra" });
        items.Add(new Item { name = "Shaders", description = "Porfirio Juan Ignacio Partida Ibarra" });
        items.Add(new Item { name = "UI", description = "Jose Alfredo Chi Zum \n Daniela Castillo Bermúdez \n Arturo Prieto Jiménez" });
        items.Add(new Item { name = "MUSIC & SFX", description = "" });
        items.Add(new Item { name = "Music", description = "Arturo Prieto Jiménez" });
        items.Add(new Item { name = "SFX", description = "Arturo Prieto Jiménez" });
        items.Add(new Item { name = "DEVELOPMENT", description = "" });
        items.Add(new Item { name = "Level Design", description = "Miguel Eduardo Cruz Carrillo \n Jesus Eduardo Ramirez Guevara \n Martin Williams Lara" });
        items.Add(new Item { name = "Mechanics", description = "Oscar Tomas Aceves Davalos \n Porfirio Juan Ignacio Partida Ibarra" });
        items.Add(new Item { name = "UI", description = "Jose Alfredo Chi Zum \n Daniela Castillo Bermúdez \n Arturo Prieto Jiménez" });
        items.Add(new Item { name = "Transitions", description = "Porfirio Juan Ignacio Partida Ibarra" });

        string credits = "";
        foreach (var item in items)
        {
            credits += item.name + ":\n" + item.description + "\n\n";
        }

        creditsText.text = credits;

        Transform parentTransform = creditsPanel.transform.parent;

        totalHeight = creditsText.preferredHeight;
        creditsPanel.sizeDelta = new Vector2(creditsPanel.sizeDelta.x, totalHeight);
        SetInitialPosition();
       
    }

    public void StartCredits() {
        _soundManager.PlayMusic(4, true);
        panelElement.SetActive(true);
        showCredit = true;
        SetInitialPosition();
    }

    void SetInitialPosition()
    {
        float startPositionY = -totalHeight / 2 - (Screen.height / 2) + 50;
        creditsPanel.localPosition = new Vector3(creditsPanel.localPosition.x, startPositionY, creditsPanel.localPosition.z);
    }

    void Update()
    {
        if(showCredit) {
            creditsPanel.transform.Translate(Vector3.up * speed * Time.deltaTime);
            CheckIfCreditsFinished();
        }
        if(showCredit && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.KeypadEnter))) {
            showCredit = false;
            panelElement.SetActive(false);
            _soundManager.PlayMusic(0, true);
        }
    }

     void CheckIfCreditsFinished()
    {
        if (creditsPanel.transform.localPosition.y > totalHeight / 2)
        {
            showCredit = false;
            panelElement.SetActive(false);
            _soundManager.PlayMusic(0, true);
        }
    }
}
