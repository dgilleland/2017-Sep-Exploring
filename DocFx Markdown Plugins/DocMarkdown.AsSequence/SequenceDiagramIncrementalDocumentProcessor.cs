using Microsoft.DocAsCode.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.IO;

namespace DocMarkdown.AsSequence
{
    public class SequenceDiagramIncrementalDocumentProcessor : ISupportIncrementalDocumentProcessor
    {
        #region Implementations for ISupportIncrementalDocumentProcessor
        public string GetIncrementalContextHash()
        {
            throw new NotImplementedException();
            // TODO: context related hash. if it changes, incremental build isn't triggered.
        }

        public FileModel LoadIntermediateModel(Stream stream)
        {
            throw new NotImplementedException();
            // TODO: the logic to load filemodel
        }

        public void SaveIntermediateModel(FileModel model, Stream stream)
        {
            throw new NotImplementedException();
            // TODO: the logic to store filemodel
        }
        #endregion

        #region Implementations for IDocumentProcessor
        public IEnumerable<IDocumentBuildStep> BuildSteps
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ProcessingPriority GetProcessingPriority(FileAndType file)
        {
            throw new NotImplementedException();
        }

        public FileModel Load(FileAndType file, ImmutableDictionary<string, object> metadata)
        {
            throw new NotImplementedException();
        }

        public SaveResult Save(FileModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateHref(FileModel model, IDocumentBuildContext context)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
