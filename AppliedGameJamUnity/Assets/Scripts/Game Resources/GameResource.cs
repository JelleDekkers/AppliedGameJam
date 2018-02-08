using System;

public enum GameResources {
    Money = 0,
    EcoMaterial = 1,
    EcoResearch = 2
}


[Serializable]
public class GameResource {
    public GameResources resourceType;
    public float amount = 0;

    public GameResource(GameResources t) {
        resourceType = t;
    }
}
