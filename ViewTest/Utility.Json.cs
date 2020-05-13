using System;
using System.Text;

namespace GX
{
    /// <summary>
    /// JSON 相关的实用函数。
    /// </summary>
    public static partial class JsonExtension
    {
        private static IJsonHelper s_JsonHelper = null;

        /// <summary>
        /// 设置 JSON 辅助器。
        /// </summary>
        /// <param name="jsonHelper">要设置的 JSON 辅助器。</param>
        public static void SetJsonHelper(IJsonHelper jsonHelper)
        {
            s_JsonHelper = jsonHelper;
        }

        /// <summary>
        /// 将对象序列化为 JSON 字符串。
        /// </summary>
        /// <param name="obj">要序列化的对象。</param>
        /// <returns>序列化后的 JSON 字符串。</returns>
        public static string Serialize(object obj)
        {
            if (s_JsonHelper == null)
            {
                throw new Exception("JSON helper is invalid.");
            }

            try
            {
                return s_JsonHelper.Serialize(obj);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("Can not convert to JSON with exception '{0}'.", exception.ToString()), exception);
            }
        }

        /// <summary>
        /// 将对象序列化为 JSON 流。
        /// </summary>
        /// <param name="obj">要序列化的对象。</param>
        /// <returns>序列化后的 JSON 流。</returns>
        public static byte[] SerializeToStream(object obj)
        {
            return Encoding.UTF8.GetBytes(Serialize(obj));
        }

        /// <summary>
        /// 将 JSON 字符串反序列化为对象。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="json">要反序列化的 JSON 字符串。</param>
        /// <returns>反序列化后的对象。</returns>
        public static T Deserialize<T>(string json)
        {
            if (s_JsonHelper == null)
            {
                throw new Exception("JSON helper is invalid.");
            }

            try
            {
                return s_JsonHelper.Deserialize<T>(json);
            }
            catch (Exception exception)
            {
                if (exception is Exception)
                {
                    throw;
                }

                throw new Exception(string.Format("Can not convert to object with exception '{0}'.", exception.ToString()), exception);
            }
        }

        /// <summary>
        /// 将 JSON 字符串反序列化为对象。
        /// </summary>
        /// <param name="objectType">对象类型。</param>
        /// <param name="json">要反序列化的 JSON 字符串。</param>
        /// <returns>反序列化后的对象。</returns>
        public static object Deserialize(Type objectType, string json)
        {
            if (s_JsonHelper == null)
            {
                throw new Exception("JSON helper is invalid.");
            }

            if (objectType == null)
            {
                throw new Exception("Object type is invalid.");
            }

            try
            {
                return s_JsonHelper.Deserialize(objectType, json);
            }
            catch (Exception exception)
            {
                if (exception is Exception)
                {
                    throw;
                }

                throw new Exception(string.Format("Can not convert to object with exception '{0}'.", exception.ToString()), exception);
            }
        }

        /// <summary>
        /// 将 JSON 流反序列化为对象。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="jsonData">要反序列化的 JSON 流。</param>
        /// <returns>反序列化后的对象。</returns>
        public static T Deserialize<T>(byte[] jsonData)
        {
            return Deserialize<T>(Encoding.UTF8.GetString(jsonData));
        }

        /// <summary>
        /// 将 JSON 字符串反序列化为对象。
        /// </summary>
        /// <param name="objectType">对象类型。</param>
        /// <param name="jsonData">要反序列化的 JSON 流。</param>
        /// <returns>反序列化后的对象。</returns>
        public static object Deserialize(Type objectType, byte[] jsonData)
        {
            return Deserialize(objectType, Encoding.UTF8.GetString(jsonData));
        }
    }
}
