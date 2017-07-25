using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OneWeek2017
{
    public static class CompileHelper
    {

        // TODO: Config this shit
        //
        private static string PREAMBLE = "using OneWeek2017; class LevelRunner{public static void Execute(";
        private static string POSTAMBLE = "}}";

        private static CompilerResults CompileCodeFromString(string code, string[] references = null, CompilerParameters CompilerParams = null)
        {
            if (CompilerParams == null)
            {
                CompilerParams = new CompilerParameters();
                CompilerParams.GenerateInMemory = true;
                CompilerParams.TreatWarningsAsErrors = false;
                CompilerParams.GenerateExecutable = false;
                CompilerParams.CompilerOptions = "/optimize";
            }

            if (references != null)
            {
                CompilerParams.ReferencedAssemblies.AddRange(references);
            }

            CSharpCodeProvider provider = new CSharpCodeProvider();
            return provider.CompileAssemblyFromSource(CompilerParams, code);
        }

        /// <summary>
        ///  Takes a list of objects in a room and the script to execute on those objects. 
        ///  TODO: Prevalidate script to prevent malicious users from doing stupid shit
        /// </summary>
        /// <param name="toInteractWith">List of objects in the room</param>
        /// <param name="script">Script to run on those objects</param>
        /// <returns></returns>
        public static bool ExecuteRoom(List<IScriptableObject> toInteractWith, string script)
        {
            string generatedClass = GenerateClass(toInteractWith, script);
            string[] assemblies = { Assembly.GetEntryAssembly().Location };
            CompilerResults compile = CompileCodeFromString(generatedClass, assemblies);

            if (compile.Errors.HasErrors)
            {
                string text = "Compile error: ";
                foreach (CompilerError error in compile.Errors)
                {
                    text += '\n' + error.ToString();
                }

                Console.WriteLine(text);

                return false;
            }

            // TODO: Hardcoded 0 is bad (we do this because the generated assembly has only 1 module)
            //
            Module module = compile.CompiledAssembly.GetModules()[0];
            Type typeInfo = null;
            MethodInfo methodInfo = null;

            if (module != null)
            {
                typeInfo = module.GetType("LevelRunner");
            }

            if (typeInfo != null)
            {
                methodInfo = typeInfo.GetMethod("Execute");
            }

            if (methodInfo != null)
            {
                // TODO: check the value? Return something?
                //
                methodInfo.Invoke(null, toInteractWith.ToArray());
            }

            return true;
        }   

        // TODO: Watchdog the script being written (we're basically asking for malicious injection or just an infinite loop)
        //
        private static string GenerateClass(List<IScriptableObject> toInteractWith, string script)
        {
            List<string> parameterizedNames = new List<string>();
            foreach(var obj in toInteractWith)
            {
                parameterizedNames.Add(obj.GetParameterizedName());
            }

            return PREAMBLE + string.Join(",", parameterizedNames) +"){" + script + POSTAMBLE;
        }
    }
}
