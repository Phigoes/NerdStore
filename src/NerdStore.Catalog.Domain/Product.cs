using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Catalog.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        protected Product() { }

        public Product(string name, string description, bool active, decimal value, Guid categoryId, DateTime registrationDate, string image, Dimensions dimensions)
        {
            Name = name;
            Description = description;
            Active = active;
            Value = value;
            RegistrationDate = registrationDate;
            CategoryId = categoryId;
            RegistrationDate = registrationDate;
            Image = image;
            Dimensions = dimensions;

            Validate();
        }

        public Guid CategoryId { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Value { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public string Image { get; private set; }
        public int StockQuantity { get; private set; }
        public Category Category { get; private set; }
        public Dimensions Dimensions { get; private set; }

        public void Enable() => Active = true;
        public void Disable() => Active = false;

        public void CategoryUpdate(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void DescriptionUpdate(string description)
        {
            Validations.ValidateIfIsEmpty(description, "The product Description field must not be empty");
            Description = description;
        }

        public void StockDebit(int quantity)
        {
            if (quantity < 0) quantity *= -1;
            if (!HasStock(quantity)) throw new DomainException("Insufficient Stock");
            StockQuantity -= quantity;
        }

        public void StockAdd(int quantity)
        {
            StockQuantity += quantity;
        }

        public bool HasStock(int quantity)
        {
            return StockQuantity >= quantity;
        }

        public void Validate()
        {
            Validations.ValidateIfIsEmpty(Name, "The product Name field must not be empty");
            Validations.ValidateIfIsEmpty(Description, "The product Description field must not be empty");
            Validations.ValidateIfIsEqual(CategoryId, Guid.Empty, "The product CategoryId field must not be empty");
            Validations.ValidateIfIsLessThanMin(Value, 1, "The product Value field must not be less or equal than 0");
            Validations.ValidateIfIsEmpty(Image, "The product Image field must not be empty");
        }
    }
}
