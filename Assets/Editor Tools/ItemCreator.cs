using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.UIElements;
using ObjectField = UnityEditor.UIElements.ObjectField;
using ColorField = UnityEditor.UIElements.ColorField;
using System;

public class ItemCreator : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;
    private VisualElement root;

    // File references
    private string filePath = "Assets/Items";

    // Item Inputs
    private TextField nameField;
    private TextField descriptionField;
    private Toggle toolField;
    private Toggle stackField;
    private ObjectField prefabField;
    private ObjectField iconField;
    private Sprite iconSprite;
    private ColorField colourField;
    private Toggle contrabandField;
    private Label errorField;

    [MenuItem("Editors/ItemCreator")]
    public static void ShowExample()
    {
        ItemCreator wnd = GetWindow<ItemCreator>();
        wnd.titleContent = new GUIContent("Item Creator");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        root = rootVisualElement;
        m_VisualTreeAsset.CloneTree(root);

        SetupUI();
    }

    private void SetupUI()
    {
        nameField = root.Q<TextField>("NameField");
        descriptionField = root.Q<TextField>("DescriptionField");
        toolField = root.Q<Toggle>("ToolField");
        toolField.RegisterValueChangedCallback(OnToolValueChanged);
        stackField = root.Q<Toggle>("StackField");
        stackField.style.display = DisplayStyle.None;
        contrabandField = root.Q<Toggle>("ContrabandField");
        prefabField = root.Q<ObjectField>("PrefabField");
        iconField = root.Q<ObjectField>("IconField");
        colourField = root.Q<ColorField>("ColourField");
        errorField = root.Q<Label>("ErrorField");

        // Button Setup
        Button Button = rootVisualElement.Q<Button>("CreateField");
        if (Button != null)
        {
            Button.clicked += OnButtonPressed;
        }
    }



    private void OnButtonPressed()
    {
        // Check if the prefab is assigned
        if (nameField.value != "" && descriptionField.value != "" && prefabField.value != null && iconField.value != null)
        {
            CreateNewItem();
        }
        else if (nameField.value == "")
        {
            errorField.text = "Error: No Name entered! Input a String name to generate item.";
            Debug.LogError("Error: No Name entered! Input a String name to generate item.");
        }
        else if (descriptionField.value == "")
        {
            errorField.text = "Error: No Desciption entered! Input a String description (capatalise each word) to generate item.";
            Debug.LogError("Error: No Desciption entered! Input a String description (capatalise each word) to generate item.");
        }
        else if (prefabField.value == null)
        {
            errorField.text = "Error: No Prefab assigned! Input a GameObject prefab to generate item.";
            Debug.LogError("Error: No Prefab assigned! Input a GameObject prefab to generate item.");
        }
        else if (iconField.value == null)
        {
            errorField.text = "Error: No Icon assigned! Input a Sprite Icon to generate item.";
            Debug.LogError("Error: No Icon assigned! Input a Sprite Icon to generate item.");
        }
    }

    private void CreateNewItem()
    {
        // Instantiate the prefab
        GameObject newItem = PrefabUtility.InstantiatePrefab(prefabField.value) as GameObject;
        PrefabUtility.UnpackPrefabInstance(newItem, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
        // Create ScriptableObject
        string dataPath = CreateScriptableObject();
        ItemData newData = AssetDatabase.LoadAssetAtPath<ItemData>(dataPath);

        // Add Item Component and assign new scriptable object
        newItem.AddComponent<Item>();
        newItem.layer = LayerMask.NameToLayer("Items");
        Item itemScript = newItem.GetComponent<Item>();
        itemScript.itemData = newData;

        // Save Prefab
        string assetPath = $"{filePath}/" + newData.name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(newItem, assetPath);

        // Re-acess the Scriptable object to assign new prefab to it
        newData.prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
        EditorUtility.SetDirty(newData);
        AssetDatabase.SaveAssets();

        // Destroy GameObject in scene

        DestroyImmediate(newItem);


        ClearFields();
    }

    private string CreateScriptableObject()
    {
        // Create a new instance of the ScriptableObject
        ItemData newData = ScriptableObject.CreateInstance<ItemData>();

        // Set values
        newData.name = nameField.value.ToLower();
        newData.ID = CalculateItemID();
        newData.itemName = nameField.value;
        newData.itemDescription = descriptionField.value;
        newData.tool = toolField.value;
        newData.doesStack = stackField.value;
        newData.contraband = contrabandField.value;
        iconSprite = iconField.value as Sprite;
        if (iconSprite != null) { newData.Icon = iconSprite; }
        Color newColor = colourField.value; newColor.a = 1;
        newData.IconColour = newColor;
        

        // Define the path to save the ScriptableObject asset
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        string assetPath = $"{filePath}/" + newData.name + ".asset";

        // Save the ScriptableObject as an asset
        UnityEditor.AssetDatabase.CreateAsset(newData, assetPath);
        UnityEditor.AssetDatabase.SaveAssets();

        return assetPath;
    }

    private int CalculateItemID()
    {
        int count = 0;

        // Get all asset files in the folder
        string[] files = Directory.GetFiles(filePath, "*.asset", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            // Load the asset
            ItemData itemData = AssetDatabase.LoadAssetAtPath<ItemData>(file);

            // Check if it is of type ItemData
            if (itemData != null)
            {
                count++;
            }
        }
        return count;
    }

    private void ClearFields()
    {
        nameField.SetValueWithoutNotify(null);
        descriptionField.SetValueWithoutNotify(null);
        toolField.SetValueWithoutNotify(false);
        stackField.SetValueWithoutNotify(true);
        contrabandField.SetValueWithoutNotify(false);
        prefabField.SetValueWithoutNotify(null);
        iconField.SetValueWithoutNotify(null);
        colourField.SetValueWithoutNotify(Color.white);
        errorField.text = string.Empty;
    }

    private void OnToolValueChanged(ChangeEvent<bool> evt)
    {
        if (toolField.value == true)
        {
            stackField.style.display = DisplayStyle.Flex;
        }
        else if (toolField.value == false)
        {
            stackField.style.display = DisplayStyle.None;
        }
    }

}
