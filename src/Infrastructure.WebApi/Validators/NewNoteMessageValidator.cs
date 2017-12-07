namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Validators
{
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using FluentValidation;

    public class NewNoteMessageValidator : AbstractValidator<NewNoteMessage>
    {
        public NewNoteMessageValidator()
        {
            // Required Fields
            RuleFor(nnm => nnm.Text)
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}