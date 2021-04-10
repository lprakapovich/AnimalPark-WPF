using System;
using System.IO;

namespace AnimalPark.Utils
{
    /// <summary>
    /// Static class encapsulating error handling during the serialization process
    /// </summary>
    public static class SerializationHandler
    { 
        public static void HandleSerializationAction(Action<string> action, string path, Action<string> errorMessageDelegate) 
        {
            try
            {
                action.Invoke(path);
            }
            catch (InvalidOperationException)
            {
                errorMessageDelegate?.Invoke("Seems like a chosen file is read only.");
            }
            catch (PathTooLongException)
            {
                errorMessageDelegate?.Invoke("Path name is too long!");
            }
            catch (FileNotFoundException)
            {
                errorMessageDelegate?.Invoke("File or directory couldn't be found!");
            }
            catch (Exception e)
            {
                errorMessageDelegate?.Invoke(e.Message);
            }
        }
    }
}
