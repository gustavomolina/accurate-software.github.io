using Core.Model;
using Core.AspNetIdentity;
using System.Collections.Generic;

namespace ifound_api
{
    public class AuthServerIdentity : SimplyIdentity
    {
        public AuthServerIdentity()
        {
            Companies = new List<CompanyIdentityViewModel>();
        }

        public string Target { get; set; }
        public List<CompanyIdentityViewModel> Companies { get; set; }
        public string FotoUri { get; set; }
        public long IdFacebook { get; set; }
        public string LoginType { get; set; }
    }

    public class CompanyIdentityViewModel : ViewModelBase
    {
        public CompanyIdentityViewModel()
        {
            Menus = new List<MenudentityViewModel>();
        }

        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public List<MenudentityViewModel> Menus { get; set; }
    }

    public class MenudentityViewModel : ViewModelBase
    {
        public MenudentityViewModel()
        {
            Funcoes = new List<FuncaoIdentityViewModel>();
        }

        public string Nome { get; set; }
        public string Chave { get; set; }
        public List<FuncaoIdentityViewModel> Funcoes { get; set; }
    }

    public class FuncaoIdentityViewModel : ViewModelBase
    {
        public string Nome { get; set; }
        public string Chave { get; set; }
    }
}