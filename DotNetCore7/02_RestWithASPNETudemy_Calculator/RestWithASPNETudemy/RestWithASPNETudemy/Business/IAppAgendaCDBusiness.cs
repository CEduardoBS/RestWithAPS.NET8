using RestWithASPNETudemy.Model;

namespace RestWithASPNETudemy.Business
{
    public interface IAppAgendaCDBusiness
    {
        AppAgendaCD Create(AppAgendaCD agendaCD);

        AppAgendaCD FindById(long id);

        List<AppAgendaCD> FindAll();

        AppAgendaCD Update(AppAgendaCD agendaCD);

        void Delete(long id);

        bool Exists(long id);
    }
}
