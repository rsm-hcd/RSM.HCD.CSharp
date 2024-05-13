using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RSM.HCD.CSharp.Core.Extensions
{
    /// <summary>
    /// TODO: Extract to RSM.HCD.CSharp.Extensions project
    /// https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/64
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Converts supplied byte array to requested type
        /// </summary>
        /// <typeparam name="T"></typeparam>
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

        /// <summary>
        /// Converts supplied data to byte array
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
