using System;
using UnityEngine;

namespace Scripts
{
    public class PlayerDataManager
    {
        private const string DataKey = "game_data";

        public static PlayerData Load()
        {
            if (!PlayerPrefs.HasKey(DataKey))
            {
                return new PlayerData
                {
                    position = new Vector3(-7.5F, 0, -5F),
                    rotation = new Vector3(0, 90, 0)
                };
            }

            var raw = PlayerPrefs.GetString(DataKey);
            return JsonUtility.FromJson<PlayerData>(raw);
        }

        public static void Save(Vector3 position, Vector3 rotation)
        {
            var raw = JsonUtility.ToJson(new PlayerData
            {
                position = position,
                rotation = rotation
            });
            PlayerPrefs.SetString(DataKey, raw);
        }
    }

    [Serializable]
    public class PlayerData
    {
        public SerializedVector3 position;
        public SerializedVector3 rotation;
    }

    [Serializable]
    public struct SerializedVector3
    {
        public float x;
        public float y;
        public float z;

        public static implicit operator Vector3(SerializedVector3 v) => new(v.x, v.y, v.z);
        public static implicit operator SerializedVector3(Vector3 v) => new()
        {
            x = v.x,
            y = v.y,
            z = v.z
        };
    }
}