using System;
using System.IO;

namespace AnimalPark.Utils
{
    /// <summary>
    /// Static class encapsulating error handling during the serialization process
    /// </summary> 
    public static class SerializationErrorHandler
    { 
        public static void HandleSerializationAction(Action<string> action, string path, Action<string> messageDelegate) 
        {
            try
            {
                action.Invoke(path);
            } 
            catch (InvalidOperationException)
            {
                messageDelegate?.Invoke("Seems like a chosen file is read only.");
            }
            catch (PathTooLongException)
            {
                messageDelegate?.Invoke("Path name is too long!");
            }
            catch (FileNotFoundException)
            {
                messageDelegate?.Invoke("File or directory couldn't be found!");
            }
            catch (Exception e)
            {
                messageDelegate?.Invoke(e.Message);
            }
        }
    }
}
