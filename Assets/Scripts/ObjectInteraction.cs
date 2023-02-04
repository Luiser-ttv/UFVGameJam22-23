using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    public List<string> dialogueLines;
    public List<string> dialogueLinesTransform;
    public List<string> dialogueLinesWitch;
    public float interactionRadius = 2.0f;
    public bool showDialogue = false;
    public bool showDialogueTransform = false;
    public bool showDialogueWitch = false;
    public bool dialogueFinished = false;
    public TMP_Text dialogueText;

    private int currentLineIndex = 0;
    private CharacterMovement characterMovement;

    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.CompareTag("Interactable"))
                {
                    showDialogue = true;
                    characterMovement.enabled = false;
                    break;
                }
                else if (collider.gameObject.CompareTag("TransformDone"))
                {
                    showDialogueTransform = true;
                    characterMovement.enabled = false;
                    break;
                }
                else if (collider.gameObject.CompareTag("Hunted"))
                {
                    showDialogueWitch = true;
                    characterMovement.enabled = false;
                    break;
                }
            }
        }

        if (showDialogue)
        {
            dialogueText.gameObject.SetActive(true);

            if (currentLineIndex < dialogueLines.Count)
            {
                dialogueText.text = dialogueLines[currentLineIndex];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentLineIndex++;
                }
            }
            else
            {
                dialogueFinished = true;
                showDialogue = false;
                characterMovement.enabled = true;
                dialogueText.gameObject.SetActive(false);
                currentLineIndex = 0;
            }
        }
        else if (showDialogueTransform)
        {
            dialogueText.gameObject.SetActive(true);

            if (currentLineIndex < dialogueLinesTransform.Count)
            {
                dialogueText.text = dialogueLinesTransform[currentLineIndex];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentLineIndex++;
                }
            }
            else
            {
                dialogueFinished = true;
                showDialogueTransform = false;
                characterMovement.enabled = true;
                dialogueText.gameObject.SetActive(false);
                currentLineIndex = 0;
            }
        }
        else if (showDialogueWitch)
        {
            dialogueText.gameObject.SetActive(true);

            if (currentLineIndex < dialogueLinesWitch.Count)
            {
                dialogueText.text = dialogueLinesWitch[currentLineIndex];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentLineIndex++;
                }
            }
            else
            {
                dialogueFinished = true;
                showDialogueWitch = false;
                characterMovement.enabled = true;
                dialogueText.gameObject.SetActive(false);
                currentLineIndex = 0;
            }
        }


    }
}
