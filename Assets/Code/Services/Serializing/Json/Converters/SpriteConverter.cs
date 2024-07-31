using System;
using Newtonsoft.Json;
using UnityEngine;

public class SpriteConverter : JsonConverter<Sprite>
{
    private class SerializeTexture
    {
        public int X;
        public int Y;
        public byte[] Bytes;
    }

    public override void WriteJson(JsonWriter writer, Sprite value, JsonSerializer serializer)
    {
        var texture = value.texture;

        serializer.Serialize(writer, new SerializeTexture
        {
            X = texture.width,
            Y = texture.height,
            Bytes = texture.EncodeToPNG()
        });
    }

    public override Sprite ReadJson(JsonReader reader, Type objectType, Sprite existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var serializeTexture = serializer.Deserialize<SerializeTexture>(reader);
        if (serializeTexture == null)
            return null;

        var texture = new Texture2D(serializeTexture.X, serializeTexture.Y);
        texture.LoadImage(serializeTexture.Bytes);

        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
    }
}