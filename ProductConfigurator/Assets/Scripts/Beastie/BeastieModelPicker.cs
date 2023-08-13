using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastieModelPicker : MonoBehaviour
{
    [SerializeField]
    private BeastieType type = BeastieType.None;
    [SerializeField]
    private BeastieModelKeyValue[] beastieModels;
    private GameObject currentModel;
    
    public void SelectModel(BeastieType typeToSelect)
    {
        type = typeToSelect;
        bool isFound = false;
        int i = 0;
        while (!isFound && i < beastieModels.Length)
        {
            if (beastieModels[i].Key == typeToSelect)
            {
                isFound = true;
                createNewModel(beastieModels[i].Model);
            }
            i++;
        }
    }

    private void createNewModel(GameObject prefabToCreate)
    {
        if (currentModel != null)
        {
            GameObject.Destroy(currentModel);
        }
        if (prefabToCreate != null)
        {
            currentModel = Instantiate(prefabToCreate, this.transform);
        }
    }

    public void SetColour(ColourType colourToSet)
    {
        currentModel?.GetComponent<BeastieColourPicker>().SetColourMaterial(colourToSet);
    }

    public void SetAura(AuraType auraToSet)
    {
        currentModel?.GetComponent<BeastieAuraPicker>().SetAura(auraToSet);
    }
}