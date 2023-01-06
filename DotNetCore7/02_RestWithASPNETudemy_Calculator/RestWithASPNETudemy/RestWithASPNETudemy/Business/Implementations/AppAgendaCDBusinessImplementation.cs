using RestWithASPNETudemy.Model;
using RestWithASPNETudemy.Repository;

namespace RestWithASPNETudemy.Business.Implementations
{
    public class AppAgendaCDBusinessImplementation : IAppAgendaCDBusiness
    {
        private readonly IAppAgendaCDRepository _repostitory;

        public AppAgendaCDBusinessImplementation(IAppAgendaCDRepository repostitory)
        {
            _repostitory = repostitory;
        }

        public List<AppAgendaCD> FindAll()
        {
            return _repostitory.FindAll();
        }

        public AppAgendaCD FindById(long id)
        {
            return _repostitory.FindById(id);
        }

        public AppAgendaCD Create(AppAgendaCD agendaCD)
        {
            return _repostitory.Create(agendaCD);
        }

        public AppAgendaCD Update(AppAgendaCD agendaCD)
        {
            return _repostitory.Update(agendaCD);
        }

        public bool Exists(long id)
        {
            return _repostitory.Exists(id);
        }

        public void Delete(long id)
        {
            _repostitory.Delete(id);
        }

        
    }
}
