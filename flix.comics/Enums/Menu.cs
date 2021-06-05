using System.ComponentModel;

namespace flix.comics.Enums
{
    public enum Menu
    {
        [Description("Listar historia em quadrinhos")]
        List = 1,
        [Description("Inserir nova historia em quadrinhos")]
        Insert = 2,
        [Description("Atualizar historia em quadrinhos")]
        Update = 3,
        [Description("Excluir historia em quadrinhos")]
        Exclude = 4,
        [Description("Visualizar historia em quadrinhos")]
        Show = 5,
        [Description("Limpar Tela")]
        Clean = 6,
        [Description("Sair")]
        Exit = 0
    }
}
