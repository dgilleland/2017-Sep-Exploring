using Microsoft.DocAsCode.Dfm;
using Microsoft.DocAsCode.MarkdownLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocMarkdown.AsSequence
{
    public class SequenceDiagramBlockCodeRenderer : DfmCustomizedRendererPartBase<IMarkdownRenderer, MarkdownCodeBlockToken, MarkdownBlockContext>
    {
        public override string Name => "SequenceDiagramRendererPart";

        public override bool Match(IMarkdownRenderer renderer, MarkdownCodeBlockToken token, MarkdownBlockContext context)
        {
            return token.Lang == "sequence";
        }

        public override StringBuffer Render(IMarkdownRenderer renderer, MarkdownCodeBlockToken token, MarkdownBlockContext context)
        {
            List<string> dependencies = new List<string>();
            dependencies.Add(@"mermaid\mermaid.min.js");
            dependencies.Add(@"mermaid\mermaid.core.js");
            context.ReportDependency(dependencies);
            StringBuffer result = "<pre><code class=\"";
            result += renderer.Options.LangPrefix;
            result += "sequence";
            result += "\">";
            result += token.Code;
            result += "\n</code></pre>";
            return result;
        }
    }
}
