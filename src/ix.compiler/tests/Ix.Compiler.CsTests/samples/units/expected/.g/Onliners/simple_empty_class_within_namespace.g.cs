using System;
using Ix.Connector;
using Ix.Connector.ValueTypes;
using System.Collections.Generic;

namespace sampleNamespace
{
    public partial class simple_empty_class_within_namespace : Ix.Connector.ITwinObject
    {
        partial void PreConstruct(Ix.Connector.ITwinObject parent, string readableTail, string symbolTail);
        partial void PostConstruct(Ix.Connector.ITwinObject parent, string readableTail, string symbolTail);
        public simple_empty_class_within_namespace(Ix.Connector.ITwinObject parent, string readableTail, string symbolTail)
        {
            Symbol = Ix.Connector.Connector.CreateSymbol(parent.Symbol, symbolTail);
            this.@SymbolTail = symbolTail;
            this.@Connector = parent.GetConnector();
            this.@Parent = parent;
            HumanReadable = Ix.Connector.Connector.CreateHumanReadable(parent.HumanReadable, readableTail);
            PreConstruct(parent, readableTail, symbolTail);
            parent.AddChild(this);
            parent.AddKid(this);
            PostConstruct(parent, readableTail, symbolTail);
        }

        public async Task<Pocos.sampleNamespace.simple_empty_class_within_namespace> OnlineToPlainAsync()
        {
            Pocos.sampleNamespace.simple_empty_class_within_namespace plain = new Pocos.sampleNamespace.simple_empty_class_within_namespace();
            await this.ReadAsync();
            return plain;
        }

        protected async Task<Pocos.sampleNamespace.simple_empty_class_within_namespace> OnlineToPlainAsync(Pocos.sampleNamespace.simple_empty_class_within_namespace plain)
        {
            return plain;
        }

        public async Task<IEnumerable<ITwinPrimitive>> PlainToOnlineAsync(Pocos.sampleNamespace.simple_empty_class_within_namespace plain)
        {
            return await this.WriteAsync();
        }

        public async Task<Pocos.sampleNamespace.simple_empty_class_within_namespace> ShadowToPlainAsync()
        {
            Pocos.sampleNamespace.simple_empty_class_within_namespace plain = new Pocos.sampleNamespace.simple_empty_class_within_namespace();
            return plain;
        }

        protected async Task<Pocos.sampleNamespace.simple_empty_class_within_namespace> ShadowToPlainAsync(Pocos.sampleNamespace.simple_empty_class_within_namespace plain)
        {
            return plain;
        }

        public async Task<IEnumerable<ITwinPrimitive>> PlainToShadowAsync(Pocos.sampleNamespace.simple_empty_class_within_namespace plain)
        {
            return this.RetrievePrimitives();
        }

        public void Poll()
        {
            this.RetrievePrimitives().ToList().ForEach(x => x.Poll());
        }

        public Pocos.sampleNamespace.simple_empty_class_within_namespace CreateEmptyPoco()
        {
            return new Pocos.sampleNamespace.simple_empty_class_within_namespace();
        }

        private IList<Ix.Connector.ITwinObject> Children { get; } = new List<Ix.Connector.ITwinObject>();
        public IEnumerable<Ix.Connector.ITwinObject> GetChildren()
        {
            return Children;
        }

        private IList<Ix.Connector.ITwinElement> Kids { get; } = new List<Ix.Connector.ITwinElement>();
        public IEnumerable<Ix.Connector.ITwinElement> GetKids()
        {
            return Kids;
        }

        private IList<Ix.Connector.ITwinPrimitive> ValueTags { get; } = new List<Ix.Connector.ITwinPrimitive>();
        public IEnumerable<Ix.Connector.ITwinPrimitive> GetValueTags()
        {
            return ValueTags;
        }

        public void AddValueTag(Ix.Connector.ITwinPrimitive valueTag)
        {
            ValueTags.Add(valueTag);
        }

        public void AddKid(Ix.Connector.ITwinElement kid)
        {
            Kids.Add(kid);
        }

        public void AddChild(Ix.Connector.ITwinObject twinObject)
        {
            Children.Add(twinObject);
        }

        protected Ix.Connector.Connector @Connector { get; }

        public Ix.Connector.Connector GetConnector()
        {
            return this.@Connector;
        }

        public string GetSymbolTail()
        {
            return this.SymbolTail;
        }

        public Ix.Connector.ITwinObject GetParent()
        {
            return this.@Parent;
        }

        public string Symbol { get; protected set; }

        private string _attributeName;
        public System.String AttributeName
        {
            get
            {
                return Ix.Localizations.LocalizationHelper.CleanUpLocalizationTokens(_attributeName);
            }

            set
            {
                _attributeName = value;
            }
        }

        public string HumanReadable { get; set; }

        protected System.String @SymbolTail { get; set; }

        protected Ix.Connector.ITwinObject @Parent { get; set; }
    }
}