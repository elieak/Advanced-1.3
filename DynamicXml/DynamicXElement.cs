using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace DynamicXml
{
    class DynamicXElement : DynamicObject
    {
        private readonly XElement _element;

        private DynamicXElement(XElement xelement)
        {
            _element = xelement;
        }

        public static dynamic Create(XElement xelement)
        {
            var dynCreate =  new DynamicXElement(xelement);
            return dynCreate;
        }

        public override bool TryGetMember(GetMemberBinder memberBinder, out object result)
        {
            result = new DynamicXElement(_element.Element(memberBinder.Name));
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder indexBinder, object[] indexes, out object result)
        {
            var name = (string)indexes[0];
            var index = (int)indexes[1];

            if (name.GetType() != typeof(string) || index.GetType() != typeof(int) || indexes.Length != 2)
            {
                result = null;
                return false;
            }

            var indexedElements = _element.Elements(name).ToList();
            result = new DynamicXElement(indexedElements.ElementAt(index));
            return true;
        }
        public override string ToString() => _element.Value;
    }
}
