using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] namesOfFields)
        {
            Type type = Type.GetType(classToInvestigate);
            FieldInfo[] fields = type.GetFields
                (BindingFlags.Public | 
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(type, new object[] { });

            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            foreach (FieldInfo field in fields.Where(f => namesOfFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string classToInvestigate)
        {
            Type type = Type.GetType(classToInvestigate);

            FieldInfo[] classFields = type.GetFields
                (BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public);
            MethodInfo[] classPublicMethods = type.GetMethods
                (BindingFlags.Instance |
                BindingFlags.Public);
            MethodInfo[] classNonPublic = type.GetMethods
                (BindingFlags.Instance |
                BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            foreach (MethodInfo method in classNonPublic.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string classToInvestigate)
        {
            Type type = Type.GetType(classToInvestigate);
            MethodInfo[] classPrivateMethods = type.GetMethods
                (BindingFlags.NonPublic |
                BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {type.Name}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (MethodInfo method in classPrivateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string GetAllMethods(string classToInvestigate)
        {
            Type type = Type.GetType(classToInvestigate);
            MethodInfo[] classAllMethods = type.GetMethods
                (BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            GetGetters(classAllMethods, sb);
            GetSetters(classAllMethods, sb);

            return sb.ToString().Trim();

        }

        private void GetGetters(MethodInfo[] classAllMethods, StringBuilder sb)
        {
            foreach (MethodInfo method in classAllMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
        }
        private void GetSetters(MethodInfo[] classAllMethods, StringBuilder sb)
        {
            foreach (MethodInfo method in classAllMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
        }
    }
}
