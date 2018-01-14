using Microsoft.DocAsCode.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace DocMarkdown.AsSequence
{
    public class SequenceDiagramBuildStep : ISupportIncrementalBuildStep
    {
        #region Implementations for ISupportIncrementalBuildStep
        public bool CanIncrementalBuild(FileAndType fileAndType) => true;

        public IEnumerable<DependencyType> GetDependencyTypesToRegister() => new[]
        {
            new DependencyType()
            {
                Name = "ref",
                Phase = BuildPhase.Link,
                Transitivity = DependencyTransitivity.None
            }
        };

        public string GetIncrementalContextHash() => null;
        #endregion

        #region Implementations for IDocumentBuildStep
        public int BuildOrder
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

        public void Build(FileModel model, IHostService host)
        {
            //.....
            host.ReportDependencyTo(model, "uid", DependencyItemSourceType.Uid, "ref");
        }

        public void Postbuild(ImmutableList<FileModel> models, IHostService host)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileModel> Prebuild(ImmutableList<FileModel> models, IHostService host)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
