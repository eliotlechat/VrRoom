using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(TagFilterAttribute))]
public class TagFilterDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.String)
        {
            // Récupérer tous les tags définis dans le projet
            string[] tags = UnityEditorInternal.InternalEditorUtility.tags;

            // Trouver l'index actuel du tag sélectionné
            int index = Mathf.Max(0, System.Array.IndexOf(tags, property.stringValue));

            // Afficher la liste déroulante et récupérer l'index sélectionné
            index = EditorGUI.Popup(position, label.text, index, tags);

            // Mettre à jour la valeur du champ avec le tag sélectionné
            property.stringValue = tags[index];
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
