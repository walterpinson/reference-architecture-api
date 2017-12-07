namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Validators
{
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using FluentValidation;

    public class NewCategoryMessageValidator : AbstractValidator<NewCategoryMessage>
    {
        public NewCategoryMessageValidator()
        {
            // Required Fields
            RuleFor(ncm => ncm.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}