using System;
using System.Xml;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel.ClassBased;
using FluentNHibernate.Utils;

namespace FluentNHibernate.AutoMap
{
    public class AutoJoinedSubClassPart<T> : AutoMap<T>, IJoinedSubclass
    {
        private readonly string keyColumn;
        private readonly Cache<string, string> attributes = new Cache<string, string>();

        public AutoJoinedSubClassPart(string keyColumn)
        {
            this.keyColumn = keyColumn;
        }

        public void Write(XmlElement classElement, IMappingVisitor visitor)
        {
            XmlElement subclassElement = classElement.AddElement("joined-subclass")
                .WithAtt("name", typeof(T).AssemblyQualifiedName);
            subclassElement.AddElement("key")
                .WithAtt("column", keyColumn);
            subclassElement.WithProperties(attributes);

            WriteTheParts(subclassElement, visitor);
        }

        public int LevelWithinPosition
        {
            get { return 4; }
        }

        public PartPosition PositionOnDocument
        {
            get { return PartPosition.Anywhere; }
        }

        public AutoJoinedSubClassPart<T> WithTableName(string tableName)
        {             
            attributes.Store("table", tableName);
            return this;
        }

        void IJoinedSubclass.CheckConstraint(string constraintName)
        {
            throw new NotImplementedException();
        }

        void IJoinedSubclass.Proxy(Type type)
        {
            throw new NotImplementedException();
        }

        void IJoinedSubclass.Proxy<T1>()
        {
            throw new NotImplementedException();
        }

        void IJoinedSubclass.SelectBeforeUpdate()
        {
            throw new NotImplementedException();
        }

        void IJoinedSubclass.Abstract()
        {
            throw new NotImplementedException();
        }

        IJoinedSubclass IJoinedSubclass.Not
        {
            get { throw new NotImplementedException(); }
        }
        JoinedSubclassMapping IJoinedSubclass.GetJoinedSubclassMapping()
        {
            throw new NotImplementedException();
        }

        #region Implementation of IJoinedSubclass

        void IJoinedSubclass.WithTableName(string tableName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}