using Microsoft.DocAsCode.Dfm;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocMarkdown.AsSequence
{
    [Export(typeof(IDfmCustomizedRendererPartProvider))]
    public class SequenceDiagramBlockCodeRendererProvider
        : IDfmCustomizedRendererPartProvider
    {
        public IEnumerable<IDfmCustomizedRendererPart> CreateParts(IReadOnlyDictionary<string, object> parameters)
        {
            yield return new SequenceDiagramBlockCodeRenderer();
        }
    }
}
