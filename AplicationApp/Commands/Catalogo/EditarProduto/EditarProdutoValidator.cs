using FluentValidation;

namespace JdMarketplace.App.Commands.Catalogo.EditarProduto;

public class EditarProdutoValidator : AbstractValidator<EditarProdutoRequest>
{
    public EditarProdutoValidator()
    {
        RuleFor(command => command.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("O campo Nome deve ter no máximo 100 caracteres.");

        RuleFor(command => command.Descricao)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.Observacao)
            .NotEmpty()
            .MaximumLength(254)
            .EmailAddress();
    }
}