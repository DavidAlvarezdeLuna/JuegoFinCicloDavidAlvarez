using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InkManager : MonoBehaviour
{
    //[SerializeField] private TextAsset _inkJsonAsset;
    private Story _story;
    [SerializeField] private Text _textField;

    [SerializeField] private VerticalLayoutGroup _choiceButtonContainer;
    [SerializeField] private Button _choiceButtonPrefab;

    [SerializeField] private GameObject textContainer;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject npc;

    private GameObject decisionManager;

    //Para los dialogos que registran una variable, me facilita la interaccion entre unity e ink, para almacenar decisiones
    public string nomVariable;

    //Almacena el valor de la variable nomVariable, para llevarla al gamemanager
    public string valorVariable;

    //variable que registra con cuanta gente se ha hablado
    //Cuando es 7 y hablas con la mujer de la posada, se pasa a la siguiente escena
    public int peopleTalked = 0;

    //Variable que comprueba si ya he interactuado con un personaje al menos una vez
    //Permite que no se repitan los dialogos con decisiones
    public bool visited;
    private string personTag;


    void Start()
    {
        decisionManager = GameObject.FindWithTag("DecisionManager");
    }

    public void StartStory(TextAsset inkJsonAsset, string nomVar, bool visited, string personTag)
    {
        this.visited = visited;
        this.personTag = personTag;
        Debug.Log("personaTag es: "+personTag);
        //Las diferentes story se estaban entrelazando mal entre personajes si no les instanciaba la historia cada vez
        _story = new Story(inkJsonAsset.text);

        //Este if permite que los personajes que necesitan comprobar una variable almacenada en ink, recuperen ese valor aunque al instanciar la historia pierdan las variables
        //De esta manera, puedo asignarles una variable que obtuviera en otro ink
        if(nomVar != ""){
            _story.variablesState[nomVar] = decisionManager.GetComponent<DecisionManager>().getValue(nomVar);
        }
        
        if(personTag != "evento" && personTag != "endDayEvent")
        {
            if(!visited)
            {
                nomVariable = nomVar;
                peopleTalked++;
            }
            else
            {
                //Que solo la mujerPosada recoja esta variable
                if(personTag == "mujerPosada")
                {
                    //Debug.Log("Es la mujer de la posada");
                    if((SceneManager.GetActiveScene().name == "Scene2" && peopleTalked >= 7 && !player.GetComponent<PlayerController>().canPlayShootGame) || (SceneManager.GetActiveScene().name == "Scene3" && peopleTalked >= 7 && !player.GetComponent<PlayerController>().canPlayDuplicateGame) || player.GetComponent<PlayerController>().canFinishScene)
                    {
                        //Debug.Log("Inicia TodosHablados");
                        _story.ChoosePathString("todosHablados");
                        peopleTalked = 0;
                        player.GetComponent<PlayerController>().canFinishScene = true;

                    }
                    else
                    {
                        //Debug.Log("Es la mujer de la posada que inicia After");
                        _story.ChoosePathString("After");
                    }
                    
                }
                else
                {
                    //Debug.Log("Otro inicia After");
                    _story.ChoosePathString("After");
                }

            }
        }
        
        
        textContainer.SetActive(true);
        DisplayNextLine();
        Debug.Log("peopleTalked: "+peopleTalked);
    }

    public void DisplayNextLine()
    {
        if (_story.canContinue)
        {
            string text = _story.Continue(); // gets next line

            text = text?.Trim(); // removes white space from text

            _textField.text = text; // displays new text
        }
        else if (_story.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        else if (!_story.canContinue)
        {
            EndStory();
        }
    }

    private void EndStory()
    {
        textContainer.SetActive(false);
        player.GetComponent<PlayerController>().canMove = true;
        //Si el dialogo maneja una variable que se quiere registrar
        if(personTag == "endDayEvent")
        {
            //CAMBIO DE ESCENA
            decisionManager.GetComponent<DecisionManager>().sceneActual++;
            SceneManager.LoadSceneAsync("Scene"+decisionManager.GetComponent<DecisionManager>().sceneActual.ToString());
        }
        else
        {
            if(nomVariable != "")
            {
                //solo ocurre la primera vez que se habla con el personaje
                if(!visited)
                {
                    if(_story.variablesState[nomVariable].ToString() != "Null")
                    {    
                        Debug.Log(_story.variablesState[nomVariable]);
                        valorVariable = _story.variablesState[nomVariable].ToString();
                        //registro de la variable en DecisionManager.cs
                        decisionManager.GetComponent<DecisionManager>().actualizarValor(nomVariable,valorVariable);
                    }
                }     
            }
        }
        

    }
    private void DisplayChoices()
    {
        // checks if choices are already being displayed
        if (_choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < _story.currentChoices.Count; i++) // iterates through all choices
        {

            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text); // creates a choice button

            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text)
    {
        // creates the button from a prefab
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

        // sets text on the button
        var buttonText = choiceButton.GetComponentInChildren<Text>();
        buttonText.text = text;

        return choiceButton;
    }

    void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index); // tells ink which choice was selected
        _story.Continue();
        RefreshChoiceView(); // removes choices from the screen
        DisplayNextLine();
    }

    void RefreshChoiceView()
    {
        if (_choiceButtonContainer != null)
        {
            foreach (var button in _choiceButtonContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }

}