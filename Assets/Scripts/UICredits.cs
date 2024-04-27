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
    

    private float totalHeight;

    [SerializeField] private float speed = 60f;

    private bool showCredit = false;

    void Start()
    {
        items.Add(new Item { name = "Objeto1", description = "Un artefacto antiguo de origen desconocido." });
        items.Add(new Item { name = "Objeto2", description = "Una herramienta útil para reparaciones caseras." });
        items.Add(new Item { name = "Objeto3", description = "Un libro de hechizos con páginas desgastadas." });
        items.Add(new Item { name = "Objeto4", description = "Una llave maestra que abre cualquier cerradura." });
        items.Add(new Item { name = "Objeto5", description = "Una piedra preciosa que brilla intensamente bajo la luna." });
        items.Add(new Item { name = "Objeto6", description = "Un reloj de bolsillo antiguo, aún en funcionamiento." });
        items.Add(new Item { name = "Objeto7", description = "Un mapa del tesoro marcado con una X en una ubicación desconocida." });
        items.Add(new Item { name = "Objeto8", description = "Una brújula que siempre señala hacia el norte verdadero." });
        items.Add(new Item { name = "Objeto9", description = "Una linterna mágica con un genio en su interior." });
        items.Add(new Item { name = "Objeto10", description = "Una capa de invisibilidad que oculta a quien la usa." });
        items.Add(new Item { name = "Objeto11", description = "Un diario con los secretos de una civilización perdida." });
        items.Add(new Item { name = "Objeto12", description = "Una espada legendaria conocida por su filo inquebrantable." });
        items.Add(new Item { name = "Objeto13", description = "Un escudo indestructible que puede absorber cualquier impacto." });
        items.Add(new Item { name = "Objeto14", description = "Botas de siete leguas que permiten al usuario viajar grandes distancias en un solo paso." });
        items.Add(new Item { name = "Objeto15", description = "Un anillo que concede deseos al portador, con gran precaución." });
        items.Add(new Item { name = "Objeto16", description = "Una pluma que escribe por sí sola cuando se le dicta." });

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
        if(showCredit && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))) {
            showCredit = false;
            panelElement.SetActive(false);
        }
    }

     void CheckIfCreditsFinished()
    {
        if (creditsPanel.transform.localPosition.y > totalHeight / 2)
        {
            showCredit = false;
            panelElement.SetActive(false);
        }
    }
}
