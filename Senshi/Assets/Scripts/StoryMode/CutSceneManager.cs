using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// Manages the CutScenes
/// By Louis
/// </summary>
public class CutSceneManager : MonoBehaviour
{
    /// <summary>
    /// used to get access to Background Images
    /// </summary>
    [SerializeField] private GameObject panel;
    /// <summary>
    /// Background Image for opening Scene
    /// </summary>
    [SerializeField] private Sprite openingScene;
    /// <summary>
    /// Background Image for CutScene Riu
    /// </summary>
    [SerializeField] private Sprite riu;
    /// <summary>
    /// Background Image for CutScene Akai
    /// </summary>
    [SerializeField] private Sprite akai;
    /// <summary>
    /// Background Image for CutScene Akuma Prefight
    /// </summary>
    [SerializeField] private Sprite akumaPre;
    /// <summary>
    /// Background Image for CutScene Akuma Midfight
    /// </summary>
    [SerializeField] private Sprite akumaMid;
    /// <summary>
    /// Background Image for EndScene
    /// </summary>
    [SerializeField] private Sprite endScene;
    /// <summary>
    /// Textfield to set story text in
    /// </summary>
    [FormerlySerializedAs("text")] [SerializeField] private Text cutsceneTextField;

    /// <summary>
    /// File Path to cfg Folder
    /// </summary>
    private const string CFG_FOLDER = "./cfg/";
    /// <summary>
    /// name of File where Story is saved
    /// </summary>
    private const string STORY_CFG = "story.json";

    /// <summary>
    /// used as comparative for textDelay (timer)
    /// </summary>
    private const float DELAY = 7f;
    /// <summary>
    /// used to campare with DELAY (as timer)
    /// </summary>
    private float textDelay = DELAY;
    /// <summary>
    /// bool so we can end the cutscene
    /// </summary>
    public static bool cutsceneActive = false;

    /// <summary>
    /// Index to check at which state of the story we are at the moment
    /// </summary>
    public static int StoryIndex = 1;
    /// <summary>
    /// Index to load CutSceneText needed
    /// </summary>
    public static int CutsceneTextIndex = 0;

    /// <summary>
    /// List of all CutSceneTexts
    /// </summary>
    private List<string[]> storyText = new List<string[]>();

    /// <summary>
    /// Load or Create the Story
    /// </summary>
    private void Awake()
    {
        if (!Directory.Exists(CFG_FOLDER))
        {
            Debug.Log("No config folder, creating...");
            Directory.CreateDirectory(CFG_FOLDER);
        }
        if (!File.Exists(CFG_FOLDER + STORY_CFG))
        {
            Debug.Log("No story file, creating...");

            storyText = new List<string[]>();

            #region default story
            storyText.Add(new string[]
            {
                "Als der gerade mal 16 Jahre alte Senshi nach der Schule nach Hause kommt, findet er seine Eltern regungslos am Boden liegen.",
                "Nach erfolglosen Versuchen diese zu wecken, ruft er nach Hilfe.",
                "Die Aerzte stempeln ihren ploetzlichen Tod als Herzversagen ab, aber Senshi weiss, dass mehr hinter dem Tod seiner Eltern stecken muss.",
                "Nachdem er mysterioese Briefe in den Unterlagen seiner Eltern findet, ist er sich sicher, dass ihr Tod kein Zufall gewesen sein kann.",
                "Sein vorheriges Leben hinter sich lassend begibt sich Senshi auf den Weg, die Wahrheit heraus zu finden.",
                "Er bemerkt schnell, dass er noetige Informationen ohne Gewalt nicht erhalten wird, so begibt er sich auf die Strasse und erkaempft sich Stueck fuer Stueck die Hinweise, die ihn letztendlich zum Moerder seiner Eltern fuehren sollen.",
            });
            storyText.Add(new string[]
            {
                "Im ersten Kampf begegnet er Riu. Riu ist ein elternloser Schlaeger, der sein Leben auf der Strasse verbringt.",
                "Seine Probleme loest er mit Gewalt und Drohungen, allerdings weiss er ueber alles was auf der Strasse passiert Bescheid.",
            });
            storyText.Add(new string[]
            {
            });
            storyText.Add(new string[]
            {
                "Nachdem Senshi Riu besiegt erfaehrt er, dass wenige Tage vor dem Tod seiner Eltern ein bekannter Drogenabhaengiger, Akai, viel Zeit vor dessen Haus verbracht haben soll.",
            });
            storyText.Add(new string[]
            {
                "Der zweite Kampf findet mit dem drogenabhaengigen Akai statt.",
                "Dieser streitet es nicht ab, an dem Tod der Eltern Senshis beteiligt gewesen zu sein, schuetzt aber den Namen seines Auftraggebers, da dieser ihn mit Drogen versorgt.",
            });
            storyText.Add(new string[]
            {
            });
            storyText.Add(new string[]
            {
                "Nachdem Senshi den Kampf gewonnen hat, bricht Akai zusammen.",
                "Waehrend er stirbt, bringt er mit letzter Kraft den Namen Akuma von den Lippen. Senshi ist sich sicher, dass es sich dabei um seinen Auftraggeber handelt.",
            });
            storyText.Add(new string[]
            {
                "Sein Weg endet bei Akuma, dem er bereits zu Beginn des Kampfes einen qualvollen Tod wuenscht.",
                "Dieser macht sich nur ueber den jungen Senshi und dessen rasende Wut lustig.",
            });
            storyText.Add(new string[]
            {
            });
            storyText.Add(new string[]
            {
                "Bevor sich Senshi nun endlich an dem Moerder seiner Eltern raechen kann, scheint er zur Vernunft zu kommen und bietet diesem an, sein Leben zu verschonen, wenn er sich freiwillig der Polizei stellt und sich zu dem Mord an seinen Eltern bekennt.",
                "Akuma bricht in Lachen aus und gibt zwar zu, den Mord in Auftrag gegeben zu haben, sagt aber, der eigentliche Moerder sei ein drogenabhaengiger Namens Akai.",
            });
            storyText.Add(new string[]
            {
                "Senshi bricht voller Wut und Verzweiflung zusammen, als ihm bewusst wird, dass der Moerder seiner Eltern bedeutungslos in einer Gasse gestorben ist und somit niemals zur Rechenschaft gezogen werden kann.",
                "Die Geschichte endet mit dem Selbstmord Senshis, der, nachdem er sein altes Leben zurueckgelassen hat und nur noch seiner blinden Wut gefolgt war, alles verloren hat.",
            });
            #endregion

            SaveStoryToFile();
        }
        else
        {
            storyText = JsonConvert.DeserializeObject<List<string[]>>(File.ReadAllText(CFG_FOLDER + STORY_CFG));
        }
    }

    private void Start()
    {
        CutsceneTextIndex = 0;
    }

    /// <summary>
    /// Sets text of CutScene depending on Story Index
    /// and runs through Cut Scene Text using a Timer
    /// </summary>
    private void Update()
    {
        textDelay += Time.deltaTime;
        if (textDelay >= DELAY && cutsceneActive)
        {
            textDelay = 0f;

            cutsceneTextField.text = storyText[StoryIndex - 1][CutsceneTextIndex];
            CutsceneTextIndex++;
            if (CutsceneTextIndex >= storyText[StoryIndex - 1].Length)
            {
                cutsceneActive = false;
            }
        }
    }

    /// <summary>
    /// Saves the Story to the story.json file
    /// </summary>
    public void SaveStoryToFile()
    {
        StreamWriter sw = File.CreateText(CFG_FOLDER + STORY_CFG);
        sw.Write(JsonConvert.SerializeObject(storyText, Formatting.Indented));
        sw.Close();
    }

    /// <summary>
    /// Loads the CutScene depending on Story Index
    /// </summary>
    /// <param name="index"></param>
    public void InitCutScene(int index)
    {
        cutsceneActive = true;
        initCutsceneOutput();
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Sets Background of Cutscene depending on Story Index
    /// Not used in the moment cause we don't have Art Assets
    /// </summary>
    private void initCutsceneOutput()
    {
        //switch (StoryIndex)
        //{
        //    case 1:
        //        //panel.GetComponent<Image>().sprite = openingScene;
        //        break;
        //    case 2:
        //        panel.GetComponent<Image>().sprite = riu;
        //        break;
        //    case 4:
        //        //panel.GetComponent<Image>().sprite = riu;
        //        break;
        //    case 5:
        //        panel.GetComponent<Image>().sprite = akai;
        //        break;
        //    case 7:
        //        panel.GetComponent<Image>().sprite = akai;
        //        break;
        //    case 8:
        //        panel.GetComponent<Image>().sprite = akumaPre;
        //        break;
        //    case 10:
        //        panel.GetComponent<Image>().sprite = akumaMid;
        //        break;
        //    case 11:
        //        panel.GetComponent<Image>().sprite = endScene;
        //        break;
        //    default:
        //        break;
        //}
    }

}