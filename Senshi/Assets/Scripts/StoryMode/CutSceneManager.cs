using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Sprite openingScene;
    [SerializeField] private Sprite riu;
    [SerializeField] private Sprite akai;
    [SerializeField] private Sprite akumaPre;
    [SerializeField] private Sprite akumaMid;
    [SerializeField] private Sprite endScene;
    [FormerlySerializedAs("text")] [SerializeField] private Text cutsceneTextField;

    private const string CFG_FOLDER = "./cfg/";
    private const string STORY_CFG = "story.json";

    private const float DELAY = 5f;
    private float textDelay = DELAY;
    private static bool cutsceneActive = false;

    public static int StoryIndex = 1;
    public static int CutsceneTextIndex = 0;

    private List<string[]> storyText = new List<string[]>();

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
                "Als der gerade mal 16 Jahre alte Senshi nach der Schule nachhause kommt findet er seine Eltern regungslos am Boden liegen.",
                "Nach Versuchen diese zu wecken ruft er nach Hilfe.",
                "Die Ärzte stempeln ihren plötzlichen Tod als Herzversagen ab, aber Senshi weiß, dass mehr hinter dem Tod seiner Eltern stecken muss.",
                "Nachdem er mysteriöse Briefe in den Unterlagen seiner Eltern findet ist er sich sicher, dass ihr Tod kein Zufall gewesen sein kann.",
                "Sein vorheriges Leben hinter sich lassend begibt sich Senshi auf den Weg die Wahrheit heraus zu finden.",
                "Er bemerkt schnell, dass er nötige Informationen ohne Gewalt nicht erhalten wird, so begibt er sich auf die Straße und erkämpft sich Stück für Stück die Hinweise, die ihn letztendlich zum Mörder seiner Eltern führen sollen.",
            });
            storyText.Add(new string[]
            {
                "Im ersten Kampf begegnet er Riu. Riu ist ein elternloser Schläger, der sein Leben auf der Straße verbringt.",
                "Seine Probleme löst er mit Gewalt und Drohungen, allerdings weiß er über alles was auf der Straße passiert Bescheid.",
            });
            storyText.Add(new string[]
            {
                "Nachdem Senshi Riu besiegt erfährt er, dass wenige Tage vor dem Tod seiner Eltern, ein bekannter Drogenabhängiger, Akai, viel Zeit vor dessen Haus verbracht haben soll.",
            });
            storyText.Add(new string[]
            {
                "Der zweite Kampf findet mit dem drogenabhängigen Akai statt.",
                "Dieser streitet es nicht ab an dem Tod der Eltern Senshis beteiligt gewesen zu sein, schützt aber den Namen seines Auftraggebers, da dieser ihn mit Drogen versorgt.",
            });
            storyText.Add(new string[]
            {
                "Nach dem Gewinnen des Kampfs bricht Akai zusammen.",
                "Während er stirbt, bringt er mit letzter Kraft den Namen Akuma von den Lippen. Senshi ist sich sicher, dass es sich dabei um seinen Auftraggeber handelt.",
            });
            storyText.Add(new string[]
            {
                "Sein Weg endet bei Akuma dem er bereits zu Beginn des Kampfes einen qualvollen Tod wünscht.",
                "Dieser macht sich nur über den jungen Senshi und dessen rasende Wut lustig.",
            });
            storyText.Add(new string[]
            {
                "Bevor sich Senshi nun endlich an dem Mörder seiner Eltern rächen kann, scheint dieser zur Vernunft zu kommen und bietet ihm an, sein Leben zu verschonen, wenn sich dieser freiwillig der Polizei stellt und sich dem Mord an seinen Eltern bekennt.",
                "Akuma bricht in Lachen aus und gibt zwar zu, den Mord in Auftrag gegeben zu haben, der eigentliche Mörder aber ein drogenabhängiger Namens Akai gewesen sei.",
            });
            storyText.Add(new string[]
            {
                "Senshi bricht voller Wut und Verzweiflung zusammen, als ihm bewusst wird, dass der Mörder seiner Eltern bedeutungslos in einer Gasse gestorben ist und somit niemals zur Rechenschaft gezogen werden kann.",
                "Die Geschichte endet mit dem Selbstmord Senshis, der, nachdem er sein altes Leben zurückgelassen hat und nur noch seiner blinden Wut gefolgt war, alles verloren hat.",
            });
            #endregion

            SaveStoryToFile();
        }
        else
        {
            storyText = JsonConvert.DeserializeObject<List<string[]>>(File.ReadAllText(CFG_FOLDER + STORY_CFG));
        }
    }

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

    public void SaveStoryToFile()
    {
        StreamWriter sw = File.CreateText(CFG_FOLDER + STORY_CFG);
        sw.Write(JsonConvert.SerializeObject(storyText, Formatting.Indented));
        sw.Close();
    }

    public void InitCutScene(int index)
    {
        cutsceneActive = true;
        initCutsceneOutput();
        SceneManager.LoadScene(1);
    }

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