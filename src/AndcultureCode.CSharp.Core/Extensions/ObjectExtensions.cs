using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AndcultureCode.CSharp.Core.Extensions
{
    /// <summary>
    /// TODO: Remove when Extensions project is updated
    /// </summary>
    public static class ObjectExtensions
    {
        public static T FromByteArray<T>(this byte[] byteArray) where T : class
        {
            if (byteArray == null)
            {
                return default(T);
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(byteArray))
            {
                return binaryFormatter.Deserialize(memoryStream) as T;
            }
        }

        public static byte[] ToByteArray(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }
    }
}
