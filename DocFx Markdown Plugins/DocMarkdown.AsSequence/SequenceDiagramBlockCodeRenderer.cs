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
            StringBuffer result = "<pre><code class=\"";
            result += renderer.Options.LangPrefix;
            result += "csharp";
            result += "\">";
            result += token.Code;
            result += "\n</code></pre>";
            return result;
        }
    }
}
