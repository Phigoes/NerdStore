using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain
{
    public class Dimensions
    {
        public Dimensions(decimal height, decimal width, decimal depth)
        {
            Validations.ValidateIfIsLessThanMin(height, 1, "The dimension height field must not be less or equal than 0");
            Validations.ValidateIfIsLessThanMin(width, 1, "The dimension width field must not be less or equal than 0");
            Validations.ValidateIfIsLessThanMin(depth, 1, "The dimension depth field must not be less or equal than 0");

            Height = height;
            Width = width;
            Depth = depth;
        }

        public decimal Height { get; private set; }
        public decimal Width { get; private set; }
        public decimal Depth { get; private set; }

        public string FormattedDescription()
        {
            return $"WxHxD: {Width} x {Height} x {Depth}";
        }

        public override string ToString()
        {
            return FormattedDescription();
        }
    }
}
