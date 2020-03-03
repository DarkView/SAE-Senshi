using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Sprite openingScene;
    [SerializeField] private Sprite riu;
    [SerializeField] private Sprite akai;
    [SerializeField] private Sprite akumaPre;
    [SerializeField] private Sprite akumaMid;
    [SerializeField] private Sprite endScene;
    [SerializeField] private Text text;

    private const string CFG_FOLDER = "./cfg/";
    private const string STORY_CFG = "story.json";

    private string[] storyText = new string[0];
    private int currDialogueIdx = 0;
    private string[] currDialogueText;

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
            storyText = new string[]
            {
                "Als der gerade mal 16 Jahre alte Senshi nach der Schule nachhause kommt findet er seine Eltern regungslos am Boden liegen.",
  "Nach Versuchen diese zu wecken ruft er nach Hilfe.",
  "Die Ärzte stempeln ihren plötzlichen Tod als Herzversagen ab, aber Senshi weiß, dass mehr hinter dem Tod seiner Eltern stecken muss.",
  "Nachdem er mysteriöse Briefe in den Unterlagen seiner Eltern findet ist er sich sicher, dass ihr Tod kein Zufall gewesen sein kann.",
  "Sein vorheriges Leben hinter sich lassend begibt sich Senshi auf den Weg die Wahrheit heraus zu finden.",
  "Er bemerkt schnell, dass er nötige Informationen ohne Gewalt nicht erhalten wird, so begibt er sich auf die Straße und erkämpft sich Stück für Stück die Hinweise, die ihn letztendlich zum Mörder seiner Eltern führen sollen.",
  "break",
  "Im ersten Kampf begegnet er Riu. Riu ist ein elternloser Schläger, der sein Leben auf der Straße verbringt.",
  "Seine Probleme löst er mit Gewalt und Drohungen, allerdings weiß er über alles was auf der Straße passiert Bescheid.",
  "break",
  "Nachdem Senshi Riu besiegt erfährt er, dass wenige Tage vor dem Tod seiner Eltern, ein bekannter Drogenabhängiger, Akai, viel Zeit vor dessen Haus verbracht haben soll.",
  "break",
  "Der zweite Kampf findet mit dem drogenabhängigen Akai statt.",
  "Dieser streitet es nicht ab an dem Tod der Eltern Senshis beteiligt gewesen zu sein, schützt aber den Namen seines Auftraggebers, da dieser ihn mit Drogen versorgt.",
  "break",
  "Nach dem Gewinnen des Kampfs bricht Akai zusammen.",
  "Während er stirbt, bringt er mit letzter Kraft den Namen Akuma von den Lippen. Senshi ist sich sicher, dass es sich dabei um seinen Auftraggeber handelt.",
  "break",
  "Sein Weg endet bei Akuma dem er bereits zu Beginn des Kampfes einen qualvollen Tod wünscht.",
  "Dieser macht sich nur über den jungen Senshi und dessen rasende Wut lustig.",
  "break",
  "Bevor sich Senshi nun endlich an dem Mörder seiner Eltern rächen kann, scheint dieser zur Vernunft zu kommen und bietet ihm an, sein Leben zu verschonen, wenn sich dieser freiwillig der Polizei stellt und sich dem Mord an seinen Eltern bekennt.",
  "Akuma bricht in Lachen aus und gibt zwar zu, den Mord in Auftrag gegeben zu haben, der eigentliche Mörder aber ein drogenabhängiger Namens Akai gewesen sei.",
  "break",
  "Senshi bricht voller Wut und Verzweiflung zusammen, als ihm bewusst wird, dass der Mörder seiner Eltern bedeutungslos in einer Gasse gestorben ist und somit niemals zur Rechenschaft gezogen werden kann.",
  "Die Geschichte endet mit dem Selbstmord Senshis, der, nachdem er sein altes Leben zurückgelassen hat und nur noch seiner blinden Wut gefolgt war, alles verloren hat.",
  "break"
            };
            SaveStoryToFile();
        }

        storyText = JsonConvert.DeserializeObject<string[]>(File.ReadAllText(CFG_FOLDER + STORY_CFG));
        foreach (string VARIABLE in storyText)
        {
            Debug.Log(VARIABLE);
        }

        //loadDialogueBlock(3);
        Debug.Log("Break");
    }

    public void SaveStoryToFile()
    {
        StreamWriter sw = File.CreateText(CFG_FOLDER + STORY_CFG);
        sw.Write(JsonConvert.SerializeObject(storyText, Formatting.Indented));
        sw.Close();
    }

    public string GetStoryFromFile(int index)
    {
        return storyText[index];
    }

    public void InitCutScene(int index)
    {
        SceneManager.LoadScene(1);
        initCutsceneOutput();
    }

    private void initCutsceneOutput()
    {
        switch (StoryManager.StoryIndex)
        {
            case 1:
                panel.GetComponent<Image>().sprite = openingScene;
                loadDialogueBlock(0);
                break;
            case 2:
                panel.GetComponent<Image>().sprite = riu;
                loadDialogueBlock(1);
                break;
            case 4:
                //panel.GetComponent<Image>().sprite = riu;
                loadDialogueBlock(2);
                break;
            case 5:
                panel.GetComponent<Image>().sprite = akai;
                loadDialogueBlock(3);
                break;
            case 7:
                panel.GetComponent<Image>().sprite = akai;
                loadDialogueBlock(4);
                break;
            case 8:
                panel.GetComponent<Image>().sprite = akumaPre;
                break;
            case 10:
                panel.GetComponent<Image>().sprite = akumaMid;
                break;
            case 11:
                panel.GetComponent<Image>().sprite = endScene;
                break;
            default:
                break;
        }
    }


    private void loadDialogueBlock(int index)
    {
        if (currDialogueIdx == index) return;
        if (currDialogueIdx > index) currDialogueIdx = 0;

        List<string> loadedStoryBuffer = new List<string>();
        for (int i = 0; i < storyText.Length; i++)
        {
            string currLoaded = storyText[i];

            if (currLoaded == null)
            {
                if (index == currDialogueIdx)
                {
                    currDialogueText = loadedStoryBuffer.ToArray();

                    // TODO: Remove
                    for (int j = 0; j < currDialogueText.Length; j++)
                    {
                        Debug.Log(currDialogueText[j]);
                    }

                    return;
                }
                currDialogueIdx++;
                break;
            }

            if (index == currDialogueIdx)
            {
                loadedStoryBuffer.Add(storyText[i]);
            }

        }
    }

    private void LoadCutScene()
    {
        switch (StoryManager.StoryIndex)
        {
            case 1:
                panel.GetComponent<Image>().sprite = openingScene;
                text.text = this.GetStoryFromFile(0);
                //StartCoroutine(Wait());
                Thread.Sleep(10000);
                text.text = this.GetStoryFromFile(1);
                StartCoroutine(Wait());
                text.text = this.GetStoryFromFile(2);
                StartCoroutine(Wait());
                text.text = this.GetStoryFromFile(3);
                StartCoroutine(Wait());
                text.text = this.GetStoryFromFile(4);
                StartCoroutine(Wait());
                text.text = this.GetStoryFromFile(5);
                //continue button
                break;
            case 2:
                panel.GetComponent<Image>().sprite = riu;
                text.text = this.GetStoryFromFile(6);
                this.Wait();
                text.text = this.GetStoryFromFile(7);
                //continue button
                break;
            case 4:
                panel.GetComponent<Image>().sprite = riu;
                text.text = this.GetStoryFromFile(8);
                //continue button
                break;
            case 5:
                panel.GetComponent<Image>().sprite = akai;
                text.text = this.GetStoryFromFile(9);
                this.Wait();
                text.text = this.GetStoryFromFile(10);
                //continue button
                break;
            case 7:
                panel.GetComponent<Image>().sprite = akai;
                text.text = this.GetStoryFromFile(11);
                this.Wait();
                text.text = this.GetStoryFromFile(12);
                //continue button
                break;
            case 8:
                panel.GetComponent<Image>().sprite = akumaPre;
                text.text = this.GetStoryFromFile(13);
                this.Wait();
                text.text = this.GetStoryFromFile(14);
                //continue button
                break;
            case 10:
                panel.GetComponent<Image>().sprite = akumaMid;
                text.text = this.GetStoryFromFile(15);
                this.Wait();
                text.text = this.GetStoryFromFile(16);
                //continue button
                break;
            case 11:
                panel.GetComponent<Image>().sprite = endScene;
                text.text = this.GetStoryFromFile(17);
                this.Wait();
                text.text = this.GetStoryFromFile(18);
                //continue button
                break;
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
}