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
    public class CompileHelper
    {
        private const string PREAMBLE = "Class LevelRunner{PublicExecute(";
        private const string POSTAMBLE = "}}";

        public static CompilerResults CompileCodeFromString(string code, string[] references = null, CompilerParameters CompilerParams = null)
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

        public void Compile(string toCompile)
        {
            CompilerResults compile = CompileHelper.CompileCodeFromString(toCompile);

            if (compile.Errors.HasErrors)
            {
                string text = "Compile error: ";
                foreach (CompilerError error in compile.Errors)
                {
                    text += '\n' + error.ToString();
                }

                return;
            }

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
                //OutputField.text = (string)methodInfo.Invoke(null, new object[] { "Here's some stuff!" });
            }
        }

        /*
        public bool ExecuteRoom(List<IScriptableObject> toInteractWith, string script)
        {


            return true;
        }
        */
        private string GenerateClass(List<IScriptableObject> toInteractWith, string script)
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
