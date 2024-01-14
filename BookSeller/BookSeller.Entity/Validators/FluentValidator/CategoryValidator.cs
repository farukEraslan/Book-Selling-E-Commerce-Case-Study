using FluentValidation;

namespace BookSeller.Entity.Validators.FluentValidator
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(customer => customer.CategoryName).NotEmpty().NotNull();
        }
    }
}
