using System;
using System.Linq;
using System.Text;
namespace DotNetToJScript
{
    class HTAJScriptGenerator : IScriptGenerator
    {
        static string GetScriptHeader()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<html>");
            builder.AppendLine("<head>");
            builder.AppendLine("<script language=\"JScript\">");
            return builder.ToString();
        }
        static string GetScriptFooter()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("</script>");
            builder.AppendLine("</head> ");
            builder.AppendLine("<body>");
            builder.AppendLine("Nothing to see here..");
            builder.AppendLine("</body>");
            builder.AppendLine("</html>");
            return builder.ToString();
        }
        public string ScriptName
        {
            get
            {
                return "HTAJScript";
            }
        }
        public bool SupportsScriptlet
        {
            get
            {
                return true;
            }
        }
        public string GenerateScript(byte[] serialized_object, string entry_class_name, string additional_script, RuntimeVersion version, bool enable_debug)
        {
            JScriptGenerator generator = new JScriptGenerator();
            string script = generator.GenerateScript(serialized_object, entry_class_name, additional_script, version, enable_debug);
            return GetScriptHeader() + script + GetScriptFooter();
        }
    }
}
