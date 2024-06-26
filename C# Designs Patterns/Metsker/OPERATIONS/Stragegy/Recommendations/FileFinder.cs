using System;
using System.IO;
using System.Reflection;
namespace Recommendations
{
    /// <summary>
    /// Provides static methods for finding files relative to the
    /// bin that this assembly runs in.
    /// </summary>
    public class FileFinder
    {
        /// <summary>
        /// Formulate and return a file name for a file in a 
        /// neighboring directory. Use the environment variable OOZINOZ
        /// to see where the superdirectory for lib, app, images and
        /// so on base based. If this environment variable is misssing,
        /// calculate it from the current assembly's location. This latter
        /// technique usually works, but won't work for an application
        /// that copies dll's around, as some testing frameworks do.
        /// </summary>
        /// <param name="dirName">neighboring directory name</param>
        /// <param name="fileName">file name</param>
        /// <returns>path name of neighboring file</returns>
        public static string GetFileName(string dirName, string fileName)
        {
            string path;
            // Can we find the file using the OOZINOZ environment variable?
            // NOTA: Esto no declara una variable global en C# sino que obtiene
            // el valor de una variable de entorno del sistema operativo.
            string oozinozBase = Environment.GetEnvironmentVariable("OOZINOZ");
            if (oozinozBase != null) 
            {
                path = Path.Combine(Path.Combine(oozinozBase, dirName), fileName);
                if (File.Exists(path))
                {
                    return path;
                }
            }

            // How 'bout relative to where the bin files are?
            Assembly a = Assembly.GetAssembly(typeof(FileFinder));
            DirectoryInfo thisDir = Directory.GetParent(a.Location);
            DirectoryInfo parentDir = Directory.GetParent(thisDir.FullName);
            path = Path.Combine(
                parentDir.FullName, 
                dirName + Path.DirectorySeparatorChar + fileName);
            if (File.Exists(path))
            {
                return path;
            }
            
            // Ok, how 'bout in the top-level directory?
            // Esto es un error, ya que no se puede acceder a la raíz del
            // sistema de archivos.
            path = Path.Combine(Path.Combine(@"\Oozinoz", dirName), fileName);

            if (File.Exists(path))
            {
                return path;
            }
            // dang
            throw new Exception("FileFinder.GetFileName() cannot find " + fileName + " in directory " + dirName);
        }
    }
}
