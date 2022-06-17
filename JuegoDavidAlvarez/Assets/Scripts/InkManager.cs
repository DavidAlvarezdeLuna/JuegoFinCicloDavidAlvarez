using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InkManager : MonoBehaviour
{
    private Story _story;
    [SerializeField] private Text _textField;

    [SerializeField] private VerticalLayoutGroup _choiceButtonContainer;
    [SerializeField] private Button _choiceButtonPrefab;

    [SerializeField] private GameObject textContainer;

    private GameObject player;
    [SerializeField] private GameObject npc;

    private GameObject decisionManager;
    private GameObject controllerCanvas;
    public Joystick joystick;
    private GameObject joyButtonA;


    //Para los dialogos que registran una variable, me facilita la interaccion entre unity e ink, para almacenar decisiones
    public string nomVariable;

    //Almacena el valor de la variable nomVariable, para llevarla al DecisionManager
    public string valorVariable;

    //variable que registra con cuanta gente se ha hablado en una escena
    //Cuando alcanza una cantidad determinada se puede pasar a la siguiente escena
    public int peopleTalked = 0;

    //Variable que comprueba si ya he interactuado con un personaje al menos una vez
    //Permite que no se repitan los dialogos con decisiones
    public bool visited;
    private string personTag;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        decisionManager = GameObject.FindWithTag("DecisionManager");
        controllerCanvas = GameObject.FindWithTag("controllerCanvas");
        joystick = FindObjectOfType<Joystick>();
        joyButtonA = GameObject.FindWithTag("buttonB");
    }

    public void StartStory(TextAsset inkJsonAsset, string nomVar, bool visited, string personTag)
    {
        this.visited = visited;
        this.personTag = personTag;
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
                //Que solo la mujer de la posada compruebe con cuantos se ha hablado
                if(personTag == "mujerPosada")
                {
                    if(((SceneManager.GetActiveScene().name == "Scene2" && peopleTalked >= 7 && !player.GetComponent<PlayerController>().canPlayShootGame) || (SceneManager.GetActiveScene().name == "Scene3" && peopleTalked >= 7 && !player.GetComponent<PlayerController>().canPlayDuplicateGame) || (SceneManager.GetActiveScene().name == "Scene1" && peopleTalked >= 7)))
                    {
                        _story.ChoosePathString("todosHablados");
                        player.GetComponent<PlayerController>().canFinishScene = true;

                    }
                    else
                    {
                        _story.ChoosePathString("After");
                    }
                    
                }
                else
                {
                    _story.ChoosePathString("After");
                }

            }
        }
        
        textContainer.SetActive(true);
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (_story.canContinue)
        {
            string text = _story.Continue();

            text = text?.Trim();

            _textField.text = text;
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
        if(personTag == "endDayEvent")
        {
            peopleTalked = 0;
            //CAMBIO DE ESCENA
            if(SceneManager.GetActiveScene().name == "Scene5")
            {
                decisionManager.GetComponent<DecisionManager>().sceneActual++;
                decisionManager.GetComponent<DecisionManager>().updateDatabase();
                SceneManager.LoadSceneAsync("Intro");
            }
            else
            {
                decisionManager.GetComponent<DecisionManager>().sceneActual++;
                decisionManager.GetComponent<DecisionManager>().updateDatabase();
                SceneManager.LoadSceneAsync("Scene" + decisionManager.GetComponent<DecisionManager>().sceneActual.ToString());
            }          
        }
        else
        {
            //Si el dialogo maneja una variable que se quiere registrar
            if (nomVariable != "")
            {
                //solo ocurre la primera vez que se habla con el personaje
                if(!visited)
                {
                    if(_story.variablesState[nomVariable].ToString() != "Null")
                    {    
                        valorVariable = _story.variablesState[nomVariable].ToString();
                        //registro la variable en DecisionManager.cs
                        decisionManager.GetComponent<DecisionManager>().actualizarValor(nomVariable,valorVariable);
                    }
                }     
            }
        }
        

    }
    private void DisplayChoices()
    {
        if (_choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < _story.currentChoices.Count; i++)
        {

            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text);

            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text)
    {
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

        var buttonText = choiceButton.GetComponentInChildren<Text>();
        buttonText.text = text;

        return choiceButton;
    }

    void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        _story.Continue();
        RefreshChoiceView();
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