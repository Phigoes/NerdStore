using NerdStore.Core.DomainObjects;
using System.Collections.Generic;

namespace NerdStore.Catalog.Domain
{
    public class Category : Entity
    {
        public Category(string name, int codeNumber)
        {
            Name = name;
            CodeNumber = codeNumber;

            Validate();
        }

        public string Name { get; private set; }
        public int CodeNumber { get; private set; }

        // EF Relation
        public ICollection<Product> Products { get; set; }

        protected Category() { }

        public override string ToString()
        {
            return $"{Name} - {CodeNumber}";
        }

        public void Validate()
        {
            Validations.ValidateIfIsEmpty(Name, "The category Name field must not be empty");
            Validations.ValidateIfIsEqual(CodeNumber, 0, "The category CodeNumber field must not be 0");
        }
    }
}
