using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EDialogue
{
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField] private Dialogue dialogueDebug;

        private DialogueWindow dialogueWindow;
        private Dialogue dialogue;

        private int speekIndex;
        private bool nextSpeek;

        [field: SerializeField] public float WriteRate { get; private set; }

        private void Awake()
        {
            dialogueWindow = FindObjectOfType<DialogueWindow>();

            if (!dialogueWindow)
            {
                Debug.Log("Dont find DialogueWindow");
                Debug.Log("Need add DialogueWindow in sceene");
            }
            else
            {
                if (dialogueDebug != null)
                {
                    dialogue = dialogueDebug;
                }

                dialogueWindow.AnswerButton1.onClick.AddListener(NextSpeekIndex);
            }
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                SetDialogue(dialogueDebug);
            }
        }

        private void SetDialogue(Dialogue dialogue)
        {
            this.dialogue = dialogue;
            speekIndex = 0;
            RefreshSpeekText();
            StartDialogue();
        }

        private void NextSpeekIndex()
        {
            speekIndex++;
            nextSpeek = true;
        }

        private void StartDialogue()
        {
            dialogueWindow.transform.GetChild(0).gameObject.SetActive(true);
            //StartCoroutine(WritenDialogueText());
            StartCoroutine(WritenDialogueTextNew());
        }

        private IEnumerator WritenDialogueText()
        {
            while (dialogue != null)
            {
                for (int i = 0; i < dialogue.Speeches.Count; i++)
                {
                    dialogueWindow.Name.text = dialogue.Speeches[i].SpeakerName;


                    for (int s = 0; s < dialogue.Speeches[i].Speachs.Count; s++)
                    {
                        for (int c = 0; c < dialogue.Speeches[i].Speachs[s].Text.Length; c++)
                        {
                            dialogueWindow.Message.text += dialogue.Speeches[i].Speachs[s].Text[c];
                            yield return new WaitForSeconds(WriteRate);
                        }

                        yield return new WaitUntil(() => nextSpeek);

                        dialogue.Speeches[i].Speachs[s].CompleteSpeach();

                        RefreshSpeekText();
                        nextSpeek = false;
                    }
                }

                EndDealogue();
            }
        }

        private IEnumerator WritenDialogueTextNew()
        {
            while (dialogue != null)
            {
                var speech = dialogue.GetNextSpeach();

                //var answer = dialogue.GetAnswer();

                if (speech == null)
                {
                    

                    EndDealogue();
                }
                else
                {
                    dialogueWindow.Name.text = dialogue.GetSpeaker().SpeakerName;

                    for (int c = 0; c < speech.Text.Length; c++)
                    {
                        dialogueWindow.Message.text += speech.Text[c];
                        yield return new WaitForSeconds(WriteRate);
                    }

                    yield return new WaitUntil(() => nextSpeek);

                    dialogue.CompleteSpeach();

                    RefreshSpeekText();
                    nextSpeek = false;
                }
            }
        }

        private void EndDealogue()
        {
            dialogue = null;
            dialogueWindow.transform.GetChild(0).gameObject.SetActive(false);
        }

        private void RefreshSpeekText()
        {
            dialogueWindow.Message.text = "";
        }
    }
}

