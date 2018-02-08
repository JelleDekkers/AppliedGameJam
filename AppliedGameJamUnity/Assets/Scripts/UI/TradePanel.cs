using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradePanel : MonoBehaviour {

    public InputField ecoMaterialCostInputField;
    public InputField ecoMaterialAmountInputField;
    public InputField ecoResearchCostInputField;
    public InputField ecoResearchAmountInputField;

    public void Trade() {
        if (ecoMaterialCostInputField.text != string.Empty && ecoMaterialAmountInputField.text != string.Empty) {
            GameResource ecoMaterialAmount = new GameResource(GameResources.EcoMaterial);
            ecoMaterialAmount.amount = float.Parse(ecoMaterialAmountInputField.text);
            Player.Instance.AddResource(ecoMaterialAmount);

            GameResource ecoMaterialCost = new GameResource(GameResources.Money);
            ecoMaterialCost.amount = float.Parse(ecoMaterialCostInputField.text);
            Player.Instance.AddResource(ecoMaterialCost);
        }

        if (ecoResearchAmountInputField.text != string.Empty && ecoResearchCostInputField.text != string.Empty) {
            GameResource ecoResearchAmount = new GameResource(GameResources.EcoResearch);
            ecoResearchAmount.amount = float.Parse(ecoResearchAmountInputField.text);
            Player.Instance.AddResource(ecoResearchAmount);

            GameResource ecoResearchCost = new GameResource(GameResources.Money);
            ecoResearchCost.amount = float.Parse(ecoResearchCostInputField.text);
            Player.Instance.AddResource(ecoResearchCost);
        }

        gameObject.SetActive(false);
    }
}
