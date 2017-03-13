﻿using System;
using System.Collections.Generic;
using LinqToGraphQL.Introspection;

namespace LinqToGraphQL.Generation.Models
{
    public class TypeModel
    {
        public TypeKind Kind { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<FieldModel> Fields { get; set; }
        public IList<TypeModel> Interfaces { get; set; }
        public IList<TypeModel> PossibleTypes { get; set; }
        public IList<EnumValueModel> EnumValues { get; set; }
        public IList<InputValueModel> InputFields { get; set; }
        public TypeModel OfType { get; set; }

        public TypeModel Clone()
        {
            return new TypeModel
            {
                Kind = Kind,
                Name = Name,
                Description = Description,
                Fields = Fields,
                Interfaces = Interfaces,
                PossibleTypes = PossibleTypes,
                EnumValues = EnumValues,
                InputFields = InputFields,
                OfType = OfType?.Clone(),
            };
        }

        public static TypeModel Int()
        {
            return new TypeModel
            {
                Kind = TypeKind.Scalar,
                Name = "Int",
            };
        }

        public static TypeModel Interface(string name)
        {
            return new TypeModel
            {
                Kind = TypeKind.Interface,
                Name = name,
            };
        }

        public static TypeModel List(TypeModel ofType)
        {
            return new TypeModel
            {
                Kind = TypeKind.List,
                OfType = ofType,
            };
        }

        public static TypeModel NonNull(TypeModel ofType)
        {
            return new TypeModel
            {
                Kind = TypeKind.NonNull,
                OfType = ofType,
            };
        }

        public static TypeModel Object(string name)
        {
            return new TypeModel
            {
                Kind = TypeKind.Object,
                Name = name,
            };
        }
    }
}
